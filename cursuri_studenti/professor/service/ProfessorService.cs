using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.professor.model;

namespace cursuri_studenti.professor.service
{
    public class ProfessorService
    {
        List<Professor> _listProfessor;
        public ProfessorService()
        {
            _listProfessor = new List<Professor>();

            this.ReadList();
        }

        public ProfessorService(List<Professor> listProfessor)
        {
            _listProfessor = listProfessor;
        }

        // Metode

        public void ReadList()
        {
            _listProfessor = new List<Professor>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\professors.txt");

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Professor p = new Professor(text);

                _listProfessor.Add(p);
            }

            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\professors.txt");

            foreach (Professor p in _listProfessor)
            {
                sw.WriteLine(p.Id + "/" + p.Name + "/" + p.Email + "/" + p.Password);
            }

            sw.Close();
        }

        public void Afisare()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (Professor p in _listProfessor)
            {
                Console.WriteLine(p.Description());
            }
        }

        public Professor FindById(int id)
        {
            foreach(Professor p in _listProfessor)
            {
                if(p.Id == id)
                {
                    return p;
                }
            }

            return null;
        }

        public Professor FindByName(string name)
        {
            foreach(Professor p in _listProfessor)
            {
                if (p.Name.Equals(name))
                {
                    return p;
                }
            }

            return null;
        }

        public Professor FindByEmail(string email)
        {
            foreach(Professor p in _listProfessor)
            {
                if (p.Email.Equals(email))
                {
                    return p;
                }
            }

            return null;
        }

        public Professor FindByEmailAndPassword(string email, string password)
        {
            foreach(Professor p in _listProfessor)
            {
                if(email.Equals(p.Email) && password.Equals(p.Password))
                {
                    return p;
                }
            }

            return null;
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

        public bool RemoveById(int id)
        {
            Professor professor = this.FindById(id);
            if(professor != null)
            {
                _listProfessor.Remove(this.FindById(id));
                return true;
            }
            return false;
        }

        public bool AddProfessor(Professor professor)
        {
            if (this.FindByEmail(professor.Email) == null)
            {
                professor.Id = this.NewId();
                _listProfessor.Add(professor);
                return true;
            }
            return false;
        }

        public int GetCount()
        {
            return _listProfessor.Count();
        }

        public void ClearList()
        {
            _listProfessor.Clear();
        }

        public List<Professor> GetList()
        {
            List<Professor> professors = new List<Professor>();

            foreach(Professor p in _listProfessor)
            {
                professors.Add(p);
            }

            return professors;
        }

        public void SetList(List<Professor> listProfessor)
        {
            _listProfessor = listProfessor;
        }
    }
}
