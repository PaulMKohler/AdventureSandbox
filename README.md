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

------------
###### Head Turning

Now that we have hotspots we can give a nice additional ineraction by having the player turn its head to look at them when we mouse over them.

In **Settings Manager** we can look at **Hotspot Settings** to find this option.

We also have to go to the **Player** Object and look at the Mechanim Settings.  If humanoid and **IK Pass** is enabled all we have to do is check **IK turning**.  But if we have a Generic model set up, we need animations that look in the four cardinal directions.  And then we can control the degree of head swivel with a **2D Blend Tree**  Head Yaw is -1 for left +1 for right, Head Pitch is -1 for down +1 for up.


------------

###### Template files

We can use a template file downloaded by a unity package to import managers.  The **Menu Manager** controls the look and feel of the UI.  When we download a package we can choose override managers to use only the new managers.

We do have to go back and change anything within the new manager which we had customized.

------------

###### NPC Creation

We can use the **character wizard** to make a new NPC from a model.

When we finish selecting a model it will add several components to the in scene instance.

If we have an NPC which doesnt move we dont need the rigidbody.  Depending on the circumstance it may be easier to create a new hotspot and capsule collider.

You can select the model and check position over selected mesh to create new hotspots.

------------

######  Opening Cutscene

The **Scene Manager** has an option for cutscene.  Making a new cutscene allows us to bring up a new **Action List**.

Use camera switches, object teleports and markers to direct a scene.

If we need to have a character look at another character's head we need to set up a neck bone object for the NPC we need to look at.

Run automatically on scene start. We can set this up on the **Scene Manager**.  To play the first time we enter a scene and not every time we come back to the room we need a variable

This can be set up from the **Variable Manager**  Global vars are used across gameplay, local are attached to scenes.

The EndCutscene input can be set up to skip cutscenes.

------------

###### Conversations

You mmay want to make a new camera for the conversation. Do this by using the scene manager to create a new Simple Camera.

Use the dialogue option to play speech, and a Start Conversation to begin a **Conversation** object.  A new conversation can be created by the **Scene Manager**.

We can create dialogue options in the conversation.

To have different opening dialogue, or to separate out part of the action list, you can create other cutscenes and run action lists from within other ones.

------------

###### Facial Animations

Third-party tools can be used but this can be handled inside Adventure Creator.

The **SkinnedMeshRenderer** Component has **Blendshapes** defined for certain expressions.

A **Shapeable** Component can be used to group the expressions into non overlapping groups.  It is in this component where we can define shape groups and shape keys.

We can use parseable keywords within textblocks to perform actions, like waiting or expression change, with [wait:x] and [expression:x]. Make sure to check the UseExpressions boolean in the dialog settings of the character. We can map the expressions to a shapeable component.

Lip synching  we can use phemones to know how to animate. The **Speech Manager** has a section for lip synching. Options not from speech text can generate data that can be fed into a third-party tool.

We can edit phemeomes by letting the dialogue effect the game object and using the **Phemome Editor**   We can group sounds like ah/o/uh into a phemome group. The default groups crates five groups.  We have blend shapes for these in our dummy model, but need to create the group and keys for them.  We can set this a the Phemone Blend Group in the characters mechanim parameters.

------------

###### Background Speech

Use a cutscene that doesnt intrrupt gameplay to perform background speech.  Use the **Run In Background** option to do this.  We can use Variable/Check Random Number to play from a random list of options.

We can use Action List Pause or Resume to pause speech if a character is far away or if we are doing something in the scene which should not be interrurpted.
