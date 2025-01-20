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
        


        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to the Legend of Zelda Text Adventure Game! Please enter your name");
            string name = Console.ReadLine() ?? "Hero";
            Player = new Player(name);
            Console.WriteLine("Your journey begins now...");
            Console.WriteLine();

            while (isPlaying = true)
            {
                if (Player.Inventory.Contains("Forest Medallion"))
                {
                    finishGame();                    
                }
                Console.WriteLine("You are standing at your house in Kokiri Village. Where would you like to go?");
                Console.WriteLine("1. Enter the Kokori forest");
                Console.WriteLine("2. Explore the The Great Deku Tree");
                Console.WriteLine("3. Enter the Kokori Village Shop");
                Console.WriteLine("4. Save the game");
                Console.WriteLine("5. Quit the game");
                Console.WriteLine("Type Inv to see your current inventory.");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                if (choice.Equals("Inv", StringComparison.OrdinalIgnoreCase))
                    {
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
            Console.WriteLine("You notice there is only one you can go and that is to the right.");
            Console.WriteLine("Do you go to the right or do you go back the way you came?");
            Console.WriteLine("1. Go to the right.");
            Console.WriteLine("2. Go back to your house.");

            Console.WriteLine("Enter your choice");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InteractSkullKid();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("You go back to the safety of your home.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;



            }


        }

        static void InteractSkullKid()
        {
            Console.Clear();
            Console.WriteLine("You run into a little kid wearing a Skull Mask. He seems to be holding a weird musical device.");
            Console.WriteLine("He's playing a lovely tune, sounds very familiar to the ears.");
            Console.WriteLine("He hands you the ocarina");
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
                    return;

                case "2":
                    Console.WriteLine("Thanks for playing! Goodbye!");
                    isPlaying = false;
                    break;


                default:
                    Console.WriteLine("Invalid choice. Please try again.");
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
                        drinkMagicPotion();
                        return;

                    case "2":
                        Console.WriteLine("You put the magic potion back into your pocket to save for a future moment.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            else 
            {
                Console.WriteLine("You may be missing something that you can use from somewhere else...");
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
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;



            }


        }

        static void EnterKokiriShop()
        {
            Console.Clear();
            Console.WriteLine("You see 4 items on the shelf.");
            Console.WriteLine("It is your lucky day, the shop is going out of business and everything is free.");
            Console.WriteLine("The 4 items are as follows: Kokori Shield, Magic Potion, Deku Stick, Deku Seed ");
            Console.WriteLine("Which item do you grab?");
            Console.WriteLine("1. Kokori Shield");
            Console.WriteLine("2. Magic Potion");
            Console.WriteLine("3. Deku Stick");
            Console.WriteLine("4. Deku Seed");

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
            Console.WriteLine("You drink your magic potion");
            Console.WriteLine("You now use your profound magic powers");
            Console.WriteLine("You have defeated all the monsters in the tree.");
            Console.WriteLine("The Deku Tree gives you it's thanks and you notice a gem on the floor");
            Console.WriteLine("You pick up the gem on the floor");
            Player.Inventory.Remove("Magic Potion");
            Player.Inventory.Add("Forest Medallion");
            Player.ShowInventory();
            Console.WriteLine("\r\n");
            Console.WriteLine(border);

        }

        static void finishGame()
        {
            Console.WriteLine("You have defeated all the creatures that brought doom to your village");
            Console.WriteLine("Thank you for playing my Zelda text adventure game!");            
            Console.WriteLine("\r\n");
            Console.WriteLine(border);
            Environment.Exit(0);
        }

    }
}
