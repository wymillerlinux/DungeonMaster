using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
	/// <summary>
	/// controller for the MVC pattern in the application
	/// </summary>
	public class Controller
	{
		#region FIELDS

		private ConsoleView _gameConsoleView;
		private Traveler _gameTraveler;
		private Universe _gameUniverse;
		private SpaceTimeLocation _currentLocation;
		private Npc _npc;
		private bool _playingGame;

		#endregion

		#region PROPERTIES


		#endregion

		#region CONSTRUCTORS

		public Controller()
		{
			//
			// setup all of the objects in the game
			//
			InitializeGame();

			//
			// begins running the application UI
			//
			ManageGameLoop();
		}

		#endregion

		#region METHODS

		/// <summary>
		/// initialize the major game objects
		/// </summary>
		private void InitializeGame()
		{
			_gameTraveler = new Traveler();
			_gameUniverse = new Universe();
			_gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);
			_playingGame = true;

			Console.CursorVisible = false;
		}

		/// <summary>
		/// method to manage the application setup and game loop
		/// </summary>
		private void ManageGameLoop()
		{
			TravelerAction travelerActionChoice = TravelerAction.None;

			//
			// display splash screen
			//
			_playingGame = _gameConsoleView.DisplaySpashScreen();

			//
			// player chooses to quit
			//
			if (!_playingGame)
			{
				Environment.Exit(1);
			}

			//
			// display introductory message
			//
			_gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
			_gameConsoleView.GetContinueKey();

			//
			// initialize the mission traveler
			// 
			InitializeMission();

			//
			// prepare game play screen
			//
			_currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationId);
			_gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

			//
			// game loop
			//
			while (_playingGame)
			{
				//
				// process all flags, events, and stats
				//
				UpdateGameStatus();

				//
				// get next game action from player
				//
				travelerActionChoice = GetNextTravelerAction();

				//
				// choose an action based on the player's menu choice
				//
				switch (travelerActionChoice)
				{
				case TravelerAction.None:
					break;

				case TravelerAction.TravelerInfo:
					_gameConsoleView.DisplayTravelerInfo();
					break;

				case TravelerAction.LookAround:
					_gameConsoleView.DisplayLookAround();
					break;

				case TravelerAction.Travel:
					TravelAction();
					break;

				case TravelerAction.TravelerLocationsVisited:
					_gameConsoleView.DisplayLocationsVisited();
					break;

				case TravelerAction.LookAt:
					LookAtAction();
					break;

				case TravelerAction.PickUp:
					PickUpAction();
					break;

				case TravelerAction.PutDown:
					PutDownAction();
					break;

				case TravelerAction.Inventory:
					_gameConsoleView.DisplayInventory();
					break;

				case TravelerAction.TalkTo:
					TalkToAction();
					break;

				case TravelerAction.ListSpaceTimeLocations:
					_gameConsoleView.DisplayListOfSpaceTimeLocations();
					break;

				case TravelerAction.ListGameObjects:
					_gameConsoleView.DisplayListOfAllGameObjects();
					break;

				case TravelerAction.ListNonplayerCharacters:
					_gameConsoleView.DisplayListOfAllNpcObjects();
					break;

				case TravelerAction.TravelerMenu:
					ActionMenu.currentMenu = ActionMenu.CurrentMenu.TravelerMenu;
					_gameConsoleView.DisplayGamePlayScreen("Traveler Menu", "Select an operation from the menu.", ActionMenu.TravelerMenu, "");
					break;

				case TravelerAction.ObjectMenu:
					ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
					_gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu.", ActionMenu.ObjectMenu, "");
					break;

				case TravelerAction.NonplayerCharacterMenu:
					ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
					_gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
					break;

				case TravelerAction.AdminMenu:
					ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
					_gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
					break;

				case TravelerAction.ReturnToMainMenu:
					ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
					_gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
					break;

				case TravelerAction.Exit:
					_playingGame = false;
					break;

				default:
					break;
				}
			}

			//
			// close the application
			//
			Environment.Exit(1);
		}

		/// <summary>
		/// display the correct menu/sub-menu and get the next traveler action
		/// </summary>
		/// <returns>traveler action</returns>
		private TravelerAction GetNextTravelerAction()
		{
			TravelerAction travelerActionChoice = TravelerAction.None;

			switch (ActionMenu.currentMenu)
			{
			case ActionMenu.CurrentMenu.MainMenu:
				travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
				break;

			case ActionMenu.CurrentMenu.ObjectMenu:
				travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
				break;

			case ActionMenu.CurrentMenu.NpcMenu:
				travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
				break;

			case ActionMenu.CurrentMenu.TravelerMenu:
				travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TravelerMenu);
				break;

			case ActionMenu.CurrentMenu.AdminMenu:
				travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
				break;

			default:
				break;
			}

			return travelerActionChoice;
		}

		/// <summary>
		/// process the Travel action
		/// </summary>
		private void TravelAction()
		{
			//
			// get new location choice and update the current location property
			//                        
			_gameTraveler.SpaceTimeLocationId = _gameConsoleView.DisplayGetNextSpaceTimeLocation();
			_currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationId);

			//
			// display the new space-time location info
			//
			_gameConsoleView.DisplayCurrentLocationInfo();
		}

		/// <summary>
		/// process the Look At action
		/// </summary>
		private void LookAtAction()
		{
			//
			// display a list of game objects in space-time location and get a player choice
			//
			int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

			//
			// display game object info
			//
			if (gameObjectToLookAtId != 0)
			{
				//
				// get the game object from the universe
				//
				GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

				//
				// display information for the object chosen
				//
				_gameConsoleView.DisplayGameObjectInfo(gameObject);
			}
		}


		/// <summary>
		/// process the Pick Up action
		/// </summary>
		private void PickUpAction()
		{
			//
			// display a list of traveler objects in space-time location and get a player choice
			//
			int travelerObjectToPickUpId = _gameConsoleView.DisplayGetTravelerObjectToPickUp();

			//
			// add the traveler object to traveler's inventory
			//
			if (travelerObjectToPickUpId != 0)
			{
				//
				// get the game object from the universe
				//
				TravelerObject travelerObject = _gameUniverse.GetGameObjectById(travelerObjectToPickUpId) as TravelerObject;

				//
				// note: traveler object is added to list and the space-time location is set to 0
				//
				_gameTraveler.Inventory.Add(travelerObject);
				travelerObject.SpaceTimeLocationId = 0;

				//
				// display confirmation message
				//
				_gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);
			}
		}

		/// <summary>
		/// process the Put Down action
		/// </summary>
		private void PutDownAction()
		{
			//
			// display a list of traveler objects in inventory and get a player choice
			//
			int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

			//
			// get the game object from the universe
			//
			TravelerObject travelerObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as TravelerObject;

			//
			// remove the object from inventory and set the space-time location to the current value
			//
			_gameTraveler.Inventory.Remove(travelerObject);
			travelerObject.SpaceTimeLocationId = _gameTraveler.SpaceTimeLocationId;

			//
			// display confirmation message
			//
			_gameConsoleView.DisplayConfirmTravelerObjectRemovedFromInventory(travelerObject);

		}


		/// <summary>
		/// process the Talk To action
		/// </summary>
		private void TalkToAction()
		{
			//
			// display a list of NPCs in space-time location and get a player choice
			//
			int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

			//
			// display NPC's message
			//
			if (npcToTalkToId != 0)
			{
				//
				// get the NPC from the universe
				//
				Npc npc = _gameUniverse.GetNpcById(npcToTalkToId);

				//
				// display information for the object chosen
				//
				_gameConsoleView.DisplayTalkTo(npc);
			}
		}

		/// <summary>
		/// initialize the player info
		/// </summary>
		private void InitializeMission()
		{
			Traveler traveler = _gameConsoleView.GetInitialTravelerInfo();

			_gameTraveler.Name = traveler.Name;
			_gameTraveler.Age = traveler.Age;
			_gameTraveler.Race = traveler.Race;
			_gameTraveler.SpaceTimeLocationId = 1;

			_gameTraveler.ExperiencePoints = 0;
			_gameTraveler.Health = 100;
			//_gameTraveler.Lives = 1;
		}

		/// <summary>
		/// part of the game loop and used to update many elements of the game and game play
		/// </summary>
		private void UpdateGameStatus()
		{
			
			if (!_gameTraveler.HasVisited(_currentLocation.SpaceTimeLocationID))
			{
				//
				// add new location to the list of visited locations if this is a first visit
				//
				_gameTraveler.SpaceTimeLocationsVisited.Add(_currentLocation.SpaceTimeLocationID);

				//
				// update experience points for visiting locations
				//
				_gameTraveler.ExperiencePoints += _currentLocation.ExperiencePoints;
			}

            // lose health, you keel over and die
            if (_gameTraveler.Health == 0)
            {
                _gameConsoleView.DisplayGamePlayScreen("Game Over", Text.GameOver(), ActionMenu.MainMenu, "");
                _gameConsoleView.GetContinueKey();
                Environment.Exit(0);
            }

            // unlocking rooms/items when you pick a certain item
			// turtles for days
            if (_gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(2)))
            {
                SpaceTimeLocation spaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(6);
                spaceTimeLocation.Accessible = true;
            }
			
			if (_gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(2)) && _gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(8)) && _gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(9)) && _gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(10)))
			{
				SpaceTimeLocation spaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(7);
				spaceTimeLocation.Accessible = true;
			}

			// keys of progression
			if (_gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(3)))
			{
				SpaceTimeLocation spaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(2);
				spaceTimeLocation.Accessible = true;

				if (_gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(5)))
				{
					spaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(3);
					spaceTimeLocation.Accessible = true;

					if (_gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(6)))
					{
						spaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(4);
						spaceTimeLocation.Accessible = true;
						
						if (_gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(7)))
						{
							spaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(5);
							spaceTimeLocation.Accessible = true;
						}
					}
				}
			}

			if (_gameTraveler.SpaceTimeLocationId == 5)
			{
				_gameConsoleView.DisplayGameCompleteScreen();
			}
			
			// tried to interact with npc's to give me unlockable items but that didn't work out
//			if (_gameUniverse.HasNpcBeenInteractedWith(1))
//			{
//				GameObject gameObject = _gameUniverse.GetGameObjectById(3);
//				gameObject.SpaceTimeLocationId = 1;
//			}
		}
		#endregion
	}
}
