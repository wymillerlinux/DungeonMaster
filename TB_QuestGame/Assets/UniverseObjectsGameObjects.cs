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
                Name = "Stone Turtle Tom",
                SpaceTimeLocationId = 2,
                Description = "A small stone turtle is looking at you blankly. Both you and the turtle are playing the staring game!",
                Type = TravelerObjectType.Turtles,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 3,
                Name = "Yellow Key",
                SpaceTimeLocationId = 1,
                Description = "It's a yellow key, shaded yellow. Looks shiny.",
                Type = TravelerObjectType.Progress,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            
            new TravelerObject
            {
                Id = 4,
                Name = "Map",
                SpaceTimeLocationId = 1,
                Description = "By golly, it's a map! Must've been left when a previous traveler came by here. However, there's nothing but text that says 'MAP'. Lame.",
                Type = TravelerObjectType.Information,
                Value = 10,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 5,
                Name = "Red Key",
                SpaceTimeLocationId = 2,
                Description =
                    "It's a key, shaded red. It looks like it's been on Mars.",
                Type = TravelerObjectType.Progress,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 6,
                Name = "Green Key",
                SpaceTimeLocationId = 3,
                Description =
                    "It's a key, shaded green. It's looks it has been rotting here.",
                Type = TravelerObjectType.Progress,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 7,
                Name = "Blue Key",
                SpaceTimeLocationId = 6,
                Description =
                    "It's a key, shaded blue. It's looked like the ocean.",
                Type = TravelerObjectType.Progress,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            
            
            new TravelerObject
            {
                Id = 8,
                Name = "Stone Turtle Tim",
                SpaceTimeLocationId = 3,
                Description = "A small stone turtle is looking at you smugly. Both you and the turtle are playing the staring game!",
                Type = TravelerObjectType.Turtles,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            
            new TravelerObject
            {
                Id = 9,
                Name = "Stone Turtle Temmie",
                SpaceTimeLocationId = 4,
                Description = "A small stone turtle is looking at you nervously. Both you and the turtle are playing the staring game!",
                Type = TravelerObjectType.Turtles,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            
            new TravelerObject
            {
                Id = 10,
                Name = "Stone Turtle Teddy",
                SpaceTimeLocationId = 2,
                Description = "A small stone turtle is looking at you cautiously. Both you and the turtle are playing the staring game!",
                Type = TravelerObjectType.Turtles,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
        };
    }
}