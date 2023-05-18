using cursuri_studenti.book.service;
using cursuri_studenti.book.model;
using cursuri_studenti.student.model;
using cursuri_studenti.student.service;
using cursuri_studenti.course.model;
using cursuri_studenti.course.service;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.enrolment.service;
using cursuri_studenti.enrolment.model;

namespace cursuri_studenti.view
{
    internal class ViewStudent
    {
        private BookService _bookService;
        private CourseService _courseService;
        private Student _student;
        private EnrolmentService _enrolmentService;
        
        public ViewStudent(Student student)
        {
            _bookService = new BookService();
            _courseService = new CourseService();
            _enrolmentService = new EnrolmentService();
            _student = student;

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine($"Bine ai venit {_student.Name} !\n");

            bool running = true;
            this.Main(running);
        }

        // Tabs

        public void Main(bool _running)
        {
            while (_running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Scrieti numele paginii in care doriti sa lucrati :");
                Console.WriteLine("Book - Pagina dedicata cartilor.");
                Console.WriteLine("Course - Pagina dedicata cursurilor.");
                Console.WriteLine("\nOrice alta tasta pentru a inchide programul.\n");

                string choice = Console.ReadLine();
                Console.WriteLine();

                bool running = true;
                switch (choice.ToLower())
                {
                    case "book":
                        this.Books(running);
                        break;
                    case "course":
                        this.Courses(running);
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        public void Books(bool _running)
        {
            while (_running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Apasati tasta :\n");
                Console.WriteLine("1 - Vezi cartile tale");
                Console.WriteLine("2 - Pentru a adauga o carte.");
                Console.WriteLine("3 - Pentru a sterge o carte.");
                Console.WriteLine("4 - Pentru a edita o carte.");
                Console.WriteLine("\nOrice alta tasta pentru a inchide pagina.\n");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "1":
                        this.DisplayYourBooks();
                        break;
                    case "2":
                        this.AddBook();
                        break;
                    case "3":
                        this.RemoveBook();
                        break;
                    case "4":
                        this.EditBook();
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        public void Courses(bool _running)
        {
            while (_running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Apasati tasta :\n");
                Console.WriteLine("1 - Vezi cursurile tale.");
                Console.WriteLine("2 - Vezi toate cursurile disponibile.");
                Console.WriteLine("3 - Inscriete la un curs.");
                Console.WriteLine("4 - Iesi dintr-un curs.");
                Console.WriteLine("\nOrice alta tasta pentru a inchide pagina.\n");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "1":
                        this.DisplayYourCourses();
                        break;
                    case "2":
                        this.DisplayAvailableCourses();
                        break;
                    case "3":
                        this.SubscribeToCourse();
                        break;
                    case "4":
                        this.UnsubscribeFromCourse();
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        // Metode

        // Book

        public void DisplayYourBooks()
        {
            List<Book> books = _bookService.FindByStudentId(_student.Id);
          
            foreach(Book b in books)
            {
                Console.WriteLine(b.DescriptionStudent());
            }
        }

        public void AddBook()
        {
            Console.Write("Introduceti numele autorului : ");
            string author = Console.ReadLine();
            Console.Write("Introduceti numele cartii : ");
            string name = Console.ReadLine();

            List<Book> books = _bookService.FindByAuthorAndName(author, name);
            for (int i = 0; i < books.Count(); i++)
            {
                Book b = books[i];
                if (b.StudentId == _student.Id)
                {
                    Console.WriteLine("\nDeja detineti aceasta carte!\n");
                    return;
                }
            }
            Book book = new Book(1, _student.Id, author, name);
            _bookService.AddBook(book);
            _bookService.SaveList();
            Console.WriteLine("\nCartea a fost adaugata!\n");
        }

        public void RemoveBook()
        {
            Console.Write("Introduceti numele autorului cartii pe care doriti sa o stergeti : ");
            string author = Console.ReadLine();
            Console.Write("Introduceti numele cartii pe care doriti sa o stergeti : ");
            string name = Console.ReadLine();

            List<Book> books = _bookService.FindByAuthorAndName(author, name);
            for (int i = 0; i < books.Count(); i++)
            {
                Book b = books[i];
                if (b.StudentId == _student.Id)
                {
                    _bookService.RemoveById(b.Id);
                    _bookService.SaveList();

                    Console.WriteLine("\nCartea a fost stearsa cu succes!\n");
                    return;
                }
            }
            Console.WriteLine("\nNu detineti aceasta carte!\n");
        }

        public void EditBook()
        {
            Console.Write("Introduceti numele autorului cartii pe care doriti sa o editati : ");
            string author = Console.ReadLine();
            Console.Write("Introduceti numele cartii pe care doriti sa o editati : ");
            string name = Console.ReadLine();

            List<Book> books = _bookService.FindByAuthorAndName(author, name);
            for (int i = 0; i < books.Count(); i++)
            {
                Book b = books[i];
                if (b.StudentId == _student.Id)
                {
                    Console.WriteLine("\nScrieti ce doriti sa editati :");
                    Console.WriteLine("author - doar autorul cartii");
                    Console.WriteLine("name - doar numele cartii");
                    Console.WriteLine("all - intreaga carte");
                    Console.WriteLine("Orice altceva pentru a te opri din editare.\n");
                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    bool edited = true;
                    switch (choice.ToLower())
                    {
                        case "author":
                            Console.WriteLine("Introduceti numele nou al autorului cartii :");
                            author = Console.ReadLine();
                            Console.WriteLine();

                            b.Author = author;

                            _bookService.EditBook(b);
                            break;

                        case "name":
                            Console.WriteLine("Introduceti numele nou al cartii :");
                            name = Console.ReadLine();
                            Console.WriteLine();

                            b.Name = name;

                            _bookService.EditBook(b);
                            break;

                        case "all":
                            Console.WriteLine("Introduceti numele nou al autorului cartii :");
                            author = Console.ReadLine();
                            Console.WriteLine("Introduceti numele nou al cartii :");
                            name = Console.ReadLine();
                            Console.WriteLine();

                            b.Author = author;
                            b.Name = name;

                            _bookService.EditBook(b);
                            break;

                        default:
                            edited = false;
                            break;
                    }
                    if (edited)
                    {
                        Console.WriteLine("Cartea a fost editata cu succes!\n");
                        _bookService.SaveList();
                    }
                    else
                    {
                        Console.WriteLine("Cartea nu a fost editata.\n");
                    }
                    return;
                }
            }
            Console.WriteLine("\nNu detineti aceasta carte!\n");
        }

        // Course

        public void DisplayYourCourses()
        {
            List<Enrolment> enrolments = _enrolmentService.FindByStudentId(_student.Id);
            List<Course> courses = new List<Course>();
            
            foreach(Enrolment e in enrolments)
            {
                courses.Add(_courseService.FindById(e.CourseId));
            }

            if (courses.Count() == 0)
            {
                Console.WriteLine("Nu sunteti inscris la niciun curs!\n");
            }
            else
            {
                foreach (Course c in courses)
                {
                    Console.WriteLine(c.DescriptionStudent());
                }
            }
        }

        public void DisplayAvailableCourses()
        {
            List<Course> courses = _courseService.GetList();
            List<Enrolment> enrolments = _enrolmentService.FindByStudentId(_student.Id);

            foreach(Enrolment e in enrolments)
            {
                courses.Remove(_courseService.FindById(e.CourseId));
            }

            foreach(Course c in courses)
            {
                Console.WriteLine(c.DescriptionStudent() + "\n");
            }
        }

        public void SubscribeToCourse()
        {
            Console.Write("Introduceti numele cursului la care doriti sa va inscrieti : ");
            string name = Console.ReadLine();

            Course course = _courseService.FindByName(name);           
            if(course == null)
            {
                Console.WriteLine("\nAcest curs nu exista!");
                return;
            }

            Enrolment enrolment = _enrolmentService.FindByStudentAndCourseId(course.Id, _student.Id);
            if (enrolment != null)
            {
                Console.WriteLine("\nSunteti deja este abonat la acel curs!\n");
            }
            else
            {
                enrolment = new Enrolment(0, _student.Id, course.Id);
                _enrolmentService.AddEnrolment(enrolment);
                _enrolmentService.SaveList();
                Console.WriteLine("\nV-ati abonat la curs cu succes!\n");
            }
        }

        public void UnsubscribeFromCourse()
        {
            Console.WriteLine("Introduceti numele cursului :");
            string courseName = Console.ReadLine();
            Console.WriteLine();

            Course course = _courseService.FindByName(courseName);
            if (course == null)
            {
                Console.WriteLine("Nu exista niciun curs cu acest nume!\n");
                return;
            }

            Enrolment enrolment = _enrolmentService.FindByStudentAndCourseId(course.Id, _student.Id);
            if (enrolment == null)
            {
                Console.WriteLine("Nu sunteti abonat la acest curs!\n");
            }
            else
            {
                _enrolmentService.RemoveById(enrolment.Id);
                _enrolmentService.SaveList();
                Console.WriteLine("V-ati dezabonat de la curs cu succes!\n");
            }
        }
    }
}
