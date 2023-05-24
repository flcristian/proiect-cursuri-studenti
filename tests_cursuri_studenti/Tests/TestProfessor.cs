using cursuri_studenti.professor.model;
using cursuri_studenti.professor.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests_cursuri_studenti.Tests
{
    public class TestProfessor
    {
        // Testing Professor Service

        [Fact]
        public void FindById_ValidMatch_ReturnsProfessor()
        {
            // Arrange
            int Id = 123;
            Professor expectedProfessor = new Professor(Id, "test name", "test@test.com", "test123");
            List<Professor> list = new List<Professor> { expectedProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindById(Id);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void FindById_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 123;
            List<Professor> list = new List<Professor>();
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindById(id);

            // Assert
            Assert.Null(actualProfessor);
        }

        [Fact]
        public void FindById_MultipleProfessors_ReturnsCorrectProfessor()
        {
            // Arrange
            int Id = 123;
            Professor expectedProfessor = new Professor(Id, "test name", "test@test.com", "test123");
            Professor anotherProfessor = new Professor(101, "just another professor", "testProfessor@email.xyz", "password");
            List<Professor> list = new List<Professor> { expectedProfessor, anotherProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindById(Id);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void FindByName_ValidMatch_ReturnsProfessor()
        {
            // Arrange
            string Name = "name";
            Professor expectedProfessor = new Professor(123, Name, "test@test.com", "test123");
            List<Professor> list = new List<Professor> { expectedProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByName(Name);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void FindByName_NoMatch_ReturnsNull()
        {
            // Arrange
            string Name = "name";
            List<Professor> list = new List<Professor>();
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByName(Name);

            // Assert
            Assert.Null(actualProfessor);
        }

        [Fact]
        public void FindByName_MultipleProfessors_ReturnsCorrectProfessor()
        {
            // Arrange
            string Name = "name";
            Professor expectedProfessor = new Professor(123, Name, "test@test.com", "test123");
            Professor anotherProfessor = new Professor(101, "just another professor", "testProfessor@email.xyz", "password");
            List<Professor> list = new List<Professor> { expectedProfessor, anotherProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByName(Name);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void FindByEmail_ValidMatch_ReturnsProfessor()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            Professor expectedProfessor = new Professor(12, "Professor Name", Email, "justAPassword");
            List<Professor> list = new List<Professor> { expectedProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByEmail(Email);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void FindByEmail_NoMatch_ReturnNull()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            List<Professor> list = new List<Professor>();
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByEmail(Email);

            // Assert
            Assert.Null(actualProfessor);
        }

        [Fact]
        public void FindByEmail_MultipleProfessors_ReturnsCorrectProfessor()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            Professor expectedProfessor = new Professor(12, "Professor Name", Email, "justAPassword");
            Professor anotherProfessor = new Professor(101, "just another professor", "testProfessor@email.xyz", "password");
            List<Professor> list = new List<Professor> { expectedProfessor, anotherProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByEmail(Email);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void FindByEmailAndPassword_ValidMatch_ReturnsProfessor()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            string Password = "justAPassword";
            Professor expectedProfessor = new Professor(12, "Professor Name", Email, Password);
            List<Professor> list = new List<Professor> { expectedProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByEmailAndPassword(Email, Password);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void FindByEmailAndPassword_NoMatch_ReturnsNull()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            string Password = "justAPassword";
            List<Professor> list = new List<Professor>();
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByEmailAndPassword(Email, Password);

            // Assert
            Assert.Null(actualProfessor);
        }

        [Fact]
        public void FindByEmailAndPassword_MultipleProfessors_ReturnsCorrectProfessor()
        {
            // Arrange
            string Email = "emailforTest@test.com";
            string Password = "justAPassword";
            Professor expectedProfessor = new Professor(12, "Professor Name", Email, Password);
            Professor anotherProfessor = new Professor(101, "just another professor", "testProfessor@email.xyz", "password");
            List<Professor> list = new List<Professor> { expectedProfessor, anotherProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor actualProfessor = professorService.FindByEmailAndPassword(Email, Password);

            // Assert
            Assert.NotNull(actualProfessor);
            Assert.Equal(expectedProfessor.Id, actualProfessor.Id);
            Assert.Equal(expectedProfessor.Name, actualProfessor.Name);
            Assert.Equal(expectedProfessor.Email, actualProfessor.Email);
            Assert.Equal(expectedProfessor.Password, actualProfessor.Password);
        }

        [Fact]
        public void NewId_ReturnsUnusedId()
        {
            // Arrange
            int Id1 = 12, Id2 = 101;
            Professor anProfessor = new Professor(Id1, "Professor Name", "email@mail.com", "pass");
            Professor anotherProfessor = new Professor(Id2, "just another professor", "testProfessor@email.xyz", "password");
            List<Professor> list = new List<Professor> { anProfessor, anotherProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            int newId = professorService.NewId();

            // Assert
            Assert.Null(professorService.FindById(newId));
            Assert.NotEqual(Id1, newId);
            Assert.NotEqual(Id2, newId);
            Assert.InRange(newId, 1, 9999);
        }

        [Fact]
        public void RemoveById_ValidMatch_RemovesProfessor_ReturnsTrue()
        {
            // Arrange
            int Id = 12;
            Professor anProfessor = new Professor(Id, "Professor Name", "email@mail.com", "pass");
            List<Professor> list = new List<Professor> { anProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            bool removed = professorService.RemoveById(Id);
            list.Remove(anProfessor);

            // Assert
            Assert.True(removed);
            Assert.Null(professorService.FindById(Id));
        }

        [Fact]
        public void RemoveById_NoMatch_DoesntRemoveProfessor_ReturnsFalse()
        {
            // Arrange
            int Id = 12;
            Professor anotherProfessor = new Professor(101, "just another professor", "testProfessor@email.xyz", "password");
            List<Professor> list = new List<Professor> { anotherProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            bool removed = professorService.RemoveById(Id);

            // Assert
            Assert.False(removed);
            Assert.Equal(list, professorService.GetList());
        }

        [Fact]
        public void RemoveById_MultipleProfessors_RemovesCorrectProfessor_ReturnsTrue()
        {
            // Arrange
            int Id = 12;
            Professor anProfessor = new Professor(Id, "Professor Name", "email@mail.com", "pass");
            Professor anotherProfessor = new Professor(101, "just another professor", "testProfessor@email.xyz", "password");
            List<Professor> list = new List<Professor> { anProfessor, anotherProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            bool removed = professorService.RemoveById(Id);
            list.Remove(anProfessor);

            // Assert
            Assert.True(removed);
            Assert.Null(professorService.FindById(Id));
        }

        [Fact]
        public void AddProfessor_NoMatchingEmail_AddsProfessor_ReturnsTrue()
        {
            // Arrange
            int Id = 281;
            Professor anProfessor = new Professor(Id, "professor", "email@email.to", "passw");
            List<Professor> list = new List<Professor> { anProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            string Email = "added@email.com";
            Professor addedProfessor = new Professor(0, "added professor", Email, "passwordAdded");
            bool added = professorService.AddProfessor(addedProfessor);

            // Assert
            Assert.True(added);
            Assert.NotNull(professorService.FindByEmail(Email));
        }

        [Fact]
        public void AddProfessor_MatchingEmail_DoesntAddProfessor_ReturnsFalse()
        {
            // Arrange
            int Id = 281;
            string Email = "email@email.to";
            Professor anProfessor = new Professor(Id, "professor", Email, "passw");
            List<Professor> list = new List<Professor> { anProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            Professor addedProfessor = new Professor(0, "added professor", Email, "password2");
            bool added = professorService.AddProfessor(addedProfessor);

            // Assert
            Assert.False(added);
            Assert.Equal(anProfessor, professorService.FindByEmail(Email));
            Assert.Equal(list, professorService.GetList());
            Assert.Equal(list.Count(), professorService.GetCount());
        }

        [Fact]
        public void GetCount_ReturnsActualCount()
        {
            // Arrange
            Professor anProfessor = new Professor(123, "professor", "email@mail.com", "passw");
            List<Professor> list = new List<Professor> { anProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            int count = professorService.GetCount();

            // Assert
            Assert.Equal(list.Count(), count);
        }

        [Fact]
        public void ClearList_ListRemainsEmpty()
        {
            // Arrange
            Professor anProfessor = new Professor(123, "professor", "email@mail.com", "passw");
            List<Professor> list = new List<Professor> { anProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            professorService.ClearList();

            // Assert
            Assert.Equal(0, professorService.GetCount());
            Assert.Empty(professorService.GetList());
        }

        [Fact]
        public void GetList_ReturnsActualList()
        {
            // Arrange
            Professor anProfessor = new Professor(123, "professor", "email@mail.com", "passw");
            List<Professor> expectedList = new List<Professor> { anProfessor };
            ProfessorService professorService = new ProfessorService(expectedList);

            // Act
            List<Professor> actualList = professorService.GetList();

            // Assert
            Assert.Equal(expectedList, actualList);
            Assert.Equal(expectedList.Count(), actualList.Count());
        }

        [Fact]
        public void SetList_EditsList()
        {
            // Arrange
            Professor anProfessor = new Professor(123, "professor", "email@mail.com", "passw");
            List<Professor> list = new List<Professor>();
            List<Professor> setList = new List<Professor> { anProfessor };
            ProfessorService professorService = new ProfessorService(list);

            // Act
            professorService.SetList(setList);

            // Assert
            Assert.Equal(setList, professorService.GetList());
            Assert.Equal(setList.Count(), professorService.GetCount());
            Assert.NotEqual(list, professorService.GetList());
        }
    }
}
