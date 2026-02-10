using UnityEngine;
using System;
using UnityEngine.UnityConsent;

namespace Arcanine.Core
{
    public interface IConsentService
    {
        bool HasConsent();
        void RequestConsent(Action<bool> callback);
    }
    
    public class ConsentService: IConsentService
    {
        private const string CONSENT_KEY = "consent_key";
        private ConsentUiConfig _config;
        private IRootUi _root;

        public ConsentService(IRootUi root, ConsentUiConfig config)
        {
            _root = root;
            _config = config;
        }
        
        public bool HasConsent()
        {
            return PlayerPrefs.HasKey(CONSENT_KEY) && (PlayerPrefs.GetInt(CONSENT_KEY) == 1);
        }

        public async void RequestConsent(Action<bool> callback)
        {
            if (HasConsent())
            {
                AcceptConsent(true);
                callback?.Invoke(true);
                
                return;
            }

            var handle =  _config.assetPrefab.InstantiateAsync(_root.Root());
            await handle.Task;

            ConsentView view = handle.Result.GetComponent<ConsentView>();
            view.Setup(accepted =>
            {
                AcceptConsent(accepted);
                callback?.Invoke(accepted);
                handle.Release();
            });
        }
        
        private void AcceptConsent(bool accepted)
        {
            PlayerPrefs.SetInt(CONSENT_KEY,  accepted? 1: 0);
            PlayerPrefs.Save();
            
            EndUserConsent.SetConsentState(new ConsentState
            {
                AdsIntent = accepted? ConsentStatus.Granted : ConsentStatus.Denied,
                AnalyticsIntent = accepted? ConsentStatus.Granted : ConsentStatus.Denied,
            });
        }
    }
}

