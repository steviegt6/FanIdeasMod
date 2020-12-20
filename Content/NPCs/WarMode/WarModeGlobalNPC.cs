using FanIdeasMod.Common.WorldModifications.WarMode;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FanIdeasMod.Content.NPCs.WarMode
{
    public class WarModeGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.MoonLordCore:
                    WarModeWorld.IsWarMode = true;
                    break;
            }
        }
    }
}