using Terraria.ModLoader;

namespace FanIdeasMod
{
    public class FanIdeasMod : Mod
    {
        /// <summary>
        /// Universal instance of <see cref="FanIdeasMod"/>.
        /// </summary>
        public static FanIdeasMod Instance { get; private set; }

        public FanIdeasMod()
        {
            Instance = this;

            Properties = new ModProperties
            {
                // All content that isn't backgrounds, gores, and sounds (i.e. items, tiles, etc.)
                Autoload = true,

                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}