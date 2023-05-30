using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursuri_studenti.course.model
{
    public class Course
    {
        private int _id;
        private int _professorId;
        private string _name;

        // Constructori

        public Course(int id, int professorId, string name)
        {
            _id = id;
            _professorId = professorId;
            _name = name;
        }

        public Course(string text)
        {
            string[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _professorId = Int32.Parse(data[1]);
            _name = data[2];
        }

        // Accesorii

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public int ProfessorId
        {
            get { return _professorId; }
            set
            {
                _professorId = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        // Metode

        public string Description()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Professor Id : " + _professorId + "\n";
            desc += "Name : " + _name + "\n";

            return desc;
        }

        public string DescriptionStudent()
        {
            string desc = "";

            desc += "Name : " + _name + "\n";

            return desc;
        }
    }
}
