using System;
//If you cant tell, I went for a Friday the 13th slasher movie style for my maze!
namespace AdventureGame.Core
{
    public class Slasher : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }

        // Renamed to match Program.cs expectation
        public int AttackPower { get; set; }

        public Slasher(string name, int health = 125, int attackPower = 25)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void Attack(ICharacter target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage!");
            target.TakeDamage(AttackPower);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage! Health is now {Health}.");
        }
    }
}
