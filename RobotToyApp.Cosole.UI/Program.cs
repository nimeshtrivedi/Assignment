using RobotToyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotToyApp.Cosole.UI
{
    class Program
    {
        
        static void Main(string[] args)
        {

            RobotToy robot = new RobotToy();    
        RobotToyService rtService = new RobotToyService( robot);

            Console.WriteLine("Enter your command 'q' to quit");
            
            // Accept Command First
            string command = null;

            while (true)
            {
                Console.WriteLine(">");
                command = Console.ReadLine();
                if (Common.GetCommand(command) == Commands.QUIT) 
                {
                    return;
                }


                if (Common.GetCommand(command) == Commands.UNKNOWN)
                {

                    Console.WriteLine("The command is not valid, " + command);
                    continue;

                }
                else
                    try {
                        Console.WriteLine(rtService.ExecuteCommand(command));
                    }
                    catch  (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
            }
        }

       
    }
}
