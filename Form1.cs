namespace nevim
{
    public partial class Form1 : Form
    {
        public static int skore,poskozeni,rychlost = 10;
        int smer;
        bool collision = false;
        bool buttonClick = false;
        bool killplayerBool = false;
        bool debugging;


        static Image enemy_textura = Properties.Resources.chobotnicka1;
        static Image e1_textura = Properties.Resources.e1;
        static Image e2_textura = Properties.Resources.e2;
        static Image domek_textura = Properties.Resources.dom;
        static Image kostel_textura = Properties.Resources.kostel;
        static Image blok_textura = Properties.Resources.blok;

        //Entita domecek = new Entita("domecek", domek_textura, 400, 400, 200, 180);

        //Inicializace hráèe na zaèátku hry
        public Entita e1 = new Entita("player", e1_textura, 500, 500, 60, 79);

        //Inicializace každé entity- musí se zadávat postupnì, aby se dobøe pøekrývaly

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
            BackgroundImage = Properties.Resources.background;
            fillTiles();
            GeneraceLokace();
    
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

                    if (tile.aktivni)
                    {
                        graphics.FillRectangle(Brushes.Green, tile.X, tile.Y, 80, 80);
                    }



                    if (tile.vypocitejVzdalenost(e1.x_pos, e1.y_pos) > 300)
                    {
                        graphics.FillEllipse(Brushes.Blue, tile.X, tile.Y, 40, 40);
                    }
                    else
                    {
                        graphics.FillEllipse(Brushes.Yellow, tile.X, tile.Y, 40, 40);
                    }
                    if (Tile.fronta.Contains(tile))
                    {
                        graphics.DrawString(tile.Krok.ToString(), Font, Brushes.Black, tile.X, tile.Y);
                    }
                    //graphics.DrawString(tile.Parametr.ToString(), Font, Brushes.Black, tile.X, tile.Y);
                }
                graphics.FillRectangle(Brushes.Brown, Tile.fronta[0].X, Tile.fronta[0].Y, 80, 80);


                graphics.DrawLine(Pens.Red, new Point(chobotnicka.x_pos + chobotnicka.width / 2, chobotnicka.y_pos + chobotnicka.height / 2), new Point(e1.x_pos + e1.width / 2, e1.y_pos + e1.height / 2));
            }
        }
        private void GeneraceKosticek()
        {
            Random rand = new Random();

            foreach (Tile t in Tile.Tiles)
            {
                if (rand.Next(0, 10) == 2)
                {
                    if(t.vypocitejVzdalenost(e1.x_pos,e1.y_pos) > 80 && t.vypocitejVzdalenost(chobotnicka.x_pos, chobotnicka.y_pos) > 80)
                    {
                        new Entita("tile", blok_textura, t.X, t.Y, 75, 75);


                        t.aktivni = true;
                    }
           
                }
            }
        }
        private void GeneraceLokace()
        {
            if (Entita.generatedTiles.Count > 0)
            {
                Entita.generatedTiles.Add("NULL");


            }
            GeneraceKosticek();
            foreach (Entita ent in Entita.entitaList)
            {
                
                if (ent.username == "tile")
                {
                    Entita.generatedTiles.Add(ent.username);
                    
                }
            }
          
            if (PohybMapy())
            {


                foreach (string s in Entita.generatedTiles)
                {
                    if (s != "NULL")
                    {
                        Entita.entitaList.Remove(Entita.FindEnt(s));
                        continue;
                    }
                    else
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
                        BackgroundImage = Properties.Resources.background;
                        GeneraceKosticek();
                        chobotnicka = new AI("chobotnicka", enemy_textura, 50, 50, 100, 100);

                    }
                    return;
                }
            }
        }

        //Pøesuneme panáèka pokaždé, když je na kraji mapy
        //- vygeneruje se nová èást mapy -
        //!! musí se ukládat pozice jednotlivých textur do array
        private bool PohybMapy()
        {
            if (AI.pocetPriserek == 0)
            {
                BackgroundImage = null;
                BackColor = Color.White;
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

        //Kontrola vstupu
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A:
                    if (!collision || collision && e1.direction == 1)
                    {
                        e1.x_pos -= rychlost;
                    }

                    break;
                case Keys.D:
                    if (!collision || collision && e1.direction == 2)
                    {
                        e1.x_pos += rychlost;
                    }
                  
                    break;
                case Keys.W:
                    if (!collision || collision && e1.direction == 3)
                    {
                        e1.y_pos -= rychlost;
                    }
                  
                    break;
                case Keys.S:
                    if (!collision || collision && e1.direction == 4)
                    {
                        e1.y_pos += rychlost;
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


            if (PohybMapy())
            {
                GeneraceLokace();
            }
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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Entita.entitaList.Remove(Entita.FindEnt("chobotnicka"));
            AI.pocetPriserek--;
            skore++;
            label2.Text = "Skóré: " + skore.ToString();
        }
        //




        //DESTRUKTIVNI BUDOVY - JEDEN HIT, DVA, TRI, SMRT - MENI SE TEXTURA

    }
}