using cursuri_studenti.admin.model;
using cursuri_studenti.admin.service;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;

namespace tests_cursuri_studenti.Tests
{
    public class TestAdmin
    {
        // Testing Admin Service

        [Fact]
        public void ReadList()
        {
            AdminService adminService = new AdminService();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\admins.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            adminService.ReadList();
            Assert.Equal(count, adminService.GetCount());
        }

        [Fact]
        public void SaveList()
        {
            AdminService adminService = new AdminService();

            adminService.SaveList();

            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\admins.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            Assert.Equal(count, adminService.GetCount());
        }

        [Fact]
        public void FindById()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Assert.NotNull(adminService.FindById(listAdmin[0].Id));
        }

        [Fact]
        public void FindByEmail()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Assert.NotNull(adminService.FindByEmail(listAdmin[0].Email));
        }

        [Fact]
        public void FindByEmailAndPassword()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Assert.NotNull(adminService.FindByEmailAndPassword(listAdmin[0].Email, listAdmin[0].Password));
        }

        [Fact]
        public void NewId_1()
        {
            AdminService adminService = new AdminService();

            Assert.Null(adminService.FindById(adminService.NewId()));
        }

        [Fact]
        public void NewId_2()
        {
            AdminService adminService = new AdminService();

            Assert.InRange(adminService.NewId(), 1, 9999);
        }

        [Fact]
        public void RemoveById_1()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Admin admin = listAdmin[0];
            adminService.RemoveById(admin.Id);

            Assert.Null(adminService.FindById(admin.Id));
        }

        [Fact]
        public void RemoveById_2()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Admin admin = listAdmin[0];
            adminService.RemoveById(admin.Id);

            Assert.Equal(listAdmin.Count() - 1, adminService.GetCount());
        }

        [Fact]
        public void AddAdmin_1()
        {
            AdminService adminService = new AdminService();

            Admin admin = new Admin(1, "test", "emailForTest@gmail.com", "test");
            adminService.AddAdmin(admin);

            Assert.NotNull(adminService.FindByEmail("emailForTest@gmail.com"));
        }

        [Fact]
        public void AddAdmin_2()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Admin admin = new Admin(1, "test", "emailForTest@gmail.com", "test");
            adminService.AddAdmin(admin);

            Assert.Equal(listAdmin.Count() + 1, adminService.GetCount());
        }

        [Fact]
        public void GetCount()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Assert.Equal(adminService.GetCount(), listAdmin.Count());
        }

        [Fact]
        public void ClearList_1()
        {
            AdminService adminService = new AdminService();

            adminService.ClearList();

            Assert.Empty(adminService.GetList());
        }

        [Fact]
        public void ClearList_2()
        {
            AdminService adminService = new AdminService();

            adminService.ClearList();

            Assert.Equal(0, adminService.GetCount());
        }

        [Fact]
        public void GetList_1()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            bool flag = true;
            foreach (Admin a in listAdmin)
            {
                if (adminService.FindById(a.Id) == null)
                {
                    flag = false;
                    break;
                }
            }

            Assert.True(flag);
        }

        [Fact]
        public void GetList_2()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = adminService.GetList();

            Assert.Equal(adminService.GetCount(), listAdmin.Count());
        }

        [Fact]
        public void SetList_1()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = new List<Admin>();

            adminService.SetList(listAdmin);

            Assert.Equal(0, adminService.GetCount());
        }

        [Fact]
        public void SetList_2()
        {
            AdminService adminService = new AdminService();
            List<Admin> listAdmin = new List<Admin>();
            Admin admin = new Admin(0, "test", "test", "test");
            listAdmin.Add(admin);

            adminService.SetList(listAdmin);

            bool flag = true;
            foreach(Admin a in listAdmin)
            {
                if(adminService.FindById(a.Id) == null)
                {
                    flag = false;
                    break;
                }
            }

            Assert.True(flag);
        }
    }
}