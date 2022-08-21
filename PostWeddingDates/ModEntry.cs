using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Quests;
using StardewValley.Objects;
using System.Collections.Generic;
using Object = StardewValley.Object;

namespace PostWeddingDates
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {


        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {

            helper.Events.GameLoop.DayEnding += this.OnDayEnded;

            //helper.Events.GameLoop.UpdateTicked += this.onUpdateTicked;

        }

        private void onUpdateTicked(object sender, EventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

        }

        private void OnDayEnded(object sender, EventArgs e)
        {

            if (!Context.IsWorldReady)
                return;

            //Remove flag to allow spouse to ask on date again
            if (Game1.player.mailReceived.Contains("failedSaloonDate"))
            {
                Game1.player.mailReceived.Remove("failedSaloonDate");
            }
            
            if (Game1.player.dialogueQuestionsAnswered.Contains(1070831)) {
                //check for failed Saloon Date
                if (!Game1.player.eventsSeen.Contains(107085))
                {
                    Game1.player.mailReceived.Add("failedSaloonDate");
                } else
                {
                    Game1.player.eventsSeen.Remove(107085);
                }
                Game1.player.dialogueQuestionsAnswered.Remove(1070831);
            }
        }
    }
}