namespace nevim
{
    public class Tile
    {
        public bool aktivni;
        public bool selfTile = false;
        public int X { get; set; }
        public int Y { get; set; }
        public int width;
        public int Krok { get; set; }
        public int Vzdalenost { get; set; }
        public int Parametr => Krok + Vzdalenost;
        static public Tile[,] Tiles = new Tile[15, 15];
        static public List<Tile> fronta = new List<Tile>();

        public Tile(int width)
        {
            this.width = width;

        }
        public bool Kolize(Entita entita)
        {
            if (entita == null) return false;
            if (X < entita.width + entita.x_pos
              && X + width > entita.x_pos
              && Y < entita.y_pos + entita.height
              && Y + width > entita.y_pos)
            {
                return true;
            }
            return false;
        }
        public int vypocitejVzdalenost(int cilX, int cilY)
        {
            /*int dx = Math.Abs(cilX - X);
            int dy = Math.Abs(cilY - Y);
            int diagonal = Math.Min(dx, dy);
            int orthogonal = dx + dy - 2 * diagonal;
            return diagonal * 5 + orthogonal * 7;*/

            /*int D = 1;
            double D2 = Math.Sqrt(2);
            float dx = Math.Abs(X - cilX);
            float dy = Math.Abs(Y - cilY);
            return Convert.ToInt32(D * (dx + dy) + (D2 - 2 * D) * Math.Min(dx, dy));*/
            return Math.Abs(cilX - X) + Math.Abs(cilY - Y);
        }
        public int vypocitejKrok(int zdrojX, int zdrojY)
        {
            return vypocitejVzdalenost(zdrojX, zdrojY) / width;
        }
        static public List<Tile> vyberCestu()
        {
            int min;

            if (fronta.Count > 0)
            {
                foreach (Tile tile in Tiles)
                {
                    min = fronta[0].Parametr;

                    if (tile.Parametr > min || tile.aktivni || (tile.Kolize(Entita.FindEnt("chobotnicka")) && tile.aktivni))
                    {
                        fronta.Remove(tile);
                    }
                    else if (tile.Parametr < min && tile.Krok < 2)
                    {
                        fronta[0] = tile;
                    }
                }
            }

            foreach (Tile tile in Tiles)
            {
                if (!tile.aktivni && tile.Krok < 3)
                {
                    fronta.Add(tile);
                }
            }



            return fronta;
        }
    }
}
