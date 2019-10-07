using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation_game
{
    class Melee:Unit
    {
        public Melee(int x, int y, string team, int health = 20, int speed = 1, int attack = 4, int range = 1, string symbol = " !  ") : base(x, y, health, speed, attack, range, team, symbol)
        {
            base.x = x;
            base.y = y;
            base.health = health;
            base.maxHealth = health;
            base.speed = speed;
            base.attack = attack;
            base.attackRange = range;
            base.team = team;
            base.symbol = symbol;
        }



        public override string ToString()
        {
            if (Health <= 0)
            {
                return "Melee: DEAD";//if dead
            }
            else
            {
                return "Melee unit: \n Health: " + Health + "\n Range: " + attackRange + "\n Speed: " + speed + "\n Team: " + team;//if alive show stats
            }
        }
    }
}
