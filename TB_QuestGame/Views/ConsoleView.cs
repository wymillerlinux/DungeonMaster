using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Traveler _gameTraveler;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Traveler gameTraveler, Universe gameUniverse)
        {
            _gameTraveler = gameTraveler;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.TravelerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public TravelerAction GetActionMenuChoice(Menu menu)
        {
            TravelerAction choosenAction = TravelerAction.None;
            Console.CursorVisible = false;

            //
            // create an array of valid keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // validate key pressed as in MenuChoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        private bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            bool validateRange = (minimumValue != 0 || maximumValue != 0);
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetDouble(string prompt, double minimumValue, double maximumValue, out double doubleChoice)
        {
            bool validResponse = false;
            doubleChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (double.TryParse(Console.ReadLine(), out doubleChoice))
                {
                    if (doubleChoice >= minimumValue && doubleChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"DUNGEON MASTER");
            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Dungeon Master";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, TravelerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != TravelerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameTraveler, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(    
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Traveler GetInitialTravelerInfo()
        {
            Traveler traveler = new Traveler();

            //
            // intro
            //
            DisplayGamePlayScreen("Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get traveler's name
            //
            DisplayGamePlayScreen("Initialization - Name", Text.InitializeMissionGetTravelerName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            traveler.Name = GetString();

            //
            // get traveler's age
            //
            //DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetTravelerAge(traveler.Name), ActionMenu.MissionIntro, "");
            //int gameTravelerAge;

            //GetInteger($"Enter your age {traveler.Name}: ", 0, 1000000, out gameTravelerAge);
            //traveler.Age = gameTravelerAge;

            //
            // get traveler's race
            //
            //DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetTravelerRace(traveler), ActionMenu.MissionIntro, "");
            //DisplayInputBoxPrompt($"Enter your race {traveler.Name}: ");
            //traveler.Race = GetRace();

            //
            // get traveler's home planet
            //
            //DisplayGamePlayScreen("Mission Initialization - Home Planet", Text.InitializeMissionGetTravelerHomePlanet(traveler), ActionMenu.MissionIntro, "");
            //DisplayInputBoxPrompt("Enter your home planet: ");
            //traveler.HomePlanet = GetString();

            //
            // echo the traveler's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTravelerInfo(traveler), ActionMenu.MissionIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return traveler;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayTravelerInfo()
        {
            SpaceTimeLocation currentSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);
            DisplayGamePlayScreen("Traveler Information", Text.TravelerInfo(_gameTraveler, currentSpaceTimeLocation), ActionMenu.MainMenu, "");
        }

        public void DisplayCurrentLocationInfo()
        {
            SpaceTimeLocation currentSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentSpaceTimeLocation), ActionMenu.MainMenu, "");
        }

        public void DisplayLookAround()
        {
            SpaceTimeLocation currentSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);
            List<GameObject> gameObjectsInCurrentSpaceTimeLocation =
                _gameUniverse.GetGameObjectsBySpaceTimeLocationId(_gameTraveler.SpaceTimeLocationID);
            string messageBoxText = Text.LookAround(currentSpaceTimeLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentSpaceTimeLocation);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentSpaceTimeLocation), ActionMenu.MainMenu, "");
        }

        public int DisplayGetNextSpaceTimeLocation()
        {
            int spaceTimeLocationId = 0;
            bool validSpaceTimeLocationId = false;

            DisplayGamePlayScreen("Travel to a New Location", Text.Travel(_gameTraveler, _gameUniverse.SpaceTimeLocations), ActionMenu.MainMenu, "");

            while (!validSpaceTimeLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new location {_gameTraveler.Name}: ", 1, _gameUniverse.GetMaxSpaceTimeLocationId(), out spaceTimeLocationId);

                //
                // validate integer as a valid space-time location id and determine accessibility
                //
                if (_gameUniverse.IsValidSpaceTimeLocationId(spaceTimeLocationId))
                {
                    if (_gameUniverse.IsAccessibleLocation(spaceTimeLocationId))
                    {
                        validSpaceTimeLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you attempting to travel to an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered an invalid Space-Time location id. Please try again.");
                }
            }

            return spaceTimeLocationId;
        }

        public void DisplayLocationsVisited()
        {
            //
            // generate a list of space time locations that have been visited
            //
            List<SpaceTimeLocation> visitedSpaceTimeLocations = new List<SpaceTimeLocation>();
            foreach (int spaceTimeLocationId in _gameTraveler.SpaceTimeLocationsVisited)
            {
                visitedSpaceTimeLocations.Add(_gameUniverse.GetSpaceTimeLocationById(spaceTimeLocationId));
            }

            DisplayGamePlayScreen("Locations Visited", Text.VisitedLocations(visitedSpaceTimeLocations), ActionMenu.MainMenu, "");
        }

        public void DisplayListOfSpaceTimeLocations()
        {
            DisplayGamePlayScreen("List: Locations", Text.ListAllSpaceTimeLocations(_gameUniverse.SpaceTimeLocations), ActionMenu.AdminMenu, "");
        }

        #endregion

        public void DisplayGameOver()
        {
            
        }

        #endregion

        #region SPRINT THREE METHODS

        public void DisplayListOfAllGameObject()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameobjects(_gameUniverse.GameObjects), ActionMenu.AdminMenu, "");
        }

        public int DisplayGetObjectsToLookAt()
        {
            int gameObjectId = 0;
            bool vaildGamerObjectId = false;

            List<GameObject> gameObjectsInSpaceTimeLocation =
                _gameUniverse.GetGameObjectsBySpaceTimeLocationId(_gameTraveler.SpaceTimeLocationID);

            if (gameObjectsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsInSpaceTimeLocation), ActionMenu.MainMenu, "");

                while (!vaildGamerObjectId)
                {
                    GetInteger($"Enter the ID number of the game object you wish to look at: ", 0, 0, out gameObjectId);

                    if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectId, _gameTraveler.SpaceTimeLocationID))
                    {
                        vaildGamerObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid ID, please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no objects here...", ActionMenu.MainMenu, "");
            }
           
            return gameObjectId;
        }

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.MainMenu, "");
        }

        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gameTraveler.Inventory), ActionMenu.MainMenu, "");
        }

        public int DisplayGetTravelerObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            List<TravelerObject> travelerObjectsInSpaceTimeLocation = _gameUniverse.GetTravelerObjectBySpaceTimeLocationId(_gameTraveler.SpaceTimeLocationID);

            if (travelerObjectsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick up Game Object", Text.GameObjectChooseList(travelerObjectsInSpaceTimeLocation), ActionMenu.MainMenu, "");

                while (!validGameObjectId)
                {
                    GetInteger($"Enter the ID number of the object you wish to add to your inventory: ", 0, 0 , out gameObjectId);

                    if (_gameUniverse.IsVaildTravelerObjectByLocationId(gameObjectId, _gameTraveler.SpaceTimeLocationID))
                    {
                        TravelerObject travelerObject = _gameUniverse.GetGameObjectById(gameObjectId) as TravelerObject;
                        if (travelerObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you may not put that object in your inventory. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object ID. Please try again.");
                    }

                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }

        public int DisplayGetInventoryObjectToPutDown()
        {
            int travelerObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gameTraveler.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gameTraveler.Inventory), ActionMenu.MainMenu, "");

                while (!validInventoryObjectId)
                {
                    GetInteger($"Enter the ID number of the object you wish to remove from your inventory: ", 0, 0, out travelerObjectId);

                    TravelerObject objectToPutDown = _gameTraveler.Inventory.FirstOrDefault(o => o.Id == travelerObjectId);

                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the ID of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.MainMenu, "");
            }

            return travelerObjectId;
        }

        public void DisplayConfirmTravelerObjectAddedToInventory(TravelerObject objectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} has been added to your inventory.", ActionMenu.MainMenu, "");
        }

        public void DisplayConfirmTravelerObjectRemovedFromInventory(TravelerObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.MainMenu, "");
        }
        #endregion
    }
}
