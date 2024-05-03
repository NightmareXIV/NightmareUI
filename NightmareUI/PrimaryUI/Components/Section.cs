using Dalamud.Interface.Colors;
using ECommons;
using ECommons.ImGuiMethods;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NightmareUI.PrimaryUI.Components;
internal class Section
{
		internal string Name = "";
		internal Vector4? Color;
		internal List<IWidget> Widgets = [];
		internal bool PrevSeparator = false;
		internal Func<bool>? Cond = null;
		internal bool CondComp;

		public bool ShouldDraw => Widgets.OfType<ImGuiWidget>().Any(z => z.ShouldDraw);

		internal void Draw()
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
										Vector4? col = (NuiBuilder.Filter != "") ? (ShouldDraw ? ImGuiColors.ParsedGreen : ImGuiColors.DalamudGrey3) : null;
										PrevSeparator = false;
										if (col != null) ImGui.PushStyleColor(ImGuiCol.Text, col.Value);
										try
										{
												if (imGuiWidget.Width != null)
												{
														ImGui.SetNextItemWidth(imGuiWidget.Width.Value);
												}
												imGuiWidget.DrawAction(imGuiWidget.Label);
												if(imGuiWidget.Help != null)
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
