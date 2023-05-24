using cursuri_studenti.enrolment.model;
using cursuri_studenti.enrolment.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests_cursuri_studenti.Tests
{
    public class TestEnrolment
    {
        // Testing Enrolment Service

        [Fact]
        public void FindById_ValidMatch_ReturnsEnrolment()
        {
            // Arrange
            int Id = 123;
            Enrolment expectedEnrolment = new Enrolment(Id, 123, 123);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            Enrolment actualEnrolment = enrolmentService.FindById(Id);

            // Assert
            Assert.NotNull(actualEnrolment);
            Assert.Equal(expectedEnrolment.Id, actualEnrolment.Id);
            Assert.Equal(expectedEnrolment.StudentId, actualEnrolment.StudentId);
            Assert.Equal(expectedEnrolment.CourseId, actualEnrolment.CourseId);
        }

        [Fact]
        public void FindById_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 123;
            List<Enrolment> list = new List<Enrolment>();
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            Enrolment actualEnrolment = enrolmentService.FindById(id);

            // Assert
            Assert.Null(actualEnrolment);
        }

        [Fact]
        public void FindById_MultipleEnrolments_ReturnsCorrectEnrolment()
        {
            // Arrange
            int Id = 123;
            Enrolment expectedEnrolment = new Enrolment(Id, 123, 123);
            Enrolment anotherEnrolment = new Enrolment(101, 100, 100);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment, anotherEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            Enrolment actualEnrolment = enrolmentService.FindById(Id);

            // Assert
            Assert.NotNull(actualEnrolment);
            Assert.Equal(expectedEnrolment.Id, actualEnrolment.Id);
            Assert.Equal(expectedEnrolment.StudentId, actualEnrolment.StudentId);
            Assert.Equal(expectedEnrolment.CourseId, actualEnrolment.CourseId);
        }

        [Fact]
        public void FindByStudentAndCourseId_ValidMatch_ReturnsEnrolment()
        {
            // Arrange
            int StudentId = 123, CourseId = 123;
            Enrolment expectedEnrolment = new Enrolment(123, StudentId, CourseId);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            Enrolment actualEnrolment = enrolmentService.FindByStudentAndCourseId(StudentId, CourseId);

            // Assert
            Assert.NotNull(actualEnrolment);
            Assert.Equal(expectedEnrolment.Id, actualEnrolment.Id);
            Assert.Equal(expectedEnrolment.StudentId, actualEnrolment.StudentId);
            Assert.Equal(expectedEnrolment.CourseId, actualEnrolment.CourseId);
        }

        [Fact]
        public void FindByStudentAndCourseId_NoMatch_ReturnsNull()
        {
            // Arrange
            int StudentId = 123, CourseId = 123;
            List<Enrolment> list = new List<Enrolment> { };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            Enrolment actualEnrolment = enrolmentService.FindByStudentAndCourseId(StudentId, CourseId);

            // Assert
            Assert.Null(actualEnrolment);
        }

        [Fact]
        public void FindByStudentAndCourseId_MultipleEnrolments_ReturnsCorrectEnrolment()
        {
            // Arrange
            int StudentId = 123, CourseId = 123;
            Enrolment expectedEnrolment = new Enrolment(123, StudentId, CourseId);
            Enrolment anotherEnrolment = new Enrolment(101, 100, 100);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            Enrolment actualEnrolment = enrolmentService.FindByStudentAndCourseId(StudentId, CourseId);

            // Assert
            Assert.NotNull(actualEnrolment);
            Assert.Equal(expectedEnrolment.Id, actualEnrolment.Id);
            Assert.Equal(expectedEnrolment.StudentId, actualEnrolment.StudentId);
            Assert.Equal(expectedEnrolment.CourseId, actualEnrolment.CourseId);
        }

        [Fact]
        public void FindByCourseId_ValidMatch_ReturnsEnrolment()
        {
            // Arrange
            int CourseId = 123;
            Enrolment expectedEnrolment = new Enrolment(123, 123, CourseId);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            List<Enrolment> enrolments = enrolmentService.FindByCourseId(CourseId);

            // Assert
            Assert.NotNull(enrolments[0]);
            Assert.Equal(expectedEnrolment.Id, enrolments[0].Id);
            Assert.Equal(expectedEnrolment.StudentId, enrolments[0].StudentId);
            Assert.Equal(expectedEnrolment.CourseId, enrolments[0].CourseId);
        }

        [Fact]
        public void FindByCourseId_NoMatch_ReturnsNull()
        {
            // Arrange
            int CourseId = 123;
            List<Enrolment> list = new List<Enrolment>();
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            List<Enrolment> enrolments = enrolmentService.FindByCourseId(CourseId);

            // Assert
            Assert.Empty(enrolments);
        }

        [Fact]
        public void FindByCourseId_MultipleEnrolments_ReturnsCorrectEnrolment()
        {
            // Arrange
            int CourseId = 123;
            Enrolment expectedEnrolment = new Enrolment(123, 123, CourseId);
            Enrolment anotherEnrolment = new Enrolment(101, 100, 100);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment, anotherEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            List<Enrolment> enrolments = enrolmentService.FindByCourseId(CourseId);

            // Assert
            Assert.NotNull(enrolments[0]);
            Assert.Equal(expectedEnrolment.Id, enrolments[0].Id);
            Assert.Equal(expectedEnrolment.StudentId, enrolments[0].StudentId);
            Assert.Equal(expectedEnrolment.CourseId, enrolments[0].CourseId);
        }

        [Fact]
        public void FindByStudentId_ValidMatch_ReturnsEnrolment()
        {
            // Arrange
            int StudentId = 111;
            Enrolment expectedEnrolment = new Enrolment(123, StudentId, 123);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            List<Enrolment> enrolments = enrolmentService.FindByStudentId(StudentId);

            // Assert
            Assert.NotNull(enrolments[0]);
            Assert.Equal(expectedEnrolment.Id, enrolments[0].Id);
            Assert.Equal(expectedEnrolment.StudentId, enrolments[0].StudentId);
            Assert.Equal(expectedEnrolment.CourseId, enrolments[0].CourseId);
        }

        [Fact]
        public void FindByStudentId_NoMatch_ReturnsNull()
        {
            // Arrange
            int StudentId = 111;
            List<Enrolment> list = new List<Enrolment>();
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            List<Enrolment> enrolments = enrolmentService.FindByStudentId(StudentId);

            // Assert
            Assert.Empty(enrolments);
        }

        [Fact]
        public void FindByStudentId_MultipleEnrolments_ReturnsCorrectEnrolment()
        {
            // Arrange
            int StudentId = 111;
            Enrolment expectedEnrolment = new Enrolment(123, StudentId, 123);
            Enrolment anotherEnrolment = new Enrolment(101, 100, 3123);
            List<Enrolment> list = new List<Enrolment> { expectedEnrolment, anotherEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            List<Enrolment> enrolments = enrolmentService.FindByStudentId(StudentId);

            // Assert
            Assert.NotNull(enrolments[0]);
            Assert.Equal(expectedEnrolment.Id, enrolments[0].Id);
            Assert.Equal(expectedEnrolment.StudentId, enrolments[0].StudentId);
            Assert.Equal(expectedEnrolment.CourseId, enrolments[0].CourseId);
        }

        [Fact]
        public void NewId_ReturnsUnusedId()
        {
            // Arrange
            int Id1 = 12, Id2 = 101;
            Enrolment aEnrolment = new Enrolment(Id1, 111, 111);
            Enrolment anotherEnrolment = new Enrolment(Id2, 222, 222);
            List<Enrolment> list = new List<Enrolment> { aEnrolment, anotherEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            int newId = enrolmentService.NewId();

            // Assert
            Assert.Null(enrolmentService.FindById(newId));
            Assert.NotEqual(Id1, newId);
            Assert.NotEqual(Id2, newId);
            Assert.InRange(newId, 1, 9999);
        }

        // TODO: REMOVE, ADD, COUNT ENROLED

        [Fact]
        public void GetCount_ReturnsActualCount()
        {
            // Arrange
            Enrolment aEnrolment = new Enrolment(111, 111, 111);
            List<Enrolment> list = new List<Enrolment> { aEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            int count = enrolmentService.GetCount();

            // Assert
            Assert.Equal(list.Count(), count);
        }

        [Fact]
        public void ClearList_ListRemainsEmpty()
        {
            // Arrange
            Enrolment aEnrolment = new Enrolment(111, 111, 111);
            List<Enrolment> list = new List<Enrolment> { aEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            enrolmentService.ClearList();

            // Assert
            Assert.Equal(0, enrolmentService.GetCount());
            Assert.Empty(enrolmentService.GetList());
        }

        [Fact]
        public void GetList_ReturnsActualList()
        {
            // Arrange
            Enrolment aEnrolment = new Enrolment(111, 111, 111);
            List<Enrolment> expectedList = new List<Enrolment> { aEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(expectedList);

            // Act
            List<Enrolment> actualList = enrolmentService.GetList();

            // Assert
            Assert.Equal(expectedList, actualList);
            Assert.Equal(expectedList.Count(), actualList.Count());
        }

        [Fact]
        public void SetList_EditsList()
        {
            // Arrange
            Enrolment aEnrolment = new Enrolment(111, 111, 111);
            List<Enrolment> list = new List<Enrolment>();
            List<Enrolment> setList = new List<Enrolment> { aEnrolment };
            EnrolmentService enrolmentService = new EnrolmentService(list);

            // Act
            enrolmentService.SetList(setList);

            // Assert
            Assert.Equal(setList, enrolmentService.GetList());
            Assert.Equal(setList.Count(), enrolmentService.GetCount());
            Assert.NotEqual(list, enrolmentService.GetList());
        }
    }
}
