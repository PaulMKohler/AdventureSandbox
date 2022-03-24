### Blender Tutorial


----------


#### Custom Character Modeling

Main window is the **Viewport**

Yellow objects are selected. Frame selected will always center selected objects.

Isometric perspective useful to align objects.

Add items with the shift+A command.  Items will be added to where the 3D cursor is, which can be repositioned using the right click.

We can perform actions on the object (S) for scale (G) to grab, after pressing G we can press an Axis to limit movement to that axis. Or Shift+Axis to remove translation in that axis. You can pull out the item transform component from the blender inspector. (R) is for Rotate.

Shift+D can duplicate shapes.

Adding Color, make sure to pay attention to the display mode.

Wireframe mode good to see overlaps. Material preview mode is where you can see what your materials all look like. Rendered mode shows whole scene including shadows.

**Shading Edit Mode**  shows a shader editor at the bottom. If we need a new material we can create one in the screen at the bottom of the window. Same types of brightness, smoothness properties as we see in Unity.

When scalang or moving we can go by local scale by changing option at top of blender.  We can also lock axis to local by pressing the axis twice.

If we have multiple objects selected which we want to scale we can choose to scale them towards a center pivot or individual center points.

------------

#### Adding More Detail


We can use background images to trace around and use as a guide.

We can click and drag an image onto a blender file. This creates a sort of plane with the image, known as an Empty. What this means is that it wont appear on the render.

We can press Option+R to undo rotations, and Option+G to undo translations. This will put image in center of coordinate plane.

There is an X-Ray view at the top of the editor which will let us see through objects.

We can adjust the opacity of the image to be able to see the axes through the image. Also we dont want to see the image in perspective mode so its a good idea to uncheck that.

Line up the front view with the z-axis bi-sencting the front of the chest, line up the side view with the z-axis bisecting the side of the face.

We can start putting basic shapes over the outline in either view, front or side. Doesnt have to be perfect just follow the outline of one view and get it in place on the other.

Select our shape and switch to **Edit mode**  And making sure we are in x-ray mode or wireframe box select vertices and move them to match our background image.  We may need to add vertices or faces, we can use Ctrl+R or **Loop Cut** to slice through our shape. Then grab the extra vertices to fill out the shape.

You can use Tab to switch modes and select the next shape.

Extruding a face creates a new set of vertices by extending the shape.  If we just want to select vertices in front of other ones we can go to solid mode instead of x-ray mode.

The body which we are modeling is mirrored naturally so we can use blender mirroring to save some time.

We can add Modifiers with the **Wrench** We can add the Mirror property to the cube.

Grabbing an object in edit move moves its pivot.

Viewport Settings Face Orientation mode will show any faces in red that should not be viewable, and wont be in game. We can use clipping to prevent this.

Make sure to add objects from object mode.

Alt+Z toggles X-Ray mode.

We can use other objects to provide the pivot point for mirroring, when enabling mirroring there is a slot for mirror object.  Ctrl+L allows us to copy modifiers from one object to another.

###### Managing objects into collections

Highlight objects to be in a collection and press M to put into a collection.

For scene decoration we can make these non-selectible and hide visibility.
