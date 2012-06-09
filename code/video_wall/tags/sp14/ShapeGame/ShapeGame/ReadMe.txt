ShapeGame - READ ME 

Copyright (c) Microsoft Corporation. All rights reserved.

=============================
OVERVIEW  
.............................
This module provides sample code used to demonstrate how to create a simple game
 that uses Kinect audio and skeletal tracking information.
The game displays the tracked skeleton of the players and shapes (circles,
triangles, stars, and so on) falling from the sky. Players can move their limbs to
make shapes change direction or even explode, and speak commands such as
"make bigger"/"make smaller" to increase/decrease the size of the shapes or
"show yellow stars" to change the color and type of falling shapes. See below for
the full vocabulary.


=============================
FILES   
.............................
- App.xaml: Declaration of application level resources.
- App.xaml.cs: Interaction logic behind app.xaml.
- FallingShapes.cs: Shape rendering, physics, and hit-testing logic.
- MainWindow.xaml: Declaration of layout within main application window.
- MainWindow.xaml.cs: NUI initialization, player skeleton tracking, and main game logic.
- Recognizer.cs: Speech verb definition and speech event recognition.


=============================
DEVELOPER PREREQUISITE
.............................
- Speech Platform SDK (v11) 
  http://www.microsoft.com/download/en/details.aspx?id=27226


=============================
OPENING IN VISUAL STUDIO   
.............................
1. Launch Start/All Programs/Microsoft Kinect SDK v1.0/Kinect SDK Sample Browser
   (Start -> typing "Kinect SDK" finds it quickly)
2. In the list of samples, select this sample.
3. Click on "Install" button.
4. Provide a location to install the sample to.
5. Open the Solution file (.sln) that was installed.

=============================
SPEECH VOCABULARY
.............................

To do this:                            Say any of these:
------------------------------------   -----------------
Reset everything to initial settings   Reset, Clear
Pause the falling shapes               Stop, Freeze, Pause Game
Resume game                            Go, Unfreeze, Resume, Continue, 
                                       Play
Fall faster                            Speed Up, Faster
Fall more slowly                       Slow Down, Slower
Drop more shapes                       More, More Shapes
Drop fewer shapes                      Less, Fewer
Show bigger shapes                     Larger, Bigger, Bigger Shapes
Show largest shapes                    Huge, Giant, Super Big, Biggest
Show smaller shapes                    Smaller
Show smallest shapes                   Smallest, Tiny, Super Small

Any combination of color and/or shape may be spoken as well:

Colors: Red, Orange, Yellow, Green, Blue, Purple, Violet, Pink,
        Brown, Gray, Black, White, Bright, Dark, Every Color, 
        All Colors, Random Colors

Shapes: Triangles, Squares, Stars, Pentagons, Hexagons, Circles,
        7 Pointed Stars, All Shapes, Everything, Bubbles, Shapes

Note: Most phrases can be preceded by any words, for example: 

"Now do green circles" will drop green circles.
"Please go faster" and "even faster" will indeed speed things up.
