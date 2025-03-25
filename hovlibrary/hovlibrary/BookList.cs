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

namespace hovlibrary
{
    public partial class BookList: Form
    {
        Book selectedBook;
        BookDetail selectedBookDetail;
        HovLibraryEntities db = new HovLibraryEntities();
        public BookList(Book selectedBook)
        {
            InitializeComponent();

            this.selectedBook = selectedBook;

            textBox1.Text = selectedBook.title;
            update_datagrid();

            textBox2.Enabled = false;
            button1.Enabled = false;

            foreach (var item in db.Locations.ToList())
            {
                comboBox1.Items.Add(item.name);
            }
        }


        private void update_datagrid()
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.Clear();
            foreach (var item in db.BookDetails.Where(b => b.book_id == selectedBook.id))
            {
                string status = db.Borrowings.Any(b => b.bookdetails_id == item.id && b.return_date != null) ? "Borrowed" : "Available";
                dataGridView1.Rows.Add(item.id, item.code, item.Location.name, status, "Delete");
            }
        }

        private void BookList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selectedBookDetail = db.BookDetails.Find(id);
                if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteCol")
                {
                    DialogResult result = MessageBox.Show("Are you sure Want to delete this Book Detail?", "", MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes)
                    {
                        db.BookDetails.Remove(selectedBookDetail);
                        db.SaveChanges();
                        update_datagrid();
                    }

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                button1.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Location loc = db.Locations.ToList()[comboBox1.SelectedIndex];

            string code = $"{(db.Books.Select(b => b.id).ToList().Max() + 1).ToString("####")}.{selectedBook.id.ToString("####")}.{loc.id.ToString("##")}.{selectedBook.publication_date.ToString("yyyy")}";

            BookDetail detail = new BookDetail()
            {
                Book = selectedBook,
                Location = loc,
                code = code,
                created_at = DateTime.Now
            };

            db.BookDetails.Add(detail);
            db.SaveChanges();

            update_datagrid();
        }
    }
}
