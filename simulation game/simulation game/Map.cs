using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation_game
{
    class Map
    {
        public string[,] map = new string[20, 20];
        public Unit[] players;
        private int numUnits;
        public Random r = new Random();      //r.Next(1,20);   random number within the array's bounds
        string[] teams = { "A", "B" };

        public Map(int numUnits)
        {
            this.numUnits = numUnits;
            players = new Unit[numUnits];
            WorldBuild();
        }

        public void WorldBuild()
        {
            
            for (int i = 0; i < numUnits; i++)//creates the player types and randomizes their positions
            {
                if (r.Next(2) == 0)
                {
                    players[i] = new Ranged(r.Next(1, 20), r.Next(0, 20), teams[r.Next(2)]);// make a Ranged Boi

                }
                else
                {
                    players[i] = new Melee(r.Next(1, 20), r.Next(0, 20), teams[r.Next(2)]);// make a melee Boi
                }
            }

            UpdateWorld();
        }

        public void UpdateWorld()//update the map of any changes
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    map[x, y] = " o ";
                }
            }

            foreach (Unit playerType in players)
            {
                map[playerType.Xvalue, playerType.Yvalue] =  playerType.Team + playerType.Symbol; //as each unit moves the entire array will need to be displayed so this method will surfise to update the positions of the units on map after they are altered by game engine or something
            }
        }
    }
}
