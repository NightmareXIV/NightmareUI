using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareUI;
[Serializable]
public sealed unsafe class NightmareUIState
{
    public Dictionary<string, string> ActiveTab = [];
}