using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TaskForVacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> employeeNames = new List<string>() 
            {   "Иванов Иван Иванович", 
                "Петров Петр Петрович", 
                "Юлина Юлия Юлиановна", 
                "Сидоров Сидор Сидорович", 
                "Павлов Павел Павлович",
                "Георгиев Георг Георгиевич"
            };

            MyLogicConditions logicConditions = new MyLogicConditions();
            List<int> listOfVactionsPeriod = new List<int> { 7, 14 };
            int allVacationDaysNumber = 28;

            DistributorVacation distributorVacation = new DistributorVacation(logicConditions.AllConditions, listOfVactionsPeriod, allVacationDaysNumber);
            var vacationsDictionary = distributorVacation.CreateVacationsForEmployees(employeeNames);
            ConsoleWorker.PrintVacationDictionary(vacationsDictionary);

            ConsoleWorker.PressAnyKey();
        }
    }
}