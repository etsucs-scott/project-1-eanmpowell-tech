using System;
// These are smores, just for healing!
namespace AdventureGame.Core
{
    public class Smores : Item
    {
        public int HealAmount { get; set; }

        public Smores(string name, int healAmount, string pickupMessage)
            : base(name, pickupMessage)
        {
            HealAmount = healAmount;
        }

        public override void Use(Player player)
        {
            player.Health += HealAmount;
            Console.WriteLine($"{player.Name} eats the {Name} and restores {HealAmount} health! Health is now {player.Health}.");
        }

        // I wanted to add different flavors, just for flavor text! :3
        public static Smores[] CreateFlavors()
        {
            return new Smores[]
            {
                new Smores("Golden Brown Smore", 100, "You pick up a Golden Brown Smore! Yum!"),
                new Smores("Lightly Toasted Smore", 100, "You pick up a Lightly Toasted Smore! Sweet!"),
                new Smores("Double Chocolate Smore", 100, "You pick up a Double Chocolate Smore! Delicious!"),
                new Smores("Strawberry Smore", 100, "You pick up a Strawberry Smore! Tasty and fruity!"),
                new Smores("Burnt Smore", 100, "You pick up an Burnt Smore! Smoky and crispy!")
            };
        }
    }
}
