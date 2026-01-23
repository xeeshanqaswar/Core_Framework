using Unity.Services.Core;
using UnityEngine;
using System;
using Unity.Services.Authentication;
using VContainer.Unity;

namespace Core.Framework
{
    public class UGSInitService: IInitializable
    {
        public UGSAuthService _authService;

        public UGSInitService(UGSAuthService auth)
        {
            _authService = auth;
        }
        
        public async void Initialize()
        {
            var initOptions = new InitializationOptions();
            await UnityServices.InitializeAsync(initOptions);
            _authService.DoAnonymousLogin();
        }
        
    }
}

