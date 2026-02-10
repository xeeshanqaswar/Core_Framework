using Unity.Services.Core;
using UnityEngine;
using System;
using Unity.Services.Authentication;
using VContainer.Unity;

namespace Arcanine.Core
{
    public class UGSInitFacade: IInitializable
    {
        public UGSAuthFacade AuthFacade;

        public UGSInitFacade(UGSAuthFacade auth)
        {
            AuthFacade = auth;
        }
        
        public async void Initialize()
        {
            var initOptions = new InitializationOptions();
            await UnityServices.InitializeAsync(initOptions);
            AuthFacade.DoAnonymousLogin();
        }
        
    }
}

