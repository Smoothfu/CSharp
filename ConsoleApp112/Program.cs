using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp112
{
    class Program
    {
        static void Main(string[] args)
        {
            var bc = new BookCollection();
            bc.ListBooks();
            Console.WriteLine("\n\n\n");

            ref var book = ref bc.GetBookByTitle("Data Structure");

            if(book!=null)
            {
                book = new Book { Title = "Algorithm", Author = "Alexander" };
            }

            bc.ListBooks();
            Console.ReadLine();
        }       
    }      

    public class Book
    {
        public string Author;
        public string Title;
    }

    public class BookCollection
    {
        private Book[] books = {new Book { Title="Dive into C#",Author="Fred"},
        new Book{Title="Data Structure",Author="Floomberg"}};

        private Book noBook = null;

        public ref Book GetBookByTitle(string title)
        {
            for(int ctr=0;ctr<books.Length;ctr++)
            {
                if(title==books[ctr].Title)
                {
                    return ref books[ctr];
                }
            }

            return ref noBook;
        }

        public void ListBooks()
        {
            foreach(var book in books)
            {
                Console.WriteLine($"{book.Title},by {book.Author}");
            }
            Console.WriteLine();
        }
    }
}
