using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;
using UniversityRecruitment.Domain.Utils;
using Xunit;

namespace UniversityRecruitment.Test.ApplicantServiceTest
{
    public class AddApplicantTest
    {
        [Fact]
        public void AddApplicant_ListShouldContainApplicant()
        {
            //Arrange
            Item applicant = new Item(1, "Piotr", "Kowalski", "99111112747", Helpers.FieldsOfStudy.AutomiationAndRobotics);
            ApplicantService _applicantService = new ApplicantService();

            //Act
            _applicantService.AddItem(applicant);

            //Assert
            Assert.NotEmpty(_applicantService.Items);
            Assert.Contains<Item>(applicant, _applicantService.Items);
        }

        [Fact]
        public void AddApplicantAndGetId_IdShouldBeCorrect()
        {
            //Arrange
            Item applicant = new Item(2, "Piotr", "Kowalski", "99111112747", Helpers.FieldsOfStudy.AutomiationAndRobotics);
            ApplicantService _applicantService = new ApplicantService();
            int lastId;
            //Act
            _applicantService.AddNewApplicant(applicant);
            lastId = _applicantService.GetLastId();
            //Assert
            Assert.Equal(lastId, applicant.Id);
        }

        [Fact]
        public void AddDifferentApplicant_ListShouldNotContainCorrectApplicant()
        {
            //Arrange
            Item applicant = new Item(1, "Piotr", "Kowalski", "99111112747", Helpers.FieldsOfStudy.AutomiationAndRobotics);
            ApplicantService _applicantService = new ApplicantService();

            //Act
            _applicantService.AddItem(new Item(2, "Piotr", "Kowalewski", "99111112748", Helpers.FieldsOfStudy.AutomiationAndRobotics));

            //Assert
            Assert.DoesNotContain<Item>(applicant, _applicantService.Items);
        }
    }
}
