using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Managers;
using UniversityRecruitment.Domain.Entity;
using UniversityRecruitment.Domain.Utils;
using Xunit;

namespace UniversityRecruitment.Test.RecruitmentTest
{
    public class GetMatureResultTest
    {
        [Theory]
        [InlineData(10f, 10f, 10f)]
        [InlineData(30f, 10f, 10f)]
        [InlineData(10f, 30f, 10f)]
        [InlineData(10f, 10f, 30f)]
        [InlineData(30f, 30f, 10f)]
        [InlineData(10f, 30f, 30f)]
        [InlineData(30f, 10f, 30f)]
        public void GetResultForFailedMatureExam_ShouldReturnFalse(float mathExam, float polishExam, float foreignLanguage)
        {
            //Arrage
            Applicant applicant = new Applicant(1, "Ola", "Fasola", "95050882102", Helpers.FieldsOfStudy.Informatics);
            applicant.ExamResults.Add("Basic Polish exam", polishExam);
            applicant.ExamResults.Add("Basic math exam", mathExam);
            applicant.ExamResults.Add("Basic foreign language exam", foreignLanguage);
            bool maturePassed;
            //Act
            maturePassed = Recruitment.CheckPassMatureExam(applicant.ExamResults);
            //Assert
            maturePassed.Should().Be(false);
        }

        [Fact]
        public void GetResultForPassedMatureExam_ShouldReturnTrue()
        {
            //Arrage
            Applicant applicant = new Applicant(1, "Ola", "Fasola", "95050882102", Helpers.FieldsOfStudy.Informatics);
            applicant.ExamResults.Add("Basic Polish exam", 30);
            applicant.ExamResults.Add("Basic math exam", 30);
            applicant.ExamResults.Add("Basic foreign language exam", 30);
            bool maturePassed;
            //Act
            maturePassed = Recruitment.CheckPassMatureExam(applicant.ExamResults);
            //Assert
            maturePassed.Should().Be(true);
        }
    }
}
