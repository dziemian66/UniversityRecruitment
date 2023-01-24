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
    public class GetDifferentMultipliersTest
    {
        [Fact]
        public void GetResultForAutomiationAndRobotics_ShouldReturnDifferentValues()
        {
            //Arrage
            Dictionary<string, float> incorrectAutomiationAndRoboticsMultipliers = new Dictionary<string, float>() {
                {"PolishBasic", 0f},
                {"MathBasic", 0.8f},
                {"ForeignLanguageBasic", 0.2f},
                {"MathExtended", 2.0f},
                {"ForeignLanguageExtended", 0.4f},
                {"PhysicsExtended", 0f} //Different value
            };
            Dictionary<string, float> returnedMultipliers = new Dictionary<string, float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.AutomiationAndRobotics);

            //Assert
            Assert.Equal(returnedMultipliers.Keys, incorrectAutomiationAndRoboticsMultipliers.Keys);
            Assert.NotEqual(returnedMultipliers.Values, incorrectAutomiationAndRoboticsMultipliers.Values);
        }

        [Fact]
        public void GetResultForElectrotechnics_ShouldReturnDifferentValues()
        {
            //Arrage
            Dictionary<string, float> incorrectElectrotechnicsMultipliers = new Dictionary<string, float>() {
                {"PolishBasic", 0f},
                {"MathBasic", 1.0f},
                {"ForeignLanguageBasic", 0.2f},
                {"MathExtended", 1.5f},
                {"ForeignLanguageExtended", 0.5f},
                {"PhysicsExtended", 0f} //Different value
            };
            Dictionary<string, float> returnedMultipliers = new Dictionary<string, float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Electrotechnics);

            //Assert     
            Assert.Equal(returnedMultipliers.Keys, incorrectElectrotechnicsMultipliers.Keys);
            Assert.NotEqual(returnedMultipliers.Values, incorrectElectrotechnicsMultipliers.Values);
        }

        [Fact]
        public void GetResultForInformatnics_ShouldReturnDifferentValues()
        {
            //Arrage
            Dictionary<string, float> incorrectInformaticsMultipliers = new Dictionary<string, float>() {
              {"PolishBasic", 0f},
              {"MathBasic", 1.0f},
              {"ForeignLanguageBasic", 0.7f},
              {"MathExtended", 1.5f},
              {"ForeignLanguageExtended", 1.3f},
              {"PhysicsExtended", 0f} //Different value
            };
            Dictionary<string, float> returnedMultipliers = new Dictionary<string, float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Informatics);

            //Assert
            Assert.Equal(returnedMultipliers.Keys, incorrectInformaticsMultipliers.Keys);
            Assert.NotEqual(returnedMultipliers.Values, incorrectInformaticsMultipliers.Values);        
        }
    }
}
