using System;
using SQLite;
namespace GetFit
{
    public class DailySteps
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TotalSteps { get; set; }
        public double Calories { get; set; }
    }
}
