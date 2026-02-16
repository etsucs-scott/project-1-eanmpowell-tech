using System;
using System.Collections.Generic;

namespace AdventureGame.Core
{
    public class Maze
    {
        public const int Width = 10;
        public const int Height = 10;

        public Tile[,] Grid { get; private set; } = new Tile[Width, Height];
        public (int X, int Y) StartPosition { get; private set; }
        public (int X, int Y) ExitPosition { get; private set; }

        private Random rand = new Random();

        public Maze()
        {
            GenerateMaze();
        }

        private void GenerateMaze()
        {
            // Step 1: Initialize all tiles as empty
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Grid[x, y] = new Tile(TileType.Empty);
                }
            }

            // Step 2: Add outer walls
            for (int x = 0; x < Width; x++)
            {
                Grid[x, 0].Type = TileType.Wall;
                Grid[x, Height - 1].Type = TileType.Wall;
            }
            for (int y = 0; y < Height; y++)
            {
                Grid[0, y].Type = TileType.Wall;
                Grid[Width - 1, y].Type = TileType.Wall;
            }

            // Step 3: Random internal walls
            int wallCount = 15;
            for (int i = 0; i < wallCount; i++)
            {
                int x = rand.Next(1, Width - 1);
                int y = rand.Next(1, Height - 1);
                Grid[x, y].Type = TileType.Wall;
            }

            // Step 4: Set start position
            StartPosition = (1, 1);
            Grid[StartPosition.X, StartPosition.Y].Type = TileType.Empty;

            // Step 5: Set exit position (bottom right-ish)
            ExitPosition = (Width - 2, Height - 2);
            Grid[ExitPosition.X, ExitPosition.Y].Type = TileType.Exit;

            // Step 6: Place Slasher randomly (not start or exit)
            PlaceSlasher();

            // Step 7: Place items randomly
            PlaceItems();
        }

        private void PlaceSlasher()
        {
            int x, y;
            do
            {
                x = rand.Next(1, Width - 1);
                y = rand.Next(1, Height - 1);
            } while ((x == StartPosition.X && y == StartPosition.Y) ||
                     (x == ExitPosition.X && y == ExitPosition.Y) ||
                     Grid[x, y].Type != TileType.Empty);

            Grid[x, y].Type = TileType.Slasher;
            Grid[x, y].Monster = new Slasher("The Slasher", 140, 25);
        }

        private void PlaceItems()
        {
            List<Item> itemsToPlace = new List<Item>()
            {
                new Map(),
                new FlareGun(),
                new Weapon("Machete", 15, "You pick up a machete."),
                new Weapon("Axe", 10, "You found an axe."),
                new Weapon("Baseball Bat", 5, "You grab a baseball bat."),
                new Smores("Golden Toasted Smore", 100, "Perfectly toasted smore."),
                new Smores("Caramel Crunch Smore", 100, "Caramel crunch smore."),
                new Smores("Double Chocolate Smore", 100, "Double chocolate smore."),
                new Smores("Cinnamon Smore", 100, "Cinnamon smore."),
                new Smores("Extra Gooey Smore", 100, "Extra gooey smore.")
            };

            foreach (Item item in itemsToPlace)
            {
                int x, y;
                do
                {
                    x = rand.Next(1, Width - 1);
                    y = rand.Next(1, Height - 1);
                } while ((x == StartPosition.X && y == StartPosition.Y) ||
                         (x == ExitPosition.X && y == ExitPosition.Y) ||
                         Grid[x, y].Type != TileType.Empty);

                Grid[x, y].Type = TileType.Item;
                Grid[x, y].Item = item;
            }
        }

        // Optional helper to display grid in console for testing
        public void PrintMaze()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    switch (Grid[x, y].Type)
                    {
                        case TileType.Empty:
                            Console.Write(".");
                            break;
                        case TileType.Wall:
                            Console.Write("#");
                            break;
                        case TileType.Exit:
                            Console.Write("E");
                            break;
                        case TileType.Item:
                            Console.Write("I");
                            break;
                        case TileType.Slasher:
                            Console.Write("S");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
