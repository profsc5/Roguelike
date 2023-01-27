using nevim;

public class AI : Entita
{
    public int hracX, hracWidth, hracY, hracHeight, distance;
    Tile dalsiKrok;
    public AI(string username, Image textura, int x_pos, int y_pos, int width, int height) : base(username, textura, x_pos, y_pos, width, height)
    {

    }
    public void sledujCil(int cilX, int cilY)
    {
    


        if (x_pos + width / 2 > cilX)
        {

                x_pos -= 5;
        
        }
        if (x_pos + width / 2 < cilX)
        {
  
                x_pos += 5;
           
        }
        if (y_pos + height / 2 > cilY)
        {

            y_pos -= 5;

        }
        if (y_pos + height / 2 < cilY)
        {
            y_pos += 5;

        }
    }

    public void najdiCestu()
    {
        if (Tile.vyberCestu().Krok < 2 && !Tile.vyberCestu().Active() )
        {

                dalsiKrok = Tile.fronta[0];

                sledujCil(dalsiKrok.X, dalsiKrok.Y);
        }
        else
        {
            Tile.fronta.Remove(Tile.fronta[0]);
        }
     
        
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
