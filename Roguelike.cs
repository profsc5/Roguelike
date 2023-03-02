using System.Diagnostics;
using System.Numerics;

namespace nevim
{
    public partial class Roguelike : Form
    {
        public static int skore, ulozeneSkore, rychlost = 10, udavatelObtiznosti = 0;
        public static double poskozeni = 1;
        int smer;
        static public Vector2 smerPohybu;
        bool killplayerBool = false;
        bool debugging, pohyb;

        static Image bubak_textura1 = Properties.Resources.bubak1;
        static Image bubak_texutra2 = Properties.Resources.bubak2;
        static Image bubak_textura3 = Properties.Resources.bubak3;
        static Image bubak_textura4 = Properties.Resources.bubak4;

        static Image blok_textura1 = Properties.Resources.blok1;
        static Image blok_textura2 = Properties.Resources.blok2;
        static Image blok_textura3 = Properties.Resources.blok3;
        static Image blok_textura4 = Properties.Resources.blok5;

        static Image hrac_textura = Properties.Resources.hrac;

        //Inicializace hráèe na zaèátku hry
        public Entita e1 = new Entita("player", hrac_textura, 500, 500, 60, 60);

        //Inicializace každé entity- musí se zadávat postupnì, aby se dobøe pøekrývaly     
        AI chobotnicka = new AI("chobotnicka", bubak_textura1, 150, 150, 60, 60);


