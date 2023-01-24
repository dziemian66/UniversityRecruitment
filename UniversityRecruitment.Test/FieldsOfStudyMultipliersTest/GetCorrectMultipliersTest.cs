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
            Dictionary<string, float> correctAutomiationAndRoboticsMultipliers = new Dictionary<string, float>() {
                {"PolishBasic", 0f},
                {"MathBasic", 0.8f},
                {"ForeignLanguageBasic", 0.2f},
                {"MathExtended", 2.0f},
                {"ForeignLanguageExtended", 0.4f},
                {"PhysicsExtended", 1.6f}
            };
            Dictionary<string, float> returnedMultipliers = new Dictionary<string, float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.AutomiationAndRobotics);

            //Assert
            Assert.Equal(returnedMultipliers.Values, correctAutomiationAndRoboticsMultipliers.Values);
            Assert.Equal(returnedMultipliers.Keys, correctAutomiationAndRoboticsMultipliers.Keys);
        }

        [Fact]
        public void GetResultForElectrotechnics_ShouldReturnSameMultipliers()
        {
            //Arrage
            Dictionary<string, float> correctElectrotechnicsMultipliers = new Dictionary<string, float>() {
                {"PolishBasic", 0f},
                {"MathBasic", 1.0f},
                {"ForeignLanguageBasic", 0.2f},
                {"MathExtended", 1.5f},
                {"ForeignLanguageExtended", 0.5f},
                {"PhysicsExtended", 1.8f}
            };
            Dictionary<string, float> returnedMultipliers = new Dictionary<string, float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Electrotechnics);

            //Assert
            Assert.Equal(returnedMultipliers.Values, correctElectrotechnicsMultipliers.Values);
            Assert.Equal(returnedMultipliers.Keys, correctElectrotechnicsMultipliers.Keys);
        }

        [Fact]
        public void GetResultForInformatnics_ShouldReturnSameMultipliers()
        {
            //Arrage
            Dictionary<string, float> correctInformaticsMultipliers = new Dictionary<string, float>() {
              {"PolishBasic", 0f},
              {"MathBasic", 1.0f},
              {"ForeignLanguageBasic", 0.7f},
              {"MathExtended", 1.5f},
              {"ForeignLanguageExtended", 1.3f},
              {"PhysicsExtended", 0.5f}
            };
            Dictionary<string, float> returnedMultipliers = new Dictionary<string, float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Informatics);

            //Assert
            Assert.Equal(returnedMultipliers.Values, correctInformaticsMultipliers.Values);
            Assert.Equal(returnedMultipliers.Keys, correctInformaticsMultipliers.Keys);
        }
    }
}
