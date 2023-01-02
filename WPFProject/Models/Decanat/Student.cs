using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Models.Decanat
{
    internal class Student
    {
        public string? StudentName { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? StudentBirthday { get; set; }
        public double Rating { get; set; }
        public string? Description { get; set; }
    }
}
