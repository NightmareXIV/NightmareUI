using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI.PrimaryUI.Components;
internal class CondIf : IWidget
{
		internal Func<bool> Predicate;

		public CondIf(Func<bool> predicate)
		{
				Predicate = predicate;
		}
}
