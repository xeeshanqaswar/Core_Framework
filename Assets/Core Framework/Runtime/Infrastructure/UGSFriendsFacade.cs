using Unity.Services.Core;
using UnityEngine;
using System;
using Unity.Services.Authentication;
using Unity.Services.Friends;
using Unity.Services.Friends.Models;
using VContainer.Unity;

namespace Core.Framework
{
    public class UGSFriendsFacade: IInitializable, IFriendFacade
    {
        public async void Initialize()
        {
            await FriendsService.Instance.InitializeAsync();
            await FriendsService.Instance.SetPresenceAvailabilityAsync(Availability.Online);
        }

        public void GetFriends()
        {
            // FriendsService.Instance.Friends
        }
        
    }
}

