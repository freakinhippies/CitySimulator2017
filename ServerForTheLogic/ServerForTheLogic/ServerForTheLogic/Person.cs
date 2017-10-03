﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions.Canada;
using Bogus;
using ConsoleDump;
using ServerForTheLogic.Utilities;
using ServerForTheLogic.Infrastructure;
using static Bogus.DataSets.Name;

namespace ServerForTheLogic
{
    public class Person
    {
        private const int MEAN_DEATH_AGE = 80;
        private const int STANDARD_DEVIATION_DEATH = 14;


        /// <summary>
        /// ID for database
        /// </summary>        
        private Guid id;
        /// <summary>
        /// Person's first name
        /// </summary>
        public string FName { get; private set; }
        /// <summary>
        /// Person's last name
        /// </summary>
        public string LName { get; private set; }
        /// <summary>
        /// Money earned every 4 weeks of simulation time
        /// </summary>
        public int MonthlyIncome { get; set; }

        /// <summary>
        /// current amount of money in bank account
        /// </summary>
        private int money;

        /// <summary>
        /// where this person works 
        /// </summary>
        /// <param name="works"></param>
        /// <returns></returns>
        private Building workplace;
        /// <summary>
        /// Where this person lives
        /// </summary>
        private Building home;
        /// <summary>
        /// If this person is alive or dead
        /// </summary>
        private bool isDead;
        /// <summary>
        /// Number of days remaining until person dies
        /// </summary>
        private int DaysLeft;

        public Person()
        {
            id = new Guid();
        }


        /// <summary>
        /// Randomly generates an age this person will die (in days) based on
        /// guassian distribution.
        /// </summary>
        public void setDeathAge()
        {
            Random random = new Random();
            //if we want to add additional randomness to death age
            //int months = random.Next(1, 13);
            //int days = random.Next(1, 30);

            Random rand = new Random();

            //generates a random number of years left to live
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = MEAN_DEATH_AGE + STANDARD_DEVIATION_DEATH * randStdNormal; //random normal(mean,stdDev^2)
            
            //converts years left to days
            DaysLeft = (int)randNormal * 365;
        }

        /// <summary>
        /// Prints out a person's attributes in a neatly formatted manner
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return FName + " " + LName + " " + "Monthly income: " +
                MonthlyIncome + " Current money: " + money + " Unique ID: " + id;
        }


    }



}