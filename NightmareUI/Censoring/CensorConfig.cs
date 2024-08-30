using ECommons.Configuration;
using System;
using System.Reflection;

namespace NightmareUI.Censoring;

[Serializable]
public class CensorConfig : IEzConfig
{
    [Obfuscation(Exclude = true)] public string Seed = Guid.NewGuid().ToString();
    [Obfuscation(Exclude = true)] public bool Enabled = false;
    [Obfuscation(Exclude = true)] public bool LesserCensor = false;
}
