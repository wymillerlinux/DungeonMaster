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
		private static Traveler _gameTraveler;
		
		public static List<string> HeaderText = new List<string>() { "Dungeon Master" };
		public static List<string> FooterText = new List<string>() { "Entourage Software, 2017" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You have woken by a common house fly, only to find that " +
            "you have fallen. Fallen into a temple of sorts. Why are you in here? " +
            "You try to remember but the fact you're holding a whiskey bottle in your " +
            "hand is never a good sign.\n" +
            " \n" +
            "Your mission to escape begins now.\n" +
            " \n" +
            "\tYou try to remember your name.\n" +
            " \n" +
            "\tPress any key to begin.\n";

            return messageBoxText;
        }

//        public static string InitialLocationInfo()
//		{
//			string messageBoxText =
//				"You are now in the Norlon Corporation research facility located in " +
//				"the city of Heraklion on the north coast of Crete. You have passed through " +
//				"heavy security and descended an unknown number of levels to the top secret " +
//				"research lab for the Aion Project.\n" +
//				" \n" +
//				"\tChoose from the menu options to proceed.\n";
//
//			return messageBoxText;
//		}

		#region Initialize Mission Text

		public static string InitializeMissionIntro()
		{
			string messageBoxText =
				"" +
				" \n" +
				"You will be prompted for the required information. Please enter the information below.\n" +
				" \n" +
				"\tPress any key to begin.";

			return messageBoxText;
		}

		public static string InitializeMissionGetTravelerName()
		{
			string messageBoxText =
				"Enter your name traveler.\n" +
				" \n" +
				"Please use the name you wish to be referred during your quest.";

			return messageBoxText;
		}

		public static string InitializeMissionGetTravelerAge(string name)
		{
            string messageBoxText =
                $"Awesome, you remember your name, {name}. You try to remember how old you are, just to make sure not drinking over age.\n" +
                " \n" +
                "Enter your age below.\n";

			return messageBoxText;
		}

		public static string InitializeMissionGetTravelerRace(Traveler gameTraveler)
		{
			string messageBoxText =
				$"{gameTraveler.Name}, you look at yourself thinking 'What the hell am I?'. Turns out, you yourself don't even know.\n" +
				" \n" +
				"Enter your race below.\n" +
				" \n";

			string raceList = null;

			foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
			{
				if (race != Character.RaceType.Other)
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
				$"Cool beans, {gameTraveler.Name}.\n" +
				" \n" +
				"This is the stuff that you remember about yourself by ask yourself questions. What a concept.\n" +
				" \n" +
				$"\tTraveler Name: {gameTraveler.Name}\n" +
				$"\tTraveler Age: {gameTraveler.Age}\n" +
				$"\tTraveler Race: {gameTraveler.Race}\n" +
				" \n" +
				"Press any key to begin your mission.";

			return messageBoxText;
		}

		#endregion

		#endregion

		#region MAIN MENU ACTION SCREENS

		public static string TravelerInfo(Traveler gameTraveler, SpaceTimeLocation currentLocation)
		{
			string messageBoxText =
				$"\tTraveler Name: {gameTraveler.Name}\n" +
				$"\tTraveler Age: {gameTraveler.Age}\n" +
				$"\tTraveler Race: {gameTraveler.Race}\n" +
				" \n" +
				$"\tCurrent Location: {currentLocation.CommonName}\n" +
				" \n";

			return messageBoxText;
		}

		public static string CurrentLocationInfo(SpaceTimeLocation spaceTimeLocation)
		{
			string messageBoxText =
				$"Current Location: {spaceTimeLocation.CommonName}\n" +
				" \n" +
				spaceTimeLocation.Description;

			return messageBoxText;
		}

		public static string LookAround(SpaceTimeLocation spaceTimeLocation)
		{
			string messageBoxText =
				$"Current Location: {spaceTimeLocation.CommonName}\n" +
				" \n" +
				spaceTimeLocation.Description;

			return messageBoxText;
		}

		/// <summary>
		/// list all locations other than the current location
		/// </summary>
		/// <param name="gametraveler">game traveler object</param>
		/// <param name="spaceTimeLocations">list of all space time locations</param>
		/// <returns></returns>
		public static string Travel(Traveler gametraveler, List<SpaceTimeLocation> spaceTimeLocations)
		{
			string messageBoxText =
				$"{gametraveler.Name}, where do you want to go?\n" +
				" \n" +
				"Enter the ID number of your desired location from the table below.\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
				"---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";

			//
			// display all locations except the current location
			//
			string spaceTimeLocationList = null;
			foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
			{
				if (spaceTimeLocation.SpaceTimeLocationID != gametraveler.SpaceTimeLocationId)
				{
					spaceTimeLocationList +=
						$"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
						$"{spaceTimeLocation.CommonName}".PadRight(30) +
						$"{spaceTimeLocation.Accessible}".PadRight(10) +
						Environment.NewLine;
				}
			}

			messageBoxText += spaceTimeLocationList;

			return messageBoxText;
		}

		public static string VisitedLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
		{
			string messageBoxText =
				"Room Locations Visited\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) + "Name".PadRight(30) + "\n" +
				"---".PadRight(10) + "----------------------".PadRight(30) + "\n";

			//
			// display all locations
			//
			string spaceTimeLocationList = null;
			foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
			{
				spaceTimeLocationList +=
					$"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
					$"{spaceTimeLocation.CommonName}".PadRight(30) +
					Environment.NewLine;
			}

			messageBoxText += spaceTimeLocationList;

			return messageBoxText;
		}

		public static string ListAllSpaceTimeLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
		{
			string messageBoxText =
				"Room Locations\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) + "Name".PadRight(30) + "\n" +
				"---".PadRight(10) + "----------------------".PadRight(30) + "\n";

			//
			// display all locations
			//
			string spaceTimeLocationList = null;
			foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
			{
				spaceTimeLocationList +=
					$"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
					$"{spaceTimeLocation.CommonName}".PadRight(30) +
					Environment.NewLine;
			}

			messageBoxText += spaceTimeLocationList;

			return messageBoxText;
		}

		public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
		{
			//
			// display table name and column headers
			//
			string messageBoxText =
				"Game Objects\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) +
				"Name".PadRight(30) +
				"Space-Time Location Id".PadRight(10) + "\n" +
				"---".PadRight(10) +
				"----------------------".PadRight(30) +
				"----------------------".PadRight(10) + "\n";

			//
			// display all traveler objects in rows
			//
			string gameObjectRows = null;
			foreach (GameObject gameObject in gameObjects)
			{
				gameObjectRows +=
					$"{gameObject.Id}".PadRight(10) +
					$"{gameObject.Name}".PadRight(30) +
					$"{gameObject.SpaceTimeLocationId}".PadRight(10) +
					Environment.NewLine;
			}

			messageBoxText += gameObjectRows;

			return messageBoxText;
		}

		public static string ListAllNpcObjects(IEnumerable<Npc> npcObjects)
		{
			//
			// display table name and column headers
			//
			string messageBoxText =
				"NPC Objects\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) +
				"Name".PadRight(30) +
				"Space-Time Location Id".PadRight(10) + "\n" +
				"---".PadRight(10) +
				"----------------------".PadRight(30) +
				"----------------------".PadRight(10) + "\n";

			//
			// display all npc objects in rows
			//
			string npcObjectRows = null;
			foreach (Npc npcObject in npcObjects)
			{
				npcObjectRows +=
					$"{npcObject.Id}".PadRight(10) +
					$"{npcObject.Name}".PadRight(30) +
					$"{npcObject.SpaceTimeLocationId}".PadRight(10) +
					Environment.NewLine;
			}

			messageBoxText += npcObjectRows;

			return messageBoxText;
		}

		public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
		{
			//
			// display table name and column headers
			//
			string messageBoxText =
				"Game Objects\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) + 
				"Name".PadRight(30) + "\n" +
				"---".PadRight(10) + 
				"----------------------".PadRight(30) + "\n";

			//
			// display all traveler objects in rows
			//
			string gameObjectRows = null;
			foreach (GameObject gameObject in gameObjects)
			{
				gameObjectRows +=
					$"{gameObject.Id}".PadRight(10) +
					$"{gameObject.Name}".PadRight(30) +
					Environment.NewLine;
			}

			messageBoxText += gameObjectRows;

			return messageBoxText;
		}


		public static string ListSpaceTimeLocationObjectsBySpaceTimeLocation(int spaceTimeLocationId, IEnumerable<GameObject> gameObjects)
		{
			//
			// generate a list of traveler objects from the game object list with the current space-time location id
			//
			List<SpaceTimeLocationObject> spaceTimeLocationObjects = new List<SpaceTimeLocationObject>();
			foreach (var gameObject in gameObjects)
			{
				if (gameObject is TravelerObject &&
					gameObject.SpaceTimeLocationId == spaceTimeLocationId)
				{
					spaceTimeLocationObjects.Add(gameObject as SpaceTimeLocationObject);
				}
			}

			//
			// display table name and column headers
			//
			string messageBoxText =
				"Room Location Objects\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) + "Name".PadRight(30) + "Type".PadRight(20) + "\n" +
				"---".PadRight(10) + "----------------------".PadRight(30) +
				"----------------------".PadRight(20) + "\n";

			//
			// display all traveler objects in rows
			//
			string spaceTimeLocationObjectRows = null;
			foreach (SpaceTimeLocationObject spaceTimeLocationObject in spaceTimeLocationObjects)
			{
				spaceTimeLocationObjectRows +=
					$"{spaceTimeLocationObject.Id}".PadRight(10) +
					$"{spaceTimeLocationObject.Name}".PadRight(30) +
					Environment.NewLine;
			}

			messageBoxText += spaceTimeLocationObjectRows;

			return messageBoxText;
		}

		public static string LookAt(GameObject gameObject)
		{
			string messageBoxText = "";

			messageBoxText =
				$"{gameObject.Name}\n" +
				" \n" +
				gameObject.Description + " \n" +
				" \n";

			if (gameObject is TravelerObject)
			{
				TravelerObject travelerObject = gameObject as TravelerObject;

				messageBoxText += $"The {travelerObject.Name} has a value of {travelerObject.Value} and ";

				if (travelerObject.CanInventory)
				{
					messageBoxText += "may be added to your inventory.";
				}
				else
				{
					messageBoxText += "may not be added to your inventory.";
				}
			}
			else
			{
				messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
			}

			return messageBoxText;
		}

		public static string CurrentInventory(IEnumerable<TravelerObject> inventory)
		{
			string messageBoxText = "";

			//
			// display table header
			//
			messageBoxText =
				"ID".PadRight(10) +
				"Name".PadRight(30) +
				"Type".PadRight(10) +
				"\n" +
				"---".PadRight(10) +
				"----------------------------".PadRight(30) +
				"----------------------".PadRight(10) +
				"\n";

			//
			// display all traveler objects in rows
			//
			string inventoryObjectRows = null;
			foreach (TravelerObject inventoryObject in inventory)
			{
				inventoryObjectRows +=
					$"{inventoryObject.Id}".PadRight(10) +
					$"{inventoryObject.Name}".PadRight(30) +
					$"{inventoryObject.Type}".PadRight(10) +
					Environment.NewLine;
			}

			messageBoxText += inventoryObjectRows;

			return messageBoxText;
		}

		public static string NpcsChooseList(IEnumerable<Npc> npcs)
		{
			//
			// display table name and column headers
			//
			string messageBoxText =
				"NPCs\n" +
				" \n" +

				//
				// display table header
				//
				"ID".PadRight(10) +
				"Name".PadRight(30) + "\n" +
				"---".PadRight(10) +
				"----------------------".PadRight(30) + "\n";

			//
			// display all NPCs in rows
			//
			string npcRows = null;
			foreach (Npc npc in npcs)
			{
				npcRows +=
					$"{npc.Id}".PadRight(10) +
					$"{npc.Name}".PadRight(30) +
					Environment.NewLine;
			}

			messageBoxText += npcRows;

			return messageBoxText;
		}

		#endregion

		public static List<string> StatusBox(Traveler traveler, Universe universe)
		{
			List<string> statusBoxText = new List<string>();

			statusBoxText.Add($"Experience Points: {traveler.ExperiencePoints}\n");
			statusBoxText.Add($"Health: {traveler.Health}\n");

			return statusBoxText;
		}

        public static string GameOver()
        {
            string messageBoxText =
                "You are dead! Ther application will now quit. Restart the application" +
                "if you like to play again.";
            return messageBoxText;
        }

		public static string GameComplete()
		{
			string messageBoxText = "Finally, you have escaped the horrible dungeon! You scream in absoulte joy and happiness.\n\n" +

//			if (_gameTraveler.Age <= 21)
//			{
//				messageBoxText += "However, you see the police with handcuffs. They take you to jail. That's not a good sign...";
//			}

			"\n\n\nYou have completed the game. You may press any key to continue back to the console.\n";
			Console.ReadKey();
			Environment.Exit(0);
			return messageBoxText;
		}
	}
}
