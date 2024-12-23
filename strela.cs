﻿using System.Numerics;
using Timer = System.Windows.Forms.Timer;

namespace nevim;

internal class strela
{
    public static List<strela> strelaList = new();
    public int cilX, cilY, zdrojX, zdrojY, X, Y, pocetVystrelu;
    public Entita kolider;
    public int rychlost = 20;
    private readonly Timer strelaTimer = new();

    public strela(int X, int Y, int cilX, int cilY)
    {
        this.X = X;
        this.Y = Y;
        zdrojX = X;
        zdrojY = Y;
        this.cilX = cilX;
        this.cilY = cilY;
        pocetVystrelu++;
        strelaList.Add(this);
        strelaTimer.Interval = 10;
        strelaTimer.Tick += strelaEvent;
        strelaTimer.Start();
    }

    public double spocitejVzdalenost(int hracX, int hracY, int mysX, int mysY)
    {
        return Math.Abs(mysX - hracX) + Math.Abs(mysY - hracY);
    }

    public void strelaEvent(object sender, EventArgs e)
    {
        if (strelaTimer.Enabled)
        {
            if (spocitejVzdalenost(X, Y, zdrojX, zdrojY) > 500)
            {
                strelaList.Remove(this);
                return;
            }

            var uhel = Vector2.Normalize(new Vector2(cilX - zdrojX, cilY - zdrojY));
            X += (int)(uhel.X * rychlost);
            Y += (int)(uhel.Y * rychlost);

            foreach (var ent in Entita.entitaList)
                if (Kolize(ent))
                {
                    if (ent.username == "chobotnicka")
                    {
                        kolider = ent;
                    }
                    else
                    {
                        strelaList.Remove(this);
                        strelaTimer.Dispose();
                    }
                }
        }
        else
        {
            strelaTimer.Dispose();
        }
    }

    public bool Kolize(Entita entita)
    {
        if (entita == null) return false;
        if (X < entita.width + entita.x_pos
            && X > entita.x_pos
            && Y < entita.y_pos + entita.height
            && Y > entita.y_pos)
            if (entita.username != "player")
                return true;
        return false;
    }
}