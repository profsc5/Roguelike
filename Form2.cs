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
    public partial class Form2 : Form
    {
        int n = 0;
        public Form2()
        {
            InitializeComponent();
            BackgroundImage = Properties.Resources.back1;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            Hide();
            fr.ShowDialog();
            Close();
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (n == 3)
            {
                n = 0;
            }
            switch (n)
            {
                case 0: BackgroundImage = Properties.Resources.back1; break;
                case 1: BackgroundImage = Properties.Resources.back2;  break;
                case 2: BackgroundImage = Properties.Resources.back3; break;
            }
            n++;
   
            Refresh();

        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.nadpisR, 55, 28, 647, 121);
        }
    }
}
