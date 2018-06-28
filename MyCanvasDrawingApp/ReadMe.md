** Description **

This is a simple console version of a drawing program.  

In a nutshell, the program should works as follows:  
 1. Create a new canvas  
 2. Start drawing on the canvas by issuing various commands  
 3. Quit  


| Command 		  | Description
------------------|------------------------------------------------------------------------------
| C w h           | Create a new canvas of width w and height h.  
| L x1 y1 x2 y2   | Create a new line from (x1,y1) to (x2,y2). Currently only horizontal or vertical lines are supported. Horizontal and vertical lines will be drawn using the 'x' character.  
| R x1 y1 x2 y2   | Create a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2,y2). Horizontal and vertical lines will be drawn using the 'x' character.  
| B x y c         | Fill the entire area connected to (x,y) with "colour" c. The behaviour of this is the same as that of the "bucket fill" tool in paint programs.  
| Q               | Quit the program.  



 *** Assumptions ***

- Coordinates are 1-based, origin is (1, 1) at the top right corner of the canvas.
- Commands are case insensitive.
- All current commands are a single character, but that could change in the future.
- "Colours" are alphanumericals characters.
- Width and height won't exceed a few thousands.
- A line limited to a single point is considered as valid (and both vertical and horizontal).
- Similarly, a rectangle reduced to a single line or a single point is considered valid.
- When drawing a line or a rectangle, it is drawn "on top" of any eventually existing lines or color.
- We don't keep track of individual lines or shapes: if 2 lines are drawn and connect, the program will subsequently assume that this is now a single line.
- When trying to draw a line or rectangle which is partially out of bounds, the application will notify the user and refuse the instruction.
- When a command receives fewer arguments than expected, it will throw an exception but when it received more arguments than expected, it will just ignore the extra arguments.


*** The Solution ***

The solution has been developped using `Visual Studio 2017` on `Windows 10` targeting the `.NET Framework 4.6.1`.

The main app `MyCanvasDrawingApp` has no dependencies other than .NET, the tests projects however have the following dependencies:  
  - `MyCanvasDrawingApp.Tests`: Moq  


*** Build and run ***

The solution can be built and ran (including the tests) the usual way using Visual Studio.


*** Future Scope ***

-End-End Tests suite
-Move validation logic from Commands to a validator class.
-Depenedency Injection using libraries like Ninject
-Add Logging statements
