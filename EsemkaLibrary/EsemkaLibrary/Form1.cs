using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaLibrary
{
    public partial class Form1: Form
    {
        EsemkaLibraryEntities db = new EsemkaLibraryEntities();
        Member member;
        public Form1()
        {
            InitializeComponent();

            timer1.Start();

            button2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("F");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_datagrid();
        }

        private void update_datagrid()
        {
            if (db.Members.Any(m => m.name == textBox1.Text))
            {
                member = db.Members.First(m => m.name == textBox1.Text);
                int counter = 0;
                dataGridView1.Rows.Clear();
                foreach (var item in db.Borrowings.Where(b => b.Member.name == textBox1.Text && b.return_date == null))
                {
                    if (counter >= 3)
                        break;

                    DateTime duedate = item.borrow_date.AddDays(7);
                    int overdueDate = 0;

                    if (DateTime.Now.ToShortDateString() == duedate.ToShortDateString())
                    {
                        int index = dataGridView1.Rows.Add(item.Book.title, item.borrow_date, duedate.ToLongDateString(), overdueDate, "Return");
                        dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;

                    }
                    else if (DateTime.Now > duedate)
                    {
                        overdueDate = (DateTime.Now - duedate).Days;
                        int index = dataGridView1.Rows.Add(item.Book.title, item.borrow_date, duedate.ToLongDateString(), overdueDate, "Return");
                        dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows.Add(item.Book.title, item.borrow_date, duedate.ToLongDateString(), overdueDate, "Return");
                    }

                    counter++;
                }

                button2.Enabled = counter < 3;
            }
            else
            {
                MessageBox.Show("Couldn't find member by given name", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string bookTi = row.Cells["TitleCol"].Value.ToString();
                Borrowing borrow = db.Borrowings.First(b => b.Book.title == bookTi
                                        && b.Member.name == member.name);
                borrow.Book.stock++;
                borrow.return_date = DateTime.Now;
                int fine = int.Parse(row.Cells["OverdueCol"].Value.ToString()) * 2000;
                borrow.fine = fine;
                db.SaveChanges();

                MessageBox.Show($"Success return '{borrow.Book.title}' Member needs to pay fine: {fine}IDR");
                update_datagrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewBorrowing borrow = new NewBorrowing(member.id);
            borrow.Show();
            this.Hide();
        }
    }
}
