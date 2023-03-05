namespace nevim
{
    public class Tile
    {
        public int multiplikator;
        public bool aktivni;
        public bool selfTile = false;
        public int X { get; set; }
        public int Y { get; set; }
        public int width;
        public int Krok { get; set; }
        public int Vzdalenost { get; set; }
        public int Parametr;
        public Tile parent;
        static public List<Tile> Tiles = new List<Tile>();


        public Tile(int width)
        {
            this.width = width;
            Tiles.Add(this);

        }
        public bool Kolize(Entita entita)
        {
            if (entita == null) return false;
            if (X < entita.width + entita.x_pos
              && X + width > entita.x_pos
              && Y < entita.y_pos + entita.height
              && Y + width > entita.y_pos)
            {
                string kolider = entita.username;
                return true;
            }
            return false;
        }
        public int vypocitejVzdalenost(int cilX, int cilY)
        {
            return Math.Abs(X - cilX) + Math.Abs(Y - cilY);
        }
        public int vypocitejKrok(int zdrojX, int zdrojY)
        {

            return vypocitejVzdalenost(zdrojX, zdrojY) / width;
        }

    }
}
