using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment;
using UniversityRecruitment.Domain.Common;
using UniversityRecruitment.Domain.Utils;

namespace UniversityRecruitment.Domain.Entity
{
    public class Item : Person
    {
        public Helpers.FieldsOfStudy FieldOfStudy { get; set; }

        public List<MatureExam> ExamResults = new List<MatureExam>();
        public float PointsSum { get; set; }

        public Item(int id, string name, string surname, string pesel, Helpers.FieldsOfStudy fieldsOfStudy)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Pesel= pesel;
            FieldOfStudy = fieldsOfStudy;
        }
        public override string ToString()
        {
            return $"| {Id,-3} |" +
                $" {(Name.Length > 10 ? Name.Substring(0, 10) + "..." : Name),-13} |" +
                $" {(Surname.Length > 15 ? Surname.Substring(0, 15) + "..." : Surname),-18} |" +
                $" {FieldOfStudy,-22} |" +
                $" {PointsSum.ToString("00.00")} |";
        }
    }
}
