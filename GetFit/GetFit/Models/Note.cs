using System;
namespace GetFit.Models
{
    public class Note
    {
        // FILENAME & DATE WHEN CREATED 
        public string Filename { get; set; }
        public DateTime Date { get; set; }

        // PAGE ADD NOTES VARIABLES 
        public string WorkoutPlan { get; set; }
        public string MealPlan { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }

    }
}
