using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hovlibrary
{
    public partial class AllBorrowing: Form
    {
        HovLibraryEntities db = new HovLibraryEntities();
        public AllBorrowing()
        {
            InitializeComponent();

            foreach (var item in db.Borrowings.ToList())
            {
                if (item.return_date == null)
                    dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, "Return");

                else
                    dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, " ");
            }

        }

        private void update_datgrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in db.Borrowings.ToList())
            {
                if (item.return_date == null)
                    dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, "Return");

                else
                    dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, " ");
            }
        }


        private void AllBorrowing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in db.Borrowings.AsEnumerable().Where(b=>b.borrow_date > dateTimePicker1.Value && b.borrow_date < dateTimePicker2.Value))
            {
                if (comboBox1.Text == "ongoing")
                {
                    if (item.return_date == null)
                    {

                        if (item.return_date == null)
                            dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, "Return");

                        else
                            dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, " ");

                    }

                }
                else if (comboBox1.Text == "Returned")
                {

                    if (item.return_date != null)
                    {

                        if (item.return_date == null)
                            dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, "Return");

                        else
                            dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, " ");
                    }
                }
                else if (comboBox1.Text == "Late")
                {

                    if (DateTime.Now > item.borrow_date.AddDays(7))
                    {

                        if (item.return_date == null)
                            dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, "Return");

                        else
                            dataGridView1.Rows.Add(item.id, item.Member.name, item.BookDetail.Book.title, item.BookDetail.code, item.borrow_date, item.return_date, item.fine, " ");
                    }
                        
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "ReturnCol")
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["ReturnCol"].Value.ToString() == "Return")
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                    Borrowing borrow = db.Borrowings.Find(id);

                    borrow.return_date = DateTime.Now;
                    if (DateTime.Now > borrow.borrow_date)
                        borrow.fine = (borrow.borrow_date - borrow.return_date)?.Days * 2000;
                    else
                        borrow.fine = 0;

                    borrow.last_updated_at = DateTime.Now;
                    db.SaveChanges();
                    update_datgrid();
                }
            }
        }
    }
}
