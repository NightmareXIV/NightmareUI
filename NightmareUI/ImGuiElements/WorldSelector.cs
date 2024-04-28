using ECommons.DalamudServices;
using ECommons.ExcelServices;
using ECommons.ImGuiMethods;
using ImGuiNET;
using Lumina.Excel.GeneratedSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI.ImGuiElements;
public class WorldSelector
{
		private static WorldSelector? _instance;
		public static WorldSelector Instance
		{
				get
				{
						_instance ??= new();
						return _instance;
				}
		}

		private string WorldFilter = "";
		private bool WorldFilterActive = false;

		private string ID;

		public WorldSelector(string id = "##world")
		{
				ID = id;
		}

		public void Draw(ref int worldConfig, ImGuiComboFlags flags = ImGuiComboFlags.HeightLarge)
		{
				ImGui.PushID(ID);
				if (ImGui.BeginCombo("", ExcelWorldHelper.GetName(worldConfig), flags))
				{
						DrawInternal(ref worldConfig);
						ImGui.EndCombo();
				}
				ImGui.PopID();
		}

		public void DrawInternal(ref int worldConfig)
		{
				ImGuiEx.SetNextItemFullWidth();
				if (ImGui.IsWindowAppearing()) ImGui.SetKeyboardFocusHere();
				ImGui.InputTextWithHint($"##worldfilter", "Search...", ref WorldFilter, 50);
				Dictionary<ExcelWorldHelper.Region, Dictionary<uint, List<uint>>> regions = [];
				foreach (var region in Enum.GetValues<ExcelWorldHelper.Region>())
				{
						regions[region] = [];
						foreach (var dc in Svc.Data.GetExcelSheet<WorldDCGroupType>()!)
						{
								if (dc.Region == (byte)region)
								{
										regions[region][dc.RowId] = [];
										foreach (var world in ExcelWorldHelper.GetPublicWorlds(dc.RowId))
										{
												if (WorldFilter == "" || world.Name.ToString().Contains(WorldFilter, StringComparison.OrdinalIgnoreCase) || world.RowId.ToString().Contains(WorldFilter, StringComparison.OrdinalIgnoreCase))
												{
														regions[region][dc.RowId].Add(world.RowId);
												}
										}
										regions[region][dc.RowId] = [.. regions[region][dc.RowId].OrderBy(ExcelWorldHelper.GetName)];
								}
						}
				}
				ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 1));
				foreach (var region in regions)
				{
						if (region.Value.Sum(dc => dc.Value.Count) > 0)
						{
								if (WorldFilter != "" && (!WorldFilterActive || ImGui.IsWindowAppearing()))
								{
										ImGui.SetNextItemOpen(true);
								}
								else if (ImGui.IsWindowAppearing() || (WorldFilter == "" && WorldFilterActive))
								{
										var w = worldConfig;
										if (region.Value.Any(d => d.Value.Contains((uint)w)))
										{
												ImGui.SetNextItemOpen(true);
										}
										else
										{
												ImGui.SetNextItemOpen(false);
												foreach (var v in region.Value)
												{
														ImGui.PushID($"{region.Key}");
														ImGui.GetStateStorage().SetInt(ImGui.GetID($"{Svc.Data.GetExcelSheet<WorldDCGroupType>()!.GetRow(v.Key)?.Name}"), 0);
														ImGui.PopID();
												}
										}
								}
								if (ImGuiEx.TreeNode($"{region.Key}"))
								{
										foreach (var dc in region.Value)
										{
												if (dc.Value.Count > 0)
												{
														if (WorldFilter != "" && (!WorldFilterActive || ImGui.IsWindowAppearing()))
														{
																ImGui.SetNextItemOpen(true);
														}
														else if (ImGui.IsWindowAppearing() || (WorldFilter == "" && WorldFilterActive))
														{
																if (dc.Value.Contains((uint)worldConfig))
																{
																		ImGui.SetNextItemOpen(true);
																}
																else
																{
																		ImGui.SetNextItemOpen(false);
																}
														}
														if (ImGuiEx.TreeNode($"{Svc.Data.GetExcelSheet<WorldDCGroupType>()!.GetRow(dc.Key)?.Name}"))
														{
																foreach (var world in dc.Value)
																{
																		ImGui.SetNextItemOpen(false);
																		if (ImGuiEx.TreeNode($"{ExcelWorldHelper.GetName(world)}", ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.Bullet | (world == worldConfig ? ImGuiTreeNodeFlags.Selected : ImGuiTreeNodeFlags.None)))
																		{
																				worldConfig = (int)world;
																				ImGui.CloseCurrentPopup();
																		}
																}
																ImGui.TreePop();
														}
												}
										}
										ImGui.TreePop();
								}
						}
				}
				ImGui.PopStyleVar();
				WorldFilterActive = WorldFilter != "";
		}
}
