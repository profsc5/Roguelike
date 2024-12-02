using System.Numerics;

public class Entita
{
    public static List<string> generatedTiles = new();
    public static List<Entita> entitaList = new();
    public bool aktivni;
    public string kolider;
    public Vector2 smerPohybu;
    public Image textura;
    public int x_pos, y_pos;
    public double zivoty;

    public Entita(string username, Image textura, int x_pos, int y_pos, int width, int height)
    {
        this.username = username;
        this.textura = textura;
        this.x_pos = x_pos;
        this.y_pos = y_pos;
        this.width = width;
        this.height = height;
        entitaList.Add(this);
        if (username == "tile") generatedTiles.Add(this.username);
        if (username == "chobotnicka") zivoty = 5;
    }

    public int width { get; set; }
    public int height { get; set; }
    public int Xdirection { get; set; }
    public int Ydirection { get; set; }
    public string username { get; set; }

    public static Image vyberTexturu(Image img1, Image img2, Image img3, Image img4)
    {
        var rand = new Random();
        Image textura = null;
        switch (rand.Next(0, 4))
        {
            case 0:
                textura = img1;
                break;
            case 1:
                textura = img2;
                break;
            case 2:
                textura = img3;
                break;
            case 3:
                textura = img4;
                break;
        }

        return textura;
    }

    public static Entita FindEnt(string name)
    {
        foreach (var ent in entitaList)
            if (ent.username == name)
                return ent;
            else
                continue;
        return null;
    }

    public bool colliding(int x_pos, int y_pos, Entita ent2)
    {
        if (ent2.username != username)
            if (x_pos < ent2.width + ent2.x_pos
                && x_pos + width > ent2.x_pos
                && y_pos < ent2.y_pos + ent2.height
                && y_pos + height > ent2.y_pos)
                return true;
        return false;
    }


    public bool Kolize()
    {
        foreach (var ent2 in entitaList)
            if (colliding(x_pos, y_pos, ent2))
            {
                kolider = ent2.username;
                return true;
            }

        return false;
    }
}