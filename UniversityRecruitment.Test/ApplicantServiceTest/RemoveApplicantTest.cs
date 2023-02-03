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
    public class RemoveApplicantTest
    {
        [Fact]
        public void RemoveApplicant_ListShouldNotIncludesThisApplicant()
        {
            //Arrange
            Item applicant = new Item(1, "Piotr", "Kowalski", "99111112747", Helpers.FieldsOfStudy.AutomiationAndRobotics);
            ApplicantService _applicantService = new ApplicantService();

            _applicantService.AddItem(applicant);
            _applicantService.AddItem(new Item(2, "Kamil", "Kozłowski", "98061114103", Helpers.FieldsOfStudy.Electrotechnics));

            //Act
            _applicantService.RemoveApplicant(1);
            //Assert
            Assert.DoesNotContain(applicant, _applicantService.Items);
            Assert.NotEmpty(_applicantService.Items);
        }
    }
}
