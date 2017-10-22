using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject.Assets
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's
    /// </summary>
    public static class UniverseObjects
    {
        public static IEnumerable<SpaceTimeLocation> SpaceTimeLocations = new List<SpaceTimeLocation>()
        {

            new SpaceTimeLocation
            {
                CommonName = "Aion Base Lab",
                SpaceTimeLocationID = 1,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Norlon Corporation research facility located in " +
                    "the city of Heraklion on the north coast of Crete and the top secret " +
                    "research lab for the Aion Project.\n",
                GeneralContents = "The lab is a large, well lit room, and staffed " +
                    "by a small number of scientists, all wearing light blue uniforms with the " +
                    "hydra-like Norlan Corporation logo. \n",
                Accessable = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Felandrian Plains",
                SpaceTimeLocationID = 2,
                UniversalDate = 386759,
                UniversalLocation = "P-2, SS-85, G-2976, LS-3976",
                Description = "The Felandrian Plains are a common destination for tourist. " +
                    "Located just north of the equatorial line on the planet of Corlon, they " +
                    "provide excellent habitat for a rich ecosystem of flora and fauna.",
                GeneralContents = "- stuff in the room -",
                Accessable = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Xantoria Market",
                SpaceTimeLocationID = 3,
                UniversalDate = 386759,
                UniversalLocation = "P-6, SS-3978, G-2976, LS-3976",
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                GeneralContents = "- stuff in the room -",
                Accessable = true,
                ExperiencePoints = 20
            },

                        new SpaceTimeLocation
            {
                CommonName = "Norlon Corporate Headquarters",
                SpaceTimeLocationID = 4,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit Michigan." +
                              "Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company " +
                              "with huge holdings in defense and space research and development.",
                GeneralContents = "- stuff in the room -",
                Accessable = false,
                ExperiencePoints = 10
            }
        };
    }
}
