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
    public partial class Agents : Form
    {
        public Agents()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menu H = new Menu();
            H.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Connexion H = new Connexion();
            H.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" | DDNTb.Text == "" | DescTb.Text == "" | TelTb.Text == "" | IDTb.Text == "")
            {
                MessageBox.Show("Attention !! Une information est vide");
            }
            else
            {
                try
                {
                    this.AgentDGV.Rows.Add(NomTb.Text, DDNTb.Text, DescTb.Text, TelTb.Text, IDTb.Text);
                    this.NomTb.Text = "";
                    this.DDNTb.Clear();
                    this.DescTb.Clear();
                    this.TelTb.Clear();
                    this.IDTb.Clear();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Attention !! Une information est vide");

                }
            }
            
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Voulez vous supprimer cette ligne ?", "Confirmation", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    int index = this.AgentDGV.CurrentRow.Index;
                    this.AgentDGV.Rows.RemoveAt(index);
                    MessageBox.Show("La suppression a été effectuée avec succès");

                }
                else
                    MessageBox.Show("La suppression a été annulée");

            }
            catch (Exception)
            {

                MessageBox.Show("La table Fabricant est vide");
            }
            
        }

        private void Rechercher_Click(object sender, EventArgs e)
        {
            int cmp = 0;
            for (int i = 0; i < this.AgentDGV.Rows.Count-1; i++)
            {
                
                if (this.AgentDGV.Rows[i].Cells[4].Value.ToString() == this.Text_ID.Text)
                {
                    MessageBox.Show("Il existe !!");
                    cmp = 1;
                }
            }
            if (cmp == 0)
                MessageBox.Show("Il n'éxiste pas");
        }

        private void Agents_Load(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
        }
        int index;
        private void Modifier_Click(object sender, EventArgs e)
        {
            int trouve = 0;
            
            for (int i = 0; i < this.AgentDGV.Rows.Count-1; i++)
            {
                if (this.AgentDGV.Rows[i].Cells[4].Value.ToString() == Text_ID.Text)
                {
                    index = i;
                    trouve = 1;
                }
            }
            if (trouve == 0)
                MessageBox.Show("Cette personne n'existe pas dans la liste");
            else
                this.groupBox1.Visible = true;
        }

        private void Appliquer_Click(object sender, EventArgs e)
        {
            this.AgentDGV.Rows[index].Cells[0].Value = TextNouveauNom.Text;
            this.AgentDGV.Rows[index].Cells[1].Value = TextNouveauDDN.Text;
            this.AgentDGV.Rows[index].Cells[2].Value = TextNouveauDesc.Text;
            this.AgentDGV.Rows[index].Cells[3].Value = TextNouveauTel.Text;
            this.AgentDGV.Rows[index].Cells[4].Value = TextNouveauID.Text;
            this.groupBox1.Visible = false;
            this.TextIDRechercher.Text = string.Empty;
        }
    }
}
