using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaLibrary
{
    public partial class Home: Form
    {
        EsemkaLibraryEntities db = new EsemkaLibraryEntities();
        

        public Home()
        {
            InitializeComponent();

            timer1.Start();
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_datagrid();
        }
        private void update_datagrid()
        {
            if (!db.Members.Any(b => b.name == textBox1.Text))
            {
                MessageBox.Show("Error Could not found member by given name");
                return;
            }

            dataGridView1.Rows.Clear();
            int counter = 0;

            foreach (var data in db.Borrowings.Where(b => b.Member.name == textBox1.Text && b.return_date == null).ToList())
            {
                if (counter < 3)
                {
                    DateTime dueDate = data.borrow_date.AddDays(7);
                    int overdue = 0, i;

                    if (DateTime.Now.ToString("d") == dueDate.ToString("d"))
                    {
                        overdue = 0;
                        i = dataGridView1.Rows.Add(data.Book.title, data.borrow_date.ToString("D"),
                                        dueDate.ToString("D"), overdue.ToString(), "Return");
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }

                    else if (DateTime.Now > dueDate)
                    {
                        overdue = (DateTime.Now - dueDate).Days;
                        i = dataGridView1.Rows.Add(data.Book.title, data.borrow_date.ToString("D"),
                                        dueDate.ToString("D"), overdue.ToString(), "Return");
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        i = dataGridView1.Rows.Add(data.Book.title, data.borrow_date.ToString("D"),
                                        dueDate.ToString("D"), overdue.ToString(), "Return");
                    }

                }

                counter++;
            }

            if (counter < 3)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                Borrowing borrow = db.Borrowings.AsEnumerable().FirstOrDefault(b => b.Member.name == textBox1.Text
                                    && b.Book.title == dataGridView1.Rows[e.RowIndex].Cells["TitleCol"].Value.ToString());

                int pay = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["overdueCol"].Value.ToString());
                MessageBox.Show($"Success return '{borrow.Book.title}' member needs to pay fine: {pay}IDR", "Notification", MessageBoxButtons.OK);

                borrow.return_date = DateTime.Now;
                borrow.fine = pay;
                Book book = db.Books.First(b=>b.title == dataGridView1.Rows[e.RowIndex].Cells["TitleCol"].Value.ToString());
                book.stock += 1;
                db.SaveChanges();
                update_datagrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Member member = db.Members.First(m => m.name == textBox1.Text);
            NewBorrowing borrow = new NewBorrowing(member.id);
            borrow.Show();
            this.Hide();
        }
    }
}
