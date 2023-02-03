using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using UniversityRecruitment.App.Managers;
using UniversityRecruitment.Domain.Entity;
using UniversityRecruitment.Domain.Utils;
using UniversityRecruitment.App.Concrete;

namespace UniversityRecruitment.Test.RecruitmentTest
{
    public class GetPointSumTest
    {      
        [Theory]
        [InlineData(Helpers.FieldsOfStudy.AutomiationAndRobotics, 340f)]
        [InlineData(Helpers.FieldsOfStudy.Electrotechnics, 320f)]
        [InlineData(Helpers.FieldsOfStudy.Informatics, 450f)]
        public void GetPointSum_ShouldBeCorrect(Helpers.FieldsOfStudy fieldsOfStudy, float result)
        {
            //Arrange
            float pointSum;
            Item applicant = new Item(1, "Ola", "Fasola", "95050882102", fieldsOfStudy);
            applicant.ExamResults = new List<MatureExam>() 
                {new MatureExam(1, "Basic Polish", false, 100f),
                new MatureExam(2, "Basic math", false, 100f),
                new MatureExam(3, "Basic foreign languageh", false, 100f),
                new MatureExam(4, "Extended math", true, 100f),
                new MatureExam(5, "Extended foreign language", true, 100f),
                new MatureExam(6, "Extended physics", true, 0f)};
            
            //Act
            pointSum = Recruitment.SumPoints(FieldsOfStudyMultipliers.GetMultipliers(fieldsOfStudy), applicant.ExamResults);

            //Assert
            Assert.Equal(result, pointSum);
        }

        [Theory]
        [InlineData(Helpers.FieldsOfStudy.AutomiationAndRobotics, 1f)]
        [InlineData(Helpers.FieldsOfStudy.Electrotechnics, 1f)]
        [InlineData(Helpers.FieldsOfStudy.Informatics, 1f)]
        public void GetPointSum_ShouldBeDifferent(Helpers.FieldsOfStudy fieldsOfStudy, float result)
        {
            //Arrange
            float pointSum;
            Item applicant = new Item(1, "Ola", "Fasola", "95050882102", fieldsOfStudy);
            MatureExamService matureExamService = new MatureExamService();
            var examResults = matureExamService.GetAllItems();
            applicant.ExamResults = new List<MatureExam>()
                {new MatureExam(1, "Basic Polish", false, 100f),
                new MatureExam(2, "Basic math", false, 100f),
                new MatureExam(3, "Basic foreign languageh", false, 100f),
                new MatureExam(4, "Extended math", true, 100f),
                new MatureExam(5, "Extended foreign language", true, 100f),
                new MatureExam(6, "Extended physics", true, 0f)};

            //Act
            pointSum = Recruitment.SumPoints(FieldsOfStudyMultipliers.GetMultipliers(fieldsOfStudy), applicant.ExamResults);
            //Assert
            Assert.NotEqual(result, pointSum);
        }

    }
}
