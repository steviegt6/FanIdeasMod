namespace FanIdeasMod.Common.Detours
{
    /// <summary>
    /// Main class that handles all detours (method swaps) performed by this mod.
    /// </summary>
    public static class DetourHandler
    {
        /// <summary>
        /// Initialized all of our detours.
        /// </summary>
        public static void Load()
        {
            UIWorldListItem_On.Load();
        }

        /// <summary>
        /// Unloads any data that isn't automatically removed.
        /// </summary>
        public static void Unload()
        {
        }
    }
}