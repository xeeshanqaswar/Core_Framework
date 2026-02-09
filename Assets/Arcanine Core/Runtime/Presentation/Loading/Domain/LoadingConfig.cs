using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "Loading Config", menuName = "UI Configs/Loading Config")]
public class LoadingConfig : ScriptableObject
{
    public AssetReference assetPrefab;
}
