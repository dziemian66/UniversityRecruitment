using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Concrete;
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
            MatureExamService matureExamService = new MatureExamService();
            Item applicant = new Item(1, "Ola", "Fasola", "95050882102", Helpers.FieldsOfStudy.Informatics);
            applicant.ExamResults = matureExamService.GetAllItems();
            applicant.ExamResults[1].Value = polishExam;
            applicant.ExamResults[2].Value = mathExam;
            applicant.ExamResults[3].Value = foreignLanguage;     
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
            MatureExamService matureExamService = new MatureExamService();
            Item applicant = new Item(1, "Ola", "Fasola", "95050882102", Helpers.FieldsOfStudy.Informatics);
            applicant.ExamResults = matureExamService.GetAllItems();
            applicant.ExamResults[0].Value = 30; //minimal value for Polish exam
            applicant.ExamResults[1].Value = 30; //minimal value for math exam
            applicant.ExamResults[2].Value = 30; //minimal value for foreign language exam
            bool maturePassed;
            //Act
            maturePassed = Recruitment.CheckPassMatureExam(applicant.ExamResults);
            //Assert
            maturePassed.Should().Be(true);
        }
    }
}
