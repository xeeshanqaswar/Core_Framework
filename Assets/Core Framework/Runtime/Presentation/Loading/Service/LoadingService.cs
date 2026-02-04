using UnityEngine;
using System;
using UnityEngine.UnityConsent;

namespace Core.Framework
{
    
    public class LoadingService
    {
        private LoadingConfig _config;
        private IRootUi _root;

        public LoadingService(IRootUi root, LoadingConfig config)
        {
            _root = root;
            _config = config;
        }
    }
}

