using System.Numerics;

public class Entita
{
    public int x_pos, y_pos;
    public Vector2 position;
    public int width { get; set; }
    public int height { get; set; }
    public int Xdirection { get; set; }
    public int Ydirection { get; set; }
    public bool aktivni;
    public int zivoty;
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
        position = new Vector2(x_pos + width / 2, y_pos + height / 2);

        entitaList.Add(this);

        if (username == "tile")
        {
            generatedTiles.Add(this.username);
        }
        if (username == "chobotnicka")
        {
            zivoty = 5;
        }

    }
    static public Image vyberTexturu(Image img1, Image img2, Image img3, Image img4)
    {
        Random rand = new Random();
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
                    Vector2 rozdilovyVektor = new Vector2((x_pos + width / 2) - (ent2.x_pos + ent2.width / 2), (y_pos + height / 2) - (ent2.y_pos + ent2.height / 2));
                    Vector2.Normalize(rozdilovyVektor);
                    /*Vector2 posun = Vector2.Subtract(rozdilovyVektor, -Form1.smerPohybu);
                    Form1.smerPohybu -= posun; */
                    int rozdilX = width / 2 - (int)rozdilovyVektor.X;
                    int rozdilY = height / 2 - (int)rozdilovyVektor.Y;
                    if (x_pos < ent2.x_pos)
                    {
                        //x_pos -= Math.Abs(x_pos - ent2.x_pos);
                        x_pos -= rozdilX;
                    }
                    else if (x_pos > ent2.x_pos)
                    {
                        //x_pos += Math.Abs(x_pos - (ent2.x_pos + width));
                        x_pos += rozdilX;
                    }
                    if (y_pos < ent2.y_pos)
                    {
                        y_pos -= rozdilY;
                        //y_pos -= Math.Abs(y_pos - ent2.y_pos);
                    }
                    else if (y_pos > ent2.y_pos)
                    {
                        y_pos += rozdilY;
                        //y_pos += Math.Abs(y_pos - (ent2.y_pos+height));
                    }
                    kolider = ent2.username;
                    return true;

                }
            }
        }
        return false;
    }

}

