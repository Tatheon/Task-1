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
                if (unit.IsDead) { continue; }

                unit.NearestEnemy(world.players);

                if(unit.ClosestUnit == null)
                {
                    gameOver = true;
                    winningFaction = unit.Team;
                    world.UpdateWorld();
                    return;
                }

                double healthPercent = unit.Health / unit.MaxHealth * 100;
                if (healthPercent <= 25)
                {
                    unit.RandomMove();
                }
                else if (unit.WithinRange())
                {
                    unit.Attack(unit.ClosestUnit);
                }
                else
                {
                    unit.Move();
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
