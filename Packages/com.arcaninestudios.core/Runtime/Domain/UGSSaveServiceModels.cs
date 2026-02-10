using System;
using UnityEngine;

namespace Arcanine.Core
{
    public struct LoadResult<T>
    {
        public bool Success;
        public T Data;

        public LoadResult(bool success, T data = default)
        {
            Success = success;
            Data = data;
        }
    }
}
