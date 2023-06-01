using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForVacation
{
    internal class VacationDate
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public VacationDate(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public List<DateTime> GetAllDateOfVacation()
        {
            List<DateTime> dateOfVacation = new List<DateTime>();
            for(DateTime date = StartDate; date < EndDate; date = date.AddDays(1))
            {
                dateOfVacation.Add(date);
            }
            return dateOfVacation;
        }
    }
}
