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


------------

###### Pathfinding

If we want characters to move around during cutscenes, or basic character NPCs to navigate we will rely on navmeshes.

In the scene settings we  can rely on Unity navigation and prebaked navmeshes.  In order to use geometries in the scene we an change mesh collider objects to be  **Navigation Static**  If we then go to Unity's Navigation tab and bake the mesh, we can get the walkable map

------------

###### Player Creation

Generic rig model allows for an **animator** component rather than an **animation** component.

A model can be made into an AC character by using the Character Wizard.  We  can drag a model from the inspector into the Wizard and set up its animations to be Mechanim based.  This creates all the components and sets it up in the **Player** tag.

Make sure the character can access things like ramps and stairs in the scene and adjust by Adding a **Character Controller** component rather than the **Rigidbody** and **Collider**. This allows for slopes and steps to be directly handled.

Movement speed controls the walk and run speed. The **Settings Manager** has a list of inputs  We can use the Input Manager native to Unity to add an input for Run and set it to use **left shift**.

We can begin to use animations for the model by blending the Idle, Walk, and Run animations  We see Mechanim Parameters in the components for our Player inspector. **MoveSpeed** is by default set to **Speed** which we are yet to define in the **animator controller**.

We may have to create an **Animator Controller** at this stage. In that controller we can create the **Speed** float. We can then crate a new **Blend Tree** to blend between our movement animations. Set up a 1d blend tree around speed and drag in the Idle Walk and Run animations. We can set up the threshholds to match our walk and run speeds.  Remember to assign the controller in the Player Controller component.

By default , there will be **Jump** and **isTalking** parameters which are undefined. We can skip over jump for the basics, and create an isTalking bool which will transision us out of moving to speaking and back with no Exit Time if isTalking is true.

We end by making this the player by returning to the **Settings Manager** by first making it a prefab and dragging it into place.

------------

###### The Default Camera

In the **Scene Manager** we see a place for a **Default Camera**, where we can click **Create** to make and assign one.  The created object has many customizible components.  It's best to play the game to give the canera a certain feel,

We can unlock movement on an axis to folow an object,  we can unlock spin so it always looks at an object, offset the starting position, Field of view to control relative zoom, min and max zoom, room constraints etc...


------------
###### Triggers

In the **Scene Manager** we can make a number of gameobjects, such as a second camera to cut to when entering another part of the scene. This can be handled by a trigger.

Triggers can be created in the **Scene Manager** this creates an unnamed cube area in the scene which can be positioned to the trigger area.  We can alter properties of the trigger by looking at its components.

The scripted events of the **Trigger** are listed in the components as an **Action List**.  We can change this to a camera action in ordder to set up a camera transition for example.  The trigger can be set to run in the background, or pause gameplay, which you may have to toy with depending on the action.

We can add multiple triggers on one object, to say cover different actions if a player enters or leaves an area.


------------

###### Hotspots and Interactions

**Hotspots** are clickable regions we can create to generate **Interactions**.

The **Scene Manager** has a **Hotspot** prefab.   Creating one will create an area which indicates where the hotspot will be in game.

We can create a name for the **Hotspot** in the component.  Underneath **Use Interactions **we can create new Interactions for this Hotspot.  An example is a **Look At** interaction can have the player comment on something or turn to face it.
We can create **Interactions** in the form of **Action Lists**, much like with Triggers.

One hotspot can have many interactions, and each can have actions that deal with many theings like Player movement, Animation, Dialogue and so forth.  We can use Markers to indicate where the Player should move to if need be.

In interactions we can send a message to call a function on a GameObject by using SendMessage.

The interaction icons are in the **Cursor Manager**
