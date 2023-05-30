using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursuri_studenti.book.model
{
    public class Book
    {
        private int _id;
        private int _studentId;
        private string _author;
        private string _name;

        // Constructori

        public Book(int id, int studentId)
        {
            _id = id;
            _studentId = studentId;
            _author = "author";
            _name = "name";
        }

        public Book(int id, int studentId, string author, string name)
        {
            _id = id;
            _studentId = studentId;
            _author = author;
            _name = name;
        }

        public Book(string text)
        {
            string[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _studentId = Int32.Parse(data[1]);
            _author = data[2];
            _name = data[3];
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

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
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
            desc += "Student Id : " + _studentId + "\n";
            desc += "Author : " + _author + "\n";
            desc += "Name : " + _name + "\n";

            return desc;
        }

        public string DescriptionStudent()
        {
            string desc = "";

            desc += "Author : " + _author + "\n";
            desc += "Name : " + _name + "\n";

            return desc;
        }
    }
}
