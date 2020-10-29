# Unity-Bowling-Game

The task is to create a realistic 3D Bowling game, using the Unity3D Game Engine. I


## The Role of the Scripts 

*	Audio_Play.cs

It controls when the sounds will be played . 

*	Back_to_menu.cs

When player pushes ‘Esc’ and ‘Back to Menu’, it returns back to menu.

*	Final1.cs 

Pause scence (View the Score and Back to Menu choice).

*	Lancer Ball.cs  

Gives force, torque to the ball, and reset.

*	Menu.cs

Menu sections.

*	Move.cs

Control translation and rotation of the camera (virtual bowling player).

*	ResetBall.cs 

Trigger interface to reset the ball.

*	ResetPins.cs

Trigger interface to reset Pins.

*	Score.cs  

Full algorithm to calculate the current score, switch player, and etch.

*	ScoreManager.cs  

Controls UI’s - Score display.

Unity Prefabs 

Each pin behaves in the same way. So I included all pins in a Prefab. Consequently, all pins have the same RigidBody, Texture, Mass, Script .

Character
I built my own Character. 
I didn’t use Unity’s FPS Controller. (Move.cs)


# Play the game 
 Downlaod .exe file and double-click on it

