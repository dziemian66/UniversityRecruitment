using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;

namespace UniversityRecruitment.App.Managers
{
    public static class Recruitment 
    {
        //Minimum result for...
        const float MIN_POLISH_LANGUAGE_EXAM = 30; //Polish exam
        const float MIN_MATH_EXAM = 30; //math exam
        const float MIN_FOREIGN_LANGUAGE_EXAM = 30; //foreign language exam

        public static float SumPoints(List<float> multipiers, List<MatureExam> examResults)
        {
            float sumPoints = 0;

            if (multipiers.Count != examResults.Count)
            {
                Console.WriteLine("Different length of lists");
                return -1;
            }
            for (int i = 0; i < multipiers.Count; i++)
            {
                sumPoints = sumPoints + multipiers.ElementAt(i) * examResults.ElementAt(i).Value;
            }
            return sumPoints;
        }
        public static bool IsCorrectResults(List<MatureExam> examResults)
        {
            return examResults.All(e => e.Value >= 0 & e.Value <= 100);
        }
        public static bool CheckPassMatureExam(List<MatureExam> examResults)
        {
            MatureExamService _matureExamService = new MatureExamService();

            if (CheckPassExam(_matureExamService.GetItemById(1).Name, examResults, MIN_POLISH_LANGUAGE_EXAM) &&
                CheckPassExam(_matureExamService.GetItemById(2).Name, examResults, MIN_MATH_EXAM) &&
                CheckPassExam(_matureExamService.GetItemById(3).Name, examResults, MIN_FOREIGN_LANGUAGE_EXAM))
            {
                return true;
            }

           else
            {
                return false;
            }
        }
        private static bool CheckPassExam(string examName, List<MatureExam> examResults, float minimumResult)
        {
            foreach (var result in examResults)
            {
                if (result.Name == examName)
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
