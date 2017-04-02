# -Summary Of Game-
In Shock players will find themselves in an abandoned warehouse during the dead of night. The goal of the game is a retreive 3 fuses in order to get the lights back on. With all the lights being out though, the player’s only source of light comes from a single wind up torch. On top of this the warehouse is also infested with light fearing creatures whose survival depends on the player not getting the lights back on. As the creatures are able to kill the player in a single touch the player must use their torch to both easily find their way towards the fuses and scare the creatures away from the. Issue the players will run into with this is the limited power that the torch has. The only way to recharge the torch is to wind it up using the crank on the side.
# -Game Mechanics-
Player movement:
The player movement is a simple first person character controller. Controlled using the analog stick located on the top of the controller the player can move left, right, backwards and forwards. The rotation might be handled in two ways depending on time and cost.
## Power management:
Power management is the core of the gameplay mechanic. The creatures that are the threat in the game will only move when in complete darkness. The player will not be able to see the creatures very well when little light is available to them. These elements add up to a mechanic that requires the player to both make sure they use their power wisely and to also charge their torch in times where they know they are safe. In addition to this the frantic action of winding a torch up adds to the intense experience of playing a horror game. Threats: The core threat of the game is the light fearing creatures. These creatures only move when close to complete darkness, with the exception of a few gas lamps the only light in the game will come from the players torch. When the player shines the torch in the direction of any creature they will stop moving until the light runs out or the player moves away from them. If the creature comes into collision with the player the player will die and the game will start again.
## Goal:
The goal of the game is to collect 3 fuses from around the level and to bring them back. This is a simple mechanic thats main goal is to make the player move along a certain path and then to walk back along that path. This works well with the threat of the game as a player will probably run into a creature one the way to a fuse and then have to walk past it again when returning to the fuse box.

## Threats:
The core threat of the game is the light fearing creatures. These creatures only move when close to complete darkness, with the exception of a few gas lamps the only light in the game will come from the players torch. When the player shines the torch in the direction of any creature they will stop moving until the light runs out or the player moves away from them.
If the creature comes into collision with the player the player will die and the game will start again. As mentioned before there will be static gas lamps that will provide permanent safety within that area to the player. The creatures will not walk into the radius of these light areas but they will move around them. This will probably be one of the few situations when the player can see the creature moving

# -Controller-
The custom controller aspect of this game will be a torch. This torch will serve as several forms of input. An analog stick located at the top of the torch will act as a form of input for moving the player. A button on the underside of the torch will be used to turn the torch on and off. A crank will be located on the left side of the torch as a form of input for charging the torch. Finally If time and budget allows a gyroscope will be located in the torch and used to rotate the player.

## Research:
From researching sites such as “http://shakethatbutton.com” I came across a game that had a similar input format as the input for my game. This game called “Crank Tank” (http://shakethatbutton.com/crank-tank/) used two cranks to control vehicles to attack an enemy base. From reading through the description I was able to see what components I would need in order to achieve the crank for my torch. The main component I need to get the desired result is a rotary encoder.

The rotary encoder is probably going to be the biggest challenge for me in the project. So far I have figured out the basics needed for setting up a simple led light toggle using a button (fig 1). Although the next step from here would be to only allow the led to turn on when the charge variable in the game is above a certain level.
What I plan on doing is simply having the rotary encoder send its input to the game and store that as the charge value. 

![alt text](https://i.gyazo.com/388951acfa3536296f71337bc98fabe8.png)
(This image shows a diagram of circuit needed for turning an led on based on a button press)

## Materials needed:
1. Rotary encoder
2. Analog joystick
3. Several white led’s
4. Button
5. Large piping for torch casing
6. Materials to make crank
7. (Possibly gyroscope)
8. Several resistor 220 ohm
9. Several resistor 10k ohm

# Final Controller
My final controller is a Pringles tube with a switch on the underside, a fishing reel on the left and a joy stick on the top. The Arduino sits on the inside and all of the wires are soldered to the components in order to avoid having the bread board also need to sit in the already crowded Pringles tube. 
The usb for the Arduino runs through the bottom of the tube. In the end, I didn't add the led's to the front of the torch due to the lack of room. I was worried if I was to add more wired and components it would end up damaging the vital components making the controller useless. 

![alt text](https://gyazo.com/864ccf3f08dcbb4bc1dcd67864f262f7.png)
(Final controller)

![alt text](https://gyazo.com/bb2b658978eb5b88061d076cea76b813.png)
(Joy stick)

![alt text](https://gyazo.com/cfb3a0005b6e3b300bab8c6c27daa1bc.png)
(Switch/Button)

![alt text](https://gyazo.com/a85e125c5fb2de6ba1f90919fe84310b.png)
(Fishing reel / Crank)

![alt text](https://gyazo.com/f759d6547f41eb60aa3c7a3d43d7af55.png)
(Ardunio)

![alt text](https://gyazo.com/df33f0ca5eda8272d11b5c535c564a68.png)
(Inside the Pringles tube)
