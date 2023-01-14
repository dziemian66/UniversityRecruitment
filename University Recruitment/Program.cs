using System;
using static System.Collections.Specialized.BitVector32;
using System.Runtime.InteropServices;
using UniversityRecruitment.App.Concrete;
using UniversityRecruitment.App.Managers;

namespace UniversityRecruitment
{
    class Program
    { 
        static void Main(string[] args)
        {
            var _manuActionService = new MenuActionService();
            var _applicantManager = new ApplicantManager();

            Console.WriteLine("Welcome to university of technology recruiting app!");
            while(true)
            {
                Console.WriteLine("Let me know what you want to do:");
                _manuActionService.DisplayMenuActionsByMenuName("Main");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                { 
                    case '1':
                        _applicantManager.AddNewApplicant();
                        break;
                    case '2':
                        _applicantManager.RemoveApplicant();
                        break;
                    case '3':
                        _applicantManager.ShowEveryApplicants();
                        break;
                    case '4':
                        _applicantManager.ShowApplicantsForFieldOfStudy();
                        break;
                    case '5':
                        _applicantManager.FindApplicant();
                        break;
                    default:
                        Console.WriteLine("Wrong action, let's try again!");
                        break;
                }
                Console.Clear();
            }
        }
    }
}

