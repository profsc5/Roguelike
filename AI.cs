using nevim;

public class AI : Entita
{
    public int hracX, hracWidth, hracY, hracHeight, distance;
    Tile dalsiKrok;
    static public int pocetPriserek = 0;
    static public List<AI> vsechnyPriserky = new List<AI>();
    public AI(string username, Image textura, int x_pos, int y_pos, int width, int height) : base(username, textura, x_pos, y_pos, width, height)
    {
        pocetPriserek++;

        vsechnyPriserky.Add(this);
    }
    public void sledujCil(int cilX, int cilY)
    {
        if (x_pos + width / 2 > cilX + 30)
        {

            x_pos -= 5;

        }
        if (x_pos + width / 2 < cilX + 30)
        {

            x_pos += 5;

        }
        if (y_pos + height / 2 > cilY + 30)
        {
            y_pos -= 5;

        }
        if (y_pos + height / 2 < cilY + 30)
        {
            y_pos += 5;

        }
    }

    public void najdiCestu()
    {
        if (vsechnyPriserky.Count > 0)
        {
            foreach (Tile t in Tile.Tiles)
            {
                t.Vzdalenost = t.vypocitejVzdalenost(FindEnt("player").x_pos, FindEnt("player").y_pos);
                t.Krok = t.vypocitejKrok(x_pos, y_pos);
            }

            if (Kolize() && kolider == "tile")
            {
                dalsiKrok = Tile.vyberCestu()[0];

            }
            if (!Kolize())
            {
                dalsiKrok = Tile.vyberCestu()[0];

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
