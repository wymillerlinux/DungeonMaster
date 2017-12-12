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
                Description = "A tall skeleton lying against a wall. You should take a look at your face.",
                Messages = new List<string>
                {
                    "The skeleton doesn't want to talk. You shake the skeleton out of frustration. You suddenly realize a red key has fallen."
                },
                InteractedWith = false
            },

            new Civilian
            {
                Id = 2,
                Name = "Dead Corpse",
                SpaceTimeLocationId = 1,
                Description = "A dead corpse, face first on the sandstone. You don't know if you should touch it.",
                Messages = new List<string>
                {
                    "This corpse seems dead, apprently. After examining him a bit, you find a wallet full of cash and a yellow key."
                },
                InteractedWith = false
            },

            new Civilian
            {
                Id = 3,
                Name = "Skeleton Jim",
                SpaceTimeLocationId = 2,
                Description = "Another skeleton lying against a wall. This skeleton, however, seems short.",
                InteractedWith = false
            },
            
            new Civilian
            {
                Id = 4,
                Name = "Trash Can Carl",
                SpaceTimeLocationId = 3,
                Description = "",
                Messages = new List<string>
                {
                    "Don't talk to me again, you rat. You'll never make out of here.",
                    "Lemme say that again, you rotten good for nothing deadbeat. You can open the secret door in this room by holding four items.",
                    "Let me give you a hint for your stupid mind. You can open the secret door in this room by holding four items.",
                    "Hey, I can talk ya know!",
                },
                InteractedWith = false
            }
        };
    }
}
