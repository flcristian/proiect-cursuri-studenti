using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursuri_studenti.student.model
{
    public class Student
    {
        private int _id;
        private int _age;
        private string _name;
        private string _email;
        private string _password;
        private bool _locked;

        // Constructori

        public Student(int id, int age, string name, string email, string password)
        {
            _id = id;
            _age = age;
            _name = name;
            _email = email;
            _password = password;
            _locked = false;
        }

        public Student(string text)
        {
            string[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _age = Int32.Parse(data[1]);
            _name = data[2];
            _email = data[3];
            _password = data[4];
            _locked = Boolean.Parse(data[5]);
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

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
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

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;
            }
        }

        // Metode

        public string Description()
        {
            string desc = "";

            desc += "Age : " + _age + "\n";
            desc += "Name : " + _name + "\n";
            desc += "Email : " + _email + "\n";

            return desc;
        }

        public string NameAndEmail()
        {
            string desc = "";
            
            desc += _id + " : " + _name + " : " + _email;
            if (_locked)
            {
                desc += " (BANNED)";
            }

            return desc;
        }
    }
}
