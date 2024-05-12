using Dalamud.Interface.Utility;
using ECommons.ExcelServices.TerritoryEnumeration;
using ECommons.ImGuiMethods;
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
		public static void InitializeSingletonWindows()
		{

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
