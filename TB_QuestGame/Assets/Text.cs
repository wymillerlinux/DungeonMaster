using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "The Aion Project" };
        public static List<string> FooterText = new List<string>() { "Laughing Leaf Productions, 2016" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You have fallen down, almost broke your head open. You feel a tad quesy from the fall.\n" +
			"You remember walking up the Temple of the Moon and staring down this dark pit. \n" +
			"You also remember your feign curiosity welling up inside you. Now look what you did. It is time\n" +
			"to escape and find help (because you're bleeding severly. Good luck with that).\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your journey begins now.\n" +
            " \n" +
            "\tPress any key to begin remembering.\n";

            return messageBoxText;
        }

        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            "Right now, you are in what you think is the Temple of the Moon but you have no idea.\n" +
			"In front of you, you see a sandstone door that seems to be opened by some sort of mechanism.\n" + 
			"\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin, can you remember your name? You figured while you do that, you could supress the bleeding.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerName()
        {
            string messageBoxText =
                "Can you remember your name, dungeon master?\n" +
                " \n" +
                "Please use the name you wish to be referred during your journey.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerAge(Traveler gameTraveler)
        {
            string messageBoxText =
				$"Alright, you remember your name, {gameTraveler.Name}. Can you remember your age?.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerRace(Traveler gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, what's in your backpack? \n" +
                " \n" +
                "Enter your starting item below.\n" +
                " \n" +
                "Please use the starting items below." +
                " \n";

            string raceList = null;

			foreach (Character.StartingItem race in Enum.GetValues(typeof(Character.StartingItem)))
            {
				if (race != Character.StartingItem.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoTravelerInfo(Traveler gameTraveler)
        {
            string messageBoxText =
                $"Awesome, {gameTraveler.Name}!\n" +
                " \n" +
                "You have remembered your name and your age! " +
                " \n" +
                $"\tYour name: {gameTraveler.Name}\n" +
                $"\tYour age: {gameTraveler.Age}\n" +
                " \n" +
                "Press any key to begin your mastering of the dugeon.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Traveler gameTraveler)
        {
            string messageBoxText =
                $"\tYour name: {gameTraveler.Name}\n" +
                $"\tYour age: {gameTraveler.Age}\n" +
                " \n";

            return messageBoxText;
        }

//        public static string Travel(int currentLocationId, List<SpaceTimeLocation> spaceTimeLocations)
//        {
//            string messageBoxText =
//                $"{gameTraveler.Name}, enter the new location.\n" +
//                " \n" +
//                "Enter the ID number of your desired location from the table below.\n" +
//                " \n";
//
//
//            string spaceTimeLocationList = null;
//
//            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
//            {
//                if (race != Character.RaceType.None)
//                {
//                    raceList += $"\t{race}\n";
//                }
//            }
//
//            messageBoxText += raceList;
//
//            return messageBoxText;
//        }

        #endregion
    }
}
