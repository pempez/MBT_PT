using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;


namespace MBTransPT
{
    public class SQLCommands
    {
        private static SqlDataAdapter myAdapter = new SqlDataAdapter();
        private static DataTable dataTable = new DataTable();
        private static SqlCommand command = new SqlCommand();
        private static bool nonNumberEntered;

        public SQLCommands()
        {

        }

        public static DataTable UcitajGodine(bool sve)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\Finansije\\connPUT.txt");
            string connection = tr.ReadLine();
            tr.Close();
            string query = "SELECT CAST(godina AS NVarChar) AS godina, ID FROM GODINE ORDER BY godina";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (sve)
            {
                DataRow dtr = dt.NewRow();
                dtr["godina"] = "Sve godine";
                dtr["ID"] = "0";
                dt.Rows.InsertAt(dtr, 0);
            }

            return dt;
        }

        //Kreiranje sql izraza
        //u zavisnosti od tipa izraza imamo select, insert, delete i update izraz
        //typeOfStatement - tip izraza
        //tableName - ime tabele
        //displayField - naziv polja koja se ispisuju u izrazu
        //selectField - naziv polja koja koriste u where izrazu
        //valueField - vrednosti polja koja se koriste u where izrazu
        //orderfield - polje po kom se sortira
        public static string CreateSQLStatement(string typeOfStatement, string tableName, string[] displayFields
            , string[] selectFields, string[] valueFields, string orderField)
        {
            string retString = "";

            switch (typeOfStatement)
            {
                case "select":
                    retString = "SELECT ";
                    //dodaj polja koja se selektuju
                    retString += AddListOfFields(displayFields, " ", " * ");
                    retString += " FROM " + tableName;
                    retString += AddFieldsEqualsValues(selectFields, valueFields, "AND", " WHERE ", "");
                    if (orderField != null && orderField.Length > 0)
                    {
                        retString += " ORDER BY " + orderField;
                    }
                    break;
                case "insert":
                    if (selectFields != null)
                    {
                        retString = "INSERT INTO " + tableName;
                        retString += AddListOfFields(selectFields, valueFields, " (", "");
                        //retString += AddListOfFields(selectFields, " (", "");
                        retString += ") VALUES ";
                        retString += AddListOfFields(valueFields, valueFields, "(", "");
                        //retString += AddListOfFields(valueFields, isFieldsString, "(", "");
                        retString += ")";
                    }
                    break;
                case "delete":
                    retString = "DELETE FROM " + tableName;
                    retString += AddFieldsEqualsValues(selectFields, valueFields, "AND", " WHERE ", "");
                    break;
                case "update":
                    //UPDATE Table1
                    //SET Column1 = Value1, Column2 = Value2
                    //WHERE Some_Column = Some_Value
                    if (selectFields != null)
                    {
                        retString = "UPDATE " + tableName;
                        retString += AddFieldsEqualsValues(selectFields, valueFields, ", ", " SET ", "");
                        //retString += AddListOfFields(selectFields, null, valueFields, " (", "");
                        //retString += AddListOfFields(selectFields, " (", "");
                        retString += AddFieldsEqualsValues(selectFields, valueFields, "AND", " WHERE ", "");
                        //retString += " WHERE ";
                        //retString += AddListOfFields(valueFields, isFieldsString, valueFields, "(", "");
                        //retString += AddListOfFields(valueFields, isFieldsString, "(", "");
                        retString += ")";
                    }
                    break;
            }
            return retString;

        }

        //kreiranje update izraza
        public static string CreateUpdateStatement(string tableName
            , string[] selectFields, string[] valueFields
            , string[] selectFieldsWhere, string[] valueFieldsWhere)
        {
            string retString = "";
            //UPDATE Table1
            //SET Column1 = Value1, Column2 = Value2
            //WHERE Some_Column = Some_Value
            if (selectFields != null)
            {
                retString = "UPDATE " + tableName;
                retString += AddFieldsEqualsValues(selectFields, valueFields, ", ", " SET ", "");
                retString += AddFieldsEqualsValues(selectFieldsWhere, valueFieldsWhere
                    , "AND", " WHERE ", "");
                //retString += ")";
            }
            return retString;

        }

