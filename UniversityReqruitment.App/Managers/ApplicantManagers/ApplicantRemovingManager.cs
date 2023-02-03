using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Abstract;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;

namespace UniversityRecruitment.App.Managers.ApplicantManagers
{
    public class ApplicantRemovingManager
    {
        private ApplicantService _applicantService;
        private ApplicantFindingManager _applicantFindingManager;
        private MenuActionService _menuActionService = new MenuActionService();
        public ApplicantRemovingManager(ApplicantService applicantsService)
        {
            _applicantService = applicantsService;
            _applicantFindingManager = new ApplicantFindingManager(_applicantService);
        }
        public void RemoveApplicant()
        {
            int applicantIdToRemove;

            Console.Write("Remove by:");
            _menuActionService.DisplayMenuActionsByMenuName("FindingApplicant");

            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    applicantIdToRemove = _applicantFindingManager.FindByFullName();
                    break;
                case '2':
                    applicantIdToRemove = _applicantFindingManager.FindByPesel();
                    break;
                case '3':
                    applicantIdToRemove = _applicantFindingManager.FindById();
                    break;
                default:
                    Console.WriteLine("Wrong action! \n Press any key to continue...");
                    Console.ReadKey();
                    return;
            }
            if (applicantIdToRemove > 0)
            {
                if (UserActionManager.ConfirmSelection("delete applicant"))
                    _applicantService.RemoveApplicant(applicantIdToRemove);
            }
            else
            {
                Console.WriteLine("Applicant doesn't exist...");
                Console.ReadKey();
            }

        }

    }
}
