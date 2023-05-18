using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.enrolment.model;
using cursuri_studenti.student.model;

namespace cursuri_studenti.enrolment.service
{
    public class EnrolmentService
    {
        List<Enrolment> _listEnrolment;

        public EnrolmentService()
        {
            _listEnrolment = new List<Enrolment>();

            this.ReadList();
        }

        public EnrolmentService(List<Enrolment> listEnrolment)
        {
            _listEnrolment = listEnrolment;
        }

        // Metode

        public void ReadList()
        {
            _listEnrolment = new List<Enrolment>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\enrolments.txt");

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Enrolment e = new Enrolment(text);

                _listEnrolment.Add(e);
            }

            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\enrolments.txt");

            foreach (Enrolment e in _listEnrolment)
            {
                sw.WriteLine(e.Id + "/" + e.StudentId + "/" + e.CourseId);
            }

            sw.Close();
        }

        public void Afisare()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (Enrolment e in _listEnrolment)
            {
                Console.WriteLine(e.Description());
            }
        }

        public Enrolment FindById(int id)
        {
            foreach(Enrolment e in _listEnrolment)
            {
                if(e.Id == id)
                {
                    return e;
                }
            }

            return null;
        }

        public List<Enrolment> FindByCourseId(int id)
        {
            List<Enrolment> enrolments = new List<Enrolment>();

            foreach(Enrolment e in _listEnrolment)
            {
                if(e.CourseId == id)
                {
                    enrolments.Add(e);
                }
            }

            return enrolments;
        }
        
        public List<Enrolment> FindByStudentId(int id)
        {
            List<Enrolment> enrolments = new List<Enrolment>();

            foreach(Enrolment e in _listEnrolment)
            {
                if(e.StudentId == id)
                {
                    enrolments.Add(e);
                }
            }

            return enrolments;
        }

        public Enrolment FindByStudentAndCourseId(int studentId, int courseId)
        {
            foreach (Enrolment e in _listEnrolment)
            {
                if (e.CourseId == courseId && e.StudentId == studentId)
                {
                    return e;
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

        public void RemoveById(int id)
        {
            _listEnrolment.Remove(this.FindById(id));
        }

        public void RemoveByStudentId(int id)
        {
            List<Enrolment> enrolments = this.FindByStudentId(id);

            foreach(Enrolment e in enrolments)
            {
                _listEnrolment.Remove(e);
            }
        }

        public void RemoveByCourseId(int id)
        {
            List<Enrolment> enrolments = this.FindByCourseId(id);

            foreach (Enrolment e in enrolments)
            {
                _listEnrolment.Remove(e);
            }
        }

        public void AddEnrolment(Enrolment enrolment)
        {
            enrolment.Id = this.NewId();
            _listEnrolment.Add(enrolment);
        }

        public int CountEnroledToCourse(int courseId)
        {
            int count = 0;
            foreach(Enrolment e in _listEnrolment)
            {
                if(e.CourseId == courseId)
                {
                    count++;
                }
            }
            return count;
        }

        public int CountCoursesStudentEnroledTo(int studentId)
        {
            int count = 0;
            foreach(Enrolment e in _listEnrolment)
            {
                if(e.StudentId == studentId)
                {
                    count++;
                }
            }
            return count;
        }

        public int GetFrequencyOfCourseById(int id)
        {
            int c = 0;
            foreach(Enrolment e in _listEnrolment)
            {
                if(e.CourseId == id)
                {
                    c++;
                }
            }
            return c;
        }

        public List<int> CourseIdsSortedByPopularity()
        {
            List<int> courseIds = new List<int>();
            int[] frequency = new int[10000];
            
            foreach(Enrolment e in _listEnrolment)
            {                
                if (!courseIds.Contains(e.CourseId))
                {
                    courseIds.Add(e.CourseId);
                }
            }

            for(int i = 0; i < courseIds.Count(); i++)
            {
                frequency[i] = this.GetFrequencyOfCourseById(courseIds[i]);
            }

            // Sorting the course id's by frequency.
            int k = 0;
            bool flag = true;
            while(flag && k < courseIds.Count())
            {
                flag = false;
                for(int j = courseIds.Count() - 1; j > k; j--)
                {
                    if (frequency[j] > frequency[j - 1])
                    {
                        int rc = courseIds[j - 1];
                        int rf = frequency[j - 1];
                        courseIds[j - 1] = courseIds[j];
                        frequency[j - 1] = frequency[j];
                        courseIds[j] = rc;
                        frequency[j] = rf;
                        flag = true;
                    }                    
                }
                k++;
            }

            return courseIds;
        }

        public int GetCount()
        {
            return _listEnrolment.Count();
        }

        public void ClearList()
        {
            _listEnrolment.Clear();
        }

        public List<Enrolment> GetList()
        {
            List<Enrolment> enrolments = new List<Enrolment>();

            foreach(Enrolment e in _listEnrolment)
            {
                enrolments.Add(e);
            }

            return enrolments;
        }
        
        public void SetList(List<Enrolment> listEnrolment)
        {
            _listEnrolment = listEnrolment;
        }
    }
}
