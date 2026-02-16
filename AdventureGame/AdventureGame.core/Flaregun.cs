using System;
//I wanted to add a required key, but just a key was boring, so I went with this flare gun!
namespace AdventureGame.Core
{
    public class FlareGun : Item
    {
        public FlareGun(string name = "Flare Gun", string pickupMessage = "You pick up a flare gun! This might come in handy...")
            : base(name, pickupMessage)
        {
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} fires the flare gun! The police have been alerted to your location at the exit!");
         
        }
    }
}
