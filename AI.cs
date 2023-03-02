using nevim;

public class AI : Entita
{
    public int hracX, hracWidth, hracY, hracHeight, distance;
    public int Krok;
    public Tile dalsiKrok;
    static public int pocetPriserek = 0;

    static public List<AI> vsechnyPriserky = new List<AI>();
    public List<Tile> fronta = new List<Tile>();
    public AI(string username, Image textura, int x_pos, int y_pos, int width, int height) : base(username, textura, x_pos, y_pos, width, height)
    {
        pocetPriserek++;
        dalsiKrok = new Tile(60);
        dalsiKrok.X = x_pos;
        dalsiKrok.Y = y_pos;
        vsechnyPriserky.Add(this);
    }
    public void sledujCil(int cilX, int cilY)
    {
        if (x_pos + width / 2 > cilX + 30)
        {

            x_pos -= 5;

        }
        else if (x_pos + width / 2 < cilX + 30)
        {

            x_pos += 5;

        }
        else if (y_pos + height / 2 > cilY + 30)
        {
            y_pos -= 5;

        }
        else if (y_pos + height / 2 < cilY + 30)
        {
            y_pos += 5;

        }
    }

    public void najdiCestu()
    {
        if (vsechnyPriserky.Count > 0)
        {
            if (x_pos + (width / 2) == dalsiKrok.X + 30 && y_pos + (height / 2) == dalsiKrok.Y + 30)
            {
                dalsiKrok = Tile.vyberCestu(fronta)[0];

                for (int x = 0; x < Tile.walkedTiles.Count; x++)
                {
                    if (Tile.walkedTiles[x].vypocitejVzdalenost(x_pos, y_pos)>120)
                    {
                        Tile.walkedTiles.Remove(Tile.walkedTiles[x]);
                    }

                }
            }
            sledujCil(dalsiKrok.X, dalsiKrok.Y);
        }
    }
    public bool KillPlayer()
    {


        if (entitaList.Contains(this) && kolider == "player")
        {
            return true;
        }
        return false;
    }



}
