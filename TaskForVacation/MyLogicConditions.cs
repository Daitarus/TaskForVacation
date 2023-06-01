using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForVacation
{
    internal class MyLogicConditions
    {
        public bool AllConditions(VacationDate vacationDateOfEmployee, List<VacationDate> allVacationDatesOfEmployee, List<VacationDate> allVacationDatesOfAnotherEmployee)
        {
            return ConditionOfWeekends(vacationDateOfEmployee) &&
                ConditionOfOtherVacation(vacationDateOfEmployee, allVacationDatesOfEmployee) &&
                ConditionOfBreakLeastMonth(vacationDateOfEmployee, allVacationDatesOfAnotherEmployee);
        }

        public bool ConditionOfWeekends(VacationDate vacationDateOfEmployee)
        {
            return !vacationDateOfEmployee.StartDate.DayOfWeek.Equals(DayOfWeek.Saturday) &&
                !vacationDateOfEmployee.StartDate.DayOfWeek.Equals(DayOfWeek.Sunday);
        }
        public bool ConditionOfOtherVacation(VacationDate vacationDateOfEmployee, List<VacationDate> allVacationDatesOfAnotherEmployee)
        {
            return !allVacationDatesOfAnotherEmployee.Any(vacation =>
            (vacation.EndDate.AddDays(3) >= vacationDateOfEmployee.StartDate && vacation.EndDate.AddDays(3) <= vacationDateOfEmployee.EndDate) ||
            (vacation.StartDate >= vacationDateOfEmployee.StartDate && vacation.StartDate <= vacationDateOfEmployee.EndDate));
        }
        public bool ConditionOfBreakLeastMonth(VacationDate vacationDateOfEmployee, List<VacationDate> allVacationDatesOfEmployee)
        {      
            return !allVacationDatesOfEmployee.Any(vacation =>
            (vacation.EndDate.AddMonths(1) >= vacationDateOfEmployee.StartDate && vacation.EndDate.AddMonths(1) <= vacationDateOfEmployee.EndDate) ||
            vacation.StartDate.AddMonths(-1) >= vacationDateOfEmployee.StartDate && vacation.StartDate.AddMonths(-1) <= vacationDateOfEmployee.EndDate);
        }
    }
}
