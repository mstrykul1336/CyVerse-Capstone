
Thank you and welcome to the read me file!  In order to get setup fast just have a look at the Demo scene file.  

SETTING UP WINDOW FUNCTIONALITY

1. Create a new Canvas for the scene.

2. Drag/drop any of the Frame## prefabs from the Prefabs directory under the Canvas or drag/drop a Window script from the Scripts directory onto a newly created Panel.

3. The following properties can be manipulated under the Window components' properties:
a. Frame Offset:  Offset in pixels to where the frame image starts.  Some 9-sliced images may have transparency around the edges for shadows.  This property will allow you to configure how far into the image the window actually begins.  A green outer border will appear in the editor for guidance.
b. Frame Thickness: Thickness in pixels of the border that can be grabbed when the Allow Resize property is set to true.  A green inner border will appear in the editor for guidance.
c. Min Size: Minimum size in pixels for the window.
d. Allow Move by Caption: True if the Panel (RectTransform) can be moved by grabbing the caption.  Make sure the caption height is greater than zero.
e. Caption Height: Thickness in pixels of the top caption that can be grabbed when the Allow Move By Caption property set to true.  A green caption border will appear in the editor for guidance.
f. Allow Resize: True if the Panel (RectTransform) can be resized in any direction.
			
SETTING UP CURSOR FUNCTIONALITY

1. Simply drag/drop the CursorSystem prefab from the Prefabs directory into the scene.  The Cursors component can then be modified to different cursors for the various mouse states such as move and resize.  This is used in conjunction with the Window component to show when windows can be moved and/or resized.  Expand the Info properties under the component for a list of all configurable cursors.

	
	

WELCOME

Please see the ReadMe.txt file for an explanaation 

	
	
	