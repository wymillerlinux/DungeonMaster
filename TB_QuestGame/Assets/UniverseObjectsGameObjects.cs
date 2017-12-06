using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new TravelerObject
            {
                Id = 1,
                Name = "Loose Sandstone",
                SpaceTimeLocationId = 1,
                Description = "A small loose sandstone just lying about. How perculiar.",
                Type = TravelerObjectType.Progress,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 2,
                Name = "Stone Turtle",
                SpaceTimeLocationId = 2,
                Description = "A small stone turtle is looking at you. Both you and the turtle are playing the staring game!",
                Type = TravelerObjectType.Progress,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 3,
                Name = "Map",
                SpaceTimeLocationId = 1,
                Description = "By golly, it's a map! Must've been left when a previous traveler came by here.",
                Type = TravelerObjectType.Information,
                Value = 10,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 4,
                Name = "Norlan Document ND-3075",
                SpaceTimeLocationId = 3,
                Description =
                    "Memo: Origin Errata" + "/n" +
                    "Universal Date: 378598" + "/n" +
                    "/n" +
                    "It appears a potential origin for the technology is based on Plenatia 5 in the Star Reach Galaxy.",
                Type = TravelerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 8,
                Name = "Aion Tracker",
                SpaceTimeLocationId = 0,
                Description =
                    "Standard issue device worn around wrist that allows for tracking and messaging.",
                Type = TravelerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 9,
                Name = "RatPak 47",
                SpaceTimeLocationId = 0,
                Description =
                    "Standard issue ration package contain nutrients for 72 hours.",
                Type = TravelerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            }
        };
    }
}