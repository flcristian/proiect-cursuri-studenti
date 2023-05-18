using cursuri_studenti.professor.model;
using cursuri_studenti.professor.service;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;

namespace tests_cursuri_studenti.Tests
{
    public class TestProfessor
    {
        // Testing Professor Service

        [Fact]
        public void ReadList()
        {
            ProfessorService professorService = new ProfessorService();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\professors.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            professorService.ReadList();

            Assert.Equal(count, professorService.GetCount());
        }

        [Fact]
        public void SaveList()
        {
            ProfessorService professorService = new ProfessorService();

            professorService.SaveList();

            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\professors.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            Assert.Equal(professorService.GetCount(), count);
        }

        [Fact]
        public void FindById()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            Assert.NotNull(professorService.FindById(listProfessor[0].Id));
        }

        [Fact]
        public void FindByEmail()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            Assert.NotNull(professorService.FindByEmail(listProfessor[0].Email));
        }

        [Fact]
        public void FindByName()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            Assert.NotNull(professorService.FindByName(listProfessor[0].Name));
        }

        [Fact]
        public void FindByEmailAndPassword()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            Assert.NotNull(professorService.FindByEmailAndPassword(listProfessor[0].Email, listProfessor[0].Password));
        }

        [Fact]
        public void NewId_1()
        {
            ProfessorService professorService = new ProfessorService();

            Assert.Null(professorService.FindById(professorService.NewId()));
        }

        [Fact]
        public void NewId_2()
        {
            ProfessorService professorService = new ProfessorService();

            Assert.InRange(professorService.NewId(), 1, 9999);
        }

        [Fact]
        public void RemoveById_1()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            professorService.RemoveById(listProfessor[0].Id);

            Assert.Null(professorService.FindById(listProfessor[0].Id));
        }

        [Fact]
        public void RemoveById_2()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            professorService.RemoveById(listProfessor[0].Id);

            Assert.Equal(listProfessor.Count() - 1, professorService.GetCount());
        }

        [Fact]
        public void AddProfessor_1()
        {
            ProfessorService professorService = new ProfessorService();
            Professor professor = new Professor(0, "test", "test", "test");
            professorService.AddProfessor(professor);

            Assert.NotNull(professorService.FindByEmail("test"));
        }

        [Fact]
        public void AddProfessor_2()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            Professor professor = new Professor(0, "test", "test", "test");
            professorService.AddProfessor(professor);

            Assert.Equal(listProfessor.Count() + 1, professorService.GetCount());
        }

        [Fact]
        public void GetCount()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            Assert.Equal(listProfessor.Count(), professorService.GetCount());
        }

        [Fact]
        public void ClearList_1()
        {
            ProfessorService professorService = new ProfessorService();

            professorService.ClearList();

            Assert.Empty(professorService.GetList());
        }

        [Fact]
        public void ClearList_2()
        {
            ProfessorService professorService = new ProfessorService();

            professorService.ClearList();

            Assert.Equal(0, professorService.GetCount());
        }

        [Fact]
        public void GetList_1()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            bool flag = true;
            foreach (Professor s in listProfessor)
            {
                if (professorService.FindById(s.Id) == null)
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
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = professorService.GetList();

            Assert.Equal(professorService.GetCount(), listProfessor.Count());
        }

        [Fact]
        public void SetList_1()
        {
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = new List<Professor>();
            Professor professor = new Professor(0, "test", "test", "test");
            listProfessor.Add(professor);
            professorService.SetList(listProfessor);

            bool flag = true;
            foreach (Professor s in listProfessor)
            {
                if (professorService.FindById(s.Id) == null)
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
            ProfessorService professorService = new ProfessorService();
            List<Professor> listProfessor = new List<Professor>();

            professorService.SetList(listProfessor);

            Assert.Equal(listProfessor.Count(), professorService.GetCount());
        }
    }
}
