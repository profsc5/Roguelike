using System.Diagnostics;

namespace nevim
{
    public partial class Form1 : Form
    {
        bool collision = false;
        bool buttonClick = false;
        bool killplayerBool = false;
        bool debugging;


        static Image enemy_textura = Properties.Resources.chobotnicka1;
        static Image e1_textura = Properties.Resources.e1;
        static Image e2_textura = Properties.Resources.e2;
        static Image domek_textura = Properties.Resources.dom;
        static Image kostel_textura = Properties.Resources.kostel;


        //Inicializace hráèe na zaèátku hry
        public Entita e1 = new Entita("player", e1_textura, 2000000, 500, 80, 99);

        //Inicializace každé entity- musí se zadávat postupnì, aby se dobøe pøekrývaly
        Entita domecek = new Entita("domek1", domek_textura, 400, 400, 200, 180);
        /*Entita domek = new Entita("domecek1", domek_textura, new Random().Next(50, 850), new Random().Next(50, 700), 200, 180);
        Entita kostel = new Entita("kostel1", kostel_textura, new Random().Next(50, 850), new Random().Next(50, 700), 300, 300);
        Entita domek2 = new Entita("domecek2", domek_textura, new Random().Next(50, 850), new Random().Next(50, 700), 200, 180);*/
        AI chobotnicka = new AI("chobotnicka", enemy_textura, 150, 150, 100, 100);
        //Entita e2 = new Entita("e2", e2_textura, 300, 300, 80, 80);

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            DoubleBuffered = true;
            fillTiles();
        }
        //Rozdìlíme celou mapu na dílky
        private void fillTiles()
        {
            int tileX = 0;
            int tileY = 0;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Tile.Tiles[x, y] = new Tile();
                    Tile.Tiles[x, y].X = tileX;
                    Tile.Tiles[x, y].Y = tileY;

                    tileY += 80;
                    if (y == 9)
                    {
                        tileX += 80;
                        tileY = 0;
                    }
                }
            }

        }

        //Vykreslování textur
        //Pohyb objektù pøes zmìnu souøadnic na každý refresh()
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (Entita ent in Entita.entitaList)
            {
                graphics.DrawImage(ent.textura, ent.x_pos, ent.y_pos, ent.width, ent.height);
            }
            //
            //DEBUGGING
            //
            if (debugging)
            {

                foreach (Tile tile in Tile.Tiles)
                {
                    
                    graphics.DrawRectangle(Pens.Black, tile.X, tile.Y, 80, 80);
                    if (tile.Active())
                    {
                        if (!tile.selfTile)
                        {
                            graphics.FillRectangle(Brushes.Green, tile.X, tile.Y, 80, 80);
                        }
                        else if (tile.selfTile)
                        {
                            graphics.FillRectangle(Brushes.Red, tile.X, tile.Y, 80, 80);
                        }
                    }
                    graphics.FillRectangle(Brushes.Brown, Tile.fronta[0].X, Tile.fronta[0].Y, 80, 80);               
                    if (tile.vypocitejVzdalenost(e1.x_pos, e1.y_pos) > 300)
                    {
                        graphics.FillEllipse(Brushes.Blue, tile.X, tile.Y, 40, 40);
                    }
                    else
                    {
                        graphics.FillEllipse(Brushes.Yellow, tile.X, tile.Y, 40, 40);
                    }
                    graphics.DrawString(tile.Krok.ToString(), Font, Brushes.Black, tile.X, tile.Y);
                }
                graphics.DrawLine(Pens.Red, new Point(chobotnicka.x_pos + chobotnicka.width / 2, chobotnicka.y_pos + chobotnicka.height / 2), new Point(e1.x_pos + e1.width / 2, e1.y_pos + e1.height / 2));
            }
        }

        private void GeneraceLokace()
        {

        }

        //Pøesuneme panáèka pokaždé, když je na kraji mapy
        //- vygeneruje se nová èást mapy -
        //!! musí se ukládat pozice jednotlivých textur do array
        private void PohybMapy()
        {
            if (e1.x_pos > Width - 24)
            {
                e1.x_pos = 5;
            }
            else if (e1.x_pos < 10)
            {
                e1.x_pos = Width - 24;
            }
            else if (e1.y_pos > Height - 68)
            {
                e1.y_pos = 5;
            }
            else if (e1.y_pos < 10)
            {
                e1.y_pos = Height - 68;
            }

        }

        //Kontrola vstupu
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A:
                    if (!collision || collision && e1.direction == 1)
                    {
                        e1.x_pos -= 15;
                    }

                    break;
                case Keys.D:
                    if (!collision || collision && e1.direction == 2)
                    {
                        e1.x_pos += 15;
                    }

                    break;
                case Keys.W:
                    if (!collision || collision && e1.direction == 3)
                    {
                        e1.y_pos -= 15;
                    }

                    break;
                case Keys.S:
                    if (!collision || collision && e1.direction == 4)
                    {
                        e1.y_pos += 15;
                    }

                    break;
            }


            //
            //Restart
            if (e.KeyCode == Keys.R)
            {
                Application.Restart();
            }
        }
        //SMRT 
        private void smrt()
        {
            if (killplayerBool == true)
            {
                DialogResult m = MessageBox.Show("Prohrál jsi :( \n\nChceš to zkusit znovu?", "Prohra :(", MessageBoxButtons.YesNo);
                if (m == DialogResult.Yes)
                {
                    Application.Restart();
                    return;
                }
                else if (m == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            chobotnicka.najdiCestu();
            Debug.Write(Tile.fronta.Count);
            //Updates na stavy
            if (e1.Kolize())
            {
                collision = true;
            }
            else if (!e1.Kolize())
            {
                collision = false;
            }
            if (chobotnicka.KillPlayer())
            {
                killplayerBool = true;
                timer1.Enabled = false;
                smrt();
            }
            //Vypocty pro kazde policko
            foreach (Tile t in Tile.Tiles)
            {
                t.Vzdalenost = t.vypocitejVzdalenost(e1.x_pos, e1.y_pos);
                t.Krok = t.vypocitejKrok(chobotnicka.x_pos, chobotnicka.y_pos);
            }


            PohybMapy();
            Refresh();


        }

        //Vytváøení objektù pomocí kliknutí na canvas
        private void button1_Click(object sender, EventArgs e)
        {
            buttonClick = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (buttonClick)
            {
                new Entita("domek" + new Random().Next(0, 50), domek_textura, e.Location.X - 100, e.Location.Y - 90, 200, 180);
            }
            buttonClick = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                debugging = true;
            else
                debugging = false;

        }
        //




        //DESTRUKTIVNI BUDOVY - JEDEN HIT, DVA, TRI, SMRT - MENI SE TEXTURA

    }
}