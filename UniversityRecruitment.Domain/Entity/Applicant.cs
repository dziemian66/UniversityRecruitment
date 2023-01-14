﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment;
using UniversityRecruitment.Domain.Common;
using UniversityRecruitment.Domain.Utils;

namespace UniversityRecruitment.Domain.Entity
{
    public class Applicant : BaseEntity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Pesel { get; private set; }
        public Helpers.FieldsOfStudy FieldOfStudy { get; private set; }

        public Dictionary<string, float> ExamResults = new Dictionary<string, float>();
        public float PointsSum { get; set; }

        public Applicant()
        {

        }
        public Applicant(int id, string name, string surname, string pesel, Helpers.FieldsOfStudy fieldsOfStudy)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Pesel= pesel;
            FieldOfStudy = fieldsOfStudy;
        }
    }
}