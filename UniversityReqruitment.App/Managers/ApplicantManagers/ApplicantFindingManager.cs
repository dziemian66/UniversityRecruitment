using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityRecruitment.App.Abstract;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;

namespace UniversityRecruitment.App.Managers.ApplicantManagers
{
    public class ApplicantFindingManager
    {
        private ApplicantService _applicantService;
        private MenuActionService _menuActionService = new MenuActionService();

        public ApplicantFindingManager(ApplicantService applicantsService)
        {
            _applicantService = applicantsService;
        }
        public int FindApplicant()
        {
            var applicantid = 0;

            Console.Write("Search by: ");
            _menuActionService.DisplayMenuActionsByMenuName("FindingApplicant");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    applicantid = FindByFullName();
                    break;
                case '2':
                    applicantid = FindByPesel();
                    break;
                case '3':
                    applicantid = FindById();
                    break;
                default:
                    Console.WriteLine("Wrong action! \n Press any key to continue...");
                    Console.ReadKey();
                    return -2;
            }
            return applicantid;
        }

        public int FindById()
        {
            int id;
            Console.Write("Applicant ID: ");
            int.TryParse(Console.ReadLine(), out id);
            var applicant = _applicantService.GetAllItems().FirstOrDefault(a => a.Id == id);
            return IsExist(applicant);
        }
        public int FindByFullName()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            var applicant = _applicantService.GetAllItems().FirstOrDefault(a => a.Name == name & a.Surname == surname);

            return IsExist(applicant);
        }
        public int FindByPesel()
        {
            Console.Write("PESEL: ");
            string pesel = Console.ReadLine();
            var applicant = _applicantService.GetAllItems().FirstOrDefault(a => a.Pesel == pesel);

            return IsExist(applicant);
        }
        private int IsExist(Item applicant)
        {
            if (applicant != null)
            {
                return applicant.Id;
            }
            else
            {
                return -1;
            }
        }
    }
}
