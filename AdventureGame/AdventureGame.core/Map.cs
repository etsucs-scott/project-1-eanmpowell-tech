using System;
//Of course any maze needs a map!
namespace AdventureGame.Core
{
    public class Map : Item
    {
        public Map(string name = "Corn Maze Map", string pickupMessage = "You pick up a map of the corn maze!")
            : base(name, pickupMessage)
        {
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} looks at the map. You see the general layout of the corn maze with notable landmarks.");
        }
    }
}