        public Roguelike()
        {
            InitializeComponent();
            KeyPreview = true;
            DoubleBuffered = true;
            fillTiles();
            GeneraceKosticek();
            GeneraceLokace();
        }
        //Rozdìlíme celou mapu na dílky
        private void fillTiles()
        {
            int tileX = 0;
            int tileY = 0;
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    Tile.Tiles[x, y] = new Tile(60);
                    Tile.Tiles[x, y].X = tileX;
                    Tile.Tiles[x, y].Y = tileY;


                    tileY += Tile.Tiles[x, y].width;
                    if (y == 14)
                    {
                        tileX += Tile.Tiles[x, y].width;
                        tileY = 0;
                    }
                }
            }
        }
        private void spawnBubaku()
        {
            Random rand = new Random();
            int X = rand.Next(10, 700);
            int Y = rand.Next(10, 700);
            Image textura = Entita.vyberTexturu(bubak_textura1, bubak_texutra2, bubak_textura3, bubak_textura4);

            AI priserka = new AI("chobotnicka", textura, X, Y, 60, 60);
            priserka.zivoty += udavatelObtiznosti;


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
            foreach (strela s in strela.strelaList)
            {
                graphics.FillEllipse(Brushes.Black, s.X, s.Y, 5, 5);
            }

            //
            //DEBUGGING
            //
            if (debugging)
            {
                graphics.DrawRectangle(Pens.Green, smerPohybu.X, smerPohybu.Y, 5, 5); //Vektor pohybu
                foreach (Tile tile in Tile.Tiles)
                {
                    graphics.DrawRectangle(Pens.Black, tile.X, tile.Y, tile.width, tile.width);
                    if (tile.aktivni)
                    {
                        graphics.FillRectangle(Brushes.Green, tile.X, tile.Y, tile.width, tile.width); //Aktivni dilky
                    }
                    if (tile.vypocitejVzdalenost(e1.x_pos, e1.y_pos) > 300)
                    {
                        graphics.FillEllipse(Brushes.Blue, tile.X, tile.Y, tile.width / 2, tile.width / 2); //Vzdalene dily
                    }
                    else
                    {
                        graphics.FillEllipse(Brushes.Yellow, tile.X, tile.Y, tile.width / 2, tile.width / 2);//Blizke dily
                    }

                    //graphics.DrawString(tile.Parametr.ToString(), Font, Brushes.Black, tile.X, tile.Y);
                }
                foreach (Entita ent in Entita.entitaList)
                {
                    if (ent.username == "chobotnicka")
                    {
                        graphics.FillEllipse(Brushes.Black, ent.x_pos, ent.y_pos, ent.width, ent.height); // Vsechny priserky
                    }
                }
                foreach (AI ai in AI.vsechnyPriserky)
                {
                    if (ai.dalsiKrok != null)
                    {
                        graphics.FillRectangle(Brushes.Brown, ai.dalsiKrok.X, ai.dalsiKrok.Y, ai.dalsiKrok.width, ai.dalsiKrok.width);// Dalsi krok pathfindingu
                    }
                    foreach (Tile tile in ai.fronta)
                    {
                        graphics.DrawString(tile.Krok.ToString(), Font, Brushes.Black, tile.X, tile.Y); //Krok kazdeho dilku
                    }

                }
                graphics.DrawLine(Pens.Red, new Point(chobotnicka.x_pos + chobotnicka.width / 2, chobotnicka.y_pos + chobotnicka.height / 2), new Point(e1.x_pos + e1.width / 2, e1.y_pos + e1.height / 2)); // Vzdusna cara od priserky ke hraci

            }

        }
        private void GeneraceKosticek()
        {
            Random rand = new Random();
            foreach (Tile t in Tile.Tiles)
            {
                if (rand.Next(0, 10) == 2)
                {
                    if (t.vypocitejVzdalenost(e1.x_pos, e1.y_pos) > 120 && t.vypocitejVzdalenost(chobotnicka.x_pos, chobotnicka.y_pos) > 120)
                    {
                        if (t.X > 40 && t.Y > 40 && t.X < 600 && t.Y < 600)
                        {
                            Image textura = Entita.vyberTexturu(blok_textura4, blok_textura3, blok_textura2, blok_textura1);
                            new Entita("tile", textura, t.X, t.Y, 60, 60);

                            t.aktivni = true;
                        }
                    }
                }
            }
        }

        private void GeneraceLokace()
        {
            if (PohybMapy())
            {
                switch (smer)
                {
                    case 1:
                        e1.x_pos = 5;
                        break;
                    case 2:
                        e1.x_pos = Width - 24;
                        break;
                    case 3:
                        e1.y_pos = 5;
                        break;
                    case 4:
                        e1.y_pos = Height - 68;
                        break;
                }
                foreach (Tile tile in Tile.Tiles)
                {
                    tile.aktivni = false;
                }

                for (int x = 0; x < Entita.entitaList.Count; x++)
                {
                    if (Entita.entitaList[x].username == "tile")
                    {
                        Entita.entitaList.RemoveAt(x);
                    }
                }


                udavatelObtiznosti++;
                for (int x = 0; x <= obtiznost(); x++)
                {
                    spawnBubaku();
                }
                GeneraceKosticek();
            }
        }
        private int obtiznost()
        {
            Random rand = new Random();
            float multiplikator = rand.Next(0, 11);
            return Convert.ToInt32(Math.Ceiling(udavatelObtiznosti * (multiplikator / 10 + 1)));

        }

        //Pøesuneme panáèka pokaždé, když je na kraji mapy
        //- vygeneruje se nová èást mapy -
        //!! musí se ukládat pozice jednotlivých textur do array
        private bool PohybMapy()
        {
            if (AI.pocetPriserek < 1)
            {
                if (e1.x_pos > Width - 24)
                {
                    smer = 1;
                    return true;
                }
                else if (e1.x_pos < 10)
                {
                    smer = 2;
                    return true;

                }
                else if (e1.y_pos > Height - 68)
                {
                    smer = 3;
                    return true;

                }
                else if (e1.y_pos < 10)
                {
                    smer = 4;
                    return true;

                }
                return false;
            }
            else return false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D || e.KeyCode == Keys.S || e.KeyCode == Keys.W) { pohyb = false; }

        }



        //Kontrola vstupu
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            smerPohybu = Vector2.Zero;
            smerPohybu = new Vector2(e1.x_pos + 30, e1.y_pos + 30);
            if (e.KeyCode == Keys.A)
            {
                smerPohybu.X += rychlost;

            }
            if (e.KeyCode == Keys.D)
            {
                smerPohybu.X -= rychlost;

            }
            if (e.KeyCode == Keys.S)
            {
                smerPohybu.Y -= rychlost;


            }
            if (e.KeyData == Keys.W)
            {
                smerPohybu.Y += rychlost;

            }

            pohyb = true;

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
                StreamWriter strW = new StreamWriter("skore.txt", true);

                strW.Write(skore.ToString());

                strW.Close();

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

            foreach (AI en in AI.vsechnyPriserky)
            {
                foreach (Tile t in Tile.Tiles)
                {
                    t.Vzdalenost = t.vypocitejVzdalenost(Entita.FindEnt("player").x_pos, Entita.FindEnt("player").y_pos);
                    t.Krok = t.vypocitejKrok(en.x_pos, en.y_pos);
                }
                en.najdiCestu();

                if (en.KillPlayer())
                {
                    killplayerBool = true;
                    timer1.Enabled = false;

                    smrt();
                }
            }


            if (pohyb)
            {
                Vector2 uhel = Vector2.Normalize(new Vector2(e1.x_pos + 30 - smerPohybu.X, e1.y_pos + 30 - smerPohybu.Y));
                e1.x_pos += (int)Math.Min(int.MaxValue, uhel.X * rychlost);
                e1.y_pos += (int)Math.Min(int.MaxValue, uhel.Y * rychlost);
            }

            for (int x = 0; x < strela.strelaList.Count; x++)
            {
                if (strela.strelaList[x].kolider != null)
                {
                    strela.strelaList[x].kolider.zivoty -= poskozeni;
                    Debug.WriteLine(strela.strelaList[x].kolider.zivoty);
                    if (strela.strelaList[x].kolider.zivoty < 1)
                    {

                        zabijPriserku(strela.strelaList[x].kolider);

                    }
                    strela.strelaList.RemoveAt(x);
                }

            }

            if (PohybMapy())
            {
                GeneraceLokace();
            }
            e1.Kolize();
            Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                debugging = true;
            else
                debugging = false;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            new strela(e1.x_pos, e1.y_pos, e.X, e.Y);

        }
        public void zabijPriserku(Entita priserka)
        {
            if (AI.pocetPriserek > 0)
            {
                Entita.entitaList.Remove(priserka);
                for (int x = 0; x < AI.vsechnyPriserky.Count(); x++)
                {
                    if (AI.vsechnyPriserky[x].x_pos == priserka.x_pos && AI.vsechnyPriserky[x].y_pos == priserka.y_pos)
                    {
                        AI.vsechnyPriserky.Remove(AI.vsechnyPriserky[x]);
                    }
                }
                AI.pocetPriserek--;
                skore++;
                label2.Text = skore.ToString();
            }
        }
    }
}