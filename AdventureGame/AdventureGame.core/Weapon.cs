using System;
//Of course we want them to be able to fight back!
namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public int AttackModifier { get; set; }

        public Weapon(string name, int attackModifier, string pickupMessage)
            : base(name, pickupMessage)
        {
            AttackModifier = attackModifier;
        }

        // Using a weapon equips it
        public override void Use(Player player)
        {
            player.EquippedWeapon = this;
            Console.WriteLine($"{player.Name} equips the {Name}!");
        }
    }
}
