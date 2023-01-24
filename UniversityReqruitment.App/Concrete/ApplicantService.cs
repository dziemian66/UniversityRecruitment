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
    public class ApplicantService : BaseService<Applicant>
    {
        public void AddNewApplicant(Applicant applicant) => AddItem(applicant);
        public void RemoveApplicant(int id)
        {
            var applicant = GetItemById(id);
            if (applicant != null)
                RemoveItem(applicant);
        }
        public Applicant GetApplicantById(int id) => GetItemById(id);

        public List<Applicant> GetAllApplicants() => GetAllItems();

        public List<Applicant> GetApplicantsByFieldsOfStudy(Helpers.FieldsOfStudy fieldOfStudy)
        {
            List<Applicant> result = new();
            result = Items.Where(a => a.FieldOfStudy == fieldOfStudy).ToList();           
            return result;
        }
    }
}
