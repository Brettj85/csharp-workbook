using System;
					
public class Program
{
	public static void Main()
	{
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("    Welcome To The Cavern Of Secrets");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

    Console.WriteLine("You enter a dark cavern out of curiousity. It is dark, but you can make out the shape of a stick on the ground in front of you. Do you take it? (yes or no?)");
    string StickInput = "";
	string FightInput = "";
	string SpiderInput = "";
    StickInput = Console.ReadLine();
	
    string[]options = new string[4];
    options[0] = "y";
    options[1] = "Y";
    options[2] = "yes";
    options[3] = "Yes";
    
		if (Array.IndexOf(options,StickInput) >=0)
      		Console.WriteLine("You got the stick!");
		else
	  		Console.WriteLine("You left the stick behind.");

	Console.WriteLine("Further into the cavern you spot something glowing in the distance do you approach it? (yes/no)");
	SpiderInput = Console.ReadLine();
	
		if (Array.IndexOf(options,SpiderInput) >=0)
			Console.WriteLine("As you approach the glowing figure it starts to move towards you slowly.");
		
		else
      		Console.WriteLine("As you move away from the glowing figure, you can see it move quickly towards you.");

  Console.WriteLine("Your attention is drawn to the glowing figure which you now see clearly is a spider!");
  Console.WriteLine("The spider is directly coming towards you with its fangs drawn. Do you attack it? (yes/no)");

   FightInput = Console.ReadLine();

    	if (Array.IndexOf(options,FightInput) < 0)
  {  Console.WriteLine("You turn to run out of the cave and lose your way in the darkness. The spider sinks its fangs into you as everything goes black.");
     Console.WriteLine("Better luch next time.");
  
  }
    	else  
		{
    		if (Array.IndexOf(options,StickInput) >=0)
            {
        	Console.WriteLine("You attack the spider with the stick!");
        	Console.WriteLine("After striking the spider, it runs back off into the distance as you run out of the cave.");
       	 	Console.WriteLine("You have escaped the cave unscathed, Congratulations!");
            }
			else
            {
        	Console.WriteLine("You attack the spider with your barehands!");
        	Console.WriteLine("You strike the spider with your fists and after a long tussle, you stun the spider long enough to stumble and run back to the entrance of the cave.");
        	Console.WriteLine("You have escaped the cave, but not without terrible injuries.");
    }
    }
    }
  }