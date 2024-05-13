using Dalamud.Interface.Utility;
using ECommons;
using ECommons.ExcelServices.TerritoryEnumeration;
using ECommons.ImGuiMethods;
using FFXIVClientStructs.FFXIV.Client.Game;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI;
public static class NuiTools
{
		private static Dictionary<string, int> ActiveTab = [];
		public static void ButtonTabs(ButtonInfo[] buttons, int maxButtons = int.MaxValue) => ButtonTabs(GenericHelpers.GetCallStackID(), buttons, maxButtons);
		public static void ButtonTabs(string id, ButtonInfo[] buttons, int maxButtons = int.MaxValue)
		{
				buttons = buttons.Where(x => x != null).ToArray();
				maxButtons = Math.Clamp(maxButtons, 1, buttons.Length);
				if (!ActiveTab.ContainsKey(id)) ActiveTab[id] = 0;
				var width = ImGui.GetContentRegionAvail().X / maxButtons;
				for (int i = 0; i < buttons.Length; i++)
				{
						var b = buttons[i];
						var act = ActiveTab[id] == i;
						ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0f);
						if (act)
						{
								ImGui.PushStyleColor(ImGuiCol.Button, ImGui.GetStyle().Colors[(int)ImGuiCol.ButtonActive]);
								ImGui.PushStyleColor(ImGuiCol.ButtonHovered, ImGui.GetStyle().Colors[(int)ImGuiCol.ButtonActive]);
						}
						var w = width;
						if((i+1) % maxButtons == 0)
						{
								w = ImGui.GetContentRegionAvail().X;
						}
						if(ImGui.Button(b.Name, new(w, ImGui.GetFrameHeight())))
						{
								ActiveTab[id] = i;
						}
						if((i+1) % maxButtons != 0 && i+1 != buttons.Length)
						{
								ImGui.SameLine(0,0);
						}
						if (act)
						{
								ImGui.PopStyleColor(2);
						}
						ImGui.PopStyleVar();
				}
				try
				{
						buttons[ActiveTab[id]].Action();
				}
				catch (Exception e)
				{
						e.Log();
				}
		}

		public record class ButtonInfo
		{
				public readonly string Name;
				public readonly Action Action;

				public ButtonInfo(string name, Action action)
				{
						Name = name ?? throw new ArgumentNullException(nameof(name));
						Action = action ?? throw new ArgumentNullException(nameof(action));
				}
		}


		public static bool RenderResidentialIcon(this uint residentialAetheryte, float? size = null)
		{
				var id = residentialAetheryte switch
				{
						ResidentalAreas.Mist => (new Vector2(0.3651f, 0.0000f), new Vector2(0.4444f, 0.1408f)),
						ResidentalAreas.The_Lavender_Beds => (new Vector2(0.4444f, 0.0000f), new Vector2(0.5238f, 0.1408f)),
						ResidentalAreas.The_Goblet => (new Vector2(0.3651f, 0.1408f), new Vector2(0.4444f, 0.2817f)),
						ResidentalAreas.Empyreum => (new Vector2(0.5238f, 0.0000f), new Vector2(0.6032f, 0.1408f)),
						ResidentalAreas.Shirogane => (new Vector2(0.7619f, 0.0000f), new Vector2(0.8413f, 0.1408f)),
						_ => (new Vector2(0.5238f, 0.1408f), new Vector2(0.6032f, 0.2817f))
				};
				if (ThreadLoadImageHandler.TryGetTextureWrap("ui/uld/Teleport_hr1.tex", out var tex))
				{
						size ??= ImGuiHelpers.GetButtonSize("A").Y;
						ImGui.Image(tex.ImGuiHandle, new(size.Value), id.Item1, id.Item2);
						return true;
				}
				return false;
		}
}
