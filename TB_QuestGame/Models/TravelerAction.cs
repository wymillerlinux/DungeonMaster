using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum TravelerAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Inventory,
        Travel,
        TravelerInfo,
        TravelerLocationsVisited,
        ListSpaceTimeLocations,
        ListGameObjects,
        AdminMenu,
        ReturnToMainMenu,
        ListItems,
        ListTreasures,
        Exit
    }
}
