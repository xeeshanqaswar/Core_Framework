using System;

namespace Arcanine.Core
{
    public interface IGameAnalyticsFacade
    {
        void ProgressionStart(string progression01, string progression02 = null, string progression03 = null);
        void ProgressionComplete(string progression01, string progression02 = null, string progression03 = null, int? score = null);
        void ProgressionFail(string progression01, string progression02 = null, string progression03 = null, int? score = null);
        
        /// <summary>
        /// eventId: "ui:shop:open"/"weapon:rocket:damage" value:120f
        /// </summary>
        void DesignEvent(string eventId, float? value = null);
        
        /// <summary>
        /// currency: Gems, amount: 100, itemType: shop, itemId: revive
        /// </summary>
        void ResourceSink(string currency, float amount, string itemType, string itemId);
        /// <summary>
        /// currency: Coins, amount: 100, itemType: level_reward, itemId: level_5
        /// </summary>
        void ResourceSource(string currency, float amount, string itemType, string itemId);
        
        void Error(GameAnalyticsSDK.GAErrorSeverity severity, string message);
        
        /// <summary>
        /// GAAdAction.RewardReceived, GAAdType.RewardVideo, "UnityAds", "rewardedVideo"
        /// </summary>]
        void AdShow(
                    GameAnalyticsSDK.GAAdAction adAction, 
                    GameAnalyticsSDK.GAAdType adType, 
                    string adSdkName,
                    string adPlacement, 
                    long? duration = null);

    }
}