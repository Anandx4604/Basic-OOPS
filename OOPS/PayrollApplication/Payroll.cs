using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum WorkLocation {Select,India,USA,Kenya}
public enum Gender{Select,Male,Female,Transgender}

namespace PayrollApplication
{
    public class Payroll
    {
        //fields
        private static int s_employeeID = 1000;

        //properties
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime DOJ { get; set; }
        public int WorkingDays { get; set; }
        public int LeaveDays { get; set; }
    }
}