﻿namespace nevim
{
    public partial class Menu : Form
    {

        Image pozadi1 = Properties.Resources.back1;
        Image pozadi2 = Properties.Resources.back2;
        Image pozadi3 = Properties.Resources.back3;
        int n = 0;
        public Menu()
        {

            InitializeComponent();
            Width = 800;
            Height = 800;
            BackgroundImage = Properties.Resources.back1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Roguelike fr = new Roguelike();
            Hide();
            fr.ShowDialog();
            Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (n == 3)
            {
                n = 0;
            }
            switch (n)
            {
                case 0: BackgroundImage = pozadi1; break;
                case 1: BackgroundImage = pozadi2; break;
                case 2: BackgroundImage = pozadi3; break;
            }
            n++;

        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            kp.DrawImage(Properties.Resources.nadpisR, 55, 28, 647, 121);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Obchod f = new Obchod();
            f.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
