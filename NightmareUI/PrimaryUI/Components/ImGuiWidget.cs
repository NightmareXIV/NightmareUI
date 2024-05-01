﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI.PrimaryUI.Components;
internal class ImGuiWidget : IWidget
{
		internal string Label;
		internal Action<string> DrawAction;
		internal string? Help;
		internal float? Width;

		public ImGuiWidget(string label, Action<string> drawAction, string? help = null)
		{
				Label = label ?? throw new ArgumentNullException(nameof(label));
				DrawAction = drawAction ?? throw new ArgumentNullException(nameof(drawAction));
				Help = help;
		}

		public ImGuiWidget(float width, string label, Action<string> drawAction, string? help = null)
		{
				Width = width;
				Label = label ?? throw new ArgumentNullException(nameof(label));
				DrawAction = drawAction ?? throw new ArgumentNullException(nameof(drawAction));
				Help = help;
		}
}