using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's
    /// </summary>
    public static partial class UniverseObjects
    {
        public static List<SpaceTimeLocation> SpaceTimeLocations = new List<SpaceTimeLocation>()
        {

            new SpaceTimeLocation
            {
                CommonName = "Starting Room (or Room One)",
                SpaceTimeLocationID = 1,
                UniversalDate = 001,
                UniversalLocation = "R1",
                Description = "This appears that this the room you have started in. " +
                    "You see light from where you have fallen into. Looks like there's no turning back. " +
                    "Also you see skeletons lying around. You can't tell if they are previous travelers or not. Spooky...",
                GeneralContents =
                 "The room is square, all the walls are sandstone.\n " +
                    "There is a door at the across from you which you cannot open. It appears a puzzle falls into your hands. " +
                    "You don't feel like you can solve puzzles after that fall you had. \n",
                Accessible = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Further In (or Room Two)",
                SpaceTimeLocationID = 2,
                UniversalDate = 002,
                UniversalLocation = "R2",
                Description = "This room appears to filled to the brim with more sandstone. " +
                    "You're very perplexed about the amount of sandstone is in this place.\n",
                GeneralContents = "Sandstone, of course. There's two doors, one to your left " +
                "and one across from you. The door in front of you has an upward arrow in the center of it." +
                "The door on the left has a lock shaped symbol on the center of it.\n You also see stone " +
                "turtles just sitting there on the floor. You don't pay any attention to it" +
                "because it's giving you the stink eye.\n There's alot of loose bricks of sandstone lying about as well. ",
                Accessible = false,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Yet Deeper (or Room Three)",
                SpaceTimeLocationID = 3,
                UniversalDate = 003,
                UniversalLocation = "R3",
                Description = "Wishing the puzzles would stop, enter yet another room!\n Again, plum full " +
                "of sandstone. By now, you're sick of sandstone.\n You facepalm and you continue to solve the next puzzle.",
                GeneralContents =
                "More sandstone walls. There's two doors, one on your right" +
                "and one across from you.\n The door in front of you has an upward arrow in the center of it." +
                "The door on the left has a lock shaped symbol on the center of it.\n You also see three pressure plates" +
                "lined up next to each other.",
                Accessible = false,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Almost There (or Room Four)",
                SpaceTimeLocationID = 4,
                UniversalDate = 004,
                UniversalLocation = "R4",
                Description = "You see light behind the last door." +
                              "You can't wait for the puzzles to be done.",
                GeneralContents = "More sandstone and one turtle",
                Accessible = false,
                ExperiencePoints = 10
            },
            
            new SpaceTimeLocation
            {
                CommonName = "The End (or The Surface)",
                SpaceTimeLocationID = 5,
                UniversalDate = 004,
                UniversalLocation = "S",
                Description = "You see the wonderful landscape of Peru. You have beaten the game!",
                GeneralContents = "Trees, trees and more trees...",
                Accessible = false,
                ExperiencePoints = 50
            },

            new SpaceTimeLocation
            {
                CommonName = "SECRET! (or Secret Room 1)",
                SpaceTimeLocationID = 6,
                UniversalDate = 999999,
                UniversalLocation = "SR1",
                Description = "You found a secret room! \n" +
                              "01010100 01101000 01100101  01110011 01100101 01100011 01110010 01100101 01110100  01110100 01101111  01100110 01101001 01101110 01101001 01110011 01101000 01101001 01101110 01100111  01110100 01101000 01100101  01100111 01100001 01101101 01100101  01101001 01110011  01110100 01101111 01101100 01100100  01101000 01101111 01101100 01100100  01100110 01101111 01110101 01110010  01101011 01100101 01111001 01110011  01110011 01100011 01100001 01110100 01110100 01100101 01110010 01100101 01100100  01100001 01100011 01110010 01101111 01110011 01110011  01110100 01101000 01100101  01100100 01110101 01101110 01100111 01100101 01101111 01101110 00111010  01110100 01101000 01100101  01010010 01100101 01100100  01001011 01100101 01111001 00101100  01110100 01101000 01100101  01011001 01100101 01101100 01101100 01101111 01110111  01001011 01100101 01111001 00101100  01010100 01101000 01100101  01000010 01101100 01110101 01100101  01001011 01100101 01111001 00101100  01100001 01101110 01100100  01110100 01101000 01100101  01000111 01110010 01100101 01100101 01101110  01001011 01100101 01111001 00101110  01000111 01100101 01110100  01110100 01101000 01101111 01110011 01100101  01100001 01101110 01100100  01111001 01101111 01110101 00100111 01101100 01101100  01100010 01100101  01100001 01100010 01101100 01100101  01110100 01101111  01100101 01111000 01101001 01110100  01110100 01101000 01100101  01100100 01110101 01101110 01100111 01100101 01101111 01101110 00101110 ",
                GeneralContents = "Rust, dust and guts. And progress.",
                Accessible = false,
                ExperiencePoints = 500
            },

            new SpaceTimeLocation
            {
                CommonName = "SECRET! (or Secret Room 2)",
                SpaceTimeLocationID = 7,
                UniversalDate = 999999,
                UniversalLocation = "SR2",
                Description = "You found a secret room! \n" +
                    "01010100 01101000 01100001 01101110 01101011  01111001 01101111 01110101  01100110 01101111 01110010  01100100 01100101 01100011 01101111 01100100 01101001 01101110 01100111  01110100 01101000 01101001 01110011  01101101 01100101 01110011 01110011 01100001 01100111 01100101 00101110  01001001  01110111 01101111 01110101 01101100 01100100  01101100 01101001 01101011 01100101  01110100 01101111  01110100 01101000 01100001 01101110 01101011  01101101 01111001  01001110 01001101 01000011  00110001 00111001 00110101  01100011 01101111 01110101 01110010 01110011 01100101  01100110 01101111 01110010  01100001 01101100 01101100 01101111 01110111 01101001 01101110 01100111  01101101 01100101  01110100 01101111  01101101 01100001 01101011 01100101  01110011 01110101 01100011 01101000  01100001 01101110  01100001 01110111 01100101 01110011 01101111 01101101 01100101  01100111 01100001 01101101 01100101 00101110",
                GeneralContents = "Rust, dust and guts. And lore, I forgot.",
                Accessible = false,
                ExperiencePoints = 500
            }
        };
    }
}
