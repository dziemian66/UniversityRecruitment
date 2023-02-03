using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Common;
using UniversityRecruitment.Domain.Entity;

namespace UniversityRecruitment.App.Concrete
{
    public class MatureExamService: BaseService<MatureExam>
    {
        public MatureExamService()
        {
            Initialize();
        }

        private void Initialize()
        {
            AddItem(new MatureExam(1, "Basic Polish", false));
            AddItem(new MatureExam(2, "Basic math", false));
            AddItem(new MatureExam(3, "Basic foreign languageh", false));
            AddItem(new MatureExam(4, "Extended math", true));
            AddItem(new MatureExam(5, "Extended foreign language", true));
            AddItem(new MatureExam(6, "Extended physics", true));
        }
    }
}
