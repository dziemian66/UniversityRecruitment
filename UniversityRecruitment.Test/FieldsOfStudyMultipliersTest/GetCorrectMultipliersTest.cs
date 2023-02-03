using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using UniversityRecruitment.App.Managers;
using UniversityRecruitment.Domain.Utils;


namespace UniversityRecruitment.Test.FieldsOfStudyMultipliersTest
{
    public class GetCorrectMultipliersTest
    {
        [Fact]
        public void GetResultForAutomiationAndRobotics_ShouldReturnSameMultipliers()
        {
            //Arrage
            List<float> correctAutomiationAndRoboticsMultipliers = new List<float>()
            {0, 0.8f, 0.2f, 2.0f, 0.4f, 1.6f};
            List<float> returnedMultipliers = new List<float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.AutomiationAndRobotics);

            //Assert
           
            Assert.Equal(returnedMultipliers, correctAutomiationAndRoboticsMultipliers);
        }

        [Fact]
        public void GetResultForElectrotechnics_ShouldReturnSameMultipliers()
        {
            //Arrage
            List<float> correctElectrotechnicsMultipliers = new List<float>()
            {0, 1.0f, 0.2f, 1.5f, 0.5f, 1.8f};
            List<float> returnedMultipliers = new List<float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Electrotechnics);

            //Assert
            Assert.Equal(returnedMultipliers, correctElectrotechnicsMultipliers);
        }

        [Fact]
        public void GetResultForInformatnics_ShouldReturnSameMultipliers()
        {
            //Arrage

            List<float> correctInformaticsMultipliers = new List<float>()
            {0, 1.0f, 0.7f, 1.5f, 1.3f, 0.5f};
            List<float> returnedMultipliers = new List<float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Informatics);

            //Assert
            Assert.Equal(returnedMultipliers, correctInformaticsMultipliers);
            
        }
    }
}
