using cursuri_studenti.student.model;
using cursuri_studenti.student.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests_cursuri_studenti.Tests
{
    public class TestStudent
    {
        // Testing Student Service

        [Fact]
        public void FindById_ValidMatch_ReturnsStudent()
        {
            // Arrange
            int Id = 123;
            Student expectedStudent = new Student(Id, 123, "test name", "test@test.com", "test123");
            List<Student> list = new List<Student> { expectedStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindById(Id);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void FindById_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 123;
            List<Student> list = new List<Student>();
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindById(id);

            // Assert
            Assert.Null(actualStudent);
        }

        [Fact]
        public void FindById_MultipleStudents_ReturnsCorrectStudent()
        {
            // Arrange
            int Id = 123;
            Student expectedStudent = new Student(Id, 123, "test name", "test@test.com", "test123");
            Student anotherStudent = new Student(101, 123, "just another student", "testStudent@email.xyz", "password");
            List<Student> list = new List<Student> { expectedStudent, anotherStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindById(Id);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void FindByName_ValidMatch_ReturnsStudent()
        {
            // Arrange
            string Name = "name";
            Student expectedStudent = new Student(123, 123, Name, "test@test.com", "test123");
            List<Student> list = new List<Student> { expectedStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByName(Name);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void FindByName_NoMatch_ReturnsNull()
        {
            // Arrange
            string Name = "name";
            List<Student> list = new List<Student>();
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByName(Name);

            // Assert
            Assert.Null(actualStudent);
        }

        [Fact]
        public void FindByName_MultipleStudents_ReturnsCorrectStudent()
        {
            // Arrange
            string Name = "name";
            Student expectedStudent = new Student(123, 123, Name, "test@test.com", "test123");
            Student anotherStudent = new Student(101, 123, "just another student", "testStudent@email.xyz", "password");
            List<Student> list = new List<Student> { expectedStudent, anotherStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByName(Name);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void FindByEmail_ValidMatch_ReturnsStudent()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            Student expectedStudent = new Student(12, 123, "Student Name", Email, "justAPassword");
            List<Student> list = new List<Student> { expectedStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByEmail(Email);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void FindByEmail_NoMatch_ReturnNull()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            List<Student> list = new List<Student>();
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByEmail(Email);

            // Assert
            Assert.Null(actualStudent);
        }

        [Fact]
        public void FindByEmail_MultipleStudents_ReturnsCorrectStudent()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            Student expectedStudent = new Student(12, 123, "Student Name", Email, "justAPassword");
            Student anotherStudent = new Student(101, 123, "just another student", "testStudent@email.xyz", "password");
            List<Student> list = new List<Student> { expectedStudent, anotherStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByEmail(Email);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void FindByEmailAndPassword_ValidMatch_ReturnsStudent()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            string Password = "justAPassword";
            Student expectedStudent = new Student(12, 123, "Student Name", Email, Password);
            List<Student> list = new List<Student> { expectedStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByEmailAndPassword(Email, Password);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void FindByEmailAndPassword_NoMatch_ReturnsNull()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            string Password = "justAPassword";
            List<Student> list = new List<Student>();
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByEmailAndPassword(Email, Password);

            // Assert
            Assert.Null(actualStudent);
        }

        [Fact]
        public void FindByEmailAndPassword_MultipleStudents_ReturnsCorrectStudent()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            string Password = "justAPassword";
            Student expectedStudent = new Student(12, 123, "Student Name", Email, Password);
            Student anotherStudent = new Student(101, 123, "just another student", "testStudent@email.xyz", "password");
            List<Student> list = new List<Student> { expectedStudent, anotherStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student actualStudent = studentService.FindByEmailAndPassword(Email, Password);

            // Assert
            Assert.NotNull(actualStudent);
            Assert.Equal(expectedStudent.Id, actualStudent.Id);
            Assert.Equal(expectedStudent.Name, actualStudent.Name);
            Assert.Equal(expectedStudent.Email, actualStudent.Email);
            Assert.Equal(expectedStudent.Password, actualStudent.Password);
        }

        [Fact]
        public void NewId_ReturnsUnusedId()
        {
            // Arrange
            int Id1 = 12, Id2 = 101;
            Student anStudent = new Student(Id1, 123, "Student Name", "email@mail.com", "pass");
            Student anotherStudent = new Student(Id2, 123, "just another student", "testStudent@email.xyz", "password");
            List<Student> list = new List<Student> { anStudent, anotherStudent };
            StudentService studentService = new StudentService(list);

            // Act
            int newId = studentService.NewId();

            // Assert
            Assert.Null(studentService.FindById(newId));
            Assert.NotEqual(Id1, newId);
            Assert.NotEqual(Id2, newId);
            Assert.InRange(newId, 1, 9999);
        }

        [Fact]
        public void RemoveById_ValidMatch_RemovesStudent_ReturnsTrue()
        {
            // Arrange
            int Id = 12;
            Student anStudent = new Student(Id, 123, "Student Name", "email@mail.com", "pass");
            List<Student> list = new List<Student> { anStudent };
            StudentService studentService = new StudentService(list);

            // Act
            bool removed = studentService.RemoveById(Id);
            list.Remove(anStudent);

            // Assert
            Assert.True(removed);
            Assert.Null(studentService.FindById(Id));
        }

        [Fact]
        public void RemoveById_NoMatch_DoesntRemoveStudent_ReturnsFalse()
        {
            // Arrange
            int Id = 12;
            Student anotherStudent = new Student(101, 123, "just another student", "testStudent@email.xyz", "password");
            List<Student> list = new List<Student> { anotherStudent };
            StudentService studentService = new StudentService(list);

            // Act
            bool removed = studentService.RemoveById(Id);

            // Assert
            Assert.False(removed);
            Assert.Equal(list, studentService.GetList());
        }

        [Fact]
        public void RemoveById_MultipleStudents_RemovesCorrectStudent_ReturnsTrue()
        {
            // Arrange
            int Id = 12;
            Student anStudent = new Student(Id, 123, "Student Name", "email@mail.com", "pass");
            Student anotherStudent = new Student(101, 123, "just another student", "testStudent@email.xyz", "password");
            List<Student> list = new List<Student> { anStudent, anotherStudent };
            StudentService studentService = new StudentService(list);

            // Act
            bool removed = studentService.RemoveById(Id);
            list.Remove(anStudent);

            // Assert
            Assert.True(removed);
            Assert.Null(studentService.FindById(Id));
        }

        [Fact]
        public void AddStudent_NoMatchingEmail_AddsStudent_ReturnsTrue()
        {
            // Arrange
            int Id = 281;
            Student anStudent = new Student(Id, 123, "student", "email@email.to", "passw");
            List<Student> list = new List<Student> { anStudent };
            StudentService studentService = new StudentService(list);

            // Act
            string Email = "added@email.com";
            Student addedStudent = new Student(0, 123, "added student", Email, "passwordAdded");
            bool added = studentService.AddStudent(addedStudent);

            // Assert
            Assert.True(added);
            Assert.NotNull(studentService.FindByEmail(Email));
        }

        [Fact]
        public void AddStudent_MatchingEmail_DoesntAddStudent_ReturnsFalse()
        {
            // Arrange
            int Id = 281;
            string Email = "email@email.to";
            Student anStudent = new Student(Id, 123, "student", Email, "passw");
            List<Student> list = new List<Student> { anStudent };
            StudentService studentService = new StudentService(list);

            // Act
            Student addedStudent = new Student(0, 123, "added student", Email, "password2");
            bool added = studentService.AddStudent(addedStudent);

            // Assert
            Assert.False(added);
            Assert.Equal(anStudent, studentService.FindByEmail(Email));
            Assert.Equal(list, studentService.GetList());
            Assert.Equal(list.Count(), studentService.GetCount());
        }

        // TODO : BANNED STUFF

        [Fact]
        public void GetCount_ReturnsActualCount()
        {
            // Arrange
            Student anStudent = new Student(123, 123, "student", "email@mail.com", "passw");
            List<Student> list = new List<Student> { anStudent };
            StudentService studentService = new StudentService(list);

            // Act
            int count = studentService.GetCount();

            // Assert
            Assert.Equal(list.Count(), count);
        }

        [Fact]
        public void ClearList_ListRemainsEmpty()
        {
            // Arrange
            Student anStudent = new Student(123, 123, "student", "email@mail.com", "passw");
            List<Student> list = new List<Student> { anStudent };
            StudentService studentService = new StudentService(list);

            // Act
            studentService.ClearList();

            // Assert
            Assert.Equal(0, studentService.GetCount());
            Assert.Empty(studentService.GetList());
        }

        [Fact]
        public void GetList_ReturnsActualList()
        {
            // Arrange
            Student anStudent = new Student(123, 123, "student", "email@mail.com", "passw");
            List<Student> expectedList = new List<Student> { anStudent };
            StudentService studentService = new StudentService(expectedList);

            // Act
            List<Student> actualList = studentService.GetList();

            // Assert
            Assert.Equal(expectedList, actualList);
            Assert.Equal(expectedList.Count(), actualList.Count());
        }

        [Fact]
        public void SetList_EditsList()
        {
            // Arrange
            Student anStudent = new Student(123, 123, "student", "email@mail.com", "passw");
            List<Student> list = new List<Student>();
            List<Student> setList = new List<Student> { anStudent };
            StudentService studentService = new StudentService(list);

            // Act
            studentService.SetList(setList);

            // Assert
            Assert.Equal(setList, studentService.GetList());
            Assert.Equal(setList.Count(), studentService.GetCount());
            Assert.NotEqual(list, studentService.GetList());
        }
    }
}
