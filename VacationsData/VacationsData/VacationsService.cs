using System;

namespace VacationsData
{
    public class VacationsService : DataBase
    {
        public void ShowVacationsEmployee()
        {
            DefineVacationDays();

            foreach (var vacationList in VacationDictionary)
            {
                Console.WriteLine("Дни отпуска " + vacationList.Key + " : ");
                for (int i = 0; i < Vacations.Count; i++) { Console.WriteLine(Vacations[i]); }
            }

            Console.ReadKey();
        }

        private void DefineVacationDays()
        {
            foreach (var vacationList in VacationDictionary)
            {
                Vacations = vacationList.Value;
                CurrentVacationCountProp = VacationCountProp;

                if (CurrentVacationCountProp > 0)
                {
                    GetRandomFirstDayVacation(out DateTime firstDayVacation);
                    
                    if (AviableWorkingDaysOfWeekWithoutWeekends.Contains(firstDayVacation.DayOfWeek.ToString()))
                    {
                        GetRandomCountVacation(firstDayVacation, out DateTime newEndDate, out int currentDifference);
                        TryAddVacationDay(firstDayVacation, newEndDate, currentDifference);
                    }
                }
            }
        }

        private void GetRandomFirstDayVacation(out DateTime firstDayVacation)
        {
            DateTime startDate = FirstDataInYear;
            int rangeFirtVacationDay = (EndDataInYear - startDate).Days;
            firstDayVacation = startDate.AddDays(RandomGen.Next(rangeFirtVacationDay));
        }

        private void GetRandomCountVacation(DateTime firstDayVacation, out DateTime newEndDate, out int currentDifference)
        {
            int vacationIndex = RandomGen.Next(VacationSteps.Length);

            newEndDate = firstDayVacation.AddDays(VacationSteps[vacationIndex]);
            currentDifference = VacationSteps[vacationIndex];

            if (currentDifference <= VacationSteps[0])
            {
                newEndDate = firstDayVacation.AddDays(VacationSteps[0]);
                currentDifference = VacationSteps[0];
            }
        }

        private void TryAddVacationDay(DateTime newStartDate, DateTime newEndDate, int difference)
        {
            if (!Vacations.Any(date => date.AddMonths(1) >= newStartDate && date <= newEndDate.AddMonths(-1)))
            {
                for (DateTime data = newStartDate; data < newEndDate; data = data.AddDays(1))
                {
                    Vacations.Add(data);
                }

                CurrentVacationCountProp -= difference;
            }
        }
    }
}
