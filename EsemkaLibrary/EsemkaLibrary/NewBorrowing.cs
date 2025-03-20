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
    public partial class NewBorrowing : Form
    {
        EsemkaLibraryEntities db = new EsemkaLibraryEntities();
        int user_id;
        public NewBorrowing(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
        }

        private void NewBorrowing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var books = db.Books.Where(b => b.title.ToLower().TrimEnd().Contains(textBox1.Text.TrimEnd().ToLower())).ToList();

            foreach (var book in books)
            {
                Genre genre = db.BookGenres.FirstOrDefault(g => g.book_id == book.id).Genre;
                if (book.stock <= 0)
                {
                    int i = dataGridView1.Rows.Add(book.title, genre.name, book.author, book.publish_date, book.stock, "");
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows.Add(book.title, genre.name, book.author, book.publish_date, book.stock, "Borrow");
                }
            }

            if (books.Count <= 0)
            {
                MessageBox.Show("Couldn't find the book title by given title");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["ActionCol"].Value.ToString() == "Borrow")
                {
                    Book book = db.Books.AsEnumerable().First(b => b.title == dataGridView1.Rows[e.RowIndex].Cells["TitleCol"].Value.ToString());

                    book.stock -= 1;

                    Member member = db.Members.Find(user_id);

                    Borrowing borrow = new Borrowing()
                    {
                        Member = member,
                        Book = book,
                        borrow_date = DateTime.Now,
                        created_at = DateTime.Now
                    };

                    db.Borrowings.Add(borrow);
                    db.SaveChanges();

                    MessageBox.Show($"Success borrow {book.title} due date is 7 days from today", "Notification", MessageBoxButtons.OK);
                    Home home = new Home();
                    home.Show();
                    this.Hide();

                }
            }
        }
    } 
}
