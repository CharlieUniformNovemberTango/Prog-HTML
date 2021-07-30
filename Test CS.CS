// Decompiled with JetBrains decompiler
// Type: BannerlordTweaks.Patches.GetMaxHeroCraftingStaminaPatch
// Assembly: BannerlordTweaks, Version=1.5.7.0, Culture=neutral, PublicKeyToken=null
// MVID: 4B62B220-4288-4EB4-B892-EE0194101C13
// Assembly location: E:\SteamLibrary\steamapps\common\Mount & Blade II Bannerlord\Modules\StaminaFix\zzBannerlordTweaks\bin\Win64_Shipping_Client\BannerlordTweaks.dll

using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;


#nullable enable
namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetMaxHeroCraftingStamina")]
    public class GetMaxHeroCraftingStaminaPatch
    {
        private static bool Prefix(CraftingCampaignBehavior __instance, ref int __result)
        {
            ref int local = ref __result;
            BannerlordTweaksSettings instance = GlobalSettings<BannerlordTweaksSettings>.get_Instance();
            int num = instance != null ? instance.MaxCraftingStamina : 100;
            local = num;
            return false;
        }

        private static bool Prepare()
        {
            BannerlordTweaksSettings instance = GlobalSettings<BannerlordTweaksSettings>.get_Instance();
            return instance != null && instance.CraftingStaminaTweakEnabled;
        }
    }
}
