using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodCourt.Resources;

namespace FoodCourt
{
    public partial class ManageForm : Form
    {
        public enum InputCondition { None=default, Insert, Update, Delete }
        FoodcourtEntities db = new FoodcourtEntities();
        private InputCondition inputCondition;
        private Users selectedUser;
        public ManageForm()
        {
            InitializeComponent();

            clear();

            refresh();
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {

        }

        private void refresh()
        {
            dataGridView1.DataSource = db.Users.AsEnumerable().Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Email,
                u.PhoneNumber,
                MemberSince = $"{u.DateJoined:dd-mm-yyyy} ({(DateTime.Now.Year - u.DateJoined.Year).ToString()} year(s))"
            }).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            errorText.Text = "";

            if (fNameInput.Text == "" || lNameInput.Text == "")
                errorText.Text = "please fill with your first name and last name!";

            if (emailInput.Text == "")
                errorText.Text = "please fill with your email!";

            if (pNumberInput.Text == "")
                errorText.Text = "please fill with your phone number!";

            if (passwordInput.Text == "")
                errorText.Text = "please fill with your password!";

            if (pNumberInput.Text.Length < 10 || pNumberInput.Text.Length > 15 || !pNumberInput.Text.All(char.IsDigit))
                errorText.Text = "Phone number should be a digit (between 10 15 digits)";

            if (passwordInput.Text.Length < 8)
                errorText.Text = "Password length must be at least 8 characters";

            if (emailInput.Text.Contains("@") && emailInput.Text.Contains("."))
            {
                if (errorText.Text == "")
                {
                    if (inputCondition.Equals(InputCondition.Insert))
                    {
                        Users user = new Users
                        {
                            FirstName = fNameInput.Text,
                            LastName = lNameInput.Text,
                            Email = emailInput.Text,
                            Password = passwordInput.Text,
                            PhoneNumber = pNumberInput.Text,
                            RoleID = 2,
                            DateJoined = DateTime.Now

                        };

                        if (db.Users.FirstOrDefault(u => u.Email == user.Email) == null)
                        {
                            Console.WriteLine("tersimpan");
                            db.Users.Add(user);
                            db.SaveChanges();

                            refresh();
                            clear();
                            // data aman
                        }
                        else
                        {
                            errorText.Text = "This Email has registered before";
                        }
                    }

                    else if (inputCondition.Equals(InputCondition.Update))
                    {
                            selectedUser.FirstName = fNameInput.Text;
                            selectedUser.LastName = lNameInput.Text;
                            selectedUser.Email = emailInput.Text;
                            selectedUser.Password = passwordInput.Text;
                            selectedUser.PhoneNumber = pNumberInput.Text;
                            selectedUser.RoleID = 2;
                            selectedUser.DateJoined = DateTime.Now;

                        if (db.Users.FirstOrDefault(u => u.Email == selectedUser.Email) == null)
                        {
                            Console.WriteLine("terubah");
                            db.SaveChanges();

                            refresh();
                            clear();
                            // data aman
                        }
                        else
                        {
                            errorText.Text = "This Email has registered before";
                        }
                    }
                }
            }
            else
            {
                errorText.Text = "Please input email correctly!";
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            string query = searchInput.Text.Trim().ToLower();


            if (searchInput.Text != "")
            {
                Console.WriteLine("effort");

                dataGridView1.DataSource = db.Users.Where(u => u.FirstName.ToLower().Contains(query)
                            || u.LastName.ToLower().Contains(query) ||
                            u.Email.ToLower().Contains(query))
                    .AsEnumerable().Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.PhoneNumber,
                    MemberSince = $"{u.DateJoined:dd-mm-yyyy} ({(DateTime.Now.Year - u.DateJoined.Year).ToString()} year(s))"
                }).ToList();
            }
            else
            {
                refresh();
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            //errorText.Text = "";

            //if (fNameInput.Text == "" || lNameInput.Text == "")
            //    errorText.Text = "please fill with your first name and last name!";

            //if (emailInput.Text == "")
            //    errorText.Text = "please fill with your email!";

            //if (pNumberInput.Text == "")
            //    errorText.Text = "please fill with your phone number!";

            //if (passwordInput.Text == "")
            //    errorText.Text = "please fill with your password!";

            //if (pNumberInput.Text.Length < 10 || pNumberInput.Text.Length > 15 || !pNumberInput.Text.All(char.IsDigit))
            //    errorText.Text = "Phone number should be a digit (between 10 15 digits)";

            //if (passwordInput.Text.Length < 8)
            //    errorText.Text = "Password length must be at least 8 characters";

            //if (emailInput.Text.Contains("@") && emailInput.Text.Contains("."))
            //{
            //    if (errorText.Text == "")
            //    {

            //        Users user = new Users
            //            {
            //                FirstName = fNameInput.Text,
            //                LastName = lNameInput.Text,
            //                Email = emailInput.Text,
            //                Password = passwordInput.Text,
            //                PhoneNumber = pNumberInput.Text,
            //                RoleID = 2,
            //                DateJoined = DateTime.Now

            //            };

            //        if (db.Users.FirstOrDefault(u => u.Email == user.Email) == null)
            //        {
            //            db.Users.Add(user);
            //            tempUsers.Add(user);

            //            dataGridView1.DataSource = db.Users.AsEnumerable().Select(u => new
            //            {
            //                u.FirstName,
            //                u.LastName,
            //                u.Email,
            //                u.PhoneNumber,
            //                MemberSince = $"{u.DateJoined:dd-mm-yyyy} ({(DateTime.Now.Year - u.DateJoined.Year).ToString()} year(s))"
            //            }).Concat(tempUsers.Select(u =>new {
            //                u.FirstName,
            //                u.LastName,
            //                u.Email,
            //                u.PhoneNumber,
            //                MemberSince = $"{u.DateJoined:dd-mm-yyyy} (0 year(s))"
            //            } )).ToList();
            //            clear();
            //            // data aman
            //        }
            //        else
            //        {
            //            errorText.Text = "This Email has registered before";
            //        }
            //    }
            //}
            //else
            //{
            //    errorText.Text = "Please input email correctly!";
            //}

            enabledInput(true);
            fNameInput.Text = "";
            lNameInput.Text = "";
            emailInput.Text = "";
            passwordInput.Text = "";
            pNumberInput.Text = "";
            inputCondition = InputCondition.Insert; 

        }

