﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI.PrimaryUI.Components;
internal class SeparatorWidget : IWidget
{
		internal Action DrawAction;

		internal SeparatorWidget(Action draw)
		{
				DrawAction = draw;
		}
}
