using System;
using System.Collections.Generic;

namespace CodeFirst.ReverseEngineered.PowerTools.Models
{
    public partial class OnlineCourse
    {
        public int CourseID { get; set; }
        public string URL { get; set; }
        public virtual Course Course { get; set; }
    }
}
