# To use this Patcher

This Patcher must be opened before your Minecraft Launcher will open. For that, you must place this Patcher's executable (along with its files and DLLs) in the same folder as your Minecraft Launcher's executable.

After that, you should run Patcher and it will generate a folder called "patcher-data", in this generated folder, open the file "settings.txt" and configure the settings. You will need to configure the following settings.

- At Line 2: You need to provide the URL to the Root folder that stores the Skin PNGs. This URL must point to a server with HTTPs protocol. The URL "https://windsoft.xyz/tld-modpack/skins-for-client-patcher" is a good example. Inside the "skins-for-client-patcher" folder on your server, you should have your files arranged as follows...
- - nickname.png: A PNG file of a player skin. The extension must be PNG and the filename must match the nickname of the player who will use this skin.
- - nickname=cape.png: A PNG file of a player's cape. The extension must be PNG and the filename must be the same as the nickname of the player who will use this cape. Cape files must have the "=cape" suffix included in the file name.
- - nickname2.png: An example of another skin file for another Player...
- - File "!skins-index.txt": This is a Text file that contains the name of all files that should be downloaded by Patch. When Patch accesses your server, it will read this file to know which skins to download and apply in Minecraft. This file must contain the name of a file to be downloaded on each line, as in the example below...
- - - nickname.png
- - - nickname=cape.png
- - - nickname2.png
- At Line 4: 
- At Line 6: 