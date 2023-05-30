using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursuri_studenti.admin.model;

namespace cursuri_studenti.admin.service
{
    public class AdminService
    {
        private List<Admin> _listAdmin;

        public AdminService()
        {
            _listAdmin = new List<Admin>();

            this.ReadList();
        }

        public AdminService(List<Admin> listAdmin)
        {
            _listAdmin = listAdmin;
        }

        // Metode

        public void ReadList()
        {
            _listAdmin = new List<Admin>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\admins.txt");

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Admin a = new Admin(text);

                _listAdmin.Add(a);
            }

            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\admins.txt");

            foreach(Admin a in _listAdmin)
            {
                sw.WriteLine(a.Id + "/" + a.Name + "/" + a.Email + "/" + a.Password);
            }

            sw.Close();
        }

        public Admin FindById(int id)
        {
            foreach (Admin a in _listAdmin)
            {
                if(a.Id == id)
                {
                    return a;
                }
            }

            return null;
        }

        public Admin FindByEmail(string email)
        {
            foreach(Admin a in _listAdmin)
            {
                if (a.Email.Equals(email))
                {
                    return a;
                }
            }

            return null;
        }

        public Admin FindByEmailAndPassword(string email, string password)
        {
            foreach(Admin a in _listAdmin)
            {
                if(email.Equals(a.Email) && password.Equals(a.Password))
                {
                    return a;
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
            Admin admin = this.FindById(id);
            if (admin != null)
            {
                _listAdmin.Remove(admin);
                return true;
            }
            return false;
        }

        public bool AddAdmin(Admin admin)
        {
            Admin a = this.FindByEmail(admin.Email);
            if (a == null)
            {
                admin.Id = this.NewId();
                _listAdmin.Add(admin);
                return true;
            }
            return false;
        }

        public int GetCount()
        {
            return _listAdmin.Count();
        }

        public void ClearList()
        {
            _listAdmin.Clear();
        }

        public List<Admin> GetList()
        {
            List<Admin> listAdmin = new List<Admin>();

            foreach(Admin a in _listAdmin)
            {
                listAdmin.Add(a);
            }

            return listAdmin;
        }

        public void SetList(List<Admin> listAdmin)
        {
            _listAdmin = listAdmin;
        }
    }
}

