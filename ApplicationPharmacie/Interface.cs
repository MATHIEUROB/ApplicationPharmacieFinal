using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationPharmacie
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
        }
        int pdd = 0;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pdd += 1;
            Bardeprogression.Value = pdd;
            if(Bardeprogression.Value == 100)
            {
                Bardeprogression.Value = 0;
                timer1.Stop();
                Connexion MyCon = new Connexion();
                MyCon.Show();
                this.Hide();
            }
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
