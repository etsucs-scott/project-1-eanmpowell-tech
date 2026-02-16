using System;
using AdventureGame.Core;

namespace AdventureGame.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Saturday the 14th ===");
            Console.Write("Enter your name (Final Girl): ");
            string playerName = Console.ReadLine();

            Player player = new Player(playerName);
            Maze maze = new Maze();

            player.X = maze.StartPosition.X;
            player.Y = maze.StartPosition.Y;

            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                DrawMaze(maze, player);

                Tile currentTile = maze.Grid[player.X, player.Y];

                // Exit check
                if (currentTile.Type == TileType.Exit)
                {
                    Console.WriteLine("\nYOU MADE IT TO THE EXIT!");
                    Console.WriteLine("Help is on the way. You escape alive!");
                    break;
                }

                // Monster encounter
                if (currentTile.Monster != null)
                {
                    currentTile.Monster = StartBattle(player, currentTile.Monster);
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("\nYou have been killed by the Slasher...");
                        break;
                    }
                }

                Console.WriteLine("\nUse arrow keys to move, I = inventory, Q = quit");

                ConsoleKeyInfo key = Console.ReadKey(true);
                int newX = player.X;
                int newY = player.Y;

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        newY--;
                        break;
                    case ConsoleKey.DownArrow:
                        newY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        newX--;
                        break;
                    case ConsoleKey.RightArrow:
                        newX++;
                        break;
                    case ConsoleKey.I:
                        ShowInventory(player);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        continue;
                    case ConsoleKey.Q:
                        gameRunning = false;
                        continue;
                    default:
                        continue;
                }

                // Check walls and bounds
                if (newX < 0 || newX >= Maze.Width || newY < 0 || newY >= Maze.Height ||
                    maze.Grid[newX, newY].Type == TileType.Wall)
                {
                    Console.WriteLine("You hit a wall! Press any key to continue...");
                    Console.ReadKey(true);
                }
                else
                {
                    player.X = newX;
                    player.Y = newY;

                    // Pick up item automatically
                    if (maze.Grid[player.X, player.Y].Item != null)
                    {
                        Item item = maze.Grid[player.X, player.Y].Item;
                        player.PickUp(item);
                        maze.Grid[player.X, player.Y].Item = null;
                        maze.Grid[player.X, player.Y].Type = TileType.Empty;

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                    }
                }
            }

            Console.WriteLine("\nThanks for playing!");
        }

        // Draw the maze
        static void DrawMaze(Maze maze, Player player)
        {
            for (int y = 0; y < Maze.Height; y++)
            {
                for (int x = 0; x < Maze.Width; x++)
                {
                    if (player.X == x && player.Y == y)
                        Console.Write("@ ");
                    else
                    {
                        switch (maze.Grid[x, y].Type)
                        {
                            case TileType.Empty:
                                Console.Write(". ");
                                break;
                            case TileType.Wall:
                                Console.Write("# ");
                                break;
                            case TileType.Exit:
                                Console.Write("E ");
                                break;
                            case TileType.Item:
                                if (maze.Grid[x, y].Item is Weapon)
                                    Console.Write("W ");
                                else if (maze.Grid[x, y].Item is Smores)
                                    Console.Write("P ");
                                else if (maze.Grid[x, y].Item is FlareGun)
                                    Console.Write("F ");
                                else
                                    Console.Write("I ");
                                break;
                            case TileType.Slasher:
                                Console.Write("M ");
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        // Inventory display
        static void ShowInventory(Player player)
        {
            Console.WriteLine("\n=== INVENTORY ===");
            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("Empty.");
                return;
            }

            foreach (Item item in player.Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }

            if (player.EquippedWeapon != null)
                Console.WriteLine($"\nEquipped Weapon: {player.EquippedWeapon.Name} (+{player.EquippedWeapon.AttackModifier} damage)");
        }

        // Turn-based battle
        static Slasher StartBattle(Player player, Slasher slasher)
        {
            Console.Clear();
            Console.WriteLine($"A wild {slasher.Name} appears!\n");

            while (player.Health > 0 && slasher.Health > 0)
            {
                Console.WriteLine($"Player HP: {player.Health} | {slasher.Name} HP: {slasher.Health}");
                Console.WriteLine("Choose action: (A)ttack, (S)more, (F)lee");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.A)
                {
                    player.Attack(slasher);
                }
                else if (key.Key == ConsoleKey.S)
                {
                    Smores smore = player.Inventory.Find(i => i is Smores) as Smores;
                    if (smore != null)
                    {
                        player.UseItem(smore);
                    }
                    else
                    {
                        Console.WriteLine("No smores available!");
                        continue;
                    }
                }
                else if (key.Key == ConsoleKey.F)
                {
                    Random rand = new Random();
                    if (rand.Next(2) == 0)
                    {
                        Console.WriteLine("You successfully flee!");
                        return slasher; // leave battle
                    }
                    else
                    {
                        Console.WriteLine("Flee failed!");
                    }
                }
                else
                {
                    continue;
                }

                // Slasher attacks if alive
                if (slasher.Health > 0)
                    slasher.Attack(player);
            }

            if (slasher.Health <= 0)
            {
                Console.WriteLine($"You killed {slasher.Name}!");
                return null; // Slasher is gone from the tile
            }

            return slasher;
        }
    }
}
