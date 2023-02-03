using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Utils;
using static UniversityRecruitment.Domain.Utils.Helpers;

namespace UniversityRecruitment.App.Managers
{
    public static class FieldsOfStudyMultipliers
    {

        public static List<float> GetMultipliers(Domain.Utils.Helpers.FieldsOfStudy fieldsOfStudy)
        {
            List<float> multipliers = new List<float>();

            if (fieldsOfStudy == Domain.Utils.Helpers.FieldsOfStudy.AutomiationAndRobotics)
            {
                multipliers = new List<float>() { 0f, 0.8f, 0.2f, 2.0f, 0.4f, 1.6f };
            }
            else if (fieldsOfStudy == Domain.Utils.Helpers.FieldsOfStudy.Electrotechnics)
            {
                multipliers = new List<float> { 0f, 1.0f, 0.2f, 1.5f, 0.5f, 1.8f };
            }
            else if (fieldsOfStudy == Domain.Utils.Helpers.FieldsOfStudy.Informatics)
            {
                multipliers = new List<float> { 0f, 1.0f, 0.7f, 1.5f, 1.3f, 0.5f };
            }
            return multipliers;
        }
    }
}
