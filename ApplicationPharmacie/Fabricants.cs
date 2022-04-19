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
    public partial class Fabricants : Form
    {
        public Fabricants()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TelTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void DescTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void NomTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Connexion H = new Connexion();
            H.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menu H = new Menu();
            H.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Voulez vous supprimer cette ligne ?", "Confirmation", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    int index = this.FabricantDGV.CurrentRow.Index;
                    this.FabricantDGV.Rows.RemoveAt(index);
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" | AddTb.Text == "" | DescTb.Text == "" | TelTb.Text == "" | IDTb.Text == "")
            {
                MessageBox.Show("Attention !! Une information est vide");
            }
            else
            {
                try
                {
                    this.FabricantDGV.Rows.Add(NomTb.Text, AddTb.Text, DescTb.Text, TelTb.Text, IDTb.Text);
                    this.NomTb.Text = "";
                    this.AddTb.Clear();
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
        int index;
        private void Modifier_Click(object sender, EventArgs e)
        {
            int trouve = 0;

            for (int i = 0; i < this.FabricantDGV.Rows.Count - 1; i++)
            {
                if (this.FabricantDGV.Rows[i].Cells[4].Value.ToString() == Text_ID.Text)
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FabricantDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Fabricants_Load(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
        }

        private void Rechercher_Click(object sender, EventArgs e)
        {
            int cmp = 0;
            for (int i = 0; i < this.FabricantDGV.Rows.Count - 1; i++)
            {

                if (this.FabricantDGV.Rows[i].Cells[4].Value.ToString() == this.Text_ID.Text)
                {
                    MessageBox.Show("Il existe !!");
                    cmp = 1;
                }
            }
            if (cmp == 0)
                MessageBox.Show("Il n'éxiste pas");
        }

        private void Appliquer_Click(object sender, EventArgs e)
        {
            this.FabricantDGV.Rows[index].Cells[0].Value = TextNouveauNom.Text;
            this.FabricantDGV.Rows[index].Cells[1].Value = TextNouveauPrix.Text;
            this.FabricantDGV.Rows[index].Cells[2].Value = TextNouveauQte.Text;
            this.FabricantDGV.Rows[index].Cells[3].Value = TextNouveauFabricant.Text;
            this.FabricantDGV.Rows[index].Cells[4].Value = TextNouveauID.Text;
            this.groupBox1.Visible = false;
            this.TextIDRechercher.Text = string.Empty;
        }
    }
}
