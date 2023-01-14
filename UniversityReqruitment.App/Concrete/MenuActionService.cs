using System;
using System.Collections.Generic;
using System.Text;
using UniversityRecruitment.App.Common;
using UniversityRecruitment.Domain.Entity;


namespace UniversityRecruitment.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public void DisplayMenuActionsByMenuName(string menuName)
        {
            Console.WriteLine();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    Console.WriteLine($"{menuAction.Id}. {menuAction.Name}");
                }
            }
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add new applicant for University of Technology", "Main"));
            AddItem(new MenuAction(2, "Remove the person from applicants list", "Main"));
            AddItem(new MenuAction(3, "Display whole list of applicants", "Main"));
            AddItem(new MenuAction(4, "Display the list of applicants for a given field of study", "Main"));
            AddItem(new MenuAction(5, "Find an applicant", "Main"));

            AddItem(new MenuAction(1, "Automation and robotics", "FieldsOfStudy"));
            AddItem(new MenuAction(2, "Electrotechnics", "FieldsOfStudy"));
            AddItem(new MenuAction(3, "Informatics", "FieldsOfStudy"));

            AddItem(new MenuAction(1, "Name and surname", "FindApplicant"));
            AddItem(new MenuAction(2, "PESEL", "FindApplicant"));
            AddItem(new MenuAction(3, "Applicant ID", "FindApplicant"));
        }
    }
}
