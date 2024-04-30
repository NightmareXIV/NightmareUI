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
public class Section
{
		internal string Name = "";
		internal Vector4? Color;
		internal List<IWidget> Widgets = [];

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
								if(x is ImGuiWidget imGuiWidget)
								{
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
								}
								else if(x is SeparatorWidget separatorWidget)
								{
										separatorWidget.DrawAction();
								}
						}
						ImGui.EndTable();
				}
				ImGui.Dummy(new(5f));
				ImGui.PopStyleVar();
		}
}
