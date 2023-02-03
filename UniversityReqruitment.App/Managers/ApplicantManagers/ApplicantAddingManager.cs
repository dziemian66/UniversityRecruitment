using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Abstract;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;
using UniversityRecruitment.Domain.Utils;

namespace UniversityRecruitment.App.Managers.ApplicantManagers
{

    public class ApplicantAddingManager
    {
        private ApplicantService _applicantService;
        private MenuActionService _menuActionService = new MenuActionService();
        public ApplicantAddingManager(ApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        public void AddNewApplicant()
        {
            Item applicant;

            Console.WriteLine("Complete the application:");
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Surname: ");
            var surname = Console.ReadLine();

            Console.Write("PESEL: ");
            var pesel = Console.ReadLine();

            Console.Write("Choose field of study:");
            _menuActionService.DisplayMenuActionsByMenuName("FieldsOfStudy");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out var fieldsOfStudy); Console.WriteLine();

            var applicantId = _applicantService.GetLastId() + 1;

            applicant = new Item(applicantId, name, surname, pesel, (Helpers.FieldsOfStudy)fieldsOfStudy);
            applicant.CreatedDateTime = DateTime.Now;
            applicant.ExamResults = AddExamResults();

            if (!Recruitment.IsCorrectResults(applicant.ExamResults) || !Recruitment.CheckPassMatureExam(applicant.ExamResults))
            {
                Console.WriteLine("Incorrect exam results...");
                Console.ReadKey();
                return;
            }

            applicant.PointsSum = Recruitment.SumPoints(FieldsOfStudyMultipliers.GetMultipliers(applicant.FieldOfStudy), applicant.ExamResults);
            _applicantService.AddItem(applicant);
        }
        public List<MatureExam> AddExamResults()
        {
            MatureExamService matureExamService = new MatureExamService();
            float value;
            foreach (var item in matureExamService.GetAllItems())
            {
                Console.Write($"{item.Name} exam result: ");
                float.TryParse(Console.ReadLine(), out value);
                item.Value = value;
            }

            return matureExamService.GetAllItems();
        }
    }
}
