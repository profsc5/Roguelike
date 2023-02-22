using System.Diagnostics;
using System.Text;

namespace nevim
{
    public partial class Form3 : Form
    {
        int zetony;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            kp.DrawImage(Properties.Resources.obchod_nadpis, 90, 50, 300, 100);
        }

        private void buttonRychlost_Click(object sender, EventArgs e)
        {



            int cena = 5;
            if (cena <= zetony)
            {


                Form1.rychlost += 5;
                zetony -= cena;
                StreamWriter strW = new StreamWriter("skore.txt");

                Debug.Write(zetony);
                //Převod na jedničky, abychom snadněji odčítali žetony
                for (int x = 0; x < zetony; x++)
                {
                    strW.Write(1);
                }
                strW.Close();

                MessageBox.Show("Zvýšil sis rychlost o 5 bodů!");
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
            StreamReader strR = new StreamReader("skore.txt", Encoding.Default);
            while (strR.Peek() != -1)
            {
                foreach (char ch in strR.ReadLine())
                {
                    zetony += (int)Char.GetNumericValue(ch);

                }
            }
            label1.Text = "Žetony: " + zetony.ToString();

            strR.Close();
        }
    }

}
