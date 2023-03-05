using System.Diagnostics;
using System.Numerics;

namespace nevim
{
    public partial class Roguelike : Form
    {
        public static int skore, ulozeneSkore, rychlost = 10, udavatelObtiznosti = 0;
        public static double poskozeni = 1;
        int smer;
        bool colize = false;
        bool killplayerBool = false;
        bool debugging = true, pohyb;

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
        //AI chobotnicka = new AI("chobotnicka", bubak_textura1, 150, 150, 60, 60);


        public Roguelike()
        {
            InitializeComponent();
            KeyPreview = true;
            DoubleBuffered = true;
            fillTiles();
            GeneraceKosticek();
            GeneraceLokace();
            spawnBubaku();
        }
        //Rozdìlíme celou mapu na dílky
        private void fillTiles()
        {
            int tileX = 0;
            int tileY = 0;
            int y = 0;
            for (int x = 0; x < 169; x++)
            {
                Tile.Tiles[x] = new Tile(60);
                Tile.Tiles[x].X = tileX;
                Tile.Tiles[x].Y = tileY;
                y += 1;
                tileY += Tile.Tiles[x].width;
                if (y == 13)
                {
                    tileX += Tile.Tiles[x].width;
                    tileY = 0;
                    y = 0;
                }

            }
        }
        private void spawnBubaku()
        {
            Random rand = new Random();
            int randTile1 = rand.Next(Tile.Tiles.Count);
            int X = 0, Y = 0;
            Image textura = Entita.vyberTexturu(bubak_textura1, bubak_texutra2, bubak_textura3, bubak_textura4);

            if (Tile.Tiles[randTile1].aktivni)
            {
                return;
            }
            X = Tile.Tiles[randTile1].X;
            Y = Tile.Tiles[randTile1].Y;


            AI priserka = new AI("chobotnicka", textura, X, Y, 60, 60);
            priserka.zivoty += udavatelObtiznosti;
            priserka.startKrok = Tile.Tiles[randTile1];
            priserka.vyberCestu();

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
                graphics.DrawRectangle(Pens.Green, e1.smerPohybu.X, e1.smerPohybu.Y, 5, 5); //Vektor pohybu
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
                    foreach (Tile tile in ai.AITiles)
                    {
                        graphics.DrawRectangle(Pens.Orange, tile.X, tile.Y, tile.width, tile.width);
                        graphics.DrawString(tile.Krok.ToString(), Font, Brushes.Black, tile.X, tile.Y);
                        graphics.DrawString(tile.Parametr.ToString(), Font, Brushes.Black, tile.X, tile.Y + 40);//Krok kazdeho dilku
                    }
                    foreach (Tile tile in ai.uzavrenyList)
                    {
                        graphics.DrawRectangle(Pens.Red, tile.X, tile.Y, tile.width, tile.width);

                    }
                    if (ai.uzavrenyList.Count > 0)
                    {
                        graphics.FillRectangle(Brushes.Green, ai.uzavrenyList[0].X, ai.uzavrenyList[0].Y, 60, 60);
                    }


                }

                //graphics.DrawLine(Pens.Red, new Point(chobotnicka.x_pos + chobotnicka.width / 2, chobotnicka.y_pos + chobotnicka.height / 2), new Point(e1.x_pos + e1.width / 2, e1.y_pos + e1.height / 2)); // Vzdusna cara od priserky ke hraci

            }

        }
        private void GeneraceKosticek()
        {
            Random rand = new Random();
            int vzdalenost = 0;
            foreach (Tile t in Tile.Tiles)
            {
                foreach (AI ai in AI.vsechnyPriserky)
                {
                    vzdalenost = t.vypocitejVzdalenost(ai.x_pos, ai.y_pos);
                }
                if (rand.Next(0, 10) == 2)
                {
                    //if (t.vypocitejVzdalenost(e1.x_pos, e1.y_pos) >60&& vzdalenost > 60)
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
            e1.smerPohybu = Vector2.Zero;
            e1.smerPohybu = new Vector2(e1.x_pos + 30, e1.y_pos + 30);
            if (e.KeyCode == Keys.A)
            {
                e1.smerPohybu.X += rychlost;

            }
            if (e.KeyCode == Keys.D)
            {
                e1.smerPohybu.X -= rychlost;

            }
            if (e.KeyCode == Keys.S)
            {
                e1.smerPohybu.Y -= rychlost;


            }
            if (e.KeyData == Keys.W)
            {
                e1.smerPohybu.Y += rychlost;

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

        private void Roguelike_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (AI en in AI.vsechnyPriserky)
            {

                Tile staryKrok = en.uzavrenyList.First();
                int staryKrokX = staryKrok.X;
                int staryKrokY = staryKrok.Y;

                for (int x = 0; x < en.uzavrenyList.Count; x++)
                {
                    en.uzavrenyList.RemoveAt(x);
                }
                for (int x = 0; x < en.AITiles.Count; x++)
                {
                    en.AITiles.RemoveAt(x);

                }

                en.startKrok.X = staryKrokX;
                en.startKrok.Y = staryKrokY;

                Debug.WriteLine(Tile.Tiles.Count);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (AI en in AI.vsechnyPriserky)
            {
                for (int x = 0; x < en.uzavrenyList.Count; x++)
                {
                    if (en.uzavrenyList[x].X == en.x_pos && en.uzavrenyList[x].Y == en.y_pos)
                    {
                        en.uzavrenyList.Remove(en.uzavrenyList[x]);
                    }
                }
                if (!en.startKrok.Kolize(e1))
                { en.vyberCestu(); }


                if (en.uzavrenyList.Count > 0)
                {
                    en.najdiCestu();
                }


                if (en.Kolize() && en.kolider == "player")
                {
                    killplayerBool = true;
                    timer1.Enabled = false;

                    smrt();
                }
            }


            if (pohyb)
            {

                e1.Kolize();
                Vector2 uhel = Vector2.Normalize(new Vector2(e1.x_pos + 30 - e1.smerPohybu.X, e1.y_pos + 30 - e1.smerPohybu.Y));
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