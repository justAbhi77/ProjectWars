# **PROJECT WARS**
<p align="center">
<img src="https://upload.wikimedia.org/wikipedia/en/a/a7/Advance_Wars_Coverart.jpg" width=480>
</p>

* The goal of this project is to use Unity Engine to create an <a href="https://en.wikipedia.org/wiki/Advance_Wars">Advance Wars</a> clone.
* Here, I've included an animated soldier along with the Main Menu structure and Pathfinding.

## **Implementation of the Main Menu**
***
The main menu is made up of two catregories:
* The Background image:
  - The background image has been taken from ----- .
  - Since it is seamless, the background image, if placed, can coexist side by side without looking out of place.
  - Public class named **Bg_scroller** is used in creating the background with member variables for controlling the speed of the background image scrolling.It has a reference to the **Rawimage** component of the Gameobject that the script exists on.

* The menu: 
> DOTween (HOTween v2), Version: 1.2.632 by Demigiant has been used in the project.
  - There exists a gameobject in the hierarchy named **MainMenu** which resides in front of the background image as a child of the Canvas.
  - This gameobject acts as a container/parent to the **Menu_item** prefab that is instantiated as a group of 3 in a group of 3 **( Start, Options, Exit)**.
  - The **scrolling of the Menu** occurs on the user-input of the respective arrow keys(:arrow_up: or :arrow_down:).
  - The code checks for the user-input (up or down arrow) and takes action accordingly. 
  - **The MoveUp() function:**
    - It is mutex controlled. 
    - The visual feedback for the player,i.e. the animation that plays on the center-most button is switched off. 
    - It implements the functionality of shifting of elements to the left of an array. 
  - **The MoveDown() function:**
    - The MoveDown() function works same as the MoveUp() function, except here the shifting of the elements takes place to the right of the array.  

<p align="center">
<img src="https://raw.githubusercontent.com/justAbhi77/ProjectWars/main/Assets/Images/ui/Background.png">
</p>

The Menu items are diagonally stacked on top of each other on as well as off screen. The center most element of the menu is animated.

# Gameplay
The gameplay is simple just press on a tile and the soldier on the screen will find the best possible path to it and traverse the map to reach its destination.It will also take into account the mountains and roads and find the best possible path.

