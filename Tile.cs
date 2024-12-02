namespace nevim;

public class Tile
{
    public static List<Tile> Tiles = new();
    public bool aktivni;
    public int multiplikator;
    public int Parametr;
    public Tile parent;
    public bool selfTile = false;
    public int width;


    public Tile(int width)
    {
        this.width = width;
        Tiles.Add(this);
    }

    public int X { get; set; }
    public int Y { get; set; }
    public int Krok { get; set; }
    public int Vzdalenost { get; set; }

    public bool Kolize(Entita entita)
    {
        if (entita == null) return false;
        if (X < entita.width + entita.x_pos
            && X + width > entita.x_pos
            && Y < entita.y_pos + entita.height
            && Y + width > entita.y_pos)
        {
            var kolider = entita.username;
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