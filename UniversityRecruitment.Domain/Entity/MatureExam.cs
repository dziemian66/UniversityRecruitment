using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.Domain.Common;

namespace UniversityRecruitment.Domain.Entity
{
    public class MatureExam: BaseEntity
    {
        public string Name { get; private set; }
        public bool IsExtended { get; private set; }
        public float Value { get; set; }
        public MatureExam(int id, string name, bool isExtended)
        {
            Id = id;
            Name = name;          
            IsExtended = isExtended;
        }
        public MatureExam(int id, string name, bool isExtended, float value) 
        {
            Id = id;
            Name = name;
            IsExtended = isExtended;
            Value = value;
        } 
        public override string ToString()
        {
            return $"| {Name,-25} |" +
                $" {Value,-3} |"; 
        }
    }
}
