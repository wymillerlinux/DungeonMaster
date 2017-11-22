using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            AdminMenu
        }

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
                    { '1', TravelerAction.TravelerInfo },
                    { '2', TravelerAction.LookAround },
                    { '3', TravelerAction.LookAt},
                    { '4', TravelerAction.PickUp},
                    { '5', TravelerAction.PutDown},
                    { '6', TravelerAction.Inventory},
                    { '7', TravelerAction.Travel },
                    { '8', TravelerAction.TravelerLocationsVisited },
                    //{ '6', TravelerAction.ListSpaceTimeLocations },
                    //{ '7', TravelerAction.ListGameObjects},
                    { '9', TravelerAction.AdminMenu},
                    { '0', TravelerAction.Exit }
                }
        };
        
        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, TravelerAction>()
            {
                { '1', TravelerAction.ListSpaceTimeLocations},
                { '2', TravelerAction.ListGameObjects},
                { '0', TravelerAction.ReturnToMainMenu}
            }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Traveler",
        //    MenuChoices = new Dictionary<char, TravelerAction>()
        //            {
        //                TravelerAction.MissionSetup,
        //                TravelerAction.TravelerInfo,
        //                TravelerAction.Exit
        //            }
        //};
    }
}
