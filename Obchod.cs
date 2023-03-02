using System.Diagnostics;
using System.Text;

namespace nevim
{
    public partial class Obchod : Form
    {
        int zetony, texturaCislo = 0;
        public Obchod()
        {
            InitializeComponent();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonRychlost_Click(object sender, EventArgs e)
        {
            int cena = 20;
            if (cena <= zetony)
            {
                Roguelike.rychlost += 5;
                odectiZetony(cena);
                MessageBox.Show("Zvýšil/a sis rychlost o 5 bodů!");
                nactiZetony();
            }
            else
            {
                MessageBox.Show("Nemáš dostatek žetonů!");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            nactiZetony();
        }
        void nactiZetony()
        {
            zetony = 0;
            StreamReader strR = new StreamReader("skore.txt", Encoding.Default);
            while (strR.Peek() != -1)
            {
                foreach (char ch in strR.ReadLine())
                {
                    zetony += (int)Char.GetNumericValue(ch);
                }
            }
            label1.Text = zetony.ToString();
            strR.Close();
        }

        private void buttonPoskozeni_Click(object sender, EventArgs e)
        {
            int cena = 30;
            if (cena <= zetony)
            {
                Roguelike.poskozeni += 0.25;
                odectiZetony(cena);
                MessageBox.Show("Zvýšil/a sis poškození o 5 bodů!");
                nactiZetony();
            }
            else
            {
                MessageBox.Show("Nemáš dostatek žetonů!");
            }
        }
        private void odectiZetony(int cena)
        {

            zetony -= cena;
            StreamWriter strW = new StreamWriter("skore.txt");
            Debug.Write(zetony);
            //Převod na jedničky, abychom snadněji odčítali žetony
            for (int x = 0; x < zetony; x++)
            {
                strW.Write(1);
            }
            strW.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            texturaCislo++;
            Image textura = null;
            switch (texturaCislo)
            {

                case 1:
                    textura = Properties.Resources.obchod2;
                    break;
                case 2:
                    textura = Properties.Resources.obchod3;
                    break;
                case 3:
                    textura = Properties.Resources.obchod4;
                    break;
                case 4:
                    textura = Properties.Resources.obchod5;
                    break;
                case 5:
                    textura = Properties.Resources.obchod6; timer1.Dispose();
                    break;
            }
            BackgroundImage = textura;
        }
    }

}
