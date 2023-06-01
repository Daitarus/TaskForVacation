using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForVacation
{
    internal static class ConsoleWorker
    {
        public static void PrintVacationDictionary(Dictionary<string, List<VacationDate>> vacationsDictionary)
        {
            foreach(var vacationForEmployee in vacationsDictionary) 
            { 
                Console.WriteLine("Дни отпуска {0}: ", vacationForEmployee.Key);
                foreach(var vacation in vacationForEmployee.Value)
                {
                    List<DateTime> vacationSegment = vacation.GetAllDateOfVacation();
                    foreach(var date in vacationSegment)
                    {
                        Console.WriteLine("|--{0}.{1}.{2}", date.Day, date.Month, date.Year);
                    }
                }
                Console.WriteLine();
            }
        }
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to end the program...");
            Console.ReadKey();
        }
    }
}
