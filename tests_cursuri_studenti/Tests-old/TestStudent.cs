using cursuri_studenti.student.model;
using cursuri_studenti.student.service;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;

namespace tests_cursuri_studenti.Tests
{
    public class TestStudent
    {
        // Testing Student Service

        [Fact]
        public void ReadList()
        {
            StudentService studentService = new StudentService();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\students.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            studentService.ReadList();

            Assert.Equal(count, studentService.GetCount());
        }

        [Fact]
        public void SaveList()
        {
            StudentService studentService = new StudentService();

            studentService.SaveList();

            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\students.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            Assert.Equal(studentService.GetCount(), count);
        }

        [Fact]
        public void FindById()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Assert.NotNull(studentService.FindById(listStudent[0].Id));
        }

        [Fact]
        public void FindByEmail()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Assert.NotNull(studentService.FindByEmail(listStudent[0].Email));
        }

        [Fact]
        public void FindByName()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Assert.NotNull(studentService.FindByName(listStudent[0].Name));
        }

        [Fact]
        public void FindByEmailAndPassword()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Assert.NotNull(studentService.FindByEmailAndPassword(listStudent[0].Email, listStudent[0].Password));
        }

        [Fact]
        public void NewId_1()
        {
            StudentService studentService = new StudentService();

            Assert.Null(studentService.FindById(studentService.NewId()));
        }

        [Fact]
        public void NewId_2()
        {
            StudentService studentService = new StudentService();

            Assert.InRange(studentService.NewId(), 1, 9999);
        }

        [Fact]
        public void RemoveById_1()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            studentService.RemoveById(listStudent[0].Id);

            Assert.Null(studentService.FindById(listStudent[0].Id));
        }

        [Fact]
        public void RemoveById_2()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            studentService.RemoveById(listStudent[0].Id);

            Assert.Equal(listStudent.Count() - 1, studentService.GetCount());
        }

        [Fact]
        public void AddStudent_1()
        {
            StudentService studentService = new StudentService();
            Student student = new Student(0, 0, "test", "test", "test");
            studentService.AddStudent(student);

            Assert.NotNull(studentService.FindByEmail("test"));
        }

        [Fact]
        public void AddStudent_2()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Student student = new Student(0, 0, "test", "test", "test");
            studentService.AddStudent(student);

            Assert.Equal(listStudent.Count() + 1, studentService.GetCount());
        }

        [Fact]
        public void IsBanned()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Assert.Equal(listStudent[0].Locked, studentService.IsBanned(listStudent[0].Id));
        }

        [Fact]
        public void Ban()
        {
            StudentService studentService = new StudentService();
            Student student = new Student(0, 0, "test", "test", "test");
            student.Locked = false;
            studentService.AddStudent(student);
            student = studentService.FindByEmail("test");

            studentService.Ban(student.Id);

            Assert.True(studentService.IsBanned(student.Id));
        }

        [Fact]
        public void Unban()
        {
            StudentService studentService = new StudentService();
            Student student = new Student(0, 0, "test", "test", "test");
            student.Locked = true;
            studentService.AddStudent(student);
            student = studentService.FindByEmail("test");

            studentService.Unban(student.Id);

            Assert.False(studentService.IsBanned(student.Id));
        }

        [Fact]
        public void GetCount()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Assert.Equal(listStudent.Count(), studentService.GetCount());
        }

        [Fact]
        public void ClearList_1()
        {
            StudentService studentService = new StudentService();

            studentService.ClearList();

            Assert.Empty(studentService.GetList());
        }

        [Fact]
        public void ClearList_2()
        {
            StudentService studentService = new StudentService();

            studentService.ClearList();

            Assert.Equal(0, studentService.GetCount());
        }

        [Fact]
        public void GetList_1()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            bool flag = true;
            foreach(Student s in listStudent)
            {
                if(studentService.FindById(s.Id) == null)
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
            StudentService studentService = new StudentService();
            List<Student> listStudent = studentService.GetList();

            Assert.Equal(studentService.GetCount(), listStudent.Count());
        }

        [Fact]
        public void SetList_1()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = new List<Student>();
            Student student = new Student(0, 0, "test", "test", "test");
            listStudent.Add(student);
            studentService.SetList(listStudent);

            bool flag = true;
            foreach(Student s in listStudent)
            {
                if(studentService.FindById(s.Id) == null)
                {
                    flag = false;
                    break;
                }
            }

            Assert.True(flag);
        }

        [Fact]
        public void SetList_2()
        {
            StudentService studentService = new StudentService();
            List<Student> listStudent = new List<Student>();

            studentService.SetList(listStudent);

            Assert.Equal(listStudent.Count(), studentService.GetCount());
        }
    }
}
