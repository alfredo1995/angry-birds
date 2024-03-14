Angry Bomb is a physics game, like its predecessors (Angry Birds), in which your objective is to eliminate yellow birds and destroy their buildings by throwing bombs at them.

The "roles" have been reversed, and now it is the "Birds" who are being eliminated!

Use the mouse to throw the bombs by clicking on the middle of the slingshot!

<br> 

Configuring game area
 
<br>
  
1) New project
              
              create a 2D template

2) Import the assets
            
              Download the assets from this repository

3) Game background

              Drag the background to the scene and name it "Background"

4) Drag the 2 parts of the slingshot to the hierarchy and position it in the scene

             in slingshot0 > Sort in layer to 3
             in slingshot1 > Sort in layer to 1
      
             Attach slingshot0 as a child of slingshot1 (Made as a single object)
             Reset the position of objects in the transform component when adding them to the scene
            
5) Create an Empty Object and name it Slingshot

            bring the slingshot0e1, into this empty Empty Object Slingshot
           
6) Create the objects that will receive the line rendering component
            
             //Inside Object Slingshot that is storing all objects in front of the slingshot
            
             Create > Empty object > effects > line > name for track0
             Create > Empty object > effects > line > name for track1
            
7) Create the objects that will define the position between the slingshot strips
            
             //Inside Object Slingshot that is storing all objects in front of the slingshot

             Create > Empty object > named it for PosicaoFaixaCentro
             position the objectPosicaoFaixaCentro in the upper center between the Slingshot gap
            
             Create > Empty object > named it for PosicaoFaixaParada
             position the objectPosicaoFaixaParada in the center to the left of the slingshot
            
8) Create the objects that will define the position of the ends of the slingshot strips
            
             //Inside Object Slingshot that is storing all objects in front of the slingshot

             Create > Empty object > named it for PosicaoPontaFaixa0
             position the PosicaoPontaFaixa0 object on the left tip of the slingshot
            
             Create > Empty object > named it for PosicaoPontaFaixa1
             position the PosicaoPontaFaixa0 object at the right end of the slingshot
            
             Make sure that all objects created are within the Estiligui Object
<br>

LineRenderer has a matrix of two or more points in 3D space, used to draw a simple straight line

<br>
            
9) Create a folder and name it for scripts

             Inside the scripts folder > Create a new C# script and name it Estiligui.cs
             Drag and connect the script to the Estiligui Object that is storing all the components
            
10) Open the Estiligui.cs script and create a Renderer component that has an array (array)
            
             // Create a public variable to store the array elements of type LineRenderer
                         public LineRenderer[] tracks;
                        
             // Create 3 Transform variables to store and manipulate the position, rotation and scale of Estiligui.cs
                         public Transform[] tipsTracks;
                         public Transform trackStop;
                         public Transform stripCenter;

            // create a bool like mouse down
                         bool mousePretado;
                        
11) Showing complete Estiligui.cs code
           
             public class Estiligui: MonoBehaviour
             {
                 public LineRenderer[] tracks;
                 public Transform[] tipsTracks;
                 public Transform trackStop;
                 public Transform stripCenter;
                
                 bool mousePretado;
                
12) Set the count and position of line renderers in the initialization method
            
             //set the count of both redenizer to 2 (positionCount)
             //set the renderer line position to the strip position (setPosition(striPositions.position)

             void Start()
             {
                 tracks[0].positionCount = 2;
                 tracks[1].positionCount = 2;
                 tracks[0].SetPosition(0, endsTracks[0].position);
                 tracks[1].SetPosition(0, tipsTracks[1].position);
                
13) Create a method to redefine and define the range using a Vector3 type parameter
            
             //Vector3 used throughout the Unit to pass 3D positions and directions around
            
             void RangePositions(
