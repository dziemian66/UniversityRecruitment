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
            Applicant applicant = new Applicant(1, "Ola", "Fasola", "95050882102", fieldsOfStudy);
            var examResults = new Dictionary<string, float>()
            {
                {"Basic Polish exam", 100f},
                {"Basic math exam", 100f},
                {"Basic foreign language exam", 100f},
                {"Extended math exam", 100f},
                {"Extended foreign language exam", 100f},
                {"Extended physics exam", 0f}
            };
            applicant.ExamResults = examResults;
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
            Applicant applicant = new Applicant(1, "Ola", "Fasola", "95050882102", fieldsOfStudy);
            var examResults = new Dictionary<string, float>()
            {
                {"Basic Polish exam", 100f},
                {"Basic math exam", 100f},
                {"Basic foreign language exam", 100f},
                {"Extended math exam", 100f},
                {"Extended foreign language exam", 100f},
                {"Extended physics exam", 0f}
            };
            applicant.ExamResults = examResults;
            //Act
            pointSum = Recruitment.SumPoints(FieldsOfStudyMultipliers.GetMultipliers(fieldsOfStudy), applicant.ExamResults);
            //Assert
            Assert.NotEqual(result, pointSum);
        }

    }
}
