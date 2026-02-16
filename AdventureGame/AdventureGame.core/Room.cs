using System;
using System.Collections.Generic;
//I added landmarks to this cornfield/maze our game takes place in, just for flavor and to make my life a bit easier! :3
namespace AdventureGame.Core
{
    public class Room
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Slasher Monster { get; set; } // Optional: Slasher may or may not be here
        public Room Up { get; set; }
        public Room Down { get; set; }
        public Room Left { get; set; }
        public Room Right { get; set; }

        public Room(string name)
        {
            Name = name;
        }

        // Add item to the room
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        // Remove item from the room (when player picks it up)
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        // Describe the room
        public void Describe()
        {
            Console.WriteLine($"You are at {Name}.");
            if (Items.Count > 0)
            {
                Console.WriteLine("You see the following items:");
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }

            if (Monster != null)
            {
                Console.WriteLine($"Watch out! A {Monster.Name} is here!");
            }
        }
    }
}
