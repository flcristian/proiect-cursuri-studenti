using cursuri_studenti.admin.service;
using cursuri_studenti.professor.service;
using cursuri_studenti.student.service;
using cursuri_studenti.admin.model;
using cursuri_studenti.view;
using cursuri_studenti.professor.model;
using cursuri_studenti.student.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursuri_studenti.view
{
    internal class ViewLogin
    {
        private AdminService _adminService;
        private StudentService _studentService;
        private ProfessorService _professorService;

        public ViewLogin()
        {
            _adminService = new AdminService();
            _studentService = new StudentService();
            _professorService = new ProfessorService();

            bool running = true;
            while (running)
            {
                _adminService.ReadList();
                _studentService.ReadList();
                _professorService.ReadList();

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Introduceti ce doriti sa faceti :");
                Console.WriteLine("1 - Pentru a te loga.");
                Console.WriteLine("2 - Pentru a te inregistra.");
                Console.WriteLine("\nOrice alta tasta pentru a inchide programul.\n");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "1":
                        this.Login();
                        break;
                    case "2":
                        this.Register();
                        break;
                    default:
                        running = false;
                        break;
                }
            }
            
        }

        // Metode

        public void Login()
        {
            Console.Write("Introduceti email-ul : ");
            string email = Console.ReadLine();
            Console.Write("Introduceti parola : ");
            string password = Console.ReadLine();
            Console.WriteLine();

            Admin admin = _adminService.FindByEmailAndPassword(email, password);
            if (admin != null)
            {
                ViewAdmin viewAdmin = new ViewAdmin(admin);
                return;
            }

            Student student = _studentService.FindByEmailAndPassword(email, password);
            if (student != null)
            {
                if (student.Locked)
                {
                    Console.WriteLine("Acestui cont ii este interzis accesul!\n");
                    return;
                }
                ViewStudent viewStudent = new ViewStudent(student);
                return;
            }    

            Console.WriteLine("Email-ul sau parola sunt gresite!\n");
        }

        public void Register()
        {
            string age = "", name = "", email = "", password = "";
            bool hasEmail = false;

            while (!hasEmail)
            {
                Console.WriteLine("Introduceti email-ul dvs. :");
                Console.WriteLine("stop - Pentru a anula.\n");
                email = Console.ReadLine();
                Console.WriteLine();
                switch (email.ToLower())
                {
                    case "stop":
                        Console.WriteLine("Ati anulat crearea contului.\n");
                        return;
                    default:
                        Admin admin = _adminService.FindByEmail(email);
                        if(admin != null)
                        {
                            Console.WriteLine("Email-ul este deja folosit!\n");
                            break;
                        }

                        Student student = _studentService.FindByEmail(email);
                        if(student != null)
                        {
                            Console.WriteLine("Email-ul este deja folosit!\n");
                            break;
                        }

                        Professor professor = _professorService.FindByEmail(email);
                        if(professor != null)
                        {
                            Console.WriteLine("Email-ul este deja folosit!\n");
                            break;
                        }

                        hasEmail = true;
                        break;
                }
            }

            Console.WriteLine("Introduceti numele dvs. :");
            name = Console.ReadLine();
            Console.WriteLine("\nIntroduceti varsta dvs. :");
            age = Console.ReadLine();
            Console.WriteLine("\nIntroduceti parola dvs. :");
            password = Console.ReadLine();
            Console.WriteLine();

            Student newStudent = new Student(0, Int32.Parse(age), name, email, password);
            _studentService.AddStudent(newStudent);
            _studentService.SaveList();
            Console.WriteLine("Contul a fost creat cu succes!\n");
        }
    }
}
