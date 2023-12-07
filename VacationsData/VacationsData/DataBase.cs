namespace VacationsData
{
    public abstract class DataBase
    {
        public Dictionary<string, List<DateTime>> VacationDictionary = new Dictionary<string, List<DateTime>>()
        {
            ["Иванов Иван Иванович"] = new List<DateTime>(),
            ["Петров Петр Петрович"] = new List<DateTime>(),
            ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
            ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
            ["Павлов Павел Павлович"] = new List<DateTime>(),
            ["Георгиев Георг Георгиевич"] = new List<DateTime>()
        };

        public List<string> AviableWorkingDaysOfWeekWithoutWeekends => new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        public DateTime FirstDataInYear => new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime EndDataInYear => new DateTime(DateTime.Now.Year, 12, 31);
        public int[] VacationSteps => new int[] {7,14};
        public int VacationCountProp => 28;
        public int CurrentVacationCountProp { get; set; }
        
        public Random RandomGen = new Random();
        public List<DateTime> Vacations = new List<DateTime>();
    }
}