        private void clear()
        {

            fNameInput.Text = "";
            lNameInput.Text = "";
            emailInput.Text = "";
            passwordInput.Text = "";
            pNumberInput.Text = "";
            inputCondition = InputCondition.None;

            enabledInput(false);
                
            errorText.Text = "";
            saveButton.Enabled = false;
            cancelButton.Enabled = false;
        }

        private void enabledInput(bool condition)
        {
            fNameInput.Enabled = condition;
            lNameInput.Enabled = condition;
            emailInput.Enabled = condition;
            passwordInput.Enabled = condition;
            pNumberInput.Enabled = condition;

            insertButton.Enabled = !condition;
            updateButton.Enabled = !condition;
            deleteButton.Enabled = !condition;
            saveButton.Enabled = condition;
            cancelButton.Enabled = condition;

        }
        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            refresh();

            clear();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            if (selectedUser != null && fNameInput.Text != "")
            {
                enabledInput(true);
                inputCondition = InputCondition.Update;

                errorText.Text = "";
            }
            else
            {
                errorText.Text = "Please Select the Data";
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && inputCondition != InputCondition.Insert)
            {
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();

                selectedUser = db.Users.First(x => x.Email == email);
                fNameInput.Text = selectedUser.FirstName;
                lNameInput.Text = selectedUser.LastName;
                emailInput.Text = selectedUser.Email;
                passwordInput.Text = selectedUser.Password;
                pNumberInput.Text = selectedUser.PhoneNumber;
            }

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedUser != null && fNameInput.Text != "")
            {
                DialogResult result = MessageBox.Show("Are You Sure to Delete This Data?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Console.WriteLine("terhilang");
                    db.Users.Remove(selectedUser);
                    db.SaveChanges();

                    refresh();
                    clear();
                }
                else
                {
                    refresh();

                    clear();
                }

                inputCondition = InputCondition.Delete;

                errorText.Text = "";
            }
            else
            {
                errorText.Text = "Please Select the Data";
            }
        }
    }
}
