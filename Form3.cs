using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nevim
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
            label1.Text ="Žetony: " + Form1.skore.ToString();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            kp.DrawImage(Properties.Resources.obchod_nadpis, 90, 50, 300, 100);
        }

        private void buttonRychlost_Click(object sender, EventArgs e)
        {
            int cena = 5;
            if(cena <= Form1.skore)
            {
                Form1.rychlost += 5;
                MessageBox.Show("Zvýšil sis rychlost o 5 bodů!");
            }
            else
            {
                MessageBox.Show("Nemáš dostatek žetonů!");
            }
        }
    }
}
