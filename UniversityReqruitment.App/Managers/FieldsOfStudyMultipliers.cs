using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.Domain.Utils;
using static UniversityRecruitment.Domain.Utils.Helpers;

namespace UniversityRecruitment.App.Managers
{
    public static class FieldsOfStudyMultipliers
    {
        public static Dictionary<string, float> GetMultipliers(Helpers.FieldsOfStudy fieldsOfStudy)
        {
            Dictionary<string, float> multipliers = new Dictionary<string, float>();

            if (fieldsOfStudy == Helpers.FieldsOfStudy.AutomiationAndRobotics)
            {
                multipliers = CreateMulipliers(0f, 0.8f, 0.2f, 2.0f, 0.4f, 1.6f);
            }
            else if (fieldsOfStudy == Helpers.FieldsOfStudy.Electrotechnics)
            {
                multipliers = CreateMulipliers(0f, 1.0f, 0.2f, 1.5f, 0.5f, 1.8f);
            }
            else if (fieldsOfStudy == Helpers.FieldsOfStudy.Informatics)
            {
                multipliers = CreateMulipliers(0f, 1.0f, 0.7f, 1.5f, 1.3f, 0.5f);
            }

            return multipliers;
        }
        
        private static Dictionary<string, float> CreateMulipliers(float polishBasic, float mathBasic, float foreinLanguageBasic, float mathExtended, 
                                                                    float foreignLanguageExtended, float physicsExtended)
        {
            Dictionary<string, float> multipliers = new Dictionary<string, float>();

            multipliers.Add("PolishBasic", polishBasic);
            multipliers.Add("MathBasic", mathBasic);
            multipliers.Add("ForeignLanguageBasic", foreinLanguageBasic);
            multipliers.Add("MathExtended", mathExtended);
            multipliers.Add("ForeignLanguageExtended", foreignLanguageExtended);
            multipliers.Add("PhysicsExtended", physicsExtended);

            return multipliers;
        }

}
}
