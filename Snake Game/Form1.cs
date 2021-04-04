using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        // Snake Defaults
        PictureBox[] snakeParts;
        int snakeSize = 5;
        Point location = new Point(120, 120);
        string direction = "Right";
        bool changingDirection = false;

        //Food Defaults
        PictureBox food = new PictureBox();
        Point foodLocation = new Point(0, 0);


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // In case of user want again when game is over 
            scorePanel.Controls.Clear();
            snakeParts = null;
            scoreLabel.Text = "0";
            snakeSize = 5;
            direction = "Right";
            location = new Point(120, 120);

            //start game
            drawSnake();
            drawFood();

            timer1.Start();

            //Disable some controls
            trackBar1.Enabled = false;
            startButton.Enabled = false;
            nameBox.Enabled = false;

            //Enable Stop button
            stopButton.Enabled = true;


        }

        private void drawSnake()
        {
            snakeParts = new PictureBox[snakeSize];

            //Loop for drawing each snake part one after another
            for (int i = 0; i < snakeSize; i++)
            {
                snakeParts[i] = new PictureBox();
                snakeParts[i].Size = new Size(15, 15);
                snakeParts[i].BackColor = Color.Red;
                snakeParts[i].BorderStyle = BorderStyle.FixedSingle;
                snakeParts[i].Location = new Point(location.X - (15 * i), location.Y);
                gamePanel.Controls.Add(snakeParts[i]);

            }
        }

        private void drawFood()
        {
            Random rnd = new Random();
            int Xrand = rnd.Next(38) * 15;
            int Yrand = rnd.Next(38) * 15;

            bool isOnSnake = true;

            // check if food is on snake body
            while (isOnSnake)
            {
                for(int i = 0; i < snakeSize; i++)
                {
                    if (snakeParts[i].Location == new Point (Xrand, Yrand))
                    {
                        Xrand = rnd.Next(38) * 15;
                        Yrand = rnd.Next(30) * 15;
                    }
                    else
                    {
                        isOnSnake = false;
                    }
                }
            }
            //NOW DRAW FOOD
            if (isOnSnake == false)
            {
                foodLocation = new Point(Xrand, Yrand);
                food.Size = new Size(15, 15);
                food.BackColor = Color.Yellow;
                food.BorderStyle = BorderStyle.FixedSingle;
                food.Location = foodLocation;
                gamePanel.Controls.Add(food);
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gamePanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gamePanel_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Change interval of timer with the value of speed trackbar
            timer1.Interval = 501 - (5 * trackBar1.Value);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move();

        }

        private void move()
        {
            Point point = new Point(0, 0);

            //Loop for moving each part of snake according to direction
            for (int i = 0; i < snakeSize; i++)
            {
                if (i == 0) 
                {
                    point = snakeParts[i].Location;
                    if (direction == "Left")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X - 15, snakeParts[i].Location.Y);
                    }
                    if (direction == "Rigth")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X + 15, snakeParts[i].Location.Y);
                    }
                    if (direction == "Top")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X, snakeParts[i].Location.Y - 15);
                    }
                    if (direction == "Down")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X, snakeParts[i].Location.Y + 15);
                    }
                } 
                else
                    {
                    Point newPoint = snakeParts[i].Location;
                    snakeParts[i].Location = point;
                    point = newPoint;
                    }

            }

        }
            
    }
}
