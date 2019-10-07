using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation_game
{
    public partial class Form1 : Form
    {
        GameEngine game = new GameEngine();//create the engine
        Timer round = new Timer();
        public Form1()
        {
            InitializeComponent();

            DrawMap();
            ShowUnits();
            initTimer();//creates timer

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void initTimer()
        {
            round.Interval = 1500;
            round.Tick += TimerTickHandeler;
        }

        void TimerTickHandeler(object sender, EventArgs e)
        {
            game.Run();//game logic will do their tasks
            game.world.UpdateWorld();//update map
            DrawMap();//show the map
            ShowUnits();

            if (game.gameOver)
            {
                round.Stop();
                lblMap.Text += "Winning team is" + game.WinningTeam;
            }

        }

        public void DrawMap()//display map
        {
            lblMap.Text = "";
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    lblMap.Text += game.world.map[x, y];
                }
                lblMap.Text += "\n";
            }
        }

        public void ShowUnits()//display units stats
        {
            lblPlayerStats.Text = game.Rounds + "\n";
            foreach (Unit unit in game.world.players)
            {
                lblPlayerStats.Text += unit.ToString() + "\n \n";
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
             round.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            round.Start();
        }
    }
}
