using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityRecruitment.App.Abstract;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;
using UniversityRecruitment.Domain.Utils;
using static UniversityRecruitment.Domain.Utils.Helpers;

namespace UniversityRecruitment.App.Managers.ApplicantManagers
{
    public class ApplicantDisplayingManager
    {
        private ApplicantService _applicantService;
        private MenuActionService _menuActionService = new MenuActionService();
        public ApplicantDisplayingManager(ApplicantService applicantsService)
        {
            _applicantService = applicantsService;
        }
        public void DisplayApplicantsForFieldOfStudy()
        {
            Console.Write("Choose field of study:");
            _menuActionService.DisplayMenuActionsByMenuName("FieldsOfStudy");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out var fieldOfStudy);
            var applicants = _applicantService.Items.Where(a => a.FieldOfStudy == (FieldsOfStudy)fieldOfStudy).ToList(); Console.WriteLine();
          
            if(applicants.Count == 0)
            {
                Console.Write($"Applicant list is empty for {(FieldsOfStudy)fieldOfStudy}!");
            }
            else
            {
                DisplayHeadlines();
                DisplayApplicants(applicants);
            }

            Console.ReadKey();
        }
        public void DisplayEveryApplicants()
        {           
            if (_applicantService.GetAllApplicants().Count == 0)
            {
                Console.Write("Applicant list is empty!");
            }
            else
            {
                DisplayHeadlines();
                DisplayApplicants(_applicantService.GetAllApplicants());
            }
            Console.ReadKey();
        }
        public void DisplayApplicant(int id)
        {
            var applicant = _applicantService.GetApplicantById(id);
            if (applicant == null) return;

            DisplayHeadlines();
            DisplayApplicantDetails(applicant);

            foreach (var result in applicant.ExamResults)
            {
                Console.WriteLine(result.ToString());
            }
            Console.ReadKey();
        }

        private void DisplayApplicantDetails(Item applicant)
        {
            if (applicant == null)
            {
                Console.WriteLine("Applicant doesn't exist");
                return;
            }
            Console.WriteLine(applicant.ToString());
        }
        private void DisplayApplicants(List<Item> applicants)
        {
            foreach (var applicant in applicants)
            {
                DisplayApplicantDetails(applicant);
            }
        }
        private void DisplayHeadlines()
        {
            string headline = $"| {"Id",-3} | {"Name",-13} | {"Surname",-18} |" +
            $" {"Field of study",-22} | {"Points",-6} |";
            Console.WriteLine(headline);
            for (int i = 0; i < headline.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}

