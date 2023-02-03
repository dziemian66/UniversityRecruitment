using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Abstract;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;
using static UniversityRecruitment.Domain.Utils.Helpers;

namespace UniversityRecruitment.App.Managers.ApplicantManagers
{
    public class ApplicantEditingManager
    {
        private ApplicantService _applicantService;
        private MenuActionService _menuActionService = new MenuActionService();
        private ApplicantFindingManager _applicantFindingManager;
        public ApplicantEditingManager(ApplicantService applicantsService)
        {
            _applicantService = applicantsService;
            _applicantFindingManager = new ApplicantFindingManager(_applicantService);
        }
        public void EditApplicant()
        {
            var applicantIdToEdit = _applicantFindingManager.FindApplicant();
            if (applicantIdToEdit == -2)
            {
                return;
            }
            if (applicantIdToEdit == -1)
            {
                Console.WriteLine("Applicant doesn't exist...");
                Console.ReadKey();
                return;
            }

            _menuActionService.DisplayMenuActionsByMenuName("EditingApplicant");
            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    EditApplicantFullname(_applicantService.GetApplicantById(applicantIdToEdit));
                    break;
                case '2':
                    EditApplicantFieldOfStudy(_applicantService.GetApplicantById(applicantIdToEdit));
                    break;
                default:
                    Console.WriteLine("Wrong action! \n Press any key to continue...");
                    Console.ReadKey();
                    return;
            }
            _applicantService.GetApplicantById(applicantIdToEdit).ModifiedDateTime= DateTime.Now;
        }

        private void EditApplicantFullname(Item applicant)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            applicant.Name = name;
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            applicant.Surname = surname;
        }
        private void EditApplicantFieldOfStudy(Item applicant)
        {
            Console.WriteLine("Choose new field of study:");
            _menuActionService.DisplayMenuActionsByMenuName("FieldsOfStudy");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out var fieldsOfStudy);
            applicant.FieldOfStudy = (FieldsOfStudy)fieldsOfStudy;
            applicant.PointsSum = Recruitment.SumPoints(FieldsOfStudyMultipliers.GetMultipliers(applicant.FieldOfStudy), applicant.ExamResults);
        }
    }
}
