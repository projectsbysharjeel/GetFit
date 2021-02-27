using System;
namespace GetFit.Models
{
    public class PersonalData
    {
        public String Filename { get; set; }

        // PAGE 1
        public String Goal { set; get; }            // lose, maintain or gain

        // PAGE 2
        public String Activitylevel { get; set; }   // not very, lightly, active, very active 

        // PAGE 3
        public String Gender { get; set; }          // male, female, other
        public String Name { get; set; }            // name
        public String DOB { get; set; }             // date of birth

        // PAGE 4
        public double CurrentWeight { get; set; }   // current weight
        public double GoalWeight { get; set; }      // Goal weight

        // PAGE 5
        public String WeeklyGoal { get; set; }      // lose 0.2, 0.5, 0.8, or 1kg

        // PAGE 6
        public int DailyNetCalories { get; set; }   // Calculates based on data

        public int MySteps { get; set; }

        public String MyName = "Sharjeelsss";
    }
}
