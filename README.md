# SSH Mod Loader
Facilitates managing and installing mobile app mods to your device via SSH.

## Mobile Device Requirements
- A jailbroken iOS device (jailbreak required for root access)
- OpenSSH installed (or similar) to allow SSHing into the device
- Filza installed (or similar) to get app directory paths

## Computer Requirements
- Windows, Mac, or Linux (any system the Unity Editor can run on)
- Unity (if building from the project)

## Future Features
- Android support

## Tutorial

### Create an App
* Click the **+** button in the top bar
* Set a friendly app name (this can be anything)
* Set the path to whatever app you want to edit (you can find this using Filza)

(i.e. On my device, my main app data folders are located at "/var/containers/Bundle/Application/###-App-Hash", but the app hash will look something like this "75141517-2D...", be different on your device, and likely change with each app update.)
* **Optional:** Set the update path, (if the app has an update path) files here may supersede changes to duplicate files in the main app data folder, on my device, Brawl Stars has an "updated" folder located here "/var/mobile/Containers/Data/Application/" inside a "Documents" folder.

**Important note: If the app uses path and update path, make sure the two paths match the sub-folder/file structure. If you have to go deeper "/###-App-Hash/App-Name/res" for path and "/###-App-Hash/Documents/updated/" to get the same structure, then do that. The mod loader uses the structure from the main app folder and if the update path doesn't match the structure, it won't be able to find the files.**
