# Bizarre Adventure
 
[Play Bizarre Adventure on Unity Website
![Intro Menu](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_1.jpg)](https://play.unity.com/mg/fps/bizarre-adventure)

## Implementation
Bizarre Adventure is built upon Unity's FPS microgame. We swapped out the default models with our own Blender models. All scripts are written in C# in Visual Studio. This was a group project including @Mjjllolis, @Gingahh, @minhlongvu, @trent-magill, @vliu2, @windcloak

## Art Style - Mishawn
Models by @Mjjllolis
Majority of the models including guns, characters, decorations, and maps were made in Blender.
I went with a low-poly design, using a simple gradient color palette to make sure all the colors aligned. 
![Models](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_2.jpg)
![Hub World](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_3.jpg)

## Hub World NPCs and Weapon Prefabs - Victoria and Albert
@vliu2 and @minhlongvu
We made the base layout for the hub. Player's speed was halved, and I added colliders to each NPC.
We also attached gun scripts and colliders to the gun models.
![Hub World Layout](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_3a.jpg)
![Hub Layout](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_3b.jpg)

## Inventory - May
@windcloak
I added an Inventory panel so Player can pick up items such as Shield, Helmet, and Potion. I added scripts to the pickup models. Picking up a new shield/helmet replaces the old, and you can press [H] to use the Potion.
![Inventory](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_5.jpg)

### Skybox and UI
I also did the skybox, backgrounds and UI of menu scenes
![Skybox](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_6.jpg)

## Plains Level Tutorial - Trent
@trent-magill
I made the Plains level tutorial. You can talk to NPCs, pick up items, and shoot a Bee enemy in the Tutorial. I also made the potion in Blender, including the semi-transparent glass composing it.
![Plains Level](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_7.jpg)

### Desert Level and Bossfight
I also designed the Desert level and boss placement.
![Desert Level](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_8.jpg)

## Ocean Level - Charles
@Gingahh
Using Mishawn’s models I created the third level/ocean themed level. I designed the final level to be longer, more complex, and harder than the levels previous as it is the last level in the game. Level has decoration such as seaweed/coral, enemies such as eels/seahorses, and the lighting has a blue tint to give the level an underwater feel.
![Ocean Level](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_9.jpg)

 I was able to tweak our AI and apply various SFX to make each enemy feel different. (They move differently, attack differently, and sound different). For example the Eel moves towards the player quickly and attacks the player up close, whereas the seahorse keeps its distance and attempts to snipe the player from afar.
![Ocean enemies](https://github.com/windcloak/BizarreAdventure/blob/main/Assets/screencaps/Screenshot_10.jpg)
