using cursuri_studenti.book.model;
using cursuri_studenti.book.service;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.IO;
using System.Xml.Linq;

namespace tests_cursuri_studenti.Tests
{
    public class TestBook
    {
        // Testing Book Service

        [Fact]
        public void ReadList()
        {
            BookService bookService = new BookService();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\books.txt");
            
            int count = 0;
            while (!sr.EndOfStream)
            {   
                sr.ReadLine();
                count++;
            }
            sr.Close();

            bookService.ReadList();
            Assert.Equal(count, bookService.GetCount());
        }

        [Fact]
        public void SaveList()
        {
            BookService bookService = new BookService();

            bookService.SaveList();

            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\books.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            Assert.Equal(count, bookService.GetCount());
        }

        [Fact]
        public void FindById()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Assert.NotNull(bookService.FindById(listBook[0].Id));
        }

        [Fact]
        public void FindByName_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            string name = listBook[0].Name;
            int count = 0;
            foreach(Book b in listBook)
            {
                if(b.Name.Equals(name))
                {
                    count++;
                }
            }

            Assert.Equal(count, bookService.FindByName(name).Count());
        }

        [Fact]
        public void FindByName_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Assert.NotEmpty(bookService.FindByName(listBook[0].Name));
        }

        [Fact]
        public void FindByAuthor_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            string author = listBook[0].Author;
            int count = 0;
            foreach (Book b in listBook)
            {
                if (b.Author.Equals(author))
                {
                    count++;
                }
            }

            Assert.Equal(count, bookService.FindByAuthor(author).Count());
        }

        [Fact]
        public void FindByAuthor_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Assert.NotEmpty(bookService.FindByAuthor(listBook[0].Author));
        }

        [Fact]
        public void FindByAuthorAndName_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            string name = listBook[0].Name, author = listBook[0].Author;
            int count = 0;
            foreach (Book b in listBook)
            {
                if (b.Name.Equals(name) && b.Author.Equals(author))
                {
                    count++;
                }
            }

            Assert.Equal(count, bookService.FindByAuthorAndName(author, name).Count());
        }

        [Fact]
        public void FindByAuthorAndName_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Assert.NotEmpty(bookService.FindByAuthorAndName(listBook[0].Author, listBook[0].Name));
        }

        [Fact]
        public void FindByStudentId_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            int studentId = listBook[0].StudentId, count = 0;
            foreach (Book b in listBook)
            {
                if (b.StudentId == studentId)
                {
                    count++;
                }
            }

            Assert.Equal(count, bookService.FindByStudentId(studentId).Count());
        }

        [Fact]
        public void FindByStudentId_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Assert.NotEmpty(bookService.FindByStudentId(listBook[0].StudentId));
        }

        [Fact]
        public void NewId_1()
        {
            BookService bookService = new BookService();

            Assert.Null(bookService.FindById(bookService.NewId()));
        }

        [Fact]
        public void NewId_2()
        {
            BookService bookService = new BookService();

            Assert.InRange(bookService.NewId(), 1, 9999);
        }

        [Fact]
        public void RemoveById_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            bookService.RemoveById(listBook[0].Id);

            Assert.Null(bookService.FindById(listBook[0].Id));
        }

        [Fact]
        public void RemoveById_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            bookService.RemoveById(listBook[0].Id);

            Assert.Equal(listBook.Count() - 1, bookService.GetCount());
        }

        [Fact]
        public void RemoveByStudentId_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();
            List<Book> removed = bookService.FindByStudentId(listBook[0].StudentId);

            bookService.RemoveByStudentId(listBook[0].StudentId);

            Assert.Equal(listBook.Count() - removed.Count(), bookService.GetCount());
        }

        [Fact]
        public void RemoveByStudentId_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            bookService.RemoveByStudentId(listBook[0].StudentId);

            Assert.Empty(bookService.FindByStudentId(listBook[0].StudentId));
        }

        [Fact]
        public void AddBook_1()
        {
            BookService bookService = new BookService();

            int id = 9876;
            string name = "test98766t";
            Book book = new Book(1, id, name, name);

            bookService.AddBook(book);

            List<Book> listBook = bookService.FindByAuthorAndName(name, name);
            foreach(Book b in listBook)
            {
                if(b.Id == id)
                {
                    book = b;
                    break;
                }
            }

            Assert.NotNull(bookService.FindById(book.Id));
        }

        [Fact]
        public void AddBook_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Book book = new Book(1, 1, "test", "test");
            bookService.AddBook(book);

            Assert.Equal(listBook.Count() + 1, bookService.GetCount());
        }

        [Fact]
        public void EditBook()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Book toEdit = new Book(0,1,"test","test");
            toEdit.Id = listBook[0].Id;
            bookService.EditBook(toEdit);

            Assert.NotEqual(listBook[0], bookService.FindById(toEdit.Id));
        }

        [Fact]
        public void GetCount()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Assert.Equal(listBook.Count(), bookService.GetCount());
        }

        [Fact]
        public void ClearList()
        {
            BookService bookService = new BookService();

            bookService.ClearList();

            Assert.Equal(0, bookService.GetCount());
        }

        [Fact]
        public void GetList_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            bool flag = true;
            foreach(Book b in listBook)
            {
                if(bookService.FindById(b.Id) == null)
                {
                    flag = false;
                    break;
                }
            }

            Assert.True(flag);
        }

        [Fact]
        public void GetList_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = bookService.GetList();

            Assert.Equal(bookService.GetCount(), listBook.Count());
        }

        [Fact]
        public void SetList_1()
        {
            BookService bookService = new BookService();
            List<Book> listBook = new List<Book>();

            bookService.SetList(listBook);

            Assert.Equal(0, bookService.GetCount());
        }

        [Fact]
        public void SetList_2()
        {
            BookService bookService = new BookService();
            List<Book> listBook = new List<Book>();
            Book book = new Book(1, 1, "test", "test");
            listBook.Add(book);

            bookService.SetList(listBook);

            bool flag = true;
            foreach(Book b in listBook)
            {
                if(bookService.FindById(b.Id) == null)
                {
                    flag = false;
                    break;
                }
            }

            Assert.True(flag);
        }
    }
}
