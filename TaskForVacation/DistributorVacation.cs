using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForVacation
{
    internal class DistributorVacation
    {
        private readonly Random random = new Random();
        private readonly List<Func<VacationDate, List<VacationDate>, List<VacationDate>, bool>> listOfDistrubutionConditions;
        private readonly int daysInYear = DateTime.IsLeapYear(DateTime.Today.Year) ? 366 : 365;
        private readonly List<int> listOfVacationPerionds;
        private readonly int allVacationDaysNumber;

        public DistributorVacation(Func<VacationDate, List<VacationDate>, List<VacationDate>, bool> distributionCondition, List<int> listOfVacationPeriods, int allVacationDaysNumber) :
            this(new List<Func<VacationDate, List<VacationDate>, List<VacationDate>, bool>>() { distributionCondition }, listOfVacationPeriods, allVacationDaysNumber)
        { }
        public DistributorVacation(List<Func<VacationDate, List<VacationDate>, List<VacationDate>, bool>> listOfDistributionCondition, List<int> listOfVacationPeriods, int allVacationDaysNumber)
        {
            this.listOfDistrubutionConditions = listOfDistributionCondition;
            this.listOfVacationPerionds = listOfVacationPeriods;
            this.allVacationDaysNumber = allVacationDaysNumber;
        }


        public Dictionary<string, List<VacationDate>> CreateVacationsForEmployees(List<string> listOfEmployeeNames)
        {
            var vacationsDictionary = new Dictionary<string, List<VacationDate>>();
            var allVacations = new List<VacationDate>();

            foreach(string employeeName in listOfEmployeeNames)
            {
                KeyValuePair<string, List<VacationDate>> vacationPair = CreateVacationsForEmployee(employeeName, allVacations);
                allVacations.AddRange(vacationPair.Value);
                vacationsDictionary.Add(vacationPair.Key, vacationPair.Value);
            }

            return vacationsDictionary;
        }

        public KeyValuePair<string, List<VacationDate>> CreateVacationsForEmployee(string employeeName, List<VacationDate> allVacationDateOfAnotherEmployee)
        {
            List<VacationDate> allVacationDateOfEmployee = new List<VacationDate>();

            int numberOfDaysLeft = allVacationDaysNumber;           
            while (numberOfDaysLeft > 0)
            {
                int vacationPeriod = GenerateRandomVacationPeriod(allVacationDaysNumber);
                DateTime startDate = GenerateRandomDayInYear();
                VacationDate vacationDate = new VacationDate(startDate, startDate.AddDays(vacationPeriod));

                if(CheckAllConditions(vacationDate, allVacationDateOfEmployee, allVacationDateOfAnotherEmployee))
                {
                    allVacationDateOfEmployee.Add(vacationDate);
                    numberOfDaysLeft -= vacationPeriod;
                }
            }

            return new KeyValuePair<string, List<VacationDate>>(employeeName, allVacationDateOfEmployee);
        }

        private bool CheckAllConditions(VacationDate vacationDateOfEmployee, List<VacationDate> allVacationDateOfEmployee, List<VacationDate> allVacationDateOfAnotherEmployee)
        {
            bool allResultConditions = true;
            foreach(var condition in listOfDistrubutionConditions)
            {
                allResultConditions = allResultConditions && condition(vacationDateOfEmployee, allVacationDateOfEmployee, allVacationDateOfAnotherEmployee);
            }
            return allResultConditions;
        }

        private DateTime GenerateRandomDayInYear()
        {
            DateTime dayOfBeginningYear = new DateTime(DateTime.Now.Year, 1, 1);
            return dayOfBeginningYear.AddDays(random.Next(daysInYear));
        }
        private int GenerateRandomVacationPeriod(int numberOfDaysLeft)
        {
            int chosenPeriodIndex = random.Next(listOfVacationPerionds.Count);
            int chosenPeriod = listOfVacationPerionds[chosenPeriodIndex];
            while(numberOfDaysLeft< chosenPeriod)
            {
                chosenPeriodIndex--;
                chosenPeriod = listOfVacationPerionds[chosenPeriodIndex];
            }
            return chosenPeriod;
        }
    }
}
