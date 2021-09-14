using System;

namespace RobotWarsSolutionCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introductory message. I decided to give my code this time around
            //a more interactive feel by prompting,collecting data and giving the programme personality
            Console.WriteLine("Hello one and all, and Welcome to today's edition of: ");

            printLogo();

            Console.WriteLine("Let's get ready to rumbleeeeee!\n");
            Console.WriteLine("First of all, let's set up the amount of space you want your robofight arena. ");
            Console.WriteLine("Please provide me with the dimensions of your stage");
            Console.Write("Length(m): ");
            int xMax = Int32.Parse(Console.ReadLine()); //Maximum x coordinate of rectangular ring
            Console.Write("Breadth(m): ");
            int yMax = Int32.Parse(Console.ReadLine()); //Maximum y coordinate of rectangular ring

            Console.WriteLine($"\nGreat, Here's the top view of your {xMax} by {yMax} arena in the form of coordinates\n\n");

            makeArena(xMax, yMax);

            Console.WriteLine("\n\nGreat Layout!. Now Let's do some tests on your robot champion and see if it is responsive to commands!. Similar to the top view of the arena setting above, give your robot a starting position and direction to face. Note that it must also fall within the dimensions of the arena\n");
            Console.Write("X-coordinates: ");//Current x coordinate of robot
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Y-coordinates: ");//Current y coordinate of robot
            int y = Int32.Parse(Console.ReadLine());
            Console.Write("And finally, a direction(which can only be \"N\", \"E\", \"W\" or \"S\"): ");
            string cardinal = Console.ReadLine();
            cardinal = cardinal.ToUpper();

            Console.WriteLine($"\nPerfect!, your robot is currently at the position ({x}, {y}) facing the direction {cardinal}");
            printRobotCurrentPosition(x, y, cardinal);

            Console.WriteLine("\nTo see if your robot is responsive, give it as many commands as you want like 'M' to Move directly forward one step, 'L' to turn left and 'R' to turn right. You should know the commands you put together to confirm your robot works well. e.g \"MMMMML\" will move my robot forward 4 steps and then it will turn left");
            Console.Write("Have a go at it!: ");
            string robotDirections = Console.ReadLine(); //The directions of the robot to be done
            robotDirections = robotDirections.ToUpper();
            char[] splitDirections = robotDirections.ToCharArray();

            //This is the only major code
            for (int i = 0; i < robotDirections.Length; i++)
            {
                char c = splitDirections[i];
                if (x+ 1 <= xMax && y+ 1 <= yMax && x >= 0 && y >= 0) //they do not go out of the dimensions
                {

                    //printRobotCurrentPosition(x, y, cardinal);//Can be uncommented to check every single step made by the robot
                    if (c == 'L')
                    {
                        switch (cardinal)
                        {
                            case "N":
                                cardinal = "W";
                                break;
                            case "E":
                                cardinal = "N";
                                break;
                            case "W":
                                cardinal = "S";
                                break;
                            case "S":
                                cardinal = "E";
                                break;
                        }
                    }
                    else if (c == 'R')
                    {
                        switch (cardinal)
                        {
                            case "N":
                                cardinal = "E";
                                break;
                            case "E":
                                cardinal = "S";
                                break;
                            case "W":
                                cardinal = "N";
                                break;
                            case "S":
                                cardinal = "W";
                                break;
                        }

                    }
                    else if (c == 'M')
                    {
                        switch (cardinal)
                        {
                            case "N":
                                x++;
                                break;
                            case "E":
                                y++;
                                break;
                            case "W":
                                y--;
                                break;
                            case "S":
                                x--;
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Your robot can not leave the arena without using the door ^_^ !");
                }

            }

            printRobotCurrentPosition(x, y, cardinal);

            Console.WriteLine("\nRobot command response testing successful!, Now go get them all champ!");
            printLogo();

        }

        static void printLogo()
        {
            Console.WriteLine("\n");
            Console.WriteLine("__________ ________ __________ ___________________  __      __  _____ __________  _________");
            Console.WriteLine("\\______   \\\\_____  \\\\______   \\\\_____  \\__    ___/ /  \\    /  \\/  _  \\\\______   \\/   _____/");
            Console.WriteLine(" |       _/ /   |   \\|    |  _/ /   |   \\|    |    \\   \\/\\/   /  /_\\  \\|       _/\\_____  \\      ");
            Console.WriteLine(" |    |   \\/    |    \\    |   \\/    |    \\    |     \\        /    |    \\    |   \\/        \\ ");
            Console.WriteLine(" |____|_  /\\_______  / ______ /\\_______  /____|      \\__/\\  /\\____|__  /____|_  /_______  /");
            Console.WriteLine("        \\/         \\/       \\/         \\/                 \\/         \\/       \\/        \\/");
            Console.WriteLine("\n\n");
        }

        static void makeArena(int xMax, int yMax)
        {
            // For printing out the arena to the number of sizes specified. Print out and for loop were done
            // in this format so that results stop being mirrored
            for (int i = yMax; i >= 0; i--)//A for loop to cover the y axis decreasing
            {

                for (int j = 0; j <= xMax; j++)// A for loop to cover the x axis increasing
                {
                    //The condition that the counters should be 0 or
                    //reach the xMax and yMax values before printing coordinates
                    if (i == 0 || i == yMax || j == 0 || j == xMax)
                        Console.Write($"({i}, {j})   ");
                    else //If the condition above has not been reached, print out a space so no other coordinates are printed except 0's and extremes
                        Console.Write("         ");
                }
                Console.WriteLine("\n");

            }

            
        }

        static void printRobotCurrentPosition(int x, int y, string cardinal)
        {
            Console.WriteLine($"Robot's current position: ({x}, {y}){cardinal}");
        }
    }
}
