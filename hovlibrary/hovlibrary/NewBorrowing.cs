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
    public partial class NewBorrowing: Form
    {
        HovLibraryEntities db = new HovLibraryEntities();

        public NewBorrowing()
        {
            InitializeComponent();


            foreach (var item in db.Books.ToList())
            {
                textBox1.AutoCompleteCustomSource.Add(item.title);
            }
            update_datagrid();
        }

        private void update_datagrid()
        {
            if (textBox1.Text == "")
            {
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows.Clear();

                foreach (var item in db.BookDetails.ToList())
                {
                    string status = db.Borrowings.Any(b => b.bookdetails_id == item.id && b.return_date != null) ? "Borrowed" : "Available";
                    dataGridView1.Rows.Add(item.id, item.code, item.Location.name, status, false);
                }
            }
        }

        private void NewBorrowing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Member member = db.Members.FirstOrDefault(m=>m.name == textBox2.Text);


            if (member != default)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool check = Convert.ToBoolean(row.Cells["SelectedCol"].Value);

                    if (check)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);

                        BookDetail book = db.BookDetails.Find(id);

                        Borrowing borrow = new Borrowing()
                        {
                            Member = member,
                            BookDetail = book,
                            borrow_date = DateTime.Now,
                            created_at = DateTime.Now,
                            last_updated_at = DateTime.Now
                        };


                        db.Borrowings.Add(borrow);
                    }
                }

                db.SaveChanges();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
