using System;
using System.Collections.Generic;

namespace gameboy
{
    class Display
    {

    }
}
//going to try and do this 
/*
_________________________________
things we need to keep track of:
_________________________________
Object - Profile:

dictionary of games and there respective dictionary of stats -  dictionary key: "game" value: (dictionary: key: "StatName" Value: int-counter)
user full name (string) method to change / method to add
user handle (string) method to change / method to add
must have a display system built in

Object - GameGenie:
Add/Remove cheat:
takes in a cheat and stores on off quality. cheat itself must be code that gets run when called.
list and run code option:
user cheats takes in a list of cheats and returns a dictionary(key "cheat") value: code to run [ie change the life counter] dictionary key: game value: list of active cheats games will have to take in the list of cheats and refer to a cheat controller to optimize itself for the cheat
must have a display system built in
_________________________________________
Display a list of options in the console 
_________________________________________
Display them horizontal & vertical
an on off switch based on request for additional menu data
build 2 sub classes that have a subclass each - the sub classes will include extra data but still the menu of the parent

structure:
classes/methods and the prams they will take:
DisplaySelect (return string)(input v for vertical h for horizontal, List of menu items,additional data in the form of a list of strings [this can be null])
ChildClasses:
vertical (return string)(display a vertical list of options)(input list)
Horizontal (return string)(display a horizontal list of options)(input list)
Child Classes of vert/hori:
verticalWithData (return string)(display a vertical list of options with differant data or menu for each selection)(input list)
HorizontalWithData (return string)(display a horizontal list of options with differant data or menu for each selection)(input list)
Return: string
_____________________
games:
_____________________
towers and mastermind
Return: dictionary<string, int>
 */
