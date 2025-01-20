using System;
using System.Numerics;
using System.Reflection.PortableExecutable;

namespace AdventureGame
{
    public class Program
    {
        private static bool isPlaying = true;
        public static string border = "***********************";        
        public static Player Player { get; set; }


        
        static void WritePrompt(string prompt, List<string> options) 
        {
           // Output prompt
           Console.WriteLine(prompt);

           options.ForEach(option => Console.WriteLine(option));
        
        }        
        


        static void Main(string[] args)
        {
            Player = Player.Load("savegame.json");

            bool firstTime = true;

            if (Player == null)
            {
                Console.WriteLine("Welcome to the Legend of Zelda Text adventure game!");
                Console.WriteLine("It looks like there is no save data. Please enter your name");
                string name = Console.ReadLine() ?? "Hero";
                Player = new Player(name);
                Console.WriteLine($"Welcome, {Player.Name}! Your journey begins now...");
            }

            else
            {
                Console.WriteLine($"Welcome back, {Player.Name}! Your journey begins now...");
                firstTime = false;
            }
           
            while (isPlaying = true)
            {
                if (Player.Inventory.Contains("Forest Medallion"))
                {
                    finishGame();                    
                }
                
                if (firstTime)
                {
                    Console.WriteLine("Welcome to the Legend of Zelda text adventure game!");
                    firstTime = false;
                }
                
                List<string> introOptions = ["1. Enter the Kokori forest" , "2. Explore the The Great Deku Tree" , "3. Enter the Kokori Village Shop" , "4. Save the game" , "5. Quit the game" , "Type Inv to see your current inventory."];
                WritePrompt("You are standing at your house in Kokiri Village. Where would you like to go?", introOptions);
                
                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                if (choice.Equals("Inv", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        Player.ShowInventory();
                        continue;
                    }

                switch (choice)
                {
                    case "1":
                        EnterKokiriForest();
                        break;

                    case "2":
                        EnterDekuTree();
                        break;

                    case "3":
                        EnterKokiriShop();
                        break;

                    case "4":
                        Player.Save("savegame.json");
                        Console.WriteLine("\r\n");
                        Console.WriteLine(border);
                        break;

                    case "5":
                        Console.WriteLine("Thanks for playing! Goodbye.");
                        isPlaying = false;
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }


            }
        }

        static void EnterKokiriForest()
        {
            Console.Clear();
            List<string> forestOptions = ["1. Go to the right.", "2. Go back to your house."];
            WritePrompt("You notice there is only one you can go and that is to the right.\nDo you go to the right or do you go back the way you came?", forestOptions);

            Console.WriteLine("Enter your choice");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    InteractSkullKid();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("You go back to the safety of your home.");
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    break;



            }


        }

        static void InteractSkullKid()
        {
            Console.Clear();
            List<string> skullOptions = ["1. Go back to your house.", "2. Quit the game."];
            WritePrompt("You run into a little kid wearing a Skull Mask. He seems to be holding a weird musical device.\nHe's playing a lovely tune, sounds very familiar to the ears.\nHe hands you the ocarina", skullOptions);
            Player.Inventory.Add("Ocarina");
            Player.ShowInventory();
            Console.WriteLine("Now what would you like to do?");
            Console.WriteLine("1. Go back to your house.");
            Console.WriteLine("2. Quit the game.");

            Console.WriteLine("Enter your choice");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    return;

                case "2":
                    Console.WriteLine("Thanks for playing! Goodbye!");
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    isPlaying = false;
                    break;


                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    break;
            }


        }

        static void EnterDekuTree()
        {
            Console.Clear();
            Console.WriteLine("You notice a bunch of monsters that have taken over the Deku Tree");
            if (Player.Inventory.Exists(item => item == "Magic Potion"))
            {
                Console.WriteLine("Would you like to drink your magic potion that you acquired earlier?");
                Console.WriteLine("Type 1 for yes or 2 for no.");
                string? userInput = Console.ReadLine();


                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\n\r");
                        Console.WriteLine(border);
                        drinkMagicPotion();
                        return;

                    case "2":
                        Console.WriteLine("You put the magic potion back into your pocket to save for a future moment.");
                        Console.WriteLine("\n\r");
                        Console.WriteLine(border);
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            else 
            {
                Console.WriteLine("You may be missing something that you can use from somewhere else...");
                Console.WriteLine("\n\r");
                Console.WriteLine(border);
            }

            Console.WriteLine("You know deep down that magic exists somewhere");
            Console.WriteLine("Do you wish to continue to try and fight the monsters?");
            Console.WriteLine("Type 1 to continue to attack the monster or 2 to run away.");

            Console.WriteLine("Enter your choice");
            string? choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    Console.WriteLine("You did not have the tools you needed to survive. You have died.");
                    Console.WriteLine("Press R to restart the game");
                    string? userChoice = Console.ReadLine();
                    {
                        if (userChoice.ToLower() != "r") //If the user doesn't press any variation of r
                        {
                            isPlaying = false; //Stops the whole loop
                            Console.WriteLine("Thanks for giving my Adventure Game a try!");
                        }

                    }

                    break;

                case "2":
                    Console.WriteLine("You go back to the safety of your home.");
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;



            }


        }

        static void EnterKokiriShop()
        {
            Console.Clear();
            List<string> shopOptions = ["1. Kokori Shield", "2. Magic Potion", "3. Deku Stick", "4. Deku Seed"];
            WritePrompt("You see 4 items on the shelf.\nIt is your lucky day, the shop is going out of business and everything is free.\nThe 4 items are as follows: Kokori Shield, Magic Potion, Deku Stick, Deku Seed.\nWhich item do you grab?", shopOptions);
            Console.WriteLine("Enter your choice");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You Grab the Kokori Shield");
                    Player.Inventory.Add("Kokori Shield");
                    Player.ShowInventory();
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    return;

                case "2":
                    Console.WriteLine("You Grab the Magic Potion");
                    Player.Inventory.Add("Magic Potion");
                    Player.ShowInventory();
                    Console.WriteLine("\n\r");
                    Console.WriteLine(border);
                    return;

                case "3":
                    Console.WriteLine("You Grab the Deku Stick");
                    Player.Inventory.Add("Deku Stick");
                    Player.ShowInventory();
                    Console.WriteLine("\r\n");
                    Console.WriteLine(border);
                    return;

                case "4":
                    Console.WriteLine("You Grab the Deku Seed");
                    Player.Inventory.Add("Deku Seed");
                    Player.ShowInventory();
                    Console.WriteLine("\r\n");
                    Console.WriteLine(border);
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;



            }


        }

        static void drinkMagicPotion()
        {
            Console.WriteLine("You drink your magic potion\nYou now use your profound magic powers\nYou have defeated all the monsters in the tree.\nThe Deku Tree gives you it's thanks and you notice a gem on the floor.\nYou pick up the gem on the floor");
            Player.Inventory.Remove("Magic Potion");
            Player.Inventory.Add("Forest Medallion");
            Player.ShowInventory();
            Console.WriteLine("\r\n");
            Console.WriteLine(border);

        }

        static void finishGame()
        {
            Console.WriteLine("You have defeated all the creatures that brought doom to your village.\nThank you for playing my Zelda text adventure game!\r\n");
            Console.WriteLine(border);
            Console.WriteLine("Please press Q to quit or R to restart.");
            string? endChoice = Console.ReadLine();
            if (endChoice.ToLower() == "q")
            {
                Environment.Exit(0);                   
            }
            if (endChoice.ToLower() == "r")
            {
                Console.Clear();
                Console.WriteLine(border);
                return;
            }
        }

    }
}
