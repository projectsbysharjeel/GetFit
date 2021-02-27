using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System;
using GetFit.Models;
using System.IO;

namespace GetFit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        SensorSpeed speed = SensorSpeed.UI;
        private double lastMagnitude = 0; // Check last value
        private int stepCount = 0; // Counts step
        private int walkingSteps = 0;
        private int runningSteps = 0;
        private double calorieBurntPerStep = 0.4;
        private double runningCalories = 0;
        private double walkingCalories = 0;

        public HomePage()
        {
            InitializeComponent();

            //==============================================================================================
            // Reference C1: Externally sourced program
            // Purpose: Accessing Accelerometer 
            // Date: 07 Nov 2020
            // Source: YouTube Video
            // Author: Microsoft Developer 
            // Url: https://www.youtube.com/watch?v=h2MGTh5bkdA
            // Adaptation: Got the idea on how to access accelerometer reading 
            //===============================================================================================

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

            if (Accelerometer.IsMonitoring)
                return;

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(speed);

            //===============================================================================================
            // End reference C1
            //===============================================================================================
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            //==============================================================================================
            // Reference D4: Externally sourced program
            // Purpose: Steps counting Algorithm  
            // Date: 05 Nov 2020
            // Source: YouTube Video
            // Author: Programmer world 
            // Url: https://www.youtube.com/watch?v=o-qpVefrfVA
            // Adaptation: Got the idea on how to calculate magnitude, 
            //===============================================================================================

            // Get the X,Y,Z Acceleration readings from the phone, and saving the, into variables as doubles
            float valueX = e.Reading.Acceleration.X;
            float valueY = e.Reading.Acceleration.Y;
            float valueZ = e.Reading.Acceleration.Z;

            // Calculates magnitude which represents the vibration on three axis coordinates (X,Y,Z)
            double currentMagnitude = Math.Sqrt((valueX * valueX) + (valueY * valueY) + (valueZ * valueZ));

            // Calculates the difference between the current and the last magnitude & checks how much of those
            // coordinate calues went up or low 
            double differenceMagnitude = currentMagnitude - lastMagnitude;
            lastMagnitude = currentMagnitude;

            // If the difference is greater than 4, Count that step as walking 
            if (differenceMagnitude > 4)
            {
                stepCount++;
                walkingSteps++;
            }

            //===============================================================================================
            // End reference D4
            //===============================================================================================

            // If the difference is greater than 6, Count that step as Running 
            else if (differenceMagnitude > 6)
            {
                stepCount++;
                runningSteps++;
            }

            walkingCalories = walkingSteps * calorieBurntPerStep;   //
            runningCalories = runningSteps * calorieBurntPerStep;

            lblSteps.Text = stepCount.ToString();                   // Update steps (in circle)
            lblTotalSteps.Text = stepCount.ToString();              // Update total steps

            lblWalkSteps.Text = walkingSteps.ToString();            // Update walking steps done so far
            lblRunSteps.Text = runningSteps.ToString();             // Update running steps done so far

            lblWalkCalorie.Text = walkingCalories.ToString();       // Update calories burnt when walking
            lblRunCalorie.Text = runningCalories.ToString();        // Update calories burnt when running 

            var copy = new PersonalData();
            copy.MySteps = stepCount;
        }
    }
}