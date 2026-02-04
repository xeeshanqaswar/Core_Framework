using Unity.Services.CloudSave;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Framework
{
    public class UGSCloudSaveFacade : ISaveSystemFacade
    {
        public async Task<bool> SaveGame<T>(string key, T data)
        {
            var payload = new Dictionary<string, object> { { key, data} };
            await CloudSaveService.Instance.Data.Player.SaveAsync(payload);
            return true;
        }

        public async Task<LoadResult<T>> LoadGame<T>(string key)
        {
            var keys = new HashSet<string> { key };
            var payload = await CloudSaveService.Instance.Data.Player.LoadAsync(keys);

            if (payload.TryGetValue(key, out var value))
                return new LoadResult<T>(false);
            
            T result = value.Value.GetAs<T>();
            return new LoadResult<T>(true, result);
        }
    }
}

