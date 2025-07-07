using BepInEx;
using UnityEngine;
using PEAKCosmeticsLib;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

[BepInPlugin("IsotopesCosmetics", "Isotopes Cosmetics", "1.0.0")]
[BepInDependency("PEAKCosmeticsLib")]
public class IsotopesCosmetics : BaseUnityPlugin
{
    void Awake()
    {
        string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string bundlePath = Path.Combine(assemblyFolder, "IsotopesCosmeticsBundle");
        Logger.LogInfo($"Attempting to load assetbundle from: {bundlePath}");
        StartCoroutine(CosmeticAPI.LoadCosmeticAssetBundle(bundlePath, OnBundleLoaded));
    }

    void OnBundleLoaded(AssetBundle? IsotopesBundle)
    {
        if (IsotopesBundle == null)
        {
            Logger.LogError("Failed to load the IsotopeCosmeticsBundle!");
            return;
        }

        Logger.LogInfo("IsotopeCosmeticsBundle loaded successfully.");

        var hatNamesToAdd = new List<string>
        {
            "panda","froggy","zombie","cherry","crazyman","mallow","pnapple","pumpkin","gasmask","peamask","plunger","squidg","poctopus","pacman","duckfloat","dogeh"
        };

        CosmeticAPI.AddHatsFromBundle(IsotopesBundle, hatNamesToAdd);

        Logger.LogInfo("Isotope's Cosmetics has finished adding all hats!");
    }
}