## Requirements
Add the following to your `manifest.json`
```json
"scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.gameanalytics.sdk",
        "com.google.external-dependency-manager",
        "com.cysharp.unitask"
      ]
    }
  ]
```

### Consume
Add the following to your `manifest.json`
```c#
"com.arcaninestudios.core": "https://github.com/xeeshanqaswar/Core_Framework.git#package"
```