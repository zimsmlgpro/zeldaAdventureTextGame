using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<string> Inventory { get; set; } = new  List<string>();

        public Player(string name) 
        {
            Name = name;            
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        public void ShowInventory()
        {
            Console.WriteLine("Your inventory contains:");
            foreach (string item in Inventory)
            {
                Console.Write($"- {item}\r\n");
            }
        }
    }
}
