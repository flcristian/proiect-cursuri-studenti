using cursuri_studenti.course.model;
using cursuri_studenti.course.service;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;

namespace tests_cursuri_studenti.Tests
{
    public class TestCourse
    {
        // Testing Course Service

        [Fact]
        public void ReadList()
        {
            CourseService courseService = new CourseService();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\courses.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            courseService.ReadList();

            Assert.Equal(count, courseService.GetCount());
        }

        [Fact]
        public void SaveList()
        {
            CourseService courseService = new CourseService();

            courseService.SaveList();

            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\courses.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            Assert.Equal(courseService.GetCount(), count);
        }

        [Fact]
        public void FindById()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            Assert.NotNull(courseService.FindById(listCourse[0].Id));
        }

        [Fact]
        public void FindByName()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            Assert.NotNull(courseService.FindByName(listCourse[0].Name));
        }

        [Fact]
        public void FindByProfessorId_1()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            int professorId = listCourse[0].ProfessorId, count = 0;
            foreach(Course c in listCourse)
            {
                if (c.ProfessorId == professorId)
                {
                    count++;
                }
            }

            Assert.Equal(count, courseService.FindByProfessorId(professorId).Count());
        }

        [Fact]
        public void FindByProfessorId_2()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            Assert.NotEmpty(courseService.FindByProfessorId(listCourse[0].ProfessorId));
        }

        [Fact]
        public void NewId_1()
        {
            CourseService courseService = new CourseService();

            Assert.Null(courseService.FindById(courseService.NewId()));
        }

        [Fact]
        public void NewId_2()
        {
            CourseService courseService = new CourseService();

            Assert.InRange(courseService.NewId(), 1, 9999);
        }

        [Fact]
        public void RemoveById_1()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            courseService.RemoveById(listCourse[0].Id);

            Assert.Null(courseService.FindById(listCourse[0].Id));
        }

        [Fact]
        public void RemoveById_2()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            courseService.RemoveById(listCourse[0].Id);

            Assert.Equal(listCourse.Count() - 1, courseService.GetCount());
        }

        [Fact]
        public void RemoveByProfessorId_1()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            courseService.RemoveByProfessorId(listCourse[0].ProfessorId);

            Assert.Empty(courseService.FindByProfessorId(listCourse[0].ProfessorId));
        }

        [Fact]
        public void RemoveByProfessorId_2()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();
            List<Course> removed = courseService.FindByProfessorId(listCourse[0].ProfessorId);

            courseService.RemoveByProfessorId(listCourse[0].ProfessorId);

            Assert.Equal(listCourse.Count() - removed.Count(), courseService.GetCount());
        }

        [Fact]
        public void AddCourse_1()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            Course course = new Course(1, 1, "test");
            courseService.AddCourse(course);

            Assert.Equal(listCourse.Count() + 1, courseService.GetCount());
        }

        [Fact]
        public void AddCourse_2()
        {
            CourseService courseService = new CourseService();

            int professorId = 9876;
            string name = "9876test6789";
            Course course = new Course(1, professorId, name);

            courseService.AddCourse(course);

            List<Course> listCourse = courseService.FindByProfessorId(professorId);
            foreach(Course c in listCourse)
            {
                if (c.Name.Equals(name))
                {
                    course = c;
                    break;
                }
            }

            Assert.NotNull(courseService.FindById(course.Id));
        }

        [Fact]
        public void EditCourse()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            Course toEdit = new Course(0, 1, "test");
            toEdit.Id = listCourse[0].Id;
            courseService.EditCourse(toEdit);

            Assert.NotEqual(listCourse[0], courseService.FindById(toEdit.Id));
        }

        [Fact]
        public void GetCount()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            Assert.Equal(listCourse.Count(), courseService.GetCount());
        }

        [Fact]
        public void ClearList_1()
        {
            CourseService courseService = new CourseService();

            courseService.ClearList();

            Assert.Empty(courseService.GetList());
        }

        [Fact]
        public void ClearList_2()
        {
            CourseService courseService = new CourseService();

            courseService.ClearList();

            Assert.Equal(0, courseService.GetCount());
        }

        [Fact]
        public void GetList_1()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            bool flag = true;
            foreach(Course c in listCourse)
            {
                if(courseService.FindById(c.Id) == null)
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
            CourseService courseService = new CourseService();
            List<Course> listCourse = courseService.GetList();

            Assert.Equal(courseService.GetCount(), listCourse.Count());
        }

        [Fact]
        public void SetList_1()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = new List<Course>();

            courseService.SetList(listCourse);

            Assert.Equal(listCourse.Count(), courseService.GetCount());
        }

        [Fact]
        public void SetList_2()
        {
            CourseService courseService = new CourseService();
            List<Course> listCourse = new List<Course>();
            Course course = new Course(1, 1, "test");
            listCourse.Add(course);

            courseService.SetList(listCourse);

            bool flag = true;
            foreach(Course c in listCourse)
            {
                if(courseService.FindById(c.Id) == null)
                {
                    flag = false;
                    break;
                }
            }

            Assert.True(flag);
        }
    }
}
