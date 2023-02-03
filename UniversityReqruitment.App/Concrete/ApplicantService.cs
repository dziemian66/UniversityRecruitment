using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Common;
using UniversityRecruitment.Domain.Entity;
using UniversityRecruitment.Domain.Utils;

namespace UniversityRecruitment.App.Concrete
{
    public class ApplicantService : BaseService<Item>
    {
        public void AddNewApplicant(Item applicant) => AddItem(applicant);

        public void SetApplicants(List<Item> applicants)
        {
            Items = applicants;
        }
        public void RemoveApplicant(int id)
        {
            var applicant = GetItemById(id);
            if (applicant != null)
                RemoveItem(applicant);
        }
        public Item GetApplicantById(int id) => GetItemById(id);

        public List<Item> GetAllApplicants() => GetAllItems();

        public List<Item> GetApplicantsByFieldsOfStudy(Helpers.FieldsOfStudy fieldOfStudy)
        {
            List<Item> result = new();
            result = Items.Where(a => a.FieldOfStudy == fieldOfStudy).ToList();           
            return result;
        }

    }
}
