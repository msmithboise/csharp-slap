using System;

namespace csharp_slap.Models
{
    internal class Player
    {
        //this is like a getter in .js

        // return the value of this item, when you get, actually return damage + 1

        // get is a method.  in this case we are using a custom method

        // this is like a get on your .js class or computed

        int baseStrength = 1;
        public int Damage { get { return Weapon.Damage + baseStrength; } }
        public string Name { get; private set; }

        public Item Weapon { get; private set; } = new Item("Fist", 1);

        public int GetDamage()
        {
            return baseStrength + Weapon.Damage;
        }


        // void doesn't give me anything back because I handed it something, it doesn't have to return anything to me.
        public void GiveWeapon(Item item)
        {
            if (Weapon == null)
            {

                Weapon = item;
                return;  // you can just say return if returning void
            }

            if (Weapon.Damage < item.Damage)
            {
                System.Console.Write("Are you sure you want to switch weapons? Y/N?");
                var choice = Console.ReadLine();
                if (choice == "Y")
                {
                    Weapon = item;
                }


            }
        }

        public Player(string name)
        {
            if (name == "jake")
            {
                baseStrength = 50;
            }
        }

        internal void PrintStats()
        {
            Console.Clear();
            var bgColor = Console.BackgroundColor;
            var fgColor = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            System.Console.WriteLine($@"
            
            -------------------
            |    Weapon   |
            -------------------
    {Weapon.Name} : {Damage}


            
            
            ");
        }
        Console.BackgroundColor = bgColor;
        Console.ForegroundColor = fgColor;
    }
}