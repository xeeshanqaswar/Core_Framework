using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "Consent UI Config", menuName = "UI Configs/Consent UI Config")]
public class ConsentUiConfig : ScriptableObject
{
    public AssetReference assetPrefab;
}
