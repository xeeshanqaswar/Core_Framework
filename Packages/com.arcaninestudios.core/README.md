## Requirements
Add the following to your `manifest.json`

```json
"com.arcaninestudios.core": "https://github.com/ORG/REPO.git#package"
```

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
