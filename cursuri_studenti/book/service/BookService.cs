using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.book.model;

namespace cursuri_studenti.book.service
{
    public class BookService
    {
        private List<Book> _listBook;

        public BookService()
        {
            _listBook = new List<Book>();

            this.ReadList();
        }

        public BookService(List<Book> listBook)
        {
            _listBook = listBook;
        }

        // Metode

        public void ReadList()
        {
            _listBook = new List<Book>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\books.txt");

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Book b = new Book(text);

                _listBook.Add(b);
            }

            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\books.txt");

            foreach (Book b in _listBook)
            {
                sw.WriteLine(b.Id + "/" + b.StudentId + "/" + b.Author + "/" + b.Name);
            }

            sw.Close();
        }

        public void Afisare()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (Book b in _listBook)
            {
                Console.WriteLine(b.Description());
            }
        }

        public void AfisareStudent()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (Book b in _listBook)
            {
                Console.WriteLine(b.DescriptionStudent());
            }
        }

        public Book FindById(int id)
        {
            foreach (Book b in _listBook)
            {
                if (b.Id == id)
                {
                    return b;
                }
            }

            return null;
        }

        public List<Book> FindByName(string name)
        {
            List<Book> books = new List<Book>();

            foreach (Book b in _listBook)
            {
                if (b.Name.Equals(name))
                {
                    books.Add(b);
                }
            }

            return books;
        }

        public List<Book> FindByAuthor(string author)
        {
            List<Book> books = new List<Book>();

            foreach (Book b in _listBook)
            {
                if (b.Author.Equals(author))
                {
                    books.Add(b);
                }
            }

            return books;
        }

        public List<Book> FindByAuthorAndName(string author, string name)
        {
            List<Book> books = new List<Book>();
            author = author.ToLower();
            name = name.ToLower();
            foreach(Book b in _listBook)
            {
                if(b.Author.ToLower().Equals(author) && b.Name.ToLower().Equals(name))
                {
                    books.Add(b);
                }
            }

            return books;
        }

        public List<Book> FindByStudentId(int id)
        {
            List<Book> books = new List<Book>();
            foreach (Book b in _listBook)
            {
                if (b.StudentId == id)
                {
                    books.Add(b);
                }
            }

            return books;
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 9999);
            while (this.FindById(id) != null)
            {
                id = rnd.Next(1, 9999);
            }
            return id;
        }

        public void RemoveById(int id)
        {
            _listBook.Remove(this.FindById(id));
        }

        public void RemoveByStudentId(int id)
        {
            List<Book> list = this.FindByStudentId(id);

            foreach(Book b in list)
            {
                _listBook.Remove(b);
            }
        }

        public void AddBook(Book book)
        {
            book.Id = this.NewId();
            _listBook.Add(book);
        }

        public void EditBook(Book book)
        {
            int i = _listBook.IndexOf(this.FindById(book.Id));
            _listBook[i] = book;
        }

        public int GetCount()
        {
            return _listBook.Count();
        }

        public void ClearList()
        {
            _listBook.Clear();
        }

        public List<Book> GetList()
        {
            List<Book> listBook = new List<Book>();

            foreach(Book b in _listBook)
            {
                listBook.Add(b);
            }

            return listBook;
        }

        public void SetList(List<Book> listBook)
        {
            _listBook = listBook;
        }
    }
}
