namespace AdventureGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Legend of Zelda Text Adventure Game!");
            Console.WriteLine("Your journey begins now...");
            Console.WriteLine();

            bool isPlaying = true;

            while (isPlaying)
            {
                Console.WriteLine("You are standing at your house in Kokiri Village. Where would you like to go?");
                Console.WriteLine("1. Enter the Kokori forest");
                Console.WriteLine("2. Explore the The Great Deku Tree");
                Console.WriteLine("3. Enter the Kokori Village Shop");
                Console.WriteLine("4. Quit the game");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("You walk into the dark forest. You see four ways to go, with a feint music sound coming fomr the right direction.");
                        break;

                    case "2":
                        Console.WriteLine("You enter the mouth of the Great Deku Tree. It's cold and damp, and you something that sounds like a spider coming from deep within.");
                        break;

                    case "3":
                        Console.WriteLine("You enter the shop and see a shield just sitting on one of the shelves, worth 40 rupees.");
                        break;

                    case "4":
                        Console.WriteLine("Thanks for playing! Goodbye.");
                        isPlaying = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
