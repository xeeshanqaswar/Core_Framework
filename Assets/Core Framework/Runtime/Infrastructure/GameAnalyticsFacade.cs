using GameAnalyticsSDK;
using UnityEngine;
using VContainer.Unity;

namespace Core.Framework
{
    public class GameAnalyticsFacade : MonoBehaviour, IGameAnalyticsFacade, IGameAnalyticsATTListener, IInitializable
    {
        public void Initialize()
        {
            if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                GameAnalytics.RequestTrackingAuthorization(this);
            }
            else
            {
                GameAnalytics.Initialize();
            }
        }

        #region I_GAME_ANALYTICS_ATT_LISTENER

        public void GameAnalyticsATTListenerNotDetermined() => GameAnalytics.Initialize();

        public void GameAnalyticsATTListenerRestricted() => GameAnalytics.Initialize();
        
        public void GameAnalyticsATTListenerDenied() => GameAnalytics.Initialize();
       
        public void GameAnalyticsATTListenerAuthorized() => GameAnalytics.Initialize();

        #endregion
       
        #region I_GAME_ANALYTICS_SERVICE

        public void ProgressionStart(string progression01, string progression02 = null, string progression03 = null)
        {
            SendProgression(GAProgressionStatus.Start, progression01, progression02, progression03, null);
        }

        public void ProgressionComplete(string progression01, string progression02 = null, string progression03 = null, int? score = null)
        {
            SendProgression(GAProgressionStatus.Complete, progression01, progression02, progression03, null);
        }

        public void ProgressionFail(string progression01, string progression02 = null, string progression03 = null, int? score = null)
        {
            SendProgression(GAProgressionStatus.Fail, progression01, progression02, progression03, null);
        }

        public void DesignEvent(string eventId, float? value = null)
        {
            if (value.HasValue)
            {
                GameAnalytics.NewDesignEvent(eventId, value.Value);
            }
            else
            {
                GameAnalytics.NewDesignEvent(eventId);
            }
        }

        public void ResourceSink(string currency, float amount, string itemType, string itemId)
        {
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, currency, amount, itemType, itemId);
        }

        public void ResourceSource(string currency, float amount, string itemType, string itemId)
        {
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, currency, amount, itemType, itemId);
        }

        public void Error(GAErrorSeverity severity, string message)
        {
            GameAnalytics.NewErrorEvent(severity, message);
        }

        public void AdShow(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long? duration = null)
        {
            if (duration.HasValue)
            {
                GameAnalytics.NewAdEvent(adAction, adType, adSdkName, adPlacement, duration.Value);
            }
            else
            {
                GameAnalytics.NewAdEvent(adAction, adType, adSdkName, adPlacement);
            }
        }

        #endregion

        private void SendProgression(
            GAProgressionStatus status,
            string p1,
            string p2,
            string p3,
            int? score
        )
        {
            if (score.HasValue)
                GameAnalytics.NewProgressionEvent(status, p1, p2, p3, score.Value);
            else
                GameAnalytics.NewProgressionEvent(status, p1, p2, p3);
        }
        
    }
}

