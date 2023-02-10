using nevim;
using System.Diagnostics;
using System.Xml.Linq;

public class AI : Entita
{
    public int hracX, hracWidth, hracY, hracHeight, distance;
    Tile dalsiKrok;
    static public int pocetPriserek = 0;
    public AI(string username, Image textura, int x_pos, int y_pos, int width, int height) : base(username, textura, x_pos, y_pos, width, height)
    {
        pocetPriserek++;
        Debug.WriteLine(pocetPriserek);
    }
    public void sledujCil(int cilX, int cilY)
    {



        if (x_pos + width / 2 > cilX + 40)
        {

            x_pos -= 5;

        }
        if (x_pos + width / 2 < cilX + 40)
        {

            x_pos += 5;

        }
        if (y_pos + height / 2 > cilY + 40)
        {

            y_pos -= 5;

        }
        if (y_pos + height / 2 < cilY + 40)
        {
            y_pos += 5;

        }
    }

    public void najdiCestu()
    {
        dalsiKrok = Tile.vyberCestu()[0];

        sledujCil(dalsiKrok.X, dalsiKrok.Y);


    }

    public bool KillPlayer()
    {
        if (kolider == "player")
        {
            return true;
        }
        return false;
    }
    


}
