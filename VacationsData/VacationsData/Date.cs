using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsData
{
    public class Date
    {
        public bool CanCreateVacationProp { get; set; }
        public bool ExistStartProp { get; set; }
        public bool ExistEndProp { get; set; }

        public List<DateTime> Vacations = new List<DateTime>();
        public List<DateTime> DatesList = new List<DateTime>();
        public List<DateTime> SetDatesList = new List<DateTime>();
        public Random RandomGen = new Random();
       
        private List<string> _aviableWorkingDaysOfWeekWithoutWeekends = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        private int[] _vacationSteps = { 7, 14 };
        private int _vacationCountProp = 28;
        private int _difference = 0;
        private int _startMonth = 1;
        private int _startDay = 1;
        private int _endMonth = 12;
        private int _endDay = 31;

        public List<string> AviableWorkingDaysOfWeekWithoutWeekends => _aviableWorkingDaysOfWeekWithoutWeekends;
        public int[] VacationSteps => _vacationSteps;
        public int VacationCountProp => _vacationCountProp;
        public int Difference => _difference;
        public int StartMonth => _startMonth;
        public int StartDay => _startDay;
        public int EndMonth => _endMonth;
        public int EndDay => _endDay;
    }
}