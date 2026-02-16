using System;
//Gotta know what you are standing on and what else is there! ^_^
namespace AdventureGame.Core
{
    public class Tile
    {
        public TileType Type { get; set; } = TileType.Empty;
        public Item Item { get; set; } = null;
        public Slasher Monster { get; set; } = null;

        public Tile(TileType type = TileType.Empty)
        {
            Type = type;
        }

        // Describe the tile when the player steps on it
        public void Describe()
        {
            switch (Type)
            {
                case TileType.Empty:
                    Console.WriteLine("You are in the corn. Nothing here.");
                    break;
                case TileType.Wall:
                    Console.WriteLine("A thick wall of corn blocks your way.");
                    break;
                case TileType.Item:
                    if (Item != null)
                        Console.WriteLine($"You see {Item.Name} here!");
                    break;
                case TileType.Slasher:
                    if (Monster != null)
                        Console.WriteLine($"Watch out! {Monster.Name} is here!");
                    break;
                case TileType.Exit:
                    Console.WriteLine("You see the exit! Freedom is near...");
                    break;
            }
        }

        // Check if tile is walkable
        public bool IsWalkable()
        {
            return Type != TileType.Wall;
        }
    }
}
