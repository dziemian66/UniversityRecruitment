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
    public class GetApplicantsTest
    {
        void InitializeApplicantsList(ApplicantService _applicantService)
        {            
            _applicantService.AddItem(new Item(1, "Piotr", "Kowalski", "99111112747", Helpers.FieldsOfStudy.Electrotechnics));
            _applicantService.AddItem(new Item(2, "Kamil", "Prus", "92111112747", Helpers.FieldsOfStudy.Electrotechnics));
            _applicantService.AddItem(new Item(3, "Michał", "Zieliński", "96112112642", Helpers.FieldsOfStudy.Electrotechnics));
            _applicantService.AddItem(new Item(4, "Ula", "Wójcik", "9904112512", Helpers.FieldsOfStudy.Informatics));
            _applicantService.AddItem(new Item(5, "Adam", "Kamiński", "9705112717", Helpers.FieldsOfStudy.Informatics));
            _applicantService.AddItem(new Item(6, "Robert", "Lewandowski", "8902042163", Helpers.FieldsOfStudy.AutomiationAndRobotics));
            _applicantService.AddItem(new Item(7, "Wojciech", "Wiśniewski", "9403015231", Helpers.FieldsOfStudy.AutomiationAndRobotics));
            _applicantService.AddItem(new Item(8, "Adam", "Lul", "92030757341", Helpers.FieldsOfStudy.Informatics));
            _applicantService.AddItem(new Item(9, "Karol", "Kokos", "96101018122", Helpers.FieldsOfStudy.Informatics));
        }
        [Fact]
        public void GetAllApplicants_ListShouldContainAllElements()
        {
            //Arrange
            ApplicantService _applicantService = new ApplicantService();
            InitializeApplicantsList(_applicantService);
            List<Item> applicantsList; 
            //Act
            applicantsList = _applicantService.GetAllApplicants();
            //Assert
            applicantsList.Should().NotBeEmpty();
            applicantsList.Should().AllBeOfType(typeof(Item));
        }
        [Theory]
        [InlineData(2, Helpers.FieldsOfStudy.AutomiationAndRobotics)]
        [InlineData(3, Helpers.FieldsOfStudy.Electrotechnics)]
        [InlineData(4, Helpers.FieldsOfStudy.Informatics)]
        public void GetApplicantsByFieldOfStudy_ListShouldContainCorrectFieldOfStudy(int numberOfApplicants, Helpers.FieldsOfStudy fieldsOfStudy)
        {
            //Arrange
            ApplicantService _applicantService = new ApplicantService();
            InitializeApplicantsList(_applicantService);
            List<Item> applicantsList;
            //Act
            applicantsList = _applicantService.GetApplicantsByFieldsOfStudy(fieldsOfStudy);
            //Assert
            applicantsList.Should().NotBeEmpty();
            applicantsList.Should().HaveCount(numberOfApplicants);
            Assert.True(applicantsList[0].FieldOfStudy == fieldsOfStudy);  
        }
        [Fact]
        public void GetApplicantById_ShouldReturnCorrectApplicant()
        {
            //Arrange
            Item returnedApplicant;
            Item applicant = new Item(10, "Krzysztof", "Krawczyk", "98091017202", Helpers.FieldsOfStudy.Informatics);
            ApplicantService _applicantService = new ApplicantService();
            InitializeApplicantsList(_applicantService);
            _applicantService.AddItem(applicant);

            //Act
            returnedApplicant = _applicantService.GetItemById(10);

            //Assert 
            returnedApplicant.Should().NotBeNull();
            returnedApplicant.Should().BeSameAs(applicant);
        }
    }
}
