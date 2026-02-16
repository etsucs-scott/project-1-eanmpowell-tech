namespace AdventureGame.Core
//This is where our two characters, the "Final Girl" and our slasher, can interact with each other, making sure their attacks actually work!
{
    public interface ICharacter
    {
        string Name { get; set; }
        int Health { get; set; }

        // Attack another character
        void Attack(ICharacter target);

        // Take damage from an attack
        void TakeDamage(int damage);
    }
}
