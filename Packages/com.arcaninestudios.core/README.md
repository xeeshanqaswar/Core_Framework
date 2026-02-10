## Requirements
Add the following to your `manifest.json`

```json
""com.arcaninestudios.core": "https://github.com/ORG/REPO.git?path=/Packages/com.arcaninestudios.core#0.1.0"
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
