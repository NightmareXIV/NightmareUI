using ECommons;
using ECommons.ImGuiMethods;
using ImGuiNET;

namespace NightmareUI;
public static class FundingBanner
{
    public static void Draw(ref bool display)
    {
        if (display)
        {
            if (ImGui.BeginTable($"FundingBanner", 1, ImGuiTableFlags.NoSavedSettings | ImGuiTableFlags.Borders | ImGuiTableFlags.SizingFixedFit))
            {
                ImGui.TableSetupColumn($"Funding1", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableNextRow();
                ImGui.TableNextColumn();

                ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0, ImGuiEx.Vector4FromRGB(0x000055).ToUint());

                ImGuiEx.LineCentered(() =>
                {
                    ImGuiEx.TextWrapped(EColor.White, $"Support this plugin on Patreon!");
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35f);
                        ImGuiEx.Text($"If you like this plugin, please consider supporting it via NightmareXIV Patreon or via other means! This will help the developer to keep it updated and maintained. And you will get additional benefits as well.\n\nLeft click - to go to Patreon;\nRight click - see all options");
                        ImGui.PopTextWrapPos();
                        ImGui.EndTooltip();
                        ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
                        if (ImGui.IsMouseClicked(ImGuiMouseButton.Left))
                        {
                            GenericHelpers.ShellStart("https://subscribe.nightmarexiv.com");
                        }
                        if (ImGui.IsMouseClicked(ImGuiMouseButton.Right))
                        {
                            ImGui.OpenPopup("NXPS");
                        }
                    }
                });
                
                if (ImGui.BeginPopup("NXPS"))
                {
                    if (ImGui.Selectable("Subscribe on Patreon"))
                    {
                        GenericHelpers.ShellStart("https://subscribe.nightmarexiv.com");
                    }
                    if (ImGui.Selectable("Donate one-time via Ko-Fi"))
                    {
                        GenericHelpers.ShellStart("https://donate.nightmarexiv.com");
                    }
                    if (ImGui.Selectable("Donate via Cryptocurrency"))
                    {
                        GenericHelpers.ShellStart("https://crypto.nightmarexiv.com");
                    }
                    if (ImGui.Selectable("Join NightmareXIV Discord"))
                    {
                        GenericHelpers.ShellStart("https://discord.nightmarexiv.com");
                    }
                    if (ImGui.Selectable("Explore other NightmareXIV plugins"))
                    {
                        GenericHelpers.ShellStart("https://explore.nightmarexiv.com");
                    }
                    ImGui.BeginDisabled();
                    ImGui.Selectable(" ");
                    ImGui.EndDisabled();
                    if (ImGui.Selectable("Hide this section"))
                    {
                        display = false;
                    }
                    ImGui.EndPopup();
                }
                ImGui.EndTable();
            }

            
        }
    }
}
