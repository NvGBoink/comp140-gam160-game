# comp140-gam160-game
Repository for Assignment 1 of COMP140-GAM160

# -Summary Of Game-
In Shock players will find themselves in an abandoned warehouse during the dead of night. The goal of the game is a retreive 3 fuses in order to get the lights back on. With all the lights being out though, the player’s only source of light comes from a single wind up torch. On top of this the warehouse is also infested with light fearing creatures whose survival depends on the player not getting the lights back on. As the creatures are able to kill the player in a single touch the player must use their torch to both easily find their way towards the fuses and scare the creatures away from the. Issue the players will run into with this is the limited power that the torch has. The only way to recharge the torch is to wind it up using the crank on the side. 

# -Controller-
The custom controller aspect of this game will be a torch. This torch will serve as several forms of input. An analog stick located at the top of the torch will act as a form of input for moving the player. A button on the underside of the torch will be used to turn the torch on and off. A crank will be located on the left side of the torch as a form of input for charging the torch. Finally If time and budget allows a gyroscope will be located in the torch and used to rotate the player.

# -Game Mechanics-
Player movement:
----------------
The player movement is a simple first person character controller. Controlled using the analog stick located on the top of the controller the player can move left, right, backwards and forwards. The rotation might be handled in two ways depending on time and cost. Ideally the rotation of the player will be handled using a gyroscope located in the torch but if that proves to be difficult then using a second analog stick in a “wii nunchuk” style setup will have to do. 

Additional movement typically found in first person games such as sprinting and jumping will not be present partly due to an effort to keep the controller simple and also partly due to the fact that adding some sort of meaningful sprint mechanic will require a stamina system. As the game already as the player managing their power for the torch adding more resource managment might over complicate the game.

Power management:
Power management is the core of the gameplay mechanic. The creatures that are the threat in the game will only move when in complete darkness. The player will not be able to see the creatures very well when little light is available to them. These elements add up to a mechanic that requires the player to both make sure they use their power wisely and to also charge their torch in times where they know they are safe. 
In addition to this the frantic action of winding a torch up adds to the intense experience of playing a horror game.
Threats:
The core threat of the game is the light fearing creatures. These creatures only move when close to complete darkness, with the exception of a few gas lamps the only light in the game will come from the players torch. When the player shines the torch in the direction of any creature they will stop moving until the light runs out or the player moves away from them.
If the creature comes into collision with the player the player will die and the game will start again. As mentioned before there will be static gas lamps that will provide permanent safety within that area to the player. The creatures will not walk into the radius of these light areas but they will move around them. This will probably be one of the few situations when the player can see the creature moving

Goal:
The goal of the game is to collect 3 fuses from around the level and to bring them back. This is a simple mechanic thats main goal is to make the player move along a certain path and then to walk back along that path. This works well with the threat of the game as a player will probably run into a creature one the way to a fuse and then have to walk past it again when returning to the fuse box.

-Materials needed-
Rotary encoders
Analog joystick
Several white led’s
Button
Large piping for torch casing
Materials to make crank
(Possibly gyroscope)
