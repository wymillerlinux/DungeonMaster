using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all npc objects
    /// </summary>
    public static partial class UniverseObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                Id = 1,
                Name = "Skeleton Joe",
                SpaceTimeLocationId = 2,
                Description = "A tall man in baggy pants with a red, pin stripped hat.",
                Messages = new List<string>
                {
                    "Greetings stranger. You are not from these parts as I can see.",
                    "You will find what you are looking for with the Pink Gorilla.",
                    "I once attended the Academy. They felt I needed more candles."
                }
            },

            new Civilian
            {
                Id = 2,
                Name = "Dead Corpse",
                SpaceTimeLocationId = 1,
                Description = "The lead developer of the Stratus Flux Capacitor.",
                Messages = new List<string>
                {
                    "I have to go. Good bye!",
                    "It was always meant for good. We had no idea.",
                    "Is that man following you?"
                }
            },

            new Civilian
            {
                Id = 3,
                Name = "Skeleton Jim",
                SpaceTimeLocationId = 2,
                Description = "A Thorian diplomat dressed in traditional phlox and cords."
            }
        };
    }
}
