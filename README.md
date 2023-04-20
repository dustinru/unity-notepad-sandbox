# Unity Notepad Sandbox App
Demo app used for Unity development debugging. Built w/ Unity 2021.3

### Common Errors
##### iOS Resolver Failed to Load
You may find some `*.dll` files failing to load with the following example error on your initial project load:
```
Assembly 'Assets/ExternalDependencyManager/Editor/Google.IOSResolver_v1.2.164.dll' will not be loaded due to errors:
Assembly name 'Google.IOSResolver' does not match file name 'Google.IOSResolver_v1.2.164'
```
This could be due to naming issues in the `Assets > External Depedency Manager > Editor` folder. However, I found this to be resolved after reloading the Editor.

Related Forum Post: https://forum.unity.com/threads/google-iosresolver-will-not-be-loaded-in-2021-1-11f1-and-later.1128617/

### Credits
Based on the notepad app built in this youtube tutorial by Jimmy Vegas: https://www.youtube.com/playlist?list=PLZ1b66Z1KFKjbczUeqC4KYpn6fzYjLKoV