using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.IO;
using System.Reflection;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;

namespace FanIdeasMod.Common.ILEdits
{
    public static class UIWorldListItem_IL
    {
        public static void Load()
        {
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawPanel += DrawPanelBlack;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += DrawSelfBlack;
        }

        public static void Unload()
        {
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawPanel -= DrawPanelBlack;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= DrawSelfBlack;
        }

        private static void DrawPanelBlack(ILContext il)
        {
            ILCursor c = new ILCursor(il);

            /* Match:
             * call valuetype [Microsoft.Xna.Framework]Microsoft.Xna.Framework.Color [Microsoft.Xna.Framework]Microsoft.Xna.Framework.Color::get_White()
             * three times, pop the current call opcode, and replace it with our own method.
             */
            for (int i = 0; i < 3; i++)
            {
                if (!c.TryGotoNext(x => x.MatchCall<Color>("get_White")))
                {
                    FanIdeasMod.Instance.Logger.Warn("[IL] Failed to match call \"get_White\"");
                    return;
                }

                c.Index++;

                c.Emit(OpCodes.Pop);
                c.Emit(OpCodes.Ldarg_0); // this.
                c.Emit(OpCodes.Ldfld, typeof(UIWorldListItem).GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance)); // _data (WorldFileData)
                c.EmitDelegate<Func<WorldFileData, Color>>((data) =>
                {
                    return GetPanelColor(data, new Color(20, 20, 20));
                });
            }
        }

        private static void DrawSelfBlack(ILContext il)
        {
            ILCursor c = new ILCursor(il);

            /* Match:
             * call valuetype [Microsoft.Xna.Framework]Microsoft.Xna.Framework.Color [Microsoft.Xna.Framework]Microsoft.Xna.Framework.Color::get_White()
             * two times (skipping the first time), pop the current call opcode, and replace it with our own method.
             */
            if (!c.TryGotoNext(i => i.MatchCall<Color>("get_White")))
            {
                FanIdeasMod.Instance.Logger.Warn("[IL] Failed to match call \"get_White\"");
                return;
            }

            if (!c.TryGotoNext(i => i.MatchCall<Color>("get_White")))
            {
                FanIdeasMod.Instance.Logger.Warn("[IL] Failed to match call \"get_White\"");
                return;
            }

            c.Index++;

            c.Emit(OpCodes.Pop);
            c.Emit(OpCodes.Ldarg_0); // this.
            c.Emit(OpCodes.Ldfld, typeof(UIWorldListItem).GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance)); // _data (WorldFileData)
            c.EmitDelegate<Func<WorldFileData, Color>>((data) =>
            {
                return GetPanelColor(data, new Color(50, 50, 50));
            });
        }

        public static Color GetPanelColor(WorldFileData data, Color color) => File.Exists(Path.ChangeExtension(data.Path, ".fwim")) ? color : Color.White;
    }
}