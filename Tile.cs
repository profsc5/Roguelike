using System.Diagnostics;

namespace nevim
{
    public class Tile
    {
        public bool selfTile = false;
        public int X { get; set; }
        public int Y { get; set; }
        public int Krok { get; set; }
        public int Vzdalenost { get; set; }
        public int Parametr => Krok + Vzdalenost;
        static public Tile[,] Tiles = new Tile[10, 10];

        static public List<Tile> fronta = new List<Tile>();

        private bool Kolize(Entita entita)
        {
            if (X < entita.width + entita.x_pos
              && X + 80 > entita.x_pos
              && Y < entita.y_pos + entita.height
              && Y + 80 > entita.y_pos)
            {
                return true;
            }
            return false;
        }

        public bool Active()
        {
            foreach (Entita entita in Entita.entitaList)
            {
                if (Kolize(entita))
                {
                    if (entita.username == "chobotnicka" )
                    {
                        selfTile = true;
                    }
                    return true;
                }
                else
                {
                    selfTile = false;
                }
            }
            return false;
        }
        public int vypocitejVzdalenost(int cilX, int cilY)
        {
            return Math.Abs(cilX - X) + Math.Abs(cilY - Y);
        }
        public int vypocitejKrok(int zdrojX, int zdrojY)
        {
            if (!selfTile && !Active())
            {
                return vypocitejVzdalenost(zdrojX, zdrojY) / 80;
            }
            return 0;
        }
        static public List<Tile> vyberCestu()
        {
            int min = 0;
            foreach (Tile t in Tiles)
            {
                if (!t.selfTile&& !t.Active())
                {
                    fronta.Add(t);
                }
               

            }
            foreach (Tile tile in Tiles)
            {
                min = fronta[0].Parametr;

                if (tile.Parametr < min )
                {
                    fronta[0] = tile;
                }
                else if(tile.Parametr> min)
                {
                    fronta.Remove(tile);
                }


            }

            return fronta;
        }

    }

}
