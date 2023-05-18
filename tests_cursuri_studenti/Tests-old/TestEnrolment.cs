using cursuri_studenti.course.model;
using cursuri_studenti.enrolment.model;
using cursuri_studenti.enrolment.service;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;

namespace tests_cursuri_studenti.Tests
{
    public class TestEnrolment
    {
        // Testing Enrolment Service

        [Fact]
        public void ReadList()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\enrolments.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            enrolmentService.ReadList();

            Assert.Equal(count, enrolmentService.GetCount());
        }

        [Fact]
        public void SaveList()
        {
            EnrolmentService enrolmentService = new EnrolmentService();

            enrolmentService.SaveList();

            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\incapsularea\\proiecte\\cursuri_studenti\\cursuri_studenti\\resources\\enrolments.txt");

            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;
            }
            sr.Close();

            Assert.Equal(enrolmentService.GetCount(), count);
        }

        [Fact]
        public void FindById()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.NotNull(enrolmentService.FindById(listEnrolment[0].Id));
        }

        [Fact]
        public void FindByStudentAndCourseId()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.NotNull(enrolmentService.FindByStudentAndCourseId(listEnrolment[0].StudentId, listEnrolment[0].CourseId));
        }

        [Fact]
        public void FindByCourseId_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            int courseId = listEnrolment[0].CourseId, count = 0;
            foreach(Enrolment e in listEnrolment)
            {
                if (e.CourseId == courseId)
                {
                    count++;
                }
            }

            Assert.Equal(count, enrolmentService.FindByCourseId(courseId).Count());
        }

        [Fact]
        public void FindByCourseId_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.NotEmpty(enrolmentService.FindByCourseId(listEnrolment[0].CourseId));
        }

        [Fact]
        public void FindByStudentId_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            int studentId = listEnrolment[0].StudentId, count = 0;
            foreach (Enrolment e in listEnrolment)
            {
                if (e.StudentId == studentId)
                {
                    count++;
                }
            }

            Assert.Equal(count, enrolmentService.FindByStudentId(studentId).Count());
        }

        [Fact]
        public void FindByStudentId_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.NotEmpty(enrolmentService.FindByStudentId(listEnrolment[0].StudentId));
        }

        [Fact]
        public void NewId_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();

            Assert.Null(enrolmentService.FindById(enrolmentService.NewId()));
        }

        [Fact]
        public void NewId_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();

            Assert.InRange(enrolmentService.NewId(), 1, 9999);
        }

        [Fact]
        public void RemoveById_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            enrolmentService.RemoveById(listEnrolment[0].Id);

            Assert.Null(enrolmentService.FindById(listEnrolment[0].Id));
        }

        [Fact]
        public void RemoveById_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            enrolmentService.RemoveById(listEnrolment[0].Id);

            Assert.Equal(listEnrolment.Count() - 1, enrolmentService.GetCount());
        }

        [Fact]
        public void RemoveByStudentId_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            enrolmentService.RemoveByStudentId(listEnrolment[0].StudentId);

            Assert.Empty(enrolmentService.FindByStudentId(listEnrolment[0].StudentId));
        }

        [Fact]
        public void RemoveByStudentId_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();
            List<Enrolment> removed = enrolmentService.FindByStudentId(listEnrolment[0].StudentId);

            enrolmentService.RemoveByStudentId(listEnrolment[0].StudentId);

            Assert.Equal(listEnrolment.Count() - removed.Count(), enrolmentService.GetCount());
        }

        [Fact]
        public void RemoveByCourseId_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            enrolmentService.RemoveByCourseId(listEnrolment[0].CourseId);

            Assert.Empty(enrolmentService.FindByCourseId(listEnrolment[0].CourseId));
        }

        [Fact]
        public void RemoveByCourseId_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();
            List<Enrolment> removed = enrolmentService.FindByCourseId(listEnrolment[0].CourseId);

            enrolmentService.RemoveByCourseId(listEnrolment[0].CourseId);

            Assert.Equal(listEnrolment.Count() - removed.Count(), enrolmentService.GetCount());
        }

        [Fact]
        public void AddEnrolment_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            Enrolment enrolment = new Enrolment(0, 9999999, 0);
            enrolmentService.AddEnrolment(enrolment);

            Assert.NotEmpty(enrolmentService.FindByStudentId(9999999));
        }

        [Fact]
        public void AddEnrolment_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Enrolment enrolment = new Enrolment(0, 0, 0);
            enrolmentService.AddEnrolment(enrolment);

            Assert.Equal(listEnrolment.Count() + 1, enrolmentService.GetCount());
        }

        [Fact]
        public void CountEnroledToCourse()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.NotEqual(0, enrolmentService.CountEnroledToCourse(listEnrolment[0].CourseId));
        }

        [Fact]
        public void CountCoursesStudentEnroledTo()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.NotEqual(0, enrolmentService.CountCoursesStudentEnroledTo(listEnrolment[0].StudentId));
        }

        [Fact]
        public void GetFrequencyOfCourseById()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.NotEqual(0, enrolmentService.GetFrequencyOfCourseById(listEnrolment[0].CourseId));
        }

        [Fact]
        public void GetCount()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.Equal(listEnrolment.Count(), enrolmentService.GetCount());
        }

        [Fact]
        public void ClearList_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();

            enrolmentService.ClearList();

            Assert.Empty(enrolmentService.GetList());
        }

        [Fact]
        public void ClearList_2()
        {
            EnrolmentService enrolmentService = new EnrolmentService();

            enrolmentService.ClearList();

            Assert.Equal(0, enrolmentService.GetCount());
        }

        [Fact]
        public void GetList_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            bool flag = true;
            foreach (Enrolment s in listEnrolment)
            {
                if (enrolmentService.FindById(s.Id) == null)
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
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = enrolmentService.GetList();

            Assert.Equal(enrolmentService.GetCount(), listEnrolment.Count());
        }

        [Fact]
        public void SetList_1()
        {
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = new List<Enrolment>();
            Enrolment enrolment = new Enrolment(0, 0, 0);
            listEnrolment.Add(enrolment);
            enrolmentService.SetList(listEnrolment);

            bool flag = true;
            foreach (Enrolment s in listEnrolment)
            {
                if (enrolmentService.FindById(s.Id) == null)
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
            EnrolmentService enrolmentService = new EnrolmentService();
            List<Enrolment> listEnrolment = new List<Enrolment>();

            enrolmentService.SetList(listEnrolment);

            Assert.Equal(listEnrolment.Count(), enrolmentService.GetCount());
        }
    }
}
