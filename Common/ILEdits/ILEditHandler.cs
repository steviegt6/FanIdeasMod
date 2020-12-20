namespace FanIdeasMod.Common.ILEdits
{
    /// <summary>
    /// Main class that handles all IL edits performed by this mod.
    /// </summary>
    public static class ILEditHandler
    {
        /// <summary>
        /// Initialized all of our IL edits.
        /// </summary>
        public static void Load()
        {
            UIWorldListItem_IL.Load();
        }

        /// <summary>
        /// Unloads any data that isn't automatically removed.
        /// </summary>
        public static void Unload()
        {
            UIWorldListItem_IL.Unload();
        }
    }
}