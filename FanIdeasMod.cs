using FanIdeasMod.Common.Detours;
using FanIdeasMod.Common.ILEdits;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace FanIdeasMod
{
    public class FanIdeasMod : Mod
    {
        /// <summary>
        /// Universal instance of <see cref="FanIdeasMod"/>.
        /// </summary>
        public static FanIdeasMod Instance { get; private set; }

        public static Assembly Assembly { get; private set; }

        public static Assembly TMLAssembly { get; private set; }

        public FanIdeasMod()
        {
            Instance = this;
            Assembly = GetType().Assembly;
            TMLAssembly = typeof(Main).Assembly;

            Properties = new ModProperties
            {
                // All content that isn't backgrounds, gores, and sounds (i.e. items, tiles, etc.)
                Autoload = true,

                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load()
        {
            DetourHandler.Load();
            ILEditHandler.Load();
        }

        public override void Unload()
        {
            DetourHandler.Load();
            ILEditHandler.Load();
        }
    }
}