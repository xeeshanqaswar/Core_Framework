using UnityEngine;
using System;
using Unity.Services.Authentication;
using Unity.Services.Core;

namespace Core.Framework
{
    public class UGSAuthService
    {
        public UGSAuthService()
        {
            
        }
        
        public void DoAnonymousLogin()
        {
            AuthenticationService.Instance.SignedIn += OnSignedInSuccess;
            AuthenticationService.Instance.SignInFailed += OnSignedInFailed;
            AuthenticationService.Instance.SignedOut += OnSignedOut;
            AuthenticationService.Instance.Expired += OnSessionExpired;
            
            AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        
        private async void OnSignedInSuccess()
        {
            var playerId = AuthenticationService.Instance.PlayerId;
            Debug.Log($"PlayerID: {playerId}");
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");

            string pName = await AuthenticationService.Instance.GetPlayerNameAsync();
            Debug.Log(pName);
            
            await AuthenticationService.Instance.UpdatePlayerNameAsync("ZeeshanQaswar");
        }

        private void OnSignedInFailed(RequestFailedException err) => Debug.LogError(err);
        
        private void OnSignedOut() => Debug.Log("Player signed out.");
        
        private void OnSessionExpired() => Debug.Log("Player session expired.");
    }
}

