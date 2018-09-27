using System;

namespace csharp_slap.Models
{


    public class Game
    {
        bool playing = false;
        private Target _currentTarget;

        Player _player;


        public void StartGame()


        {
            Setup();

            while (playing)
            {

                GetUserInput();





            }



            Console.Clear();
            System.Console.WriteLine("Bye Felicia!");

        }

        private void GetUserInput()
        {

            _currentTarget.GetDescription();


            System.Console.WriteLine("What ya wanna do:  ");
            string input = Console.ReadLine();
            input = input.ToLower();

            switch (input)
            {

                case "quit":
                    playing = false;
                    break;

                case "fight":
                    _currentTarget.Health -= _player.Damage;
                    break;

                case "take":
                    if (_currentTarget.Health > 0)
                    {
                        System.Console.WriteLine($" Yo {_currentTarget.Name} just punched ya in da face");
                        return;
                    }
                    System.Console.WriteLine("What ya gonna take?");
                    var itemName = Console.ReadLine();
                    Item lootedItem = _currentTarget.TryToTakeItem(itemName);
                    if (lootedItem != null)
                    {
                        _player.GiveWeapon(lootedItem);
                    }

                    break;

                case "advance":
                case "open":
                    if (_currentTarget.Health > 0)
                    {

                        System.Console.WriteLine($" Yo {_currentTarget.Name} just punched ya in da face");
                        System.Console.WriteLine("Yall betta fight");
                        return;

                    }
                    System.Console.WriteLine("Which way we goin?");
                    _currentTarget.PrintNextFighterChoiceDirection();
                    var direction = Console.ReadLine();
                    if (_currentTarget.NextFighterChoice.ContainsKey(direction))
                    {
                        _currentTarget = _currentTarget.NextFighterChoice[direction];

                    }
                    else
                    {
                        System.Console.WriteLine("Yo you done messed up, da po po gotcha");
                        playing = false;
                    }


                    break;


                case "stats":
                    _player.PrintStats();
                    break;


                default:
                    System.Console.WriteLine("Stop messin around!");
                    break;




            }

        }
        void Setup()
        {

            playing = true;
            var joe = new Target("Glass Jaw Joe", 1);
            var moe = new Target("Glass Eye Moe", 10);
            var bo = new Target("Bobo the Clown", 100);
            var hector = new Target("Hector the wise", 450);
            var bat = new Item("Lucille", 1000);
            var saber = new Item("A mysterious device", 1000);
            var monkeyFist = new Item("Monkey Fist", 1920);

            joe.Items.Add(saber);
            moe.Items.Add(bat);
            moe.Items.Add(monkeyFist);

            // relationships 

            joe.NextFighterChoice.Add("right", moe);
            moe.NextFighterChoice.Add("left", joe);

            joe.NextFighterChoice.Add("north", hector);
            hector.NextFighterChoice.Add("south", joe);
            joe.NextFighterChoice.Add("sewer", bo);




            // where do we start?

            _currentTarget = joe;


            // create our player
            Console.Clear();
            System.Console.WriteLine("What is your name brave warrior?");
            var name = Console.ReadLine();
            _player = new Player(name);


        }

    }

}


