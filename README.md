The Last Days Patcher is a Minecraft Patch that opens before Minecraft Launcher opens, and then it installs Skins (from a Remote server) into your Minecraft files. This way the Skins can be used by players of your ModPack in Single Player or Multiplayer. This Patcher works together with the Offline Skins mod and was developed for large scale servers, such as servers for groups of friends and so on. This is a solution for everyone to use Skins (including Multiplayer) in ModPacks Forge, regardless of the Launcher they use and so on.

# To use this Patcher

This Patcher must be opened before your Minecraft Launcher will open. For that, you must place this Patcher's executable (along with its files and DLLs) in the same folder as your Minecraft Launcher's executable.

After that, you should run Patcher and it will generate a folder called "patcher-data", in this generated folder, open the file "settings.txt" and configure the settings. You will need to configure the following settings.

- **At Line 2:** You need to provide the URL to the Root folder that stores the Skin PNGs. This URL must point to a server with HTTPs protocol. The URL "https://windsoft.xyz/tld-modpack/skins-for-client-patcher" is a good example. Inside the "skins-for-client-patcher" folder on your server, you should have your files arranged as follows...
- - **nickname.png**: A PNG file of a player skin. The extension must be PNG and the filename must match the nickname of the player who will use this skin.
- - **nickname=cape.png**: A PNG file of a player's cape. The extension must be PNG and the filename must be the same as the nickname of the player who will use this cape. Cape files must have the "=cape" suffix included in the file name.
- - **nickname2.png**: An example of another skin file for another Player...
- - **!skins-index.txt**: This is a Text file that contains the name of all files that should be downloaded by Patch. When Patch accesses your server, it will read this file to know which skins to download and apply in Minecraft. This file must contain the name of a file to be downloaded on each line, as in the example below...
- - - **Line 1 of !skins-index.txt:** nickname.png
- - - **Line 2 of !skins-index.txt:** nickname=cape.png
- - - **Line 3 of !skins-index.txt:** nickname2.png
- **At Line 4:** Here you must insert the executable directory of this Patch to the folder "cachedImage" which is inside the folder ".minecraft" of your Minecraft. The "cachedImage" folder is the folder that will receive the Skins downloaded by Patcher. The folder "cachedImages" will only appear in your ".minecraft" if you install the mod "Offline Skins" in your Minecraft. This mod requires Forge to be installed, and this mod is only compatible with Minecraft version 1.12.2. 
- **At Line 6:** Here you must put the name (including the extension) of your Minecraft Launcher executable. It will automatically open whenever Patcher completes its work.

It is very important that you always keep the "!skins-index.txt" file always up to date, referencing existing PNG files. Never leave filenames that no longer exist inside the "!skins-index.txt" file.

Whenever any changes are made, skins removed or added on your server, it is necessary that the Minecraft Clients are also re-opened so that Patcher can update the Skins on them as well. If Patcher cannot access your server, the device is not connected to the Internet, Patcher cannot access the "!skins-index.txt" or cannot download any skin, an error message will be displayed and the player will be able to Try Again, or Play Without Patch.

# Prerequisites to use this Patcher

You need to fulfill some requirements to be able to use this Patcher...

- The computer may need to have .Net 3.1 installed in order to run Patcher.
- Your Minecraft must have Forge 1.12.2 installed and you must also install the Offline Skins mod installed on this same Minecraft. The mod will do the job of reading the Skins installed in "cachedImages" and applying them in-game.

# About the Offline Skins mod

The Offline Skins mod was created by **LainMI**, all mod creation rights are reserved to the Mod author. You can see the Mod Official Page by clicking <a href="https://www.curseforge.com/minecraft/mc-mods/offlineskins" target="_blank">here</a>, on CurseForge. You can also go to the Mod Official GitHub by clicking <a href="https://github.com/zlainsama/OfflineSkins" target="_blank">here</a>.

# How to edit this Patcher

The source code (and Visual Studio project) is included in this repository. You just need to have Visual Studio downloaded on your Computer and open this project with Visual Studio to edit it.

# Support projects like this

If you liked this Patcher and found it useful for your projects, please consider making a donation (if possible). This would make it even more possible for me to create and continue to maintain projects like this, but if you cannot make a donation, it is still a pleasure for you to use it! Thanks! 😀

<br>

<p align="center">
    <a href="https://www.paypal.com/donate/?hosted_button_id=MVDJY3AXLL8T2" target="_blank">
        <img src="The-Last-Days-Patcher-Source/Resources/paypal-donate.png" alt="Donate" />
    </a>
</p>

<br>

<p align="center">
Created with ❤ by Marcos Tomaz
</p>