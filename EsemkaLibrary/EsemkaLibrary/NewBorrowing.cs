using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaLibrary
{
    public partial class NewBorrowing: Form
    {
        EsemkaLibraryEntities db = new EsemkaLibraryEntities();
        int member_id;
        public NewBorrowing(int member_id)
        {
            this.member_id = member_id;
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            foreach (var item in db.Books.Where(b=>b.title.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())))
            {
                Genre genre = db.BookGenres.First(g => g.Book.title.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).Genre;
                if (item.stock <= 0)
                {
                    int index = dataGridView1.Rows.Add(item.title, genre.name, item.author, item.publish_date, item.stock, "");
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows.Add(item.title, genre.name, item.author, item.publish_date, item.stock, "Borrow");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if (dataGridView1.CurrentRow.Index != -1 && row.Cells["ActionCol"].Value.ToString() != ""
                    && dataGridView1.Columns[e.ColumnIndex].Name == "ActionCol")
            {

                Book book = db.Books.AsEnumerable().First(b => b.title == row.Cells["TitleCol"].Value.ToString());
                book.stock--;
                Member member = db.Members.Find(member_id);


                Borrowing newborrow = new Borrowing()
                {
                    Member = member,
                    Book = book,
                    borrow_date = DateTime.Now,
                    created_at = DateTime.Now
                };

                db.Borrowings.Add(newborrow);
                db.SaveChanges();

                MessageBox.Show($"Success Borrow '{book.title}' Due date is 7 days from today");
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }
    }
}
