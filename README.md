

 * Author : Logothetis Fragkoulis 
 * ECE
 * Electrical and Computer Engineer 
 

1.Introduction 
The task is to create a realistic 3D Bowling game, using the Unity3D Game Engine. Initially, the scene of the game was implemented. Especially by using cubes floor, the walls and the whole arena were created. Then for each of the objects in the scene was given a Physic Material, Texture, Colliders:
1. The floor had to have almost zero friction, so the Dynamic friction was set to zero.
2. The ball should be able to slip easily on the floor, so its friction on the floor was kept low.
3. All the objects have its own textures and physic material and settings like (Light Emission) were adjusted.
When the stage architecture was completed, code scripts  were created to give life to the scene. Scripts were written  for throwing the ball, moving the camera (virtual player), UI’s, Audio Source , Score Projection , Restoring Pins and Ball, etc.
Then on the scene in Screen Space mode UI's were placed to show the current frame and the two-player Score.
Of course, the sound could not be missed from the game. A plenty of  sounds are played during ball slips on the floor, during the collision of the ball with the pins. Furthermore there is background music.
Finally, after all the basic steps were completed, a menu of options was designed.

Menu and the  Abilities of The Game 
There exist 4 choices at the menu:
1.	Start the game for 2 players
2.	Start the game but the player will play against the Computer (Random Functions – Fair Uniform Distribution)
3.	Options (Player could find there, the instructions of the game and the buttons that should use) 
4.	Quit the Applications


User-friendly Scene
It is widely known, that the secret of a successful Game is the photorealistic graphics. Based on these, I used textures on the wall, on the ball, on the floor, pins that we meet in a Bowling Arena.
Extras 
1.	Power Bar Line (When player throws the Ball)
2.	Menu 
3.	Play against Computer (Using Random Functions)
4.	Pause Frame (When player push ‘Esc’)
5.	UI’s


The Role of the Scripts 

	Audio_Play.cs   It controls when the sounds will be played . 

	Back_to_menu.cs   When player pushes ‘Esc’ and ‘Back to Menu’, it returns back to menu.

	Final1.cs Pause Scence (View the Score and Back to Menu choice).

	Lancer Ball.cs  Give Force, Torque to Ball, Reset the Ball.

	Menu.cs  Menu Sections.

	Move.cs  Control Translation and Rotation of the Camera(Virtual Bowling Player).

	ResetBall .cs Trigger Interface to Reset the Ball.

	ResetPins .csTrigger Interface to Reset Pins.

	Score.cs  Full Algorithm to calculate the current Score, Switch Player etch.

	ScoreManager.cs  Controls UI’s -Score Display.

Unity Prefabs 

Each pin behaves in the game in the same way. So I include all pins in a Prefab. Consequently, all pins have the same RigidBody, Texture, Mass, Script .

Character
I built my own Character. I didn’t use Unity’s FPS Controller. (Move.cs)

