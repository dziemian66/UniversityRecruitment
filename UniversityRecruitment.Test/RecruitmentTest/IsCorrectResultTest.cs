using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Managers;
using UniversityRecruitment.Domain.Entity;
using Xunit;

namespace UniversityRecruitment.Test.RecruitmentTest
{
    public class IsCorrectResultTest
    {
        [Fact]
        public void CheckTooSmallResults_ShouldReturnFalse()
        {
            //Arrange
            List<MatureExam> resltTocheck = new List<MatureExam>() 
                { new MatureExam(1, "Basic Polish", false, -10f),
                    new MatureExam(2, "Basic math", false, -1f)};
            bool isCorrecnt;
            //Act
            isCorrecnt = Recruitment.IsCorrectResults(resltTocheck);
            //Assert
            Assert.False(isCorrecnt);
        }
        [Fact]
        public void CheckTooHighResults_ShouldReturnFalse()
        {
            //Arrange
            List<MatureExam> resltTocheck = new List<MatureExam>()
                { new MatureExam(1, "Basic Polish", false, 101f),
                    new MatureExam(2, "Basic math", false, 101f)};
            bool isCorrecnt;
            //Act
            isCorrecnt = Recruitment.IsCorrectResults(resltTocheck);
            //Assert
            Assert.False(isCorrecnt);
        }
        [Fact]
        public void CheckCorrectResults_ShouldReturnTrue()
        {
            //Arrange
            List<MatureExam> resltTocheck = new List<MatureExam>()
                { new MatureExam(1, "Basic Polish", false, 0f),
                    new MatureExam(2, "Basic math", false, 100f)};
            bool isCorrecnt;
            //Act
            isCorrecnt = Recruitment.IsCorrectResults(resltTocheck);
            //Assert
            Assert.True(isCorrecnt);
        }
    }
}
