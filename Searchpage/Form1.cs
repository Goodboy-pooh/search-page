using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Searchpage
{
    public partial class Form1 : Form
    {
        private List<Book> books = new List<Book>
    {
        new Book("The Great Gatsby", "F. Scott Fitzgerald", "123456"),
        new Book("To Kill a Mockingbird", "Harper Lee", "789012"),
        new Book("1984", "George Orwell", "345678"),
        new Book("Moby Dick", "Herman Melville", "901234"),
        new Book("Pride and Prejudice", "Jane Austen", "567890")
    };
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            dgvResults.DataSource = books; // Load all books initially
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            // Perform search based on Title, Author, or ISBN
            var filteredBooks = books.Where(b =>
                b.Title.ToLower().Contains(keyword) ||
                b.Author.ToLower().Contains(keyword) ||
                b.ISBN.Contains(keyword)
            ).ToList();

            dgvResults.DataSource = filteredBooks;

            // Show message if no results found
            if (filteredBooks.Count == 0)
            {
                MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }
    }
}
