using System;
using static System.Collections.Specialized.BitVector32;
using System.Runtime.InteropServices;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.App.Managers;
using UniversityRecruitment.App.Managers.ApplicantManagers;

namespace UniversityRecruitment
{
    class Program
    { 
        static void Main(string[] args)
        {
            const string JSON_PATH = @"C:\Pliki\applicants.txt";

            var _manuActionService = new MenuActionService();
            var _applicantService = new ApplicantService();
            var _applicantAddingManager = new ApplicantAddingManager(_applicantService);
            var _applicantDisplayingManager = new ApplicantDisplayingManager(_applicantService);
            var _applicantFindingManager = new ApplicantFindingManager(_applicantService);
            var _applicantRemovingManager = new ApplicantRemovingManager(_applicantService);
            var _applicantEditingManager = new ApplicantEditingManager(_applicantService);

            Console.WriteLine("Welcome to university of technology recruiting app!");
            while(true)
            {
                Console.WriteLine("Let me know what you want to do:");
                _manuActionService.DisplayMenuActionsByMenuName("Main");

                var key = Console.ReadKey(); Console.WriteLine();
                switch (key.KeyChar)
                { 
                    case '1':
                        _applicantAddingManager.AddNewApplicant();
                        break;
                    case '2':                       
                        _applicantRemovingManager.RemoveApplicant();
                        break;
                    case '3':
                        _applicantEditingManager.EditApplicant();
                        break;
                    case '4':
                        _applicantDisplayingManager.DisplayEveryApplicants();
                        break;
                    case '5':
                        _applicantDisplayingManager.DisplayApplicantsForFieldOfStudy();
                        break;
                    case '6':
                        _applicantDisplayingManager.DisplayApplicant(_applicantFindingManager.FindApplicant());
                        break;
                    case '7':
                        if (UserActionManager.ConfirmSelection("save applicants to JSON file"))
                        ToFileManager.WriteToJsonFile(JSON_PATH, _applicantService.GetAllItems());
                        break;
                    case '8':
                        if (UserActionManager.ConfirmSelection("load applicants from JSON file"))
                        _applicantService.SetApplicants(ToFileManager.ReadJsonFile(JSON_PATH));
                        break;
                    default:
                        Console.WriteLine("Wrong action, let's try again!"); Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}

