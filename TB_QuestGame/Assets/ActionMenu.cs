using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
	/// <summary>
	/// static class to hold key/value pairs for menu options
	/// </summary>
	public static class ActionMenu
	{
		public enum CurrentMenu
		{
			MissionIntro,
			InitializeMission,
			MainMenu,
			ObjectMenu,
			NpcMenu,
			TravelerMenu,
			AdminMenu
		}

		//
		// flag current operating menu
		//
		public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

		public static Menu MissionIntro = new Menu()
		{
			MenuName = "MissionIntro",
			MenuTitle = "",
			MenuChoices = new Dictionary<char, TravelerAction>()
			{
				{ ' ', TravelerAction.None }
			}
		};

		public static Menu InitializeMission = new Menu()
		{
			MenuName = "InitializeMission",
			MenuTitle = "Initialize Mission",
			MenuChoices = new Dictionary<char, TravelerAction>()
			{
				{ '1', TravelerAction.Exit }
			}
		};

		public static Menu MainMenu = new Menu()
		{
			MenuName = "MainMenu",
			MenuTitle = "Main Menu",
			MenuChoices = new Dictionary<char, TravelerAction>()
			{
				{ '1', TravelerAction.LookAround },
				{ '2', TravelerAction.Travel },
				{ '3', TravelerAction.ObjectMenu },
				{ '4', TravelerAction.NonplayerCharacterMenu},
				{ '5', TravelerAction.TravelerMenu},
				{ '6', TravelerAction.AdminMenu },
				{ '0', TravelerAction.Exit }
			}
		};

		public static Menu AdminMenu = new Menu()
		{
			MenuName = "AdminMenu",
			MenuTitle = "Admin Menu",
			MenuChoices = new Dictionary<char, TravelerAction>()
			{
				{ '1', TravelerAction.ListSpaceTimeLocations },
				{ '2', TravelerAction.ListGameObjects},
				{ '3', TravelerAction.ListNonplayerCharacters},
				{ '0', TravelerAction.ReturnToMainMenu }
			}
		};

		public static Menu TravelerMenu = new Menu()
		{
			MenuName = "TravelerMenu",
			MenuTitle = "Traveler Menu",
			MenuChoices = new Dictionary<char, TravelerAction>()
			{
				{ '1', TravelerAction.TravelerInfo },
				{ '2', TravelerAction.Inventory},
				{ '3', TravelerAction.TravelerLocationsVisited},
				{ '0', TravelerAction.ReturnToMainMenu }
			}
		};

		public static Menu ObjectMenu = new Menu()
		{
			MenuName = "ObjectMenu",
			MenuTitle = "Object Menu",
			MenuChoices = new Dictionary<char, TravelerAction>()
			{
				{ '1', TravelerAction.LookAt },
				{ '2', TravelerAction.PickUp},
				{ '3', TravelerAction.PutDown},
				{ '0', TravelerAction.ReturnToMainMenu }
			}
		};

		public static Menu NpcMenu = new Menu()
		{
			MenuName = "NpcMenu",
			MenuTitle = "NPC Menu",
			MenuChoices = new Dictionary<char, TravelerAction>()
			{
				{ '1', TravelerAction.TalkTo},
				{ '0', TravelerAction.ReturnToMainMenu }
			}
		};

	}
}
