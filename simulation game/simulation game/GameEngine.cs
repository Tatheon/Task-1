using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation_game
{
    class GameEngine
    {
        private int rounds;//after all units have had their turn this is incremented
        public Map world = new Map(10);
        public bool gameOver = false;
        string winningFaction;

        public void Run()
        {
            foreach(Unit unit in world.players)
            {
                if (unit.IsDead) { continue; }//if the unit is dead, dont waist your bread.....

                unit.NearestEnemy(world.players);//find a unit

                if (unit.ClosestUnit == null)
                {
                    gameOver = true;
                    winningFaction = unit.Team;
                    world.UpdateWorld();
                    return;
                }

                double healthPercent = unit.Health / unit.MaxHealth * 100;
                if (healthPercent <= 25)//if the unit is low on health it should run away
                {
                    unit.RandomMove();
                }
                else if (unit.WithinRange())//if the closest unit is in attack range, attack it
                {
                    unit.Attack(unit.ClosestUnit);
                }
                else
                {
                    unit.Move();//if they cant reach their enemy then they must move closer to their enemy.
                }

                world.UpdateWorld();
                
            }
            rounds++;
        }

        public GameEngine()
        {

        }

        public string Rounds
        {
            get { return "Rounds " + rounds; }
        }

        public string WinningTeam
        {
            get { return winningFaction; }
        }
    }
}
