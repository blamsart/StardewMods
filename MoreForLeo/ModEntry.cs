using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Objects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewValley.Buildings;
using StardewValley.Characters;
using StardewValley.Locations;
using StardewValley.Menus;
using StardewValley.Network;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;
using SObject = StardewValley.Object;

namespace MoreForLeo
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {

        private Hat duckHat;
        private Hat cocoHead;
        private Hat woodCrown;
        private Hat bossSlime;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += this.onNewDay;
            helper.Events.GameLoop.UpdateTicking += this.onUpdateTicked;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void onNewDay(object sender, DayStartedEventArgs e)
        {
            
            if(Game1.player.whichPetBreed == 1 && !Game1.player.mailReceived.Contains("FarmerHasDog"))
            {
                Game1.player.mailReceived.Add("FarmerHasDog");
            }

            if(Game1.player.eventsSeen.Contains(127105) && Game1.player.dialogueQuestionsAnswered.Contains(1271052)){
                Game1.player.eventsSeen.Remove(127105);
                Game1.player.dialogueQuestionsAnswered.Remove(1271052);
            }

            Dictionary<int, string> allHats = Game1.content.Load<Dictionary<int, string>>("Data\\Hats");
            foreach(KeyValuePair<int, string> hat in allHats)
            {
                if(hat.Value.Contains("Duck Hat") && duckHat == null){
                    duckHat = new Hat(hat.Key);
                } 
                else if (hat.Value.Contains("Coco Head") && cocoHead == null)
                {
                    cocoHead = new Hat(hat.Key);
                }
                else if (hat.Value.Contains("Wood Crown") && woodCrown == null)
                {
                    woodCrown = new Hat(hat.Key);
                }
                else if (hat.Value.Contains("Boss Slime") && bossSlime == null)
                {
                    bossSlime = new Hat(hat.Key);
                }
            }

        }
        private void onUpdateTicked(object sender, EventArgs e)
        {
            if (!Context.IsWorldReady)
                return;


            if (Game1.activeClickableMenu == null)
            {
                if (Game1.player.mailReceived.Contains("duckHatComplete"))
                {
                    Game1.player.addItemByMenuIfNecessary(duckHat);
                    Game1.player.mailReceived.Remove("duckHatComplete");
                }
                else if (Game1.player.mailReceived.Contains("cocoHeadComplete"))
                {
                    Game1.player.addItemByMenuIfNecessary(cocoHead);
                    Game1.player.mailReceived.Remove("cocoHeadComplete");
                }
                else if (Game1.player.mailReceived.Contains("woodCrownComplete"))
                {
                    Game1.player.addItemByMenuIfNecessary(woodCrown);
                    Game1.player.mailReceived.Remove("woodCrownComplete");
                }
                else if (Game1.player.mailReceived.Contains("bossSlimeComplete"))
                {
                    Game1.player.addItemByMenuIfNecessary(bossSlime);
                    Game1.player.mailReceived.Remove("bossSlimeComplete");
                }
            }
        }
    }
}