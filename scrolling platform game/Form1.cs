using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scrolling_platform_game
{
    public partial class sidescrollingplatformgame : Form
    {
        bool goleft = false;
        bool goright = false;
        bool jumping = false;
        bool hasKey = false;

        int jumpSpeed = 10;
        int force = 8;
        int score = 0;

        int playerspeed = 18;
        int backleft = 8;

        public sidescrollingplatformgame()
        {
            InitializeComponent();
        }

        private void sidescrollingplatformgame_Load(object sender, EventArgs e)
        {

        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            player.Top += jumpSpeed;

            player.Refresh();

            if(jumping && force < 0)
            {
                jumping = false;
            }

            if(jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if(goleft && player.Left >100)
            {
                player.Left -= playerspeed;
            }

            if(goright && background.Left > -1353)
            {
                background.Left -= backleft;

                foreach(Control x in this.Controls)
                {
                    if(x is PictureBox&& x.Tag == "Platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
                    {
                        x.Left -= backleft;
                    }
                }
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Left)
            {
                goleft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if(e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = false;
            }
        }
    }
}
