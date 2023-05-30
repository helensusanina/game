using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        System.Media.SoundPlayer startSound = new System.Media.SoundPlayer(@"C:\Windows\Media\chord.wav");
        System.Media.SoundPlayer endSound = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");
        bool goLeft, goRight, goUp, goDown, youWin;
        bool goLeft2, goRight2, goUp2, goDown2, youWin2;
        int speed = 10;
        public Form3()
        {
            InitializeComponent();
            movetostart();
            movetostart2();
            moveTimer.Tick += new EventHandler(MoveTimerEvent);
            moveTimer.Start();
        }
        private void Labyrinth_MouseEnter(object sender, EventArgs e)
        {
            movetostart();
        }
        private void movetostart()
        {
            Console.WriteLine("Start1");
            startSound.Play();
            Point startingpoint = panel1.Location;
            startingpoint.Offset(0, 0);
            Point start = new Point(0, 0);
            player11.Location = start;
        }
        private void movetostart2()
        {
            Console.WriteLine("Start2");
            startSound.Play();
            Point start = new Point(100, 0);
            player22.Location = start;
        }

        private void checkFinish()
        {
            if (youWin)
            {
                goLeft = goRight = goUp = goDown = youWin = false;
                goLeft2 = goRight2 = goUp2 = goDown2 = youWin2 = false;
                endSound.Play();
                MessageBox.Show("Player1 Win");
                Close();
            }

        }
        private void checkFinish2()
        {
            if (youWin2)
            {
                goLeft = goRight = goUp = goDown = youWin = false;
                goLeft2 = goRight2 = goUp2 = goDown2 = youWin2 = false;
                endSound.Play();
                MessageBox.Show("Player2 Win");
                Close();

            }

        }
        private void isKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;

            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }

            if (e.KeyCode == Keys.A)
            {
                goLeft2 = true;
            }

            if (e.KeyCode == Keys.D)
            {
                goRight2 = true;

            }

            if (e.KeyCode == Keys.W)
            {
                goUp2 = true;
            }

            if (e.KeyCode == Keys.S)
            {
                goDown2 = true;
            }
        }

        private void isKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;

            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.A)
            {
                goLeft2 = false;
            }

            if (e.KeyCode == Keys.D)
            {
                goRight2 = false;

            }

            if (e.KeyCode == Keys.W)
            {
                goUp2 = false;
            }

            if (e.KeyCode == Keys.S)
            {
                goDown2 = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void MovePlayer()
        {
            if (goLeft == true && player11.Left > 0)
            {
                player11.Left -= speed;
            }

            if (goRight == true && player11.Left + player11.Width < panel1.Width)
            {
                player11.Left += speed;

            }

            if (goUp == true && player11.Top > 0)
            {
                player11.Top = player11.Top - speed;
            }

            if (goDown == true && player11.Top + player11.Height < panel1.Height)
            {
                player11.Top += speed;

            }
        }

        private bool CollidesWithWall(PictureBox control)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c != player11 && c != player22 && c != Finish && c.Bounds.IntersectsWith(control.Bounds))
                    return true;
                if (c != player11 && c != player22 && c == Finish && c.Bounds.IntersectsWith(control.Bounds))
                {
                    if (control == player11) { youWin = true; }
                    if (control == player22) { youWin2 = true; }
                    return true;
                }

            }
            return false;
        }

        private void CheckForCollision()
        {
            if (CollidesWithWall(player11))
            {
                movetostart();
            }
            if (CollidesWithWall(player22))
            {
                movetostart2();
            }
        }

        //----------------------------------------------------------------------------

        private void MovePlayer2()
        {
            if (goLeft2 == true && player22.Left > 0)
            {
                player22.Left -= speed;
            }

            if (goRight2 == true && player22.Left + player22.Width < panel1.Width)
            {
                player22.Left += speed;

            }

            if (goUp2 == true && player22.Top > 0)
            {
                player22.Top = player22.Top - speed;
            }

            if (goDown2 == true && player22.Top + player22.Height < panel1.Height)
            {
                player22.Top += speed;

            }
        }
        private void MoveTimerEvent(object sender, EventArgs e)
        {
            MovePlayer();
            MovePlayer2();
            CheckForCollision();
            checkFinish();
            checkFinish2();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Finish_Click(object sender, EventArgs e)
        {

        }
    }
}
