
using System.Diagnostics;

public class Entita
{
    public int x_pos { get; set; }
    public int y_pos { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int direction;
    public string username { get; set; }
    public string kolider;
    public Image textura;

    static public List<string> generatedTiles = new List<string>();
    static public List<Entita> entitaList = new List<Entita>();

    public Entita(string username, Image textura, int x_pos, int y_pos, int width, int height)
    {
        this.username = username;
        this.textura = textura;
        this.x_pos = x_pos;
        this.y_pos = y_pos;
        this.width = width;
        this.height = height;
        entitaList.Add(this);

        if (username == "tile")
        {
            generatedTiles.Add(this.username);
        }

    }
    static public Entita FindEnt(string name)
    {
        foreach (Entita ent in entitaList)
        {

            if (ent.username == name)
            {
                return ent;
            }
            else
            {
                continue;
            }
        }
        return null;
    }
    public bool Kolize()
    {

        foreach (Entita ent2 in entitaList)
        {
            if (ent2.username != username)
            {
                if (x_pos < ent2.width + ent2.x_pos
                   && x_pos + width > ent2.x_pos
                   && y_pos < ent2.y_pos + ent2.height
                   && y_pos + height > ent2.y_pos)
                {

                    if (x_pos + width < ent2.x_pos)
                    {
                        direction = 1;
                    }
                    if (x_pos  > ent2.x_pos + ent2.width)
                    {
                        direction = 2;
                    }
                    if (y_pos + height < ent2.y_pos)
                    {
                        direction = 3;
                    }
                    if (y_pos  > ent2.y_pos + ent2.height)
                    {
                        direction = 4;
                    }
                    kolider = ent2.username;
                    return true;

                }
            }
        }       
        return false;
    }
}

