using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlDeveloperProject
{
    public partial class Tables : Form
    {
        
        //TODO: IMPLEMENT AUTO INCREMENT - DONE
        //TODO: FIX AUTO INCREMENT - DONE
        //TODO: IMPLEMENT PRIMARY KEY - DONE

        string strDDL = "";
        List<String> columnNames;
        List<String> dataType;
        List<String> size;
        bool[] isPrimary = new bool[20];
        bool[] isAutoIncrement = new bool[20];
        bool[] isVarchar = new bool[20];

        DatabaseHandler dbHandler;

        public Tables()
        {
            InitializeComponent();
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            columnNames = new List<string>();
            dataType = new List<string>();
            size = new List<String>();

            for(int i = 0; i < 20; i++)
            {
                isPrimary[i] = false;
                isAutoIncrement[i] = false;
                isVarchar[i] = false;
            }

            dbHandler = new DatabaseHandler();

            LoadTablesToCombobox();
        }

        private void LoadTablesToCombobox()
        {
            cmbTables.Items.Clear();
            cmbSchemasCreate.Items.Clear();
            cmbSchemasDelete.Items.Clear();

            var listTables = dbHandler.GetSchemaTables(DatabaseHandler.currentSchema);
            var listSchemas = dbHandler.GetConnectionSchemas("");

            foreach (String str in listTables)
                cmbTables.Items.Add(str);

            foreach (String str in listSchemas)
            {
                if(str != "SYSTEM") //Avoid adding system table in order to avoid deleting its tables
                    cmbSchemasDelete.Items.Add(str);

                cmbSchemasCreate.Items.Add(str);
            }

            cmbSchemasCreate.SelectedIndex =  cmbSchemasDelete.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (cmbDataType.SelectedItem.ToString() == "integer") //If the variable type is integer then automatically set the size will be 4 bytes
                txtSize.Text = "9";
            else if (cmbDataType.SelectedItem.ToString() == "boolean")
                txtSize.Text = "9";
            else if (cmbDataType.SelectedItem.ToString() == "bigint") //If the variable type is integer then automatically set the size will be 19 bytes
                txtSize.Text = "19";
            
            if ( txtName.Text != "" && txtSize.Text != "")
            {
                if (cmbDataType.SelectedItem.ToString() == "varchar")
                    isVarchar[columnNames.Count] = true;
                
                isAutoIncrement[columnNames.Count] = Convert.ToBoolean(chkAutoIncrement.CheckState);

                /* if the field autoincrement is equal to true then its automatically a primary key and shouldnt be added
                 * to the primary keys array to avoid duplicated primary keys */
                if (isAutoIncrement[columnNames.Count] == false) 
                    isPrimary[columnNames.Count] = Convert.ToBoolean(chkPrimaryKey.CheckState);

                /* Remove all whitespaces from the Name text and add it to the list */
                columnNames.Add(RemoveWhiteSpaceFromString(txtName.Text));

                dataType.Add(cmbDataType.SelectedItem.ToString());
                
                size.Add(txtSize.Text);

                txtName.Text = "";
                txtSize.Text = "";
                cmbDataType.SelectedIndex = 0;

                updateLabelScript();

                chkAutoIncrement.Checked = false;
                chkPrimaryKey.Checked = false;

            } else
            {
                MessageBox.Show("Fill all spaces in order to save");

            }
                    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /* Check if the user has saved at least one object by checking if the label text is the same as the form was loaded 
             * and if the list is empty */
            if(labelScript.Text == "label1" && columnNames.Count == 0)
            {
                MessageBox.Show("Save at least one field in order to create table");
                return;
            }

            string generatedDDL = GenerateDDL();

            string status = dbHandler.CreateTable(generatedDDL);

            if(status == "Success")
            {
                MessageBox.Show("Table saved succesfully");
                LoadTablesToCombobox();

            } else
            {
                MessageBox.Show("Something went wrong while creating table\nError Message: "+status);
            }

            updateLabelScript();
            resetAllLists();
            
        }

        public void updateLabelScript()
        {
            labelScript.Text = "CREATE TABLE " + cmbSchemasCreate.SelectedItem.ToString() +"."+ 
                RemoveWhiteSpaceFromString(txtTableName.Text) + " (\n   ";

            /* Loop through all the lists and forming the ddl */
            for (int i = 0; i < columnNames.Count; i++)
            {
                /*if the current field data type is not a varchar then the size shouldnt be added to the script */
                if (isVarchar[i] == true)
                    labelScript.Text += columnNames[i].ToString() + " " + dataType[i].ToString() + "(" + size[i].ToString() + ") NOT NULL";
                else
                    labelScript.Text += columnNames[i].ToString() + " " + dataType[i].ToString();

                if ( isAutoIncrement[i] == true)
                    labelScript.Text += " generated always as identity primary key";

                if (columnNames.Count != i+1)
                {
                    labelScript.Text += ",\n   ";
                }

            }

            /* Loop through the boolean array to add the primary keys at the end of the string */
            bool thereIsAPrimaryKey = false;
            for(int i = 0; i < columnNames.Count; i++)
            {

                if(isPrimary[i] == true)
                {
                    if(thereIsAPrimaryKey == false)
                    {
                        labelScript.Text += ", PRIMARY KEY ( " + columnNames[i].ToString();
                        thereIsAPrimaryKey = true;
                    } else
                    {
                        labelScript.Text += " , " + columnNames[i].ToString();
                    }
                }

            }

            if (thereIsAPrimaryKey)
                labelScript.Text += ")\n";

            labelScript.Text += ");";
            
        }

        public string GenerateDDL()
        {
            return labelScript.Text.Replace('\n', ' ');
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {

            var tables = dbHandler.GetTableDDL(cmbTables.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

            richTextBox1.Text = "Table " + cmbTables.SelectedItem.ToString() + "\n";
            foreach (String str in tables)
                richTextBox1.Text += "\t"+ str +"\n";

            richTextBox1.Text += "\n\t ------ INDEXES ------\n\n";

            //VERY SMART CODE!!!!!!!!!!!  I managed to use an existing code, adding a part of the query and eliminating the rest of the query by using comments
            var indexes = dbHandler.GetSchemaIndexes(cmbSchemasDelete.SelectedItem.ToString() + "' and Tablename = '"+cmbTables.SelectedItem.ToString()+"';//");

            foreach (String str in indexes)
            {
                richTextBox1.Text += "\t" + str + "\n";

                var indexFields = dbHandler.GetIndexFields(str, cmbSchemasDelete.SelectedItem.ToString());

                richTextBox1.Text += "\t-----ON FIELDS------ \n";

                foreach (string strField in indexFields)
                    richTextBox1.Text += "\t\t" + strField + "\n";

                richTextBox1.Text += "\t-----END------ \n\n";
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {

            var comboBox = sender as ComboBox;

            if (comboBox.SelectedItem.ToString() == "integer" || comboBox.SelectedItem.ToString() == "bigint")
            {
                chkAutoIncrement.Enabled = true;
                chkPrimaryKey.Enabled = true;
            } else
            {
                chkAutoIncrement.Enabled = false;
                chkPrimaryKey.Enabled = false;
            }
        }

        private void cmbDataType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {

            if(cmbSchemasDelete.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Select a schema to delete the table");
                return;
            }

            string status = dbHandler.DeleteTable(cmbTables.SelectedItem.ToString(), cmbSchemasDelete.SelectedItem.ToString());

            if(status == "Success")
            {
                MessageBox.Show("Table Deleted");
                LoadTablesToCombobox();
                cmbTables.SelectedIndex = 0;
            } else
            {
                MessageBox.Show("Something went wrong while deleting the table\n Error Message: " + status);
            }
    
        }

        public void resetAllLists()
        {
            columnNames.Clear();
            dataType.Clear();
            size.Clear();

            for (int i = 0; i < 20; i++)
            {
                isPrimary[i] = false;
                isAutoIncrement[i] = false;
                isVarchar[i] = false;
            }
        }

        private void cmbSchemasDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            
            var listTables = dbHandler.GetSchemaTables(cmb.SelectedItem.ToString());
            
            cmbTables.Items.Clear();

            foreach (String str in listTables)
                cmbTables.Items.Add(str);

            cmbTables.SelectedIndex = 0;
        }

        public string RemoveWhiteSpaceFromString(string str)
        {
            /* Remove all whitespaces and fills the whitespace by joining the rest of the string*/
            
            return new string(str.Where
                            (
                                c => !char.IsWhiteSpace(c)
                            )
                            .ToArray<char>()
                       );
        }
    }
}
