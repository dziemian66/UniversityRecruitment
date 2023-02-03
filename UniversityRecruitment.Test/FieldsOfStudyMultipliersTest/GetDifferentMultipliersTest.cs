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
            List<float> incorrectAutomiationAndRoboticsMultipliers = new List<float>()
            {0, 0.8f, 0.2f, 2.0f, 0.4f,
                                        0f}; //Different value
            List<float> returnedMultipliers = new List<float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.AutomiationAndRobotics);

            //Assert
            Assert.NotEqual(returnedMultipliers, incorrectAutomiationAndRoboticsMultipliers);
        }

        [Fact]
        public void GetResultForElectrotechnics_ShouldReturnDifferentValues()
        {
            //Arrage
            List<float> incorrectElectrotechnicsMultipliers = new List<float>()
            {0, 1.0f, 0.2f, 1.5f, 0.5f,
                                     0f}; //Different value
            List<float> returnedMultipliers = new List<float>();
           
            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Electrotechnics);

            //Assert     
            Assert.NotEqual(returnedMultipliers, incorrectElectrotechnicsMultipliers);
        }

        [Fact]
        public void GetResultForInformatnics_ShouldReturnDifferentValues()
        {
            //Arrage

            List<float> incorrectInformaticsMultipliers = new List<float>()
            {0, 1.0f, 0.7f, 1.5f, 1.3f,
                                     0f}; //Different value
            List<float> returnedMultipliers = new List<float>();

            //Act
            returnedMultipliers = FieldsOfStudyMultipliers.GetMultipliers(Helpers.FieldsOfStudy.Informatics);

            //Assert
            Assert.NotEqual(returnedMultipliers, incorrectInformaticsMultipliers);        
        }
    }
}
