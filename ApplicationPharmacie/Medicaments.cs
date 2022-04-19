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
    public partial class Medicaments : Form
    {
        public Medicaments()
        {
            InitializeComponent();
        }

        private void Medicaments_Load(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
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
            if (NomTb.Text == "" | PrixTb.Text == "" | QteTb.Text == "" | FabTb.Text == "" | IDTb.Text == "")
            {
                MessageBox.Show("Attention !! Une information est vide");
            }
            else
            {
                try
                {
                    this.MedicamentsDGV.Rows.Add(NomTb.Text, PrixTb.Text, QteTb.Text, FabTb.Text, IDTb.Text);
                    this.NomTb.Text = "";
                    this.PrixTb.Clear();
                    this.QteTb.Clear();
                    this.FabTb.Clear();
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
                    int index = this.MedicamentsDGV.CurrentRow.Index;
                    this.MedicamentsDGV.Rows.RemoveAt(index);
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
            for (int i = 0; i < this.MedicamentsDGV.Rows.Count - 1; i++)
            {

                if (this.MedicamentsDGV.Rows[i].Cells[4].Value.ToString() == this.Text_ID.Text)
                {
                    MessageBox.Show("Il existe !!");
                    cmp = 1;
                }
            }
            if (cmp == 0)
                MessageBox.Show("Il n'éxiste pas");
        }
        int index;
        private void Modifier_Click(object sender, EventArgs e)
        {
            int trouve = 0;

            for (int i = 0; i < this.MedicamentsDGV.Rows.Count - 1; i++)
            {
                if (this.MedicamentsDGV.Rows[i].Cells[4].Value.ToString() == Text_ID.Text)
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
            this.MedicamentsDGV.Rows[index].Cells[0].Value = TextNouveauNom.Text;
            this.MedicamentsDGV.Rows[index].Cells[1].Value = TextNouveauPrix.Text;
            this.MedicamentsDGV.Rows[index].Cells[2].Value = TextNouveauQte.Text;
            this.MedicamentsDGV.Rows[index].Cells[3].Value = TextNouveauFabricant.Text;
            this.MedicamentsDGV.Rows[index].Cells[4].Value = TextNouveauID.Text;
            this.groupBox1.Visible = false;
            this.TextIDRechercher.Text = string.Empty;
        }
    }
}
