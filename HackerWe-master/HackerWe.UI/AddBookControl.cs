using HackerWe.Entities;
using HackerWe.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackerWe.UI
{
    public partial class AddBookControl : UserControl
    {
        Book newBook = new Book();

        public event Action<Book> SaveNewBook;

        public AddBookControl()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                newBook.Name = textBox1.Text;
                newBook.Id = int.Parse(textBox2.Text);
                newBook.Author = textBox3.Text;
                newBook.NumberOfPages = int.Parse(textBox4.Text);
                newBook.NumberOfCopies = short.Parse(textBox5.Text);
                newBook.NumberOfBorrowedOut = 0;
                newBook.ISBN = new Guid();
                newBook.DatePublished = dateTimePicker1.Value;

                Library.Books.Insert(0, newBook);
                Library.SaveBooksAsJSON();

                SaveNewBook(newBook);
            }
            catch 
            {
                MessageBox.Show("Something went wrong\nCheck ID, Number of copies or Number of Pages");
            }
           
        }
    }
}
