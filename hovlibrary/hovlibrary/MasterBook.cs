using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hovlibrary
{
    public partial class MasterBook: Form
    {

        HovLibraryEntities db = new HovLibraryEntities();
        List<Book> books;
        bool filterActive = false;
        Book selectedBook;
        public MasterBook()
        {
            InitializeComponent();

            books = db.Books.ToList();
            update_datagrid();

            EnableInput(false);

            foreach (var item in db.Languages.ToList())
            {
                comboBox2.Items.Add(item.long_text);
            }
            var bookpage = db.Books.Select(b => b.number_of_pages).ToList().Distinct().ToList();
            bookpage.Sort();

            foreach (var item in bookpage)
            {
                comboBox3.Items.Add(item);
                comboBox4.Items.Add(item);
            }

            var bookrate = db.Books.Select(b => b.ratings_count).ToList().Distinct().ToList();
            bookrate.Sort();

            foreach (var item in bookrate)
            {
                comboBox6.Items.Add(item);
                comboBox5.Items.Add(item);
            }
        }

        private void update_datagrid()
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.Clear();
            foreach (var item in books)
            {
                dataGridView1.Rows.Add(item.id, item.Language.long_text, 
                                    item.title, item.isbn, item.isbn13, item.authors, 
                                    item.Publisher.name, item.publication_date, 
                                    item.number_of_pages, item.ratings_count, "Show", "Edit", "Delete");

            }
        }

        private void EnableInput(bool condition)
        {
            textBox4.Enabled = condition;
            textBox2.Enabled = condition;
            textBox3.Enabled = condition;
            textBox6.Enabled = condition;
            textBox5.Enabled = condition;
            textBox9.Enabled = condition;
            textBox8.Enabled = condition;
            textBox7.Enabled = condition;
            dateTimePicker3.Enabled = condition;
            button2.Enabled = condition;

        }

        private void MasterBook_Load(object sender, EventArgs e)
        {

        }
        private void Searching(List<Book> booksQuery=null)
        {
            if (textBox1.Text == "" )
            {
                if (booksQuery != null)
                    books = booksQuery;
                else
                    books = db.Books.ToList();
            }


            switch (comboBox1.SelectedIndex)
            {
                case 0: //title
                    if (booksQuery == null)
                        books = db.Books.Where(b => b.title.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
                    else
                        books = booksQuery.Where(b => b.title.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
                    break;

                case 1: //author
                    if (booksQuery == null)
                        books = db.Books.Where(b => b.authors.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
                    else
                        books = booksQuery.Where(b => b.authors.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
                    break;

                case 2: //publisher
                    if (booksQuery == null)
                        books = db.Books.Where(b => b.Publisher.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
                    else
                        booksQuery = booksQuery.Where(b => b.Publisher.name.ToLower().TrimEnd().Contains(textBox1.Text.ToLower().TrimEnd())).ToList();
                    break;

                default:
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                books = db.Books.ToList();
            }

            else
            {
                if (!filterActive)
                    Searching();

                else
                    Filtering();
            }

            update_datagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filtering();
            update_datagrid();
        }

        private void Filtering()
        {
            filterActive = true;
            if (textBox1.Text == "" || comboBox1.SelectedIndex == 0)
            {
                try
                {
                    books = db.Books.AsEnumerable().Where(b=>
                                b.Language.long_text == comboBox2.Text && 
                                b.publication_date > dateTimePicker1.Value &&
                                b.publication_date < dateTimePicker2.Value && 
                                b.number_of_pages > int.Parse(comboBox3.Text) &&
                                b.number_of_pages < int.Parse(comboBox4.Text) &&
                                b.ratings_count > int.Parse(comboBox6.Text) &&
                                b.ratings_count < int.Parse(comboBox5.Text)
                                ).ToList();
                }
                catch
                {
                    books = db.Books.ToList(); 
                }
            }
            else
            {
                List<Book> booksQuery;
                try
                {
                     booksQuery = db.Books.AsEnumerable().Where(b =>
                                    b.Language.long_text == comboBox2.Text &&
                                    b.publication_date > dateTimePicker1.Value &&
                                    b.publication_date < dateTimePicker2.Value &&
                                    b.number_of_pages > int.Parse(comboBox3.Text) &&
                                    b.number_of_pages < int.Parse(comboBox4.Text) &&
                                    b.ratings_count > int.Parse(comboBox6.Text) &&
                                    b.ratings_count < int.Parse(comboBox5.Text)
                                    ).ToList();
                }
                catch
                {   
                    booksQuery = db.Books.ToList(); 
                }
                Searching(booksQuery);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!filterActive)
                Searching();

            else
                Filtering();

            update_datagrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selectedBook = db.Books.Find(id);

                if (dataGridView1.Columns[e.ColumnIndex].Name == "BookListCol")
                {

                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "EditCol")
                {
                    EnableInput(true);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteCol")
                {
                    DialogResult result = MessageBox.Show("Are you sure Want to delete this Book?", "", MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes)
                    {
                        db.Books.Remove(selectedBook);
                        db.SaveChanges();
                        update_datagrid();
                    }
                }

                textBox4.Text = selectedBook.Language.long_text;
                textBox2.Text = selectedBook.title;
                textBox3.Text = selectedBook.isbn;
                textBox6.Text = selectedBook.isbn13;
                textBox5.Text = selectedBook.authors;
                textBox9.Text = selectedBook.Publisher.name;
                textBox8.Text = selectedBook.number_of_pages.ToString();
                textBox7.Text = selectedBook.ratings_count.ToString();
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedBook.Language.long_text = textBox4.Text;
            selectedBook.title = textBox2.Text;
            selectedBook.isbn = textBox3.Text;
            selectedBook.isbn13 = textBox6.Text;
            selectedBook.authors = textBox5.Text;
            selectedBook.Publisher.name = textBox9.Text;
            selectedBook.number_of_pages= int.Parse(textBox8.Text);
            selectedBook.ratings_count = int.Parse(textBox7.Text);

            db.SaveChanges();

            update_datagrid();
            EnableInput(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
