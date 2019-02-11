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
    public partial class UserForm : Form
    {

        bool isExpanded = false;
        DatabaseHandler dbHandler;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            DatabaseHandler.userLogged = "DBA";
            DatabaseHandler.userPassword = "goalie";
            DatabaseHandler.currentSchema = "HOCKEY";
            dbHandler = new DatabaseHandler();

            LoadUsers();
            
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                DatabaseHandler database = new DatabaseHandler();
                
                if( database.Login(txtUsername.Text, txtPassword.Text))
                {
                    DatabaseHandler.userLogged = txtUsername.Text;
                    DatabaseHandler.userPassword = txtPassword.Text;

                    Form1 main = new Form1(txtUsername.Text, txtPassword.Text);
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Authentication Failed");
                }
                    
            }
            else
            {
                MessageBox.Show("Fill all spaces");
            }
            

        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                DatabaseHandler database = new DatabaseHandler();

                if (database.CreateUser(txtUsername.Text, txtPassword.Text))
                {
                    MessageBox.Show("User created succesfully");
                    LoadUsers();
                }
                else
                    MessageBox.Show("User wasnt created");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isExpanded)
            {
                Form1.ActiveForm.Width = 334;

                button1.Location = new Point(Form1.ActiveForm.Width - 100, button1.Location.Y);
                button1.Text = "View Users";
            }
            else
            {
                Form1.ActiveForm.Width = 973;

                button1.Location = new Point(Form1.ActiveForm.Width - 100, button1.Location.Y);
                button1.Text = "Quit";
            }

            isExpanded = !isExpanded;

        }

        public void LoadUsers()
        {
            listView1.Items.Clear();
            cmbAlterUsers.Items.Clear();

            var listUsers = dbHandler.GetUsers();

            foreach (String str in listUsers)
            {
                listView1.Items.Add(str);
                cmbAlterUsers.Items.Add(str);
            }

            cmbAlterUsers.SelectedIndex = 0;

        }

        private void cmbAlterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAlterScript();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateAlterScript();
        }

        private void UpdateAlterScript()
        {
            labelScript.Text = "ALTER USER \"" + cmbAlterUsers.SelectedItem.ToString() + "\" password '" + txtNewPassword.Text + "'";
        }

        private void btnAlterUser_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != "")
            {
                var status = new DatabaseHandler().AlterUser(labelScript.Text);

                if (status == "Success")
                {
                    MessageBox.Show("User altered correctly");
                    txtNewPassword.Text = "";

                }
                else
                {
                    MessageBox.Show("Something went wrong when altering user\nError: " + status);
                }
            }
            else
            {
                MessageBox.Show("Write the password");
            }
        }
    }
}
