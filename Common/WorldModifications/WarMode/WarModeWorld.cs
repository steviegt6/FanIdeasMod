using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace FanIdeasMod.Common.WorldModifications.WarMode
{
    public class WarModeWorld : ModWorld
    {
        public static bool IsWarMode = false;

        public override TagCompound Save()
        {
            // Get the saving world's file name and attempt to a delete a file with the same name ending in ".fwim".
            string fiPath = Path.ChangeExtension(Main.ActiveWorldFileData.Path, ".fwim");
            File.Delete(fiPath);

            // If the world is in War mode, save a blank file with the same name as the active world's file name then ends in ".fwim".
            // This is used for detecting whether or not a world is in War mode in the world menu.
            if (IsWarMode)
                File.Create(fiPath);

            return new TagCompound()
            {
                { "IsWarMode", IsWarMode }
            };
        }

        public override void Load(TagCompound tag) => IsWarMode = tag.GetBool("IsWarMode");
    }
}