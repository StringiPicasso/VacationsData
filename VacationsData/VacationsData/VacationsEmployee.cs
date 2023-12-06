using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsData
{
    public class VacationsEmployee
    {
        private Date _date = new Date();
        private int _currentVacationCountProp;

        private Dictionary<string, List<DateTime>> _vacationDictionary = new Dictionary<string, List<DateTime>>()
        {
            ["Иванов Иван Иванович"] = new List<DateTime>(),
            ["Петров Петр Петрович"] = new List<DateTime>(),
            ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
            ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
            ["Павлов Павел Павлович"] = new List<DateTime>(),
            ["Георгиев Георг Георгиевич"] = new List<DateTime>()
        };

        public void ShowVacationsEmployee()
        {
            DefineVacationDays();

            foreach (var VacationList in _vacationDictionary)
            {
                _date.SetDatesList = VacationList.Value;
                Console.WriteLine("Дни отпуска " + VacationList.Key + " : ");
                for (int i = 0; i < _date.SetDatesList.Count; i++) { Console.WriteLine(_date.SetDatesList[i]); }
            }

            Console.ReadKey();
        }

        private void DefineVacationDays()
        {
            foreach (var VacationList in _vacationDictionary)
            {
                _currentVacationCountProp = _date.VacationCountProp;
                DateTime startProp = new DateTime(DateTime.Now.Year, _date.StartMonth, _date.StartDay);
                DateTime endProp = new DateTime(DateTime.Now.Year, _date.EndMonth, _date.EndDay);
                _date.DatesList = VacationList.Value;

                while (_currentVacationCountProp > 0)
                {
                    _date.CanCreateVacationProp = false;
                    _date.ExistStartProp = false;
                    _date.ExistEndProp = false;

                    int range = (endProp - startProp).Days;
                    DateTime newStartDate = startProp.AddDays(_date.RandomGen.Next(range));

                    if (_date.AviableWorkingDaysOfWeekWithoutWeekends.Contains(newStartDate.DayOfWeek.ToString()))
                    {
                        AddDaysForNewDate(newStartDate);
                    }
                }
            }
        }

        private void AddDaysForNewDate(DateTime newStartDate)
        {
            int vacationIndex = _date.RandomGen.Next(_date.VacationSteps.Length);
            var newEndDate = new DateTime(DateTime.Now.Year, _date.EndMonth, _date.EndDay);
            int currentDifference = _date.Difference;

            newEndDate = newStartDate.AddDays(_date.VacationSteps[vacationIndex]);
            currentDifference = _date.VacationSteps[vacationIndex];

            if (currentDifference <= _date.VacationSteps[0])
            {
                newEndDate = newStartDate.AddDays(_date.VacationSteps[0]);
                currentDifference = _date.VacationSteps[0];
            }

            TryVAcationDay(newStartDate, newEndDate, currentDifference);
        }

        private void TryVAcationDay(DateTime newStartDate, DateTime newEndDate, int difference)
        {
            if (!_date.Vacations.Any(element => element >= newStartDate && element <= newEndDate))
            {
                if (!_date.Vacations.Any(element => element.AddDays(3) >= newStartDate && element.AddDays(3) <= newEndDate))
                {
                    _date.ExistStartProp = _date.DatesList.Any(element => element.AddMonths(1) >= newStartDate && element.AddMonths(1) >= newEndDate);
                    _date.ExistEndProp = _date.DatesList.Any(element => element.AddMonths(-1) <= newStartDate && element.AddMonths(-1) <= newEndDate);
                    if (!_date.ExistStartProp || !_date.ExistEndProp)
                        _date.CanCreateVacationProp = true;
                }
            }

            if (_date.CanCreateVacationProp)
            {
                for (DateTime dt = newStartDate; dt < newEndDate; dt = dt.AddDays(1))
                {
                    _date.Vacations.Add(dt);
                    _date.DatesList.Add(dt);
                }
                _currentVacationCountProp -= difference;
            }
        }
    }
}
