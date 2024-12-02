using nevim;

public class AI : Entita
{
    public static int pocetPriserek;

    public static List<AI> vsechnyPriserky = new();
    public List<Tile> AITiles = new();
    public Tile dalsiKrok, startKrok;
    public int hracX, hracWidth, hracY, hracHeight, distance, rychlost = 3;
    public int Krok;
    public List<Tile> uzavrenyList = new();

    public AI(string username, Image textura, int x_pos, int y_pos, int width, int height) : base(username, textura,
        x_pos, y_pos, width, height)
    {
        pocetPriserek++;
        vsechnyPriserky.Add(this);
    }

    public void sledujCil(int cilX, int cilY)
    {
        if (x_pos + width / 2 > cilX + 30)
            x_pos -= rychlost;
        else if (x_pos + width / 2 < cilX + 30)
            x_pos += rychlost;
        else if (y_pos + height / 2 > cilY + 30)
            y_pos -= rychlost;
        else if (y_pos + height / 2 < cilY + 30) y_pos += rychlost;
    }

    public void zkontrolujVedlejsi(int X, int Y)
    {
        foreach (var t in Tile.Tiles)
            if (!t.aktivni && !AITiles.Contains(t) && !uzavrenyList.Contains(t) &&
                (Math.Abs(X - t.X) + Math.Abs(Y - t.Y)) / width < 2)
            {
                AITiles.Add(t);
                if (t.X == X && t.Y == Y) uzavrenyList.Add(startKrok);
            }
    }

    public void vyberCestu()
    {
        var min = 0;

        zkontrolujVedlejsi(startKrok.X, startKrok.Y);
        foreach (var t in AITiles)
        {
            t.Vzdalenost = t.vypocitejVzdalenost(FindEnt("player").x_pos, FindEnt("player").y_pos);
            t.Krok = t.vypocitejKrok(startKrok.X, startKrok.Y);
            t.Parametr = t.Vzdalenost + t.Krok;
        }

        if (AITiles.Count > 0)
        {
            for (var x = 0; x < AITiles.Count; x++)
            {
                min = AITiles[0].Parametr;
                if (AITiles[x].Parametr < min) AITiles[0] = AITiles[x];
            }

            uzavrenyList.Add(AITiles[0]);
            AITiles.RemoveAt(0);
            if (uzavrenyList.Count > 0) startKrok = uzavrenyList.Last();
        }
    }

    public void najdiCestu()
    {
        if (uzavrenyList.Count > 0)
        {
            var oldposX = x_pos;
            var oldposY = y_pos;
            sledujCil(uzavrenyList[0].X, uzavrenyList[0].Y);
        }
    }

    public bool KillPlayer()
    {
        if (entitaList.Contains(this) && kolider == "player") return true;

        return false;
    }
}