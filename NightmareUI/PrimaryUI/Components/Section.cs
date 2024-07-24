using Dalamud.Interface.Colors;
using ECommons;
using ECommons.ImGuiMethods;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace NightmareUI.PrimaryUI.Components;
internal class Section
{
		internal string Name = "";
		internal Vector4? Color;
		internal List<IWidget> Widgets = [];
		internal bool PrevSeparator = false;
		internal Func<bool>? Cond = null;
		internal bool CondComp;

		public bool ShouldHighlight => Widgets.OfType<ImGuiWidget>().Any(z => z.ShouldHighlight);

		internal void Draw(NuiBuilder builder)
		{
				ImGui.PushStyleVar(ImGuiStyleVar.CellPadding, new Vector2(7f));
				if (ImGui.BeginTable(Name, 1, ImGuiTableFlags.Borders | ImGuiTableFlags.SizingFixedFit))
				{
						ImGui.TableSetupColumn(Name, ImGuiTableColumnFlags.WidthStretch);
						if (Color != null) ImGui.PushStyleColor(ImGuiCol.TableHeaderBg, Color.Value);
						ImGui.TableHeadersRow();
						if (Color != null) ImGui.PopStyleColor();
						ImGui.TableNextRow();
						ImGui.TableNextColumn();
						foreach(var x in Widgets)
						{
								if(x is CondIf condIf)
								{
										CondComp = true;
										Cond = condIf.Predicate;
								}
								else if(x is CondElse)
								{
										CondComp = false;
								}
								else if(x is CondEndIf)
								{
										Cond = null;
								}
								if (Cond != null && Cond.Invoke() != CondComp) continue;
								if(x is ImGuiWidget imGuiWidget)
								{
										Vector4? col = (builder.Filter != "") ? (imGuiWidget.ShouldHighlight ? ImGuiColors.ParsedGreen : ImGuiColors.DalamudGrey3) : null;
										PrevSeparator = false;
										if (col != null) ImGui.PushStyleColor(ImGuiCol.Text, col.Value);
										try
										{
												if (imGuiWidget.Width != null)
												{
														ImGui.SetNextItemWidth(imGuiWidget.Width.Value);
												}
												ImGui.PopStyleVar();
												try
												{
														imGuiWidget.DrawAction(imGuiWidget.Label);
												}
												catch(Exception iex)
												{
														iex.Log();
												}
                        ImGui.PushStyleVar(ImGuiStyleVar.CellPadding, new Vector2(7f));
                        if (imGuiWidget.Help != null)
												{
														ImGuiEx.HelpMarker(imGuiWidget.Help);
												}
										}
										catch(Exception e)
										{
												e.Log();
										}
										if (col != null) ImGui.PopStyleColor();
								}
								else if(x is SeparatorWidget separatorWidget)
								{
										if (!PrevSeparator)
										{
												separatorWidget.DrawAction();
												PrevSeparator = true;
										}
								}
						}
						ImGui.EndTable();
				}
				ImGui.Dummy(new(5f));
				ImGui.PopStyleVar();
		}
}
