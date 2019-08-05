using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grand_circus.Models
{
    public class ViewCourses
    {
        public string CourseName { get; set; }
        public string Semester { get; set; }
        public double Grade { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        public double Average { get; set; }

        public ViewCourses(string _courseName, string _semester, double _grade, double _max, double _min, double _average)
        {
            CourseName = _courseName;
            Semester = _semester;
            Grade = _grade;
            Max = _max;
            Min = _min;
            Average = _average;
        }
    }
}
