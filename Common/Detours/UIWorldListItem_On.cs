using Microsoft.Xna.Framework;
using System.IO;
using System.Reflection;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.UI;

namespace FanIdeasMod.Common.Detours
{
    public static class UIWorldListItem_On
    {
        public static void Load()
        {
            On.Terraria.GameContent.UI.Elements.UIWorldListItem.MouseOver += MouseOverBlack;
            On.Terraria.GameContent.UI.Elements.UIWorldListItem.MouseOut += MouseOutBlack;
            On.Terraria.GameContent.UI.Elements.UIWorldListItem.ctor += ConstructorBlack;
        }

        private static void ConstructorBlack(On.Terraria.GameContent.UI.Elements.UIWorldListItem.orig_ctor orig, UIWorldListItem self, WorldFileData data, int snapPointIndex)
        {
            orig(self, data, snapPointIndex);

            if (File.Exists(Path.ChangeExtension(data.Path, ".fwim")))
            {
                self.BackgroundColor = new Color(25, 25, 25);
                self.BorderColor = new Color(50, 50, 50);
            }
        }

        private static void MouseOutBlack(On.Terraria.GameContent.UI.Elements.UIWorldListItem.orig_MouseOut orig, UIWorldListItem self, UIMouseEvent evt)
        {
            orig(self, evt);

            if (File.Exists(Path.ChangeExtension(((WorldFileData)FanIdeasMod.TMLAssembly.GetType("Terraria.GameContent.UI.Elements.UIWorldListItem").GetField("_data", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(self)).Path, ".fwim")))
            {
                self.BackgroundColor = new Color(25, 25, 25);
                self.BorderColor = new Color(50, 50, 50);
            }
        }

        private static void MouseOverBlack(On.Terraria.GameContent.UI.Elements.UIWorldListItem.orig_MouseOver orig, UIWorldListItem self, UIMouseEvent evt)
        {
            orig(self, evt);

            if (File.Exists(Path.ChangeExtension(((WorldFileData)FanIdeasMod.TMLAssembly.GetType("Terraria.GameContent.UI.Elements.UIWorldListItem").GetField("_data", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(self)).Path, ".fwim")))
            {
                self.BackgroundColor = new Color(35, 35, 35);
                self.BorderColor = new Color(60, 60, 60);
            }
        }
    }
}