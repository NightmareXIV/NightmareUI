using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI.PrimaryUI.Components;
public class SeparatorWidget : IWidget
{
		internal Action DrawAction;

		public SeparatorWidget(Action draw)
		{
				DrawAction = draw;
		}
}
