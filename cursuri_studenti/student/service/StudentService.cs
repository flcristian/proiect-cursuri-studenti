using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.book.model;
using cursuri_studenti.student.model;

namespace cursuri_studenti.student.service
{
    public class StudentService
    {
        private List<Student> _listStudent;

        public StudentService()
        {
            _listStudent = new List<Student>();

            this.ReadList();
        }

        public StudentService(List<Student> listStudent)
        {
            _listStudent = listStudent;
        }

        // Metode

        public void ReadList()
        {
            _listStudent = new List<Student>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\students.txt");

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Student s = new Student(text);

                _listStudent.Add(s);
            }

            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\students.txt");

            foreach (Student s in _listStudent)
            {
                sw.WriteLine($"{s.Id}/{s.Age}/{s.Name}/{s.Email}/{s.Password}/{s.Locked}");
            }

            sw.Close();
        }

        public void Afisare()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (Student s in _listStudent)
            {
                Console.WriteLine(s.Description());
            }
        }

        public Student FindById(int id)
        {
            foreach(Student s in _listStudent)
            {
                if(s.Id == id)
                {
                    return s;
                }
            }

            return null;
        }

        public Student FindByName(string name)
        {
            foreach (Student s in _listStudent)
            {
                if (s.Name.Equals(name))
                {
                    return s;
                }
            }

            return null;
        }

        public Student FindByEmail(string email)
        {
            foreach(Student s in _listStudent)
            {
                if (s.Email.Equals(email))
                {
                    return s;
                }
            }

            return null;
        }

        public Student FindByEmailAndPassword(string email, string password)
        {
            foreach(Student s in _listStudent)
            {
                if(email.Equals(s.Email) && password.Equals(s.Password))
                {
                    return s;
                }
            }

            return null;
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 9999);
            while(this.FindById(id) != null)
            {
                id = rnd.Next(1, 9999);
            }
            return id;
        }

        public bool RemoveById(int id)
        {
            Student student = this.FindById(id);
            if (student != null)
            {
                _listStudent.Remove(this.FindById(id));
                return true;
            }
            return false;
        }

        public bool AddStudent(Student student)
        {
            if(this.FindByEmail(student.Email) == null)
            {
                student.Id = this.NewId();
                _listStudent.Add(student);
                return true;
            }
            return false;
        }

        public int IsBanned(int id)
        {
            Student student = this.FindById(id);
            if(student != null)
            {
                if (this.FindById(id).Locked)
                {
                    return 1;
                }
                return 0;
            }
            return -1;
        }

        public void Ban(int id)
        {
            this.FindById(id).Locked = true;
        }

        public void Unban(int id)
        {
            this.FindById(id).Locked = false;
        }
        
        public int GetCount()
        {
            return _listStudent.Count();
        }

        public void ClearList()
        {
            _listStudent.Clear();
        }

        public List<Student> GetList()
        {
            List<Student> students = new List<Student>();

            foreach (Student s in _listStudent)
            {
                students.Add(s);
            }

            return students;
        }

        public void SetList(List<Student> listStudent)
        {
            _listStudent = listStudent;
        }
    }
}
