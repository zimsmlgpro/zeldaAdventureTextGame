using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public static string border = "***********************";

        public Player(string name) 
        {
            Name = name;            
        }

        public Player()
        {
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        public void ShowInventory()
        {            
            Console.WriteLine("Your Inventory:");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Your don't have any items in your inventory.");

            }
            else
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($" - {item}");
                }
            }
            Console.WriteLine("\r\n");
            Console.WriteLine(border);
        }

        public void Save(string PlayerProgress)
        {
            string jsonData = JsonSerializer.Serialize(this);
            File.WriteAllText(PlayerProgress, jsonData);
            Console.WriteLine("Game Saved Successfully.");
        }

        public static Player? Load(string PlayerProgress)
        {
            if (File.Exists(PlayerProgress))
            {
                string jsonData = File.ReadAllText(PlayerProgress);
                return JsonSerializer.Deserialize<Player>(jsonData);
            }
            else 
            {
                Console.WriteLine("No saved game found, starting a new game.");
                return new Player();
            }
        }
    }
}
