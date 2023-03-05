using nevim;
using System.Diagnostics;

public class AI : Entita
{
    public int hracX, hracWidth, hracY, hracHeight, distance;
    public int Krok;
    public Tile dalsiKrok, startKrok;
    static public int pocetPriserek = 0;
    public List<Tile> walkedTiles = new List<Tile>();
    public List<Tile> AITiles = new List<Tile>();
    public List<Tile> uzavrenyList = new List<Tile>();

    static public List<AI> vsechnyPriserky = new List<AI>();
    public List<Tile> fronta = new List<Tile>();
    public AI(string username, Image textura, int x_pos, int y_pos, int width, int height) : base(username, textura, x_pos, y_pos, width, height)
    {
        pocetPriserek++;
        /*dalsiKrok = new Tile(60);
        dalsiKrok.X = x_pos;
        dalsiKrok.Y = y_pos;
        dalsiKrok.Krok = 1;*/
        vsechnyPriserky.Add(this);
      
        //Debug.Write("X :" + dalsiKrok.X);
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
    public void zkontrolujVedlejsi(int X, int Y)
    {

        foreach (Tile t in Tile.Tiles)
        {
            if (!AITiles.Contains(t)&&!uzavrenyList.Contains(t) && !t.aktivni && ((Math.Abs(X-t.X ) +Math.Abs(Y-t.Y))/width ) < 2)
            {
                AITiles.Add(t);
                if (t.X == X && t.Y ==Y)
                {
                    t.parent = startKrok;
                    uzavrenyList.Add(startKrok);
                }
            }
        }
    }
    public void vyberCestu()
    {
        int min = 0;
        int minKrok = 0;
        
        zkontrolujVedlejsi(startKrok.X,startKrok.Y);
        foreach (Tile t  in AITiles)
        {
            t.Vzdalenost = t.vypocitejVzdalenost(FindEnt("player").x_pos, FindEnt("player").y_pos);
            t.Krok = t.vypocitejKrok(startKrok.X, startKrok.Y);
            t.Parametr = t.Vzdalenost + t.Krok;
        }
        if (AITiles.Count > 0)
        {
            for (int x = 0; x < AITiles.Count; x++)
            {
                min = AITiles[0].Parametr;
                if (AITiles[x].Parametr < min)
                {
                    AITiles[0] = AITiles[x];
                }
            }
        }
        uzavrenyList.Add(AITiles[0]);
        AITiles.RemoveAt(0);
        startKrok = uzavrenyList.Last();

    }

    public void najdiCestu()
    {
        sledujCil(uzavrenyList[0].X, uzavrenyList[0].Y);      
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
