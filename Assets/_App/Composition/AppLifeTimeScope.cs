using Core.Framework;
using Core.Framework.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

public class AppLifeTimeScope : LifetimeScope
{
    [SerializeField] private ConsentUiConfig consentConfigs;
    
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);

        builder.RegisterInstance(consentConfigs);
        
        builder.RegisterComponentInHierarchy<IRootUi>();
        
        builder.Register<UGSAuthService>(Lifetime.Singleton);
        builder.Register<UGSInitService>(Lifetime.Singleton);
        builder.Register<UGSLeaderboardService>(Lifetime.Singleton);
        
        builder.Register<IConsentService, ConsentService>(Lifetime.Singleton);
        
        builder.RegisterBuildCallback(container =>
        {
            var consentService = container.Resolve<IConsentService>();
            consentService.RequestConsent(accepted =>
            {
                if (accepted)
                {
                    IInitializable ugsInit = container.Resolve<UGSInitService>();
                    ugsInit.Initialize();
                }
                else
                {
                    Debug.Log("User declined consent");
                    // Application.Quit();
                }
            });
        });

        builder.Register<IGameAnalyticsService, GameAnalyticsService>(Lifetime.Singleton).As<IInitializable>();

    }
}
