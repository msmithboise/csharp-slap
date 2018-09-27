using System;
using System.Collections.Generic;

namespace csharp_slap.Models
{

    public class Target
    {

        public int Health { get; set; }
        public string Name { get; set; }

        public Dictionary<string, Target> NextFighterChoice { get; set; }

        public List<Item> Items = new List<Item>();

        public Target(string name, int health)
        {
            Name = name;
            Health = health;
            NextFighterChoice = new Dictionary<string, Target>();

        }

        internal void GetDescription()
        {

            if (Health > 0)
            {
                Health -= _player.Damage;
                System.Console.WriteLine($"Name: {Name} Health: {Health}");
                return;
            }
            System.Console.WriteLine("Yo you just done killt {Name}");
            if (Items.Count > 0)
            {

                System.Console.WriteLine("Looks like he dropped some stuff");
                Items.ForEach(i => System.Console.WriteLine(i.Name));
            }
        }

        public Item TryToTakeItem(string itemName)
        {
            if (Health <= 0)
            {

                return Items.Find(i => i.Name == itemName);
            }
            return null;
        }

        internal void PrintNextFighterChoiceDirection()
        {
            foreach (var choice in NextFighterChoice)
            {
                System.Console.WriteLine(choice.Key);
            }
        }
    }
}