using Arcanine.Core;
using UnityEngine;
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
        
        builder.Register<UGSAuthFacade>(Lifetime.Singleton);
        builder.Register<UGSInitFacade>(Lifetime.Singleton);
        builder.Register<UGSLeaderboardFacade>(Lifetime.Singleton);
        builder.Register<ISaveSystemFacade, UGSCloudSaveFacade>(Lifetime.Singleton);
        builder.Register<IFriendFacade, UGSFriendsFacade>(Lifetime.Singleton);
        
        builder.Register<IConsentService, ConsentService>(Lifetime.Singleton);
        builder.Register<IGameAnalyticsFacade, GameAnalyticsFacade>(Lifetime.Singleton).As<IInitializable>();
        
        builder.RegisterBuildCallback(container =>
        {
            var consentService = container.Resolve<IConsentService>();
            consentService.RequestConsent(accepted =>
            {
                if (accepted)
                {
                    var ugsInit = container.Resolve<IInitializable>();
                    var friendsInit = container.Resolve<IInitializable>();
                    
                    ugsInit.Initialize();
                    friendsInit.Initialize();
                }
                else
                {
                    Debug.Log("User declined consent");
                    // Application.Quit();
                }
            });
        });

        
    }
}
