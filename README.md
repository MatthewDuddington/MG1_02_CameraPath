# MG1_02_CameraPath
GS MSc CG&amp;E - Maths &amp; Graphics 2016 - Assignment 2 - Camera Path

Game Demo App

An app to be used across different game engines, to provide video demo of a game and its environment. Take the game’s visual environment and select a small number of interesting views; calculate a smooth path that will take the camera/character past each of these in turn, following the game’s terrain. Camera will turn to view the selected points of interest, or to follow the path ahead. 
Code in C++ and C#, with ability to link to Unity, Unreal and other game engines, so that developers can hook it into their games.


We will be exploring a system for moving a camera through a 3D scene, such that it will position and orient itself dynamically to produce an engaging route along ‘points of interest’, terrain and the player's path.
We will compare our library of functions’ performance with native / pre-existing mathematics libraries, as well as our own maths library that will implement matrix algebra, vector manipulation etc. 

(We’ll need to bare in mind the short scale of the project. Seems to be about 3-4 weeks? As end of Jan early Feb seemed to be the date Frederic mentioned?)
We could all write a few parts of the overall custom mathematics library? Or should we each do one (seems a bit overwork and redundant?)
Need Lerp and spline from the new stuff if we're going to have curved paths.
Collision / Proximity detection for points of interest (unless their positions are known and stored at load time?)
Could it cope with randomly spawning POIs like incidental scenes that are generated as you wander through the map? (Wow look at that amazing green cube we just teleported in that is metaphorically representing something of extreme interest!)
