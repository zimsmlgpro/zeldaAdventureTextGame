using System.Numerics;

namespace AdventureGame
{
    internal class Program
    {
        private static bool isPlaying = true;

        public static Player Player { get; private set; }

        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to the Legend of Zelda Text Adventure Game! Please enter your name");
            string name = Console.ReadLine() ?? "Hero";
            Player = new Player(name);
            Console.WriteLine("Your journey begins now...");
            Console.WriteLine();

            //bool isPlaying = true;

            while (isPlaying)
            {                
                Console.WriteLine("You are standing at your house in Kokiri Village. Where would you like to go?");
                Console.WriteLine("1. Enter the Kokori forest");
                Console.WriteLine("2. Explore the The Great Deku Tree");
                Console.WriteLine("3. Enter the Kokori Village Shop");
                Console.WriteLine("4. Quit the game");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

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
                        Console.WriteLine("Thanks for playing! Goodbye.");
                        isPlaying = false;
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
            Console.WriteLine("You feel like you have the ability to wipe all the monsters with the magic power you possess.");
            Console.WriteLine("1. Attempt to use that magic power");
            Console.WriteLine("2. Run away like the coward you are.");

            Console.WriteLine("Enter your choice");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Your magic ability has failed you and the monsters have attacked. You have died.");
                    isPlaying = false;
                    break;

                case "2":
                    //Console.WriteLine("You go back to the safety of your home.");
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
                    Player.AddItem("Kokori Shield");
                    Player.ShowInventory();
                    return;

                case "2":
                    Console.WriteLine("You Grab the Magic Potion");
                    Player.AddItem("Magic Potion");
                    Player.ShowInventory();
                    return;

                case "3":
                    Console.WriteLine("You Grab the Deku Stick");
                    Player.AddItem("Deku Stick");
                    Player.ShowInventory();
                    return;

                case "4":
                    Console.WriteLine("You Grab the Deku Seed");
                    Player.AddItem("Deku Seed");
                    Player.ShowInventory();
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;



            }


        }

    }
}
