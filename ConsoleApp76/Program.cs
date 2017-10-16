using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp76
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogManager bmManager = new BlogManager();
            Reader readerA = new Reader(bmManager);
            bmManager.WriteNewBlog("The first author","My First Article",DateTime.Now);
            readerA.Unregister(bmManager);
            bmManager.WriteNewBlog("The second author", "my second artice,shold not be received", DateTime.Now);
            Console.ReadLine();

        }
    }

    internal class BlogEventArgs : EventArgs
    {
        private readonly string author, content;
        private DateTime tdate;

        public BlogEventArgs(string author, string content, DateTime date)
        {
            this.author = author;
            this.content = content;
            this.tdate = date;
        }

        public string Author
        {
            get
            {
                return author;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }
        }

        public DateTime TDate
        {
            get
            {
                return tdate;
            }
        }
    }

    internal class BlogManager
    {
        public event EventHandler<BlogEventArgs> NewBlog;

        protected virtual void OnNewBlog(BlogEventArgs e)
        {
            EventHandler<BlogEventArgs> temp = Volatile.Read(ref NewBlog);
            if(temp!=null)
            {
                temp(this, e);
            }
        }

        public void WriteNewBlog(string author,string content,DateTime date)
        {
            BlogEventArgs e = new BlogEventArgs(author, content, date);
            OnNewBlog(e);
        }
    }

    internal sealed class Reader
    {
        public Reader(BlogManager blogManager)
        {
            blogManager.NewBlog += BlogManager_NewBlog;
        }

        private void BlogManager_NewBlog(object sender, BlogEventArgs e)
        {
            Console.WriteLine("The reader has received the blog!");
            Console.WriteLine("Author:{0},Content:{1},Publish time:{2}", e.Author, e.Content, e.TDate.ToShortTimeString());
        }

        public void Unregister(BlogManager bmManager)
        {
            bmManager.NewBlog -= BlogManager_NewBlog;
        }
    }
}
