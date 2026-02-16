using System;
using System.Collections.Generic;

namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<Item> Inventory { get; private set; }
        public Weapon EquippedWeapon { get; set; }

        // Player coordinates in the maze
        public int X { get; set; }
        public int Y { get; set; }

        // Constructor
        public Player(string name)
        {
            Name = name;
            Health = 100;
            Inventory = new List<Item>();
            EquippedWeapon = null;
        }

        // Pick up an item
        public void PickUp(Item item)
        {
            Inventory.Add(item);

            // Auto-equip weapon if it’s better
            if (item is Weapon weapon)
            {
                if (EquippedWeapon == null || weapon.AttackModifier > EquippedWeapon.AttackModifier)
                {
                    EquippedWeapon = weapon;
                    Console.WriteLine($"You equip the {weapon.Name}.");
                }
            }

            // Flare gun picked up (optional auto-message)
            if (item is FlareGun flare)
            {
                Console.WriteLine(flare.PickupMessage);
            }

            // Note: Smores no longer auto-use; player chooses when to eat them
        }

        // Use an item manually
        public void UseItem(Item item)
        {
            if (item is Smores smore)
            {
                Health = Math.Min(Health + smore.HealAmount, 100);
                Console.WriteLine($"You eat the {smore.Name}. Health restored to {Health}.");
                Inventory.Remove(item);
            }
            else if (item is Weapon weapon)
            {
                EquippedWeapon = weapon;
                Console.WriteLine($"You equip the {weapon.Name}.");
            }
            else if (item is FlareGun flare)
            {
                flare.Use(this); // calls the Use method
                Inventory.Remove(flare);
            }
        }

        // Attack another character
        public void Attack(ICharacter target)
        {
            int baseDamage = 10;
            int weaponDamage = EquippedWeapon != null ? EquippedWeapon.AttackModifier : 0;
            int totalDamage = baseDamage + weaponDamage;

            Console.WriteLine($"{Name} attacks {target.Name} for {totalDamage} damage!");
            target.TakeDamage(totalDamage);
        }

        // Take damage from an attack
        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} takes {amount} damage! Health now {Health}.");
        }
    }
}
