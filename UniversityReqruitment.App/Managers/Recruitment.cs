using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRecruitment.App.Managers
{
    public static class Recruitment
    {
        const uint MIN_POLISZ_LANGUAGE_EXAM = 30; //Minimum result for polish exam
        const uint MIN_MATH_EXAM = 30; //Minimum result for math exam
        const uint MIN_FOREIGN_LANGUAGE_EXAM = 30; //Minimum result for foreign language exam
        public static float SumPoints(Dictionary<string, float> multipiers, Dictionary<string, float> examResults)
        {
            float sumPoints = 0;

            if (multipiers.Count != examResults.Count)
            {
                Console.WriteLine("Different length of lists");
                return -1;
            }
            for (int i = 0; i < multipiers.Count; i++)
            {
                sumPoints = sumPoints + multipiers.ElementAt(i).Value * examResults.ElementAt(i).Value;
            }
            return sumPoints;
        }
        public static bool CheckPassMaturaExam(Dictionary<string, float> examResults)
        {
            if(CheckPassExam("Basic Polish exam", examResults, MIN_POLISZ_LANGUAGE_EXAM) &&
                CheckPassExam("Basic math exam", examResults, MIN_MATH_EXAM) &&
                CheckPassExam("Basic foreign language exam", examResults, MIN_FOREIGN_LANGUAGE_EXAM))
            {
                return true;
            }

           else
            {
                Console.WriteLine("You cannot add applicant because of failed Matura exam" +
                    "\nPress any key to continue...");
                Console.ReadKey();
                return false;
            }
        }
        private static bool CheckPassExam(string examName, Dictionary<string, float> examResults, uint minimumResult)
        {
            foreach (var result in examResults)
            {
                if (result.Key == examName)
                {
                    if (result.Value >= minimumResult)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
