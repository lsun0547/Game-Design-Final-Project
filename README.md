![image](https://github.com/user-attachments/assets/726b99cf-91ef-4deb-bf96-93272337014f)

**Sizeable Swine**  
	You wake up next to a barn on the side of the road. Your stomach aches and growls. Looking up, you see a bunch of food on the ground. Why is it there? You don't care. You just need to eat. As you run over to the food, you realize your path is blocked. Blocked by what? Pigs. These sizable swine (big pigs, if you will) must have broken out of the barn and are now roaming freely. You don't care, but as you try to circle around them to get to the food, you're blocked. These pigs don't want you eating, and they're doing everything in their power (including shooting ham) to keep you away. Looking in your pockets, you find an infinite supply of metal spheres the size of your head. How did they get there? It doesn't matter. Armed with these spheres, you start fighting your way to a full stomach. <br>
 
<a href="https://www.youtube.com/watch?v=IlN22H9dXM8" target="_blank">Demo Video</a>

![image](https://github.com/user-attachments/assets/33adda58-7295-44a5-a3f3-c9e865c9e9ad)
![image](https://github.com/user-attachments/assets/e7a578f0-0180-4856-a086-89c3809e45ec)
![image](https://github.com/user-attachments/assets/9d25b0d0-82ce-43b5-af3c-336d0a55a6c7)

**Controls**
| Key | Action |
| ----- | :---- |
| **WASD or Arrow Keys** | Move |
| **Space Bar** | Jump |
| **Left Click or Left Control** | Throw Sphere |
| **Escape** | Pause/Unpause |

**Game Mechanics**  
	The game mechanics in this game include a one-hit elimination, ragdoll physics, and collectable items. Both the player and the enemies will be eliminated by a single hit. If the player is eliminated, the level resets and the player has to restart the level. If an enemy is eliminated, then it becomes subject to ragdoll physics and cannot hurt the player anymore. Possibly the most important game mechanic is the collectable items. Each level has a certain number of items that must be collected to progress to the next one. All of these mechanics come directly from the game *Big Pig*, of which this game is a recreation of. One mechanic I included that is not featured in the original game is the ability to destroy the enemy projectiles with your own. I included this feature to make the game a little easier to play. This feature could potentially be toggled in a future update to control difficulty.  

**Gameplay Loops**  
	The main gameplay loop is moving around and collecting items. This is the main goal of the game, as collecting all items is necessary to progress through the levels. The secondary gameplay loop is eliminating enemies by throwing spheres to hit them. This is not technically necessary to complete the game, but it is functionally impossible to win as the enemies will prevent you from collecting all of the food. There are no tertiary gameplay loops.  

**Bugs/Future Updates**  
	Currently, there are a few issues with the game that would require a day 1 patch. The biggest issue lies in the enemy movement. Currently, enemies move strangely if they are on an elevated plane compared to the player. This issue could be rectified by changing the colliders (such as implementing Character Controllers) and/or scripts involved in enemy movement. However, this is not game-breaking and is mostly a quality issue. Somewhat related to this is that the colliders on the terrain are not very good. This is because they were auto=generated in Unity from the object meshes, which means some places have colliders where there shouldn't be. I would have to manually create colliders for all affected objects in the game. Another issue that would require a day 1 patch is the lack of the ability to pick ragdolled enemies up. This is a game mechanic that is present in the original *Big Pig* that I was not able to recreate. The core problem lies in the way the enemy asset is structured and how object transforms work in the Unity game engine. Once eliminated, the enemy object itself does not move. What actually moves, and what the player sees, is the children of the enemy object, specifically the joints and colliders that allow for ragdoll physics. These have a transform relative to the overall enemy object. As such, the ability to pick up ragdolled enemies would require intricate scripting or a revamp of the enemy asset. One final issue is the lack of music or sound effects. This is a very simple endeavor that I simply did not have time to implement.

**Credits**
| People | Assets |
| :---: | :---: |
| Leo Sun \- Scripting & Design <br> Chris Mirah \- Game Design Teacher <br> Annabelle Sun \- Rigging & Texturing <br> Kofi Amexo \- Moral Support <br> Tanner Kinne \- Chief Consultant (fixed 1 bug) <br> Rishi Aitha & Brody Glenn \- Playtesters <br> BecomeANobody \- Inspiration | [Half Ham by Quixel](https://www.fab.com/listings/089a9e41-8b23-4dd5-a01f-e1551be88c67) <br> [Low Poly Environment by Sky Den Games](https://assetstore.unity.com/packages/3d/environments/low-poly-environment-315184) <br> [SimplePoly City by VenCreations](https://assetstore.unity.com/packages/3d/environments/simplepoly-city-low-poly-assets-58899) <br> [Food Props by Unity Technologies](https://assetstore.unity.com/packages/3d/food-props-163295) <br> [SMC: Pack 1 by Visyde Interactives](https://assetstore.unity.com/packages/2d/gui/icons/simple-modern-crosshairs-pack-1-79034) <br> Farm Animals Set by Vertex Cat (Deprecated) |
