using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.course.model;

namespace cursuri_studenti.course.service
{
    public class CourseService
    {
        List<Course> _listCourse;

        public CourseService()
        {
            _listCourse = new List<Course>();

            this.ReadList();
        }

        // Metode

        public void ReadList()
        {
            _listCourse = new List<Course>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\courses.txt");

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Course c = new Course(text);

                _listCourse.Add(c);
            }

            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\courses.txt");

            foreach (Course c in _listCourse)
            {
                sw.WriteLine(c.Id + "/" + c.ProfessorId + "/" + c.Name);
            }

            sw.Close();
        }

        public void Afisare()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (Course c in _listCourse)
            {
                Console.WriteLine(c.Description());
            }
        }

        public void AfisareStudent()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (Course c in _listCourse)
            {
                Console.WriteLine(c.DescriptionStudent());
            }
        }

        public Course FindById(int id)
        {
            foreach(Course c in _listCourse)
            {
                if(c.Id == id)
                {
                    return c;
                }
            }

            return null;
        }

        public Course FindByName(string name)
        {
            foreach(Course c in _listCourse)
            {
                if (c.Name.Equals(name))
                {
                    return c;
                }
            }

            return null;
        }

        public List<Course> FindByProfessorId(int id)
        {
            List<Course> courses = new List<Course>();
            
            foreach(Course c in _listCourse)
            {
                if(c.ProfessorId == id)
                {
                    courses.Add(c);
                }
            }

            return courses;
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1,9999);
            while(this.FindById(id) != null)
            {
                id = rnd.Next(1, 9999);
            }
            return id;
        }

        public void RemoveById(int id)
        {
            _listCourse.Remove(this.FindById(id));
        }

        public void RemoveByProfessorId(int id)
        {
            List<Course> toRemove = this.FindByProfessorId(id);

            foreach(Course c in toRemove)
            {
                _listCourse.Remove(c);
            }
        }

        public void AddCourse(Course course)
        {
            course.Id = this.NewId();
            _listCourse.Add(course);
        }

        public void EditCourse(Course course)
        {
            int i = _listCourse.IndexOf(this.FindById(course.Id));
            _listCourse[i] = course;
        }

        public int GetCount()
        {
            return _listCourse.Count();
        }

        public void ClearList()
        {
            _listCourse.Clear();
        }

        public List<Course> GetList()
        {
            List<Course> listCourse = new List<Course>();

            foreach(Course c in _listCourse)
            {
                listCourse.Add(c);
            }

            return listCourse;
        }

        public void SetList(List<Course> listCourse)
        {
            _listCourse = listCourse;
        }
    }
}
