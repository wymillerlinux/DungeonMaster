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
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "This appears that this the room you have started in. " +
                    "You see light from where you have fallen into. Looks like there's no turning back. " +
                    "Also you see skeletons lying around. You can't tell if they are previous travelers or not. Spooky...\n",
                GeneralContents = "The room is square, all the walls are sandstone. " +
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
                UniversalLocation = "P-2, SS-85, G-2976, LS-3976",
                Description = "This room appears to filled to the brim with more sandstone. " +
                    "You're very perplexed about the amount of sandstone is in this place. ",
                GeneralContents = "Sandstone, of course. There's is two doors, one to your right " +
                "and one across from you. You also see a stone turtle just sitting there.",
                Accessible = false,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Yet Deeper (or Room Three)",
                SpaceTimeLocationID = 3,
                UniversalDate = 003,
                UniversalLocation = "P-6, SS-3978, G-2976, LS-3976",
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                GeneralContents = "- stuff in the room -",
                Accessible = false,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Almost There (or Room Four)",
                SpaceTimeLocationID = 4,
                UniversalDate = 004,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit Michigan." +
                              "Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company " +
                              "with huge holdings in defense and space research and development.",
                GeneralContents = "- stuff in the room -",
                Accessible = true,
                ExperiencePoints = 10
            },
            
            new SpaceTimeLocation
            {
                CommonName = "IT'S A SECRET! (or Secret Room 1)",
                SpaceTimeLocationID = 5,
                UniversalDate = 386759,
                UniversalLocation = "P-?, SS-???, G-????, LS-????",
                Description = "You found a secret room! Treasure will appear here." +
                              "" +
                              " ",
                GeneralContents = "Rust, Dust and Guts",
                Accessible = false,
                ExperiencePoints = 10   
            }
        };
    }
}