        public static string Convert_proba(string datum)
        {
            string date = "";

            if (datum.Substring(1, 1) == ".")
            {
                if (datum.Substring(3, 1) == ".")
                {
                    date = datum.Substring(4, 4) + "-" + datum.Substring(2, 1) + "-0" + datum.Substring(0, 1);
                }
                else
                {
                    date = datum.Substring(5, 4) + "-" + datum.Substring(2, 2) + "-0" + datum.Substring(0, 1);
                }
            }
            else
            {
                if (datum.Substring(4, 1) == ".")
                {
                    date = datum.Substring(5, 4) + "-0" + datum.Substring(3, 1) + "-" + datum.Substring(0, 2);
                }
                else
                {
                    date = datum.Substring(6, 4) + "-" + datum.Substring(3, 2) + "-" + datum.Substring(0, 2);
                }
            }
            return date;
        }

        //izvrsava sql izraz i vraca true ako je uspesno izvrsen
        public static bool ExecuteSQLStatement(SqlConnection connection, string sqlString)
        {
            command.CommandText = sqlString;
            command.Connection = connection;
            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //vraca tabelu sa podacima na osnovu sql query-ja
        public static DataTable GetDataTable(SqlConnection connection, string sqlQuery)
        {
            myAdapter = new SqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();

            try
            {
                myAdapter.Fill(dataTable);
            }
            catch
            {
            }
            return dataTable;
        }

        //vraca prvu kolonu iz tabele na osnovu sql query-ja
        public static DataRow GetFirstDataRow(SqlConnection connection, string sqlQuery)
        {
            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlQuery, connection);
            dataTable = new DataTable();

            myAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0];
            }
            else
            {
                return null;
            }

        }

        //vraca bool vrednost u zavisnosti da li postoji bar jedan selektovan rekord
        public static bool PostojiRekord(SqlConnection connection, string tableName
            , string[] fieldList, string[] valueList)
        {
            string query = CreateSQLStatement("select", tableName, null
                    , fieldList, valueList, null);

            dataTable = GetDataTable(connection, query);

            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //vraca bool vrednost u zavisnosti da li postoji bar jedan selektovan rekord
        // na osnovu sql query-ja
        public static bool PostojiRekord(SqlConnection connection, string query)
        {
            dataTable = GetDataTable(connection, query);

            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //popunjava data grid sa vrednostima kad je data source vec vezan za tabelu
        //columNames - imena kolona u tabeli
        //columnVisibility - da li je kolona vidljiva u tabeli
        //columnWidth - sirine kolona u tabeli
        public static void PopulateDataGridView(DataGridView dataGridView
            , string[] columnNames, bool[] columnVisiblity, int[] columnWidth)
        {
            //podesi sirine kolona
            DataGridViewColumn column;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                column = dataGridView.Columns[i];
                if (column.ValueType.Name == "Int32" || column.ValueType.Name == "Decimal")
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (columnWidth.Length > i)
                    column.Width = columnWidth[i];
                if (columnVisiblity.Length > i)
                    column.Visible = columnVisiblity[i];
                if (columnNames.Length > i)
                    column.HeaderText = columnNames[i];
            }
        }

        //popunjava data grid sa vrednostima kad je data source vec vezan za tabelu
        //columNames - imena kolona u tabeli
        //columnVisibility - da li je kolona vidljiva u tabeli
        //columnWidth - sirine kolona u tabeli
        public static void SetDataGridViewColumnsProp(DataGridView dataGridView
            , string[] columnNames, bool[] columnVisiblity, int[] columnWidth)
        {
            //podesi sirine kolona
            DataGridViewColumn column;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                column = dataGridView.Columns[i];
                if (column.ValueType.Name == "Int32" || column.ValueType.Name == "Decimal")
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (columnWidth.Length > i)
                    column.Width = columnWidth[i];
                if (columnVisiblity.Length > i)
                    column.Visible = columnVisiblity[i];
                if (columnNames.Length > i)
                    column.HeaderText = columnNames[i];
            }
        }


        //popunjava data grid sa vrednostima na osnovu query-ja
        //SqlConnection - konekcija na bazu
        //columNames - imena kolona u tabeli
        //columnVisibility - da li je kolona vidljiva u tabeli
        //columnWidth - sirine kolona u tabeli
        public static void PopulateDataGridView(SqlConnection connection, DataGridView dataGridView
            , string query, string[] columnNames, bool[] columnVisiblity, int[] columnWidth)
        {
            dataGridView.DataSource = GetDataTable(connection, query);

            //podesi sirine kolona
            DataGridViewColumn column;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                column = dataGridView.Columns[i];
                if (column.ValueType.Name == "Int32" || column.ValueType.Name == "Decimal")
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (columnWidth.Length > i)
                    column.Width = columnWidth[i];
                if (columnVisiblity.Length > i)
                    column.Visible = columnVisiblity[i];
                if (columnNames.Length > i)
                    column.HeaderText = columnNames[i];
            }
        }

        //popunjava combo box sa vrednostima
        //tableName - naziv tabele
        //orderField - polje po kom se sortira
        //idField - id polje u combobox-u
        //valueField - polje koje se ispisuje u combobox-u
        public static void PopulateComboBoxOneTable(SqlConnection connection, ComboBox comboBox
            , string tableName, string orderField, string idField, string valueField)
        {
            string query = "SELECT * FROM " + tableName + " ORDER BY " + orderField;

            comboBox.DisplayMember = valueField;
            comboBox.ValueMember = idField;
            comboBox.DataSource = GetDataTable(connection, query);
        }

        //popunjava combo box sa vrednostima
        //tableName - naziv tabele
        //orderField - polje po kom se sortira
        //idField - id polje u combobox-u
        //valueField - polje koje se ispisuje u combobox-u
        //dependField - naziv polja koje se nalazi u where izkazu
        //dependFieldValue - vrednost polja koje se nalazi u where izrazu
        public static void PopulateComboBoxDepend(SqlConnection connection, ComboBox comboBox, string tableName
            , string orderField, string idField, string valueField, string dependfield, string dependFieldValue)
        {
            string query = "SELECT * FROM " + tableName +
                " WHERE " + dependfield + " = " + dependFieldValue + " ORDER BY " + orderField + " ASC";

            comboBox.DataSource = GetDataTable(connection, query);
            comboBox.DisplayMember = valueField;
            comboBox.ValueMember = idField;
        }

        private static string AddListOfFields(string[] listOfFields, string existsFieldsString
            , string notExistsFieldsString)
        {
            string retStr = "";

            if (listOfFields != null && listOfFields.Length > 0)
            {
                retStr += existsFieldsString;
                for (int i = 0; i < listOfFields.Length; i++)
                {
                    if (i != 0)
                        retStr += ", ";
                    retStr += listOfFields[i];
                }
            }
            else
            {
                retStr += notExistsFieldsString;
            }

            return retStr;
        }

        private static string AddListOfFields(string[] listOfFields, bool[] isFieldsString
            , string existsFieldsString, string notExistsFieldsString)
        {
            string retStr = "";
            int i = 0;

            if (listOfFields != null && listOfFields.Length > 0)
            {
                retStr += existsFieldsString;
                foreach (string str in listOfFields)
                {
                    if (i != 0)
                        retStr += ", ";
                    if (isFieldsString[i])
                        retStr += QuotedString(str);
                    else
                        retStr += str;
                    i++;
                }
            }
            else
            {
                retStr += notExistsFieldsString;
            }

            return retStr;
        }

        private static string AddListOfFields(string[] listOfFields, bool[] isFieldsString, string[] dependField
            , string existsFieldsString, string notExistsFieldsString)
        {
            string retStr = "";
            int addedFields = 0;

            if (listOfFields != null && listOfFields.Length > 0)
            {
                retStr += existsFieldsString;
                for (int i = 0; i < listOfFields.Length; i++)
                {
                    if (dependField.Length > i && dependField[i].Trim().Length > 0)
                    {
                        if (addedFields != 0)
                            retStr += ", ";
                        if (isFieldsString != null && isFieldsString.Length > i && isFieldsString[i])
                            retStr += QuotedString(listOfFields[i]);
                        else
                            retStr += listOfFields[i];
                        addedFields++;
                    }
                }
            }
            else
            {
                retStr += notExistsFieldsString;
            }

            return retStr;
        }

        private static string AddListOfFields(string[] listOfFields, string[] dependField
            , string existsFieldsString, string notExistsFieldsString)
        {
            string retStr = "";
            int addedFields = 0;

            if (listOfFields != null && listOfFields.Length > 0)
            {
                retStr += existsFieldsString;
                for (int i = 0; i < listOfFields.Length; i++)
                {
                    if (dependField.Length > i && dependField[i].Trim().Length > 0 && dependField[i] != "''")
                    {
                        if (addedFields != 0)
                            retStr += ", ";
                        retStr += listOfFields[i];
                        addedFields++;
                    }
                }
            }
            else
            {
                retStr += notExistsFieldsString;
            }

            return retStr;
        }

        private static string AddFieldsEqualsValues(string[] listOfFields, string[] listOfValues
            , string connectString, string existsFieldsString
            , string notExistsFieldsString)
        {
            string retStr = "";
            //int i = 0;

            if (listOfFields != null && listOfFields.Length > 0)
            {
                retStr += existsFieldsString;
                for (int i = 0; i < listOfFields.Length; i++)
                {
                    if (listOfValues.Length > i && listOfValues[i].Trim().Length > 0 && listOfValues[i] != "''")
                    {
                        if (i > 0)
                            retStr += " " + connectString + " ";

                        retStr += listOfFields[i];
                        retStr += " = ";
                        retStr += listOfValues[i];
                        //i++;
                    }
                }
            }
            else
            {
                retStr += notExistsFieldsString;
            }

            return retStr;
        }

        public static string QuotedString(string inputStr)
        {
            return "'" + inputStr + "'";
        }

        //podesava properties za dataGrid
        public static void SetDataGridProp(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeRows = false;
            //dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 18;
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridView.TabStop = false;
        }

        //brisanje svih zavisnih vrednosti za prijavu
        public static void ObrisiSveUnoseZaPrijavu(SqlConnection connection, string idPrijave)
        {
            BrisanjeElemenataIzTabele(connection, "ClanDomacinstva", "IDPoreskePrijave", idPrijave);
            BrisanjeElemenataIzTabele(connection, "ClanPorodice", "IDPoreskePrijave", idPrijave);
            BrisanjeElemenataIzTabele(connection, "ElementiKvalitetaPoreskePrijave", "IDPoreskePrijave", idPrijave);
            BrisanjeElemenataIzTabele(connection, "PovrsineNepokrPoreskePrijave", "IDPoreskePrijave", idPrijave);
            BrisanjeElemenataIzTabele(connection, "RacunObveznika", "IDPoreskePrijave", idPrijave);
            BrisanjeElemenataIzTabele(connection, "OslobadjanjePoreskePrijave", "IDPoreskePrijave", idPrijave);
        }

        //brisanje vrednosti iz tabele
        private static void BrisanjeElemenataIzTabele(SqlConnection connection, string tableName, string idField, string idValue)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + idField + " = " + QuotedString(idValue);
            ExecuteSQLStatement(connection, query);
        }

        //dodavanje vrednosti u combobox sa prvom vrednosti
        //firstValue - prva vrednost u combobox-u
        //connection - konekcija
        //query - sql query
        //combobox - combo u koji se upisuju vrednosti
        //fieldToDisplay - polje koje se ispisuje u combobox-u
        public static void AddItemsToCombo(string firstValue, SqlConnection connection
            , string query, ComboBox comboBox, string fieldToDisplay)
        {
            DataTable dataTable = GetDataTable(connection, query);

            comboBox.Items.Clear();
            comboBox.Items.Add(firstValue);

            foreach (DataRow row in dataTable.Rows)
            {
                comboBox.Items.Add(row[fieldToDisplay].ToString());
            }
            comboBox.SelectedIndex = 0;

        }

        //vraca vrednost kljuca za selektovanu vrednost u combobox-u
        //connection - konekcija
        //returnFieldName - naziv polja koje se vraca
        //indexInCombo - selektovani index u combobox-u
        //combo - combobox
        public static string GetIdFromUserEnteredCombo(SqlConnection connection, string query
            , string returnFieldName, int indexInCombo, ComboBox combo)
        {
            DataTable dataTable = GetDataTable(connection, query);

            if (indexInCombo > 0 && dataTable.Rows.Count > indexInCombo - 1)
            {
                return dataTable.Rows[indexInCombo - 1][returnFieldName].ToString();
            }
            else
                return null;
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        public static void textBoxInteger_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        public static void textBoxFloat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            // Determine whether the keystroke is a number from the keypad.
            // Determine whether the keystroke is a backspace.
            // Determine whether the keystroke is a comma.
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                && e.KeyCode != Keys.Back)
            {
                if ((e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Oemcomma && e.KeyCode != Keys.Decimal) || ((e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal)
                    && (((TextBox)sender).Text.Length == 0 || ((TextBox)sender).Text.Contains(".") || ((TextBox)sender).Text.Contains(","))))
                {
                    // A non-numerical keystroke  or second comma was pressed.
                    // Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = true;
                }
            }
        }

        // This event occurs after the KeyDown event and can be used to prevent
        // characters from entering the control.
        public static void textBoxBroj_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }

            try
            {
                if (((TextBox)sender) != null)
                {
                    ((TextBox)sender).TextAlign = HorizontalAlignment.Right;
                }
            }
            catch
            {
            }
        }

        //nakon selektovanja maskedTextBox-a
        private static void maskedTextBox_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).Focus();
            ((MaskedTextBox)sender).SelectAll();
        }

        /// <summary>
        /// vraca string sa formatom datuma koji mora da se upise u bazu
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static string MaskedSaveDateFormat(string dateStr)
        {
            string splitter = ".";
            string day, month, year;
            int index = 0;
            try
            {
                if (dateStr.Contains("."))
                    splitter = ".";
                if (dateStr.Contains("/"))
                    splitter = "/";
                day = dateStr.Substring(index, dateStr.IndexOf(splitter));
                index = dateStr.IndexOf(splitter) + 1;
                month = dateStr.Substring(index, dateStr.IndexOf(splitter, index) - index);
                index = dateStr.IndexOf(splitter, index) + 1;
                year = dateStr.Substring(index, dateStr.Length - index);
                DateTime date = new DateTime(Convert.ToInt16(year), Convert.ToInt16(month)
                    , Convert.ToInt16(day));
                if (date >= new DateTime(1900, 1, 1) && date <= new DateTime(2079, 1, 1))
                {
                    return "'" + month + "/" + day + "/" + year + "'";
                }
                else
                {
                    return "null";

                }
            }
            catch
            {
                return "null";
            }
        }

        /// <summary>
        /// vraca string sa formatom datuma koji mora da se upise u bazu
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static string MaskedSaveDate(string dateStr)
        {
            string splitter = ".";
            string day, month, year;
            int index = 0;
            try
            {
                if (dateStr.Contains("."))
                    splitter = ".";
                if (dateStr.Contains("/"))
                    splitter = "/";
                day = dateStr.Substring(index, dateStr.IndexOf(splitter));
                index = dateStr.IndexOf(splitter) + 1;
                month = dateStr.Substring(index, dateStr.IndexOf(splitter, index) - index);
                index = dateStr.IndexOf(splitter, index) + 1;
                year = dateStr.Substring(index, dateStr.Length - index);
                DateTime date = new DateTime(Convert.ToInt16(year), Convert.ToInt16(month)
                    , Convert.ToInt16(day));
                if (date >= new DateTime(1900, 1, 1) && date <= new DateTime(2079, 1, 1))
                {
                    return month + "/" + day + "/" + year;
                }
                else
                {
                    return "null";

                }
            }
            catch
            {
                return "null";
            }
        }


        /// <summary>
        /// ucitavanje datuma u mask text box
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string MaskLoadDate(Object date)
        {
            try
            {
                DateTime datetime = Convert.ToDateTime(date);
                return datetime.Day.ToString("D2") + "/" + datetime.Month.ToString("D2") + "/" + datetime.Year.ToString("D4");
            }
            catch
            {
                return "  /  /    ";
            }
        }

        /// <summary>
        /// vraca datum iz masked text boxa
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static string MaskGetDate(string dateStr)
        {
            try
            {
                string day, month, year;
                day = dateStr.Substring(0, 2);
                month = dateStr.Substring(3, 2);
                year = dateStr.Substring(6, 4);
                return (new DateTime(Convert.ToInt16(year), Convert.ToInt16(month), Convert.ToInt16(day))).ToShortDateString();
            }
            catch
            {
                return null;
            }
        }

        //public static void TimerTickProgressBarLoop(Common.BusyBar progressBar)
        //{
        //    if (progressBar.Value + 10 > progressBar.Maximum)
        //        progressBar.Value = 0;
        //    progressBar.Value += 10;
        //}

        public static void SetComboProperties(ComboBox combo)
        {
            combo.AllowDrop = true;
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void ControlKeyDownReturn(Object sender, KeyEventArgs e, Object formObject)
        {
            if (e.KeyCode == Keys.Return)
            {
                ((Form)formObject).SelectNextControl(((System.Windows.Forms.Control)sender)
                    , true, true, true, true);
            }
        }

        public static int GetAccessLevel(SqlConnection conn, string username, string accessType)
        {
            DataRow row = SQLCommands.GetFirstDataRow(conn
                , "SELECT * FROM PristupiKorisnika WHERE IDKorisnika = "
                + SQLCommands.QuotedString(username) +
                " AND IDNazivaDelaPristupa = " + accessType);

            if (row != null)
                return int.Parse(row["IDNivoPristupa"].ToString());
            else
                return 0;
        }

        public static string kontoOK(string konto, string tip, string programfk, string prog_akt_proj_fk, string connstr, string godina, int duzina_konta)
        {
            konto = konto.Substring(0, duzina_konta);

            string query = "";

            if (tip == "programska aktivnost")
            {
                query = "SELECT id FROM FIN_PLAN_BUDZETA WHERE (godina = " + godina + ") AND (aktivan = 1) AND (konto like '" + konto + "%') AND (programfk = " + programfk + ") AND (progaktivnostfk = " + prog_akt_proj_fk + ")";
            }
            else if (tip == "projekat")
            {
                query = "SELECT id FROM FIN_PLAN_BUDZETA WHERE (godina = " + godina + ") AND (aktivan = 1) AND (konto like '" + konto + "%') AND (programfk = " + programfk + ") AND (projekatfk = " + prog_akt_proj_fk + ")";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, connstr);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            if (tbl.Rows.Count > 0)
            {
                return "ok";
            }
            else
            {
                string k = koji_konto_za_program(tip, programfk, prog_akt_proj_fk, connstr, godina);
                return k;
            }
        }

        private static string koji_konto_za_program(string tip, string programfk, string prog_akt_proj_fk, string connstr, string godina)
        {
            string query = "";

            if (tip == "programska aktivnost")
            {
                query = "SELECT konto FROM FIN_PLAN_BUDZETA WHERE (godina = " + godina + ") AND (aktivan = 1) AND (programfk = " + programfk + ") AND (progaktivnostfk = " + prog_akt_proj_fk + ")";
            }
            else if (tip == "projekat")
            {
                query = "SELECT konto FROM FIN_PLAN_BUDZETA WHERE (godina = " + godina + ") AND (aktivan = 1) AND (programfk = " + programfk + ") AND (projekatfk = " + prog_akt_proj_fk + ")";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, connstr);
            DataTable tbl = new DataTable();
            da.Fill(tbl);

            if (tbl.Rows.Count > 0)
            {
                DataRow row = tbl.Rows[0];
                string konto = row["konto"].ToString();

                return konto;
            }
            else
            {
                return "Nije u programskom budžetu dodeljen konto za ovu programsku aktivnost/projekt !!!";
            }
        }

        public static int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                DataRowView row = obj as DataRowView;

                label1.Text = row["naziv"].ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            if (maxWidth == 0) return 250;
            return maxWidth;
        }
    }
}
