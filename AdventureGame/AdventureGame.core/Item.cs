using System;
//Our items! The stuff we need to help get outta here!
namespace AdventureGame.Core
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string PickupMessage { get; set; }

        protected Item(string name, string pickupMessage)
        {
            Name = name;
            PickupMessage = pickupMessage;
        }

        // Every item must define what happens when the player uses it
        public abstract void Use(Player player);
    }
}
