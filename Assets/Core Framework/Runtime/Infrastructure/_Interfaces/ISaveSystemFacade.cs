using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Framework
{
    public interface ISaveSystemFacade
    {
        public Task<bool> SaveGame<T>(string key, T data);
        public Task<LoadResult<T>> LoadGame<T>(string key);
    }
}