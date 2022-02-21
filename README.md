### AC Game Editor


[========]


#### New Game

Sub-windows are known as "Managers", each having a parent asset file.  The New Game Wizard will walk us through creating our own.

Automatically puts manager asset files into a **Game Title**/Managers File.

Note: There is a file in the **Game Title** director that sets all the game manager files to these files should something like an AC re-download set them to the Demo ones.


[========]

#### Scene Manager

Allows us to structure our game object library using helper objects.

In the navigation objects directory, we will see Default Player Starts which is the default player location and rotation on scene start.

Under cameras is the MainCamera which will be used in the scene.

If using imported meshes we can add mesh colliders to them and test scenes out with a demo player.

###### Pathfinding

If we want characters to move around during cutscenes, or basic character NPCs to navigate we will rely on navmeshes.

In the scene settings we  can rely on Unity navigation and prebaked navmeshes.  In order to use geometries in the scene we an change mesh collider objects to be  **Navigation Static**  If we then go to Unity's Navigation tab and bake the mesh, we can get the walkable map
