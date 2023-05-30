using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.admin.model;
using cursuri_studenti.book.model;
using cursuri_studenti.book.service;
using cursuri_studenti.course.model;
using cursuri_studenti.course.service;
using cursuri_studenti.enrolment.model;
using cursuri_studenti.enrolment.service;
using cursuri_studenti.student.model;
using cursuri_studenti.student.service;
using cursuri_studenti.professor.model;
using cursuri_studenti.professor.service;

namespace cursuri_studenti.view
{
    internal class ViewAdmin
    {
        private Admin _admin;
        private StudentService _studentService;
        private BookService _bookService;
        private CourseService _courseService;
        private EnrolmentService _enrolmentService;
        private ProfessorService _professorService;

        public ViewAdmin(Admin admin)
        {
            _studentService = new StudentService();
            _bookService = new BookService();
            _courseService = new CourseService();
            _enrolmentService = new EnrolmentService();
            _professorService = new ProfessorService();
            _admin = admin;

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine($"Bine ai venit {_admin.Name} !\n");

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
                Console.WriteLine("1 - Vezi lista de studenti.");
                Console.WriteLine("2 - Pagina dedicata studentilor.");
                Console.WriteLine("3 - Pagina dedicata cartilor.");
                Console.WriteLine("4 - Pagina dedicata cursurilor.");
                Console.WriteLine("\nOrice alta tasta pentru a inchide programul.\n");

                string choice = Console.ReadLine();
                Console.WriteLine();

                bool running = true;
                switch (choice.ToLower())
                {
                    case "1":
                        this.DisplayStudentEmails();
                        break;
                    case "2":
                        this.Students(running);
                        break;
                    case "3":
                        this.Books(running);
                        break;
                    case "4":
                        this.Courses(running);
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        public void Students(bool _running)
        {
            while (_running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Apasati tasta :\n");
                Console.WriteLine("1 - Vezi lista de studenti.");
                Console.WriteLine("2 - Vezi lista de cursuri a unui student.");
                Console.WriteLine("3 - Aboneaza un student la un curs.");
                Console.WriteLine("4 - Dezaboneaza un student de la un curs.");
                Console.WriteLine("5 - Interzice accesul unui student.");
                Console.WriteLine("6 - Pentru a permite accesul unui student.");
                Console.WriteLine("\nOrice alta tasta pentru a inchide pagina.\n");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "1":
                        this.DisplayStudentEmails();
                        break;
                    case "2":
                        this.DisplayStudentCourses();
                        break;
                    case "3":
                        this.SubscribeStudentToCourse();
                        break;
                    case "4":
                        this.UnsubscribeStudentFromCourse();
                        break;
                    case "5":
                        this.BanStudent();
                        break;
                    case "6":
                        this.UnbanStudent();
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        public void Books(bool _running)
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine("Scrieti email-ul studentului caruia doriti sa-i modificati cartile :\n");
            string email = Console.ReadLine();
            Console.WriteLine();

            Student student = _studentService.FindByEmail(email);
            if (student == null)
            {
                Console.WriteLine($"Nu a fost gasit un student cu email-ul {email}!\n");
            }
            else
            {
                Console.WriteLine($"In momentul de fata modifici cartile lui {student.Name}!\n");
                while (_running)
                {
                    
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                    Console.WriteLine("Apasati tasta :\n");
                    Console.WriteLine("1 - Vezi cartile studentului.");
                    Console.WriteLine("2 - Pentru a adauga o carte");
                    Console.WriteLine("3 - Pentru a sterge o carte");
                    Console.WriteLine("4 - Pentru a edita o carte.");
                    Console.WriteLine("\nOrice alta tasta pentru a inchide pagina.\n");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice.ToLower())
                    {
                        case "1":
                            this.DisplayBooks(student);
                            break;
                        case "2":
                            this.AddBook(student);
                            break;
                        case "3":
                            this.RemoveBook(student);
                            break;
                        case "4":
                            this.EditBook(student);
                            break;
                        default:
                            _running = false;
                            break;
                    }
                }
            }
        }

        public void Courses(bool _running)
        {
            while (_running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Apasati tasta :\n");
                Console.WriteLine("1 - Vezi cursurile.");
                Console.WriteLine("2 - Vezi cursurile sortate dupa popularitate.");
                Console.WriteLine("3 - Adauga un curs.");
                Console.WriteLine("4 - Sterge un curs.");
                Console.WriteLine("5 - Editeaza un curs.");
                Console.WriteLine("\nOrice alta tasta pentru a inchide pagina.\n");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "1":
                        this.DisplayCourses();
                        break;
                    case "2":
                        this.DisplayCoursesSortedByPopularity();
                        break;
                    case "3":
                        this.AddCourse();
                        break;
                    case "4":
                        this.RemoveCourse();
                        break;
                    case "5":
                        this.EditCourse();
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        // Students

        public void DisplayStudentEmails()
        {
            List<Student> students = _studentService.GetList();

            foreach (Student s in students)
            {
                Console.WriteLine(s.NameAndEmail());
            }

            Console.WriteLine();
        }

        public void DisplayStudentCourses()
        {
            Console.WriteLine("Introduceti email-ul studentului :");
            string email = Console.ReadLine();
            Console.WriteLine();

            Student student = _studentService.FindByEmail(email);
            if(student == null)
            {
                Console.WriteLine("Studentul nu exista!\n");
                return;
            }

            List<Enrolment> enrolments = _enrolmentService.FindByStudentId(student.Id);
            List<Course> courses = new List<Course>();

            foreach(Enrolment e in enrolments)
            {
                courses.Add(_courseService.FindById(e.CourseId));
            }

            if(courses.Count() == 0)
            {
                Console.WriteLine("Studentul nu este inscris la niciun curs!\n");
            }
            else
            {
                foreach(Course c in courses)
                {
                    Console.WriteLine(c.DescriptionStudent());
                }
            }
        }

        public void BanStudent()
        {
            Console.WriteLine("Introdu email-ul studentului :\n");
            string email = Console.ReadLine();
            Console.WriteLine();

            Student student = _studentService.FindByEmail(email);
            if (_studentService.IsBanned(student.Id) == 1)
            {
                Console.WriteLine("Acestui student ii este deja interzis accesul!\n");
            }
            else
            {
                _studentService.Ban(student.Id);
                _studentService.SaveList();
                Console.WriteLine("Ati interzis accesul studentului cu succes!\n");
            }
        }

        public void UnbanStudent()
        {
            Console.WriteLine("Introdu email-ul studentului :\n");
            string email = Console.ReadLine();
            Console.WriteLine();

            Student student = _studentService.FindByEmail(email);
            if (_studentService.IsBanned(student.Id) == 0)
            {
                Console.WriteLine("Acestui student nu ii este interzis accesul!\n");
            }
            else
            {
                _studentService.Unban(student.Id);
                _studentService.SaveList();
                Console.WriteLine("Ati permis accesul studentului cu succes!\n");
            }
        }

        public void SubscribeStudentToCourse()
        {
            Console.WriteLine("Introduceti email-ul studentului :");
            string email = Console.ReadLine();
            Console.WriteLine();

            Student student = _studentService.FindByEmail(email);
            if(student == null)
            {
                Console.WriteLine("Nu exista niciun student cu acest email!\n");
                return;
            }
            Console.WriteLine("Introduceti numele cursului :");
            string courseName = Console.ReadLine();
            Console.WriteLine();

            Course course = _courseService.FindByName(courseName);
            if(course == null)
            {
                Console.WriteLine("Nu exista niciun curs cu acest nume!\n");
                return;
            }

            Enrolment enrolment = _enrolmentService.FindByStudentAndCourseId(course.Id, student.Id);
            if(enrolment != null)
            {
                Console.WriteLine("Studentul deja este abonat la acel curs!\n");
            }
            else
            {
                enrolment = new Enrolment(0, student.Id, course.Id);
                _enrolmentService.AddEnrolment(enrolment);
                _enrolmentService.SaveList();
                Console.WriteLine("Ati abonat studentul la curs cu succes!\n");
            }
        }

        public void UnsubscribeStudentFromCourse()
        {
            Console.WriteLine("Introduceti email-ul studentului :");
            string email = Console.ReadLine();
            Console.WriteLine();

            Student student = _studentService.FindByEmail(email);
            if (student == null)
            {
                Console.WriteLine("Nu exista niciun student cu acest email!\n");
                return;
            }
            Console.WriteLine("Introduceti numele cursului :");
            string courseName = Console.ReadLine();
            Console.WriteLine();

            Course course = _courseService.FindByName(courseName);
            if (course == null)
            {
                Console.WriteLine("Nu exista niciun curs cu acest nume!\n");
                return;
            }

            Enrolment enrolment = _enrolmentService.FindByStudentAndCourseId(course.Id, student.Id);
            if (enrolment == null)
            {
                Console.WriteLine("Studentul nu este abonat la acel curs!\n");
            }
            else
            {
                _enrolmentService.RemoveById(enrolment.Id);
                _enrolmentService.SaveList();
                Console.WriteLine("Ati dezabonat studentul de la curs cu succes!\n");
            }
        }

        // Books

        public void DisplayBooks(Student student)
        {
            List<Book> books = _bookService.FindByStudentId(student.Id);

            foreach (Book b in books)
            {
                Console.WriteLine(b.Description());
            }
        }

        public void AddBook(Student student)
        {
            Console.Write("Introduceti numele autorului : ");
            string author = Console.ReadLine();
            Console.Write("Introduceti numele cartii : ");
            string name = Console.ReadLine();

            List<Book> books = _bookService.FindByAuthorAndName(author, name);
            for (int i = 0; i < books.Count(); i++)
            {
                Book b = books[i];
                if (b.StudentId == student.Id)
                {
                    Console.WriteLine("\nStudentul deja detine aceasta carte!\n");
                    return;
                }
            }
            Book book = new Book(1, student.Id, author, name);
            _bookService.AddBook(book);
            _bookService.SaveList();
            Console.WriteLine("\nCartea a fost adaugata!\n");
        }

        public void RemoveBook(Student student)
        {
            Console.Write("Introduceti numele autorului cartii pe care doriti sa o stergeti : ");
            string author = Console.ReadLine();
            Console.Write("Introduceti numele cartii pe care doriti sa o stergeti : ");
            string name = Console.ReadLine();

            List<Book> books = _bookService.FindByAuthorAndName(author, name);
            for(int i = 0; i < books.Count(); i++)
            {
                Book b = books[i];
                if(b.StudentId == student.Id)
                {
                    _bookService.RemoveById(b.Id);
                    _bookService.SaveList();

                    Console.WriteLine("\nCartea a fost stearsa cu succes!\n");
                    return;
                }                
            }
            Console.WriteLine("\nStudentul nu detine aceasta carte!\n");
        }

        public void EditBook(Student student)
        {
            Console.Write("Introduceti numele autorului cartii pe care doriti sa o editati : ");
            string author = Console.ReadLine();
            Console.Write("Introduceti numele cartii pe care doriti sa o editati : ");
            string name = Console.ReadLine();

            List<Book> books = _bookService.FindByAuthorAndName(author, name);
            for (int i = 0; i < books.Count(); i++)
            {
                Book b = books[i];
                if (b.StudentId == student.Id)
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
                        _bookService.SaveList();
                        Console.WriteLine("Cartea a fost editata cu succes!\n");
                    }
                    else
                    {
                        Console.WriteLine("Cartea nu a fost editata.\n");
                    }
                    return;
                }                
            }
            Console.WriteLine("\nStudentul nu detine aceasta carte!\n");
        }

        // Courses

        public void DisplayCourses()
        {
            List<Course> courses = _courseService.GetList();

            for (int i = 0; i < courses.Count(); i++)
            {
                Course c = courses[i];
                Professor p = _professorService.FindById(c.ProfessorId);

                Console.WriteLine(p.Name + " : " + c.Name + " - " + _enrolmentService.GetFrequencyOfCourseById(c.Id));
            }
            Console.WriteLine();
        }

        public void DisplayCoursesSortedByPopularity()
        {
            List<int> courseIds = _enrolmentService.CourseIdsSortedByPopularity();
            List<Course> courses = new List<Course>();

            foreach (int id in courseIds)
            {
                courses.Add(_courseService.FindById(id));
            }

            for(int i = 0; i < courses.Count(); i++)
            {
                Course c = courses[i];
                Professor p = _professorService.FindById(c.ProfessorId);

                Console.WriteLine(p.Name + " : " + c.Name + " - " + _enrolmentService.GetFrequencyOfCourseById(c.Id));
            }
            Console.WriteLine();
        }

        public void AddCourse()
        {
            Console.WriteLine("Introduceti numele profesorului care va detine cursul :\n");
            string professorName = Console.ReadLine();
            Professor professor = _professorService.FindByName(professorName);

            if(professor == null)
            {
                Console.WriteLine("\nAcest profesor nu exista!\n");
                return;
            }

            Console.WriteLine("\nIntroduceti numele cursului pe care doriti sa-l creati :\n");
            string courseName = Console.ReadLine();
            Console.WriteLine();

            if(_courseService.FindByName(courseName) != null)
            {
                Console.WriteLine("\nAcest curs deja exista!\n");
            }
            else
            {
                Course course = new Course(0, professor.Id, courseName);
                _courseService.AddCourse(course);
                _courseService.SaveList();
                Console.WriteLine("\nAti creat cursul cu succes!\n");
            }            
        }

        public void RemoveCourse()
        {
            Console.WriteLine("Introduceti numele cursului pe care doriti sa-l stergeti :\n");
            string name = Console.ReadLine();
            Console.WriteLine();

            Course course = _courseService.FindByName(name);
            if(course == null)
            {
                Console.WriteLine("Nu exista niciun curs cu aceasta denumire!\n");
            }
            else
            {
                _courseService.RemoveById(course.Id);
                _courseService.SaveList();
                Console.WriteLine("Cursul a fost sters cu succes!\n");
            }
        }

        public void EditCourse()
        {
            Console.WriteLine("Introduceti numele cursului pe care doriti sa-l editati :\n");
            string name = Console.ReadLine();
            Console.WriteLine();

            Course course = _courseService.FindByName(name);
            if (course == null)
            {
                Console.WriteLine("Nu exista niciun curs cu aceasta denumire!\n");
            }
            else
            {
                Console.WriteLine("Scrieti ce doriti sa editati :\n");
                Console.WriteLine("prof - doar profesorul care detine cursul.");
                Console.WriteLine("name - doar numele cursului.");
                Console.WriteLine("all - intreg cursul.");
                Console.WriteLine("Orice altceva pentru a te opri din editare.\n");
                string choice = Console.ReadLine();
                Console.WriteLine();

                string prof;
                Professor professor;

                bool edited = true;
                switch (choice.ToLower())
                {
                    case "prof":
                        Console.WriteLine("Introduceti numele profesorului care doriti sa detina cursul :");
                        prof = Console.ReadLine();
                        Console.WriteLine();

                        professor = _professorService.FindByName(prof);
                        if(professor == null)
                        {
                            Console.WriteLine("Acest profesor nu exista!\n");
                            edited = false;
                            return;
                        }

                        course.ProfessorId = professor.Id;
                        _courseService.EditCourse(course);
                        break;

                    case "name":
                        Console.WriteLine("Introduceti numele nou al cursului :");
                        name = Console.ReadLine();
                        Console.WriteLine();

                        course.Name = name;
                        _courseService.EditCourse(course);
                        break;

                    case "all":
                        Console.WriteLine("Introduceti numele profesorului care doriti sa detina cursul :");
                        prof = Console.ReadLine();

                        professor = _professorService.FindByName(prof);
                        if(professor == null)
                        {
                            Console.WriteLine("\nAcest profesor nu exista!\n");
                            edited = false;
                            return;
                        }

                        Console.WriteLine("Introduceti numele nou al cursului :");
                        name = Console.ReadLine();
                        Console.WriteLine();

                        course.ProfessorId = professor.Id;
                        course.Name = name;
                        _courseService.EditCourse(course);
                        break;

                    default:
                        edited = false;
                        break;
                }
                if (edited)
                {
                    _courseService.SaveList();
                    Console.WriteLine("Cursul a fost editat cu succes!\n");
                }
                else
                {
                    Console.WriteLine("Cursul nu a fost editat.\n");
                }
                return;
            }
        }
    }
}
