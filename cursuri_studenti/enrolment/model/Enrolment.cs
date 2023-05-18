using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursuri_studenti.enrolment.model
{
    public class Enrolment
    {
        private int _id;
        private int _studentId;
        private int _courseId;

        // Constructori

        public Enrolment(int id, int studentId, int courseId)
        {
            _id = id;
            _studentId = studentId;
            _courseId = courseId;
        }

        public Enrolment(string text)
        {
            string[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _studentId = Int32.Parse(data[1]);
            _courseId = Int32.Parse(data[2]);
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

        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
            }
        }

        public int CourseId
        {
            get { return _courseId; }
            set
            {
                _courseId = value;
            }
        }

        // Metode

        public string Description()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Student Id : " + _studentId + "\n";
            desc += "Course Id : " + _courseId + "\n";

            return desc;
        }
    }
}
