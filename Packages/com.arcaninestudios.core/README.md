## Requirements
Add the following to your `manifest.json`

```json
"com.arcaninestudios.core": "https://github.com/xeeshanqaswar/Core_Framework.git?path=/Packages/com.arcaninestudios.core#0.1.0"
```

```json
"scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.gameanalytics.sdk",
        "com.google.external-dependency-manager",
        "com.cysharp.unitask",
        "com.ohze.google.external-dependency-manager",
        "com.ohze.google.firebase.app",
        "com.ohze.google.firebase.crashlytics"
      ]
    }
  ]
```
