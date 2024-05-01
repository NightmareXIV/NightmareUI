using ECommons.ImGuiMethods;
using FFXIVClientStructs.FFXIV.Client.UI;
using ImGuiNET;
using NightmareUI.PrimaryUI.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NightmareUI.PrimaryUI;
public class NuiBuilder
{
		private Section? CurrentSection;
		private List<Section> Sections = [];

		public NuiBuilder() { }

		public NuiBuilder Section(string name)
		{
				CurrentSection = new() { Name = name };
				Sections.Add(CurrentSection);
				return this;
		}

		[MemberNotNull(nameof(CurrentSection))]
		private void EnsureSectionNotNull()
		{
				if (CurrentSection == null) throw new NullReferenceException("CurrentSection is null");
		}

		public NuiBuilder Widget(string name, Action<string> drawAction, string? help = null)
		{
				EnsureSectionNotNull();
				CurrentSection.Widgets.Add(new ImGuiWidget(name, drawAction, help));
				return this;
		}

		public delegate ref bool RefBoolDelegate();
		public NuiBuilder Checkbox(string name, RefBoolDelegate value, string? help = null)
		{
				EnsureSectionNotNull();
				CurrentSection.Widgets.Add(new ImGuiWidget(name, (x) => ImGui.Checkbox(x, ref value()), help));
				return this;
		}

		public delegate ref int RefIntDelegate();
		public NuiBuilder InputInt(float width, string name, RefIntDelegate value, string? help = null)
		{
				EnsureSectionNotNull();
				CurrentSection.Widgets.Add(new ImGuiWidget(name, (x) =>
				{
						ImGui.SetNextItemWidth(width);
						ImGui.InputInt(name, ref value());
				}, help));
				return this;
		}

		public NuiBuilder SliderInt(float width, string name, RefIntDelegate value, int min, int max, string? help = null, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
		{
				EnsureSectionNotNull();
				CurrentSection.Widgets.Add(new ImGuiWidget(name, (x) =>
				{
						ImGui.SetNextItemWidth(width);
						ImGuiEx.SliderInt(name, ref value(), min, max, "%d", flags);
				}, help));
				return this;
		}

		public NuiBuilder Widget(float width, string name, Action<string> drawAction, string? help = null)
		{
				EnsureSectionNotNull();
				CurrentSection.Widgets.Add(new ImGuiWidget(width, name, drawAction, help));
				return this;
		}

		public NuiBuilder Separator()
		{
				EnsureSectionNotNull();
				CurrentSection.Widgets.Add(new SeparatorWidget(() =>
				{
						ImGui.TableNextRow();
						ImGui.TableNextColumn();
				}));
				return this;
		}

		public void Draw()
		{
				foreach(var x in Sections)
				{
						x.Draw();
				}
		}
}
