using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.Domain.Entity;
using UniversityRecruitment.Domain.Utils;

namespace UniversityRecruitment.App.Managers
{
    public class ApplicantManager
    {
        private ApplicantService _applicantService = new ApplicantService();
        private MenuActionService _menuActionService = new MenuActionService();

        public void AddNewApplicant()
        {
            Applicant applicant;

            Console.WriteLine("\nComplete the application:");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            
            Console.Write("Surname: ");
            var surname = Console.ReadLine();

            Console.Write("PESEL: ");
            var pesel = Console.ReadLine();

            Console.Write("Choose field of study:");
            _menuActionService.DisplayMenuActionsByMenuName("FieldsOfStudy");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out var fieldsOfStudy);

            var applicantId = _applicantService.GetLastId() + 1;

            applicant = new Applicant(applicantId, name, surname, pesel, (Helpers.FieldsOfStudy)fieldsOfStudy);

            uint value;

            Console.Write("Basic Polish exam result: ");
            UInt32.TryParse(Console.ReadLine(), out value);
            applicant.ExamResults.Add("Basic Polish exam", value);

            Console.Write("Basic math exam result: ");
            UInt32.TryParse(Console.ReadLine(), out value);
            applicant.ExamResults.Add("Basic math exam", value);

            Console.Write("Basic foreign language exam result: ");
            UInt32.TryParse(Console.ReadLine(), out value);
            applicant.ExamResults.Add("Basic foreign language exam", value);

            if (!Recruitment.CheckPassMaturaExam(applicant.ExamResults))
            {
                return;
            }

            Console.Write("Extended math exam result: ");
            UInt32.TryParse(Console.ReadLine(), out value);
            applicant.ExamResults.Add("Extended math exam", value);

            Console.Write("Extended foreign language exam result: ");
            UInt32.TryParse(Console.ReadLine(), out value);
            applicant.ExamResults.Add("Extended foreign language exam", value);

            Console.Write("Extended physics exam result: ");
            UInt32.TryParse(Console.ReadLine(), out value);
            applicant.ExamResults.Add("Extended physics exam", value);
                
            applicant.PointsSum = Recruitment.SumPoints(applicant.ExamResults, FieldsOfStudyMultipliers.GetMultipliers(applicant.FieldOfStudy));               
            _applicantService.AddItem(applicant);  
        }

        public void FindApplicant()
        {
            var applicantid = 0;

            Console.Write("Search by: ");
            _menuActionService.DisplayMenuActionsByMenuName("FindApplicant");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch(key.KeyChar) 
            {
                case '1':
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Surname: ");
                    string surname = Console.ReadLine();
                    foreach (var item in _applicantService.Items)
                    {
                        if(item.Surname == surname && item.Name == name)
                        {
                            applicantid = item.Id;
                            break;
                        }
                    }
                    break;
                case '2':
                    Console.Write("PESEL: ");
                    string pesel = Console.ReadLine();                
                    foreach (var item in _applicantService.Items)
                    {
                        if (item.Pesel == pesel)
                        {
                            applicantid = item.Id;
                            break;
                        }
                    }
                    break;
                case '3':
                    Console.Write("Applicant ID: ");
                    int.TryParse(Console.ReadLine(), out applicantid);
                    break;
                default:
                    Console.WriteLine("Wrong action! \n Press any key to continue...");
                    Console.ReadKey();
                    return;
            }
            DisplayApplicantDetails(_applicantService.GetItemById(applicantid));
            DisplayApplicantMaturaExamResults(_applicantService.GetItemById(applicantid));
            Console.ReadKey();
        }

        public void RemoveApplicant()
        {
            Console.Write("Enter applicant ID to remove person from list: ");
            int.TryParse(Console.ReadLine(),out int applicantId);
            _applicantService.RemoveApplicant(applicantId);
        }

        public void ShowApplicantsForFieldOfStudy()
        {
            var applicants = _applicantService.GetAllApplicant();
            Console.Write("Choose field of study:");
            _menuActionService.DisplayMenuActionsByMenuName("FieldsOfStudy");
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out var fieldOfStudy);

            foreach(var applicant in applicants) 
            {
                if (applicant.FieldOfStudy == (Helpers.FieldsOfStudy)fieldOfStudy)
                {
                    DisplayApplicantDetails(applicant);
                }
            }
            Console.ReadKey();
        }
        public void ShowEveryApplicants()
        {
            var applicants = _applicantService.GetAllApplicant();
            foreach (var applicant in applicants)
            {
                DisplayApplicantDetails(applicant);
            }
            Console.ReadKey();
        }

        private void DisplayApplicantDetails(Applicant applicant)
        {
            if(applicant == null)
            {
                Console.WriteLine("Applicant not exist");
                return;
            }
            Console.WriteLine($"|ID: {applicant.Id} | Name: {applicant.Name} | " +
                $"Surname: {applicant.Surname} | Field of study: {applicant.FieldOfStudy}|");
        }
        private void DisplayApplicantMaturaExamResults(Applicant applicant)
        {
            if (applicant == null)
            {
                return;
            }
            foreach (var result in applicant.ExamResults)
            {
                Console.WriteLine($"{result.Key}: {result.Value}");
            }
        }
    }
}
