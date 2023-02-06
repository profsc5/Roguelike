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

        public bool Kolize(Entita entita)
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
            //          !!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!PROBLEM PATHFINDINGU!!!!!!!!!!!!!!!
            //          !!!!!!!!!!!!!!!!!!!!!
            foreach (Entita entita in Entita.entitaList)
            {
                if (Kolize(entita))
                {
                    Debug.WriteLine(entita.username);
                    return true;                            
                }
                else
                {                    
                    return false;
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
                return vypocitejVzdalenost(zdrojX, zdrojY) / 80;         
        }
        static public List<Tile> vyberCestu()
        {
            int min = 0;
            foreach (Tile t in Tiles)
            {

                    if (!t.Active())
                    {
                        fronta.Add(t);
                    }
                
               
               

            }
            foreach (Tile tile in Tiles)
            {
                min = fronta[0].Parametr;

                if(tile.Parametr> min || tile.Active())
                {
                    fronta.Remove(tile);
                }
                else if (tile.Parametr < min && tile.Krok < 3)
                {
                    fronta[0] = tile;
                }
            }

            return fronta;
        }

    }

}
