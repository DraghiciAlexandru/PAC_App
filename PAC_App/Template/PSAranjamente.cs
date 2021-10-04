using PAC_App.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.Template
{
    class PSAranjamente : Panel
    {
        private Panel Formula;

        public PSAranjamente()
        {
            Formula = new Panel();
            layout();
        }

        private void layout()
        {
            this.Size = new Size(525, 360);
            this.Location = new Point(0, 0);
            this.BackColor = Color.FromArgb(40, 40, 40);

            setPanelFormula(Formula);

            setLblA();
            setNumarN();
            setNumarM();
            setRezultat();
            setCalculTotal();
        }

        private void setPanelFormula(Panel formula)
        {
            formula.Size = new Size(180, 100);
            formula.BorderStyle = BorderStyle.Fixed3D;
            formula.Location = new Point(335, 10);

            setLblAFormula(formula);
            setLblN(formula);
            setLblK(formula);
            setLblEgal(formula);
            setPanelEgal(formula);
            setLblNFac(formula);
            setLblNMK(formula);

            this.Controls.Add(formula);
        }

        private void setLblAFormula(Panel formula)
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "A";
            lblP.AutoSize = false;
            lblP.Size = new Size(27, 27);
            lblP.Location = new Point(20, 30);
            lblP.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);

            formula.Controls.Add(lblP);
        }

        private void setLblK(Panel formula)
        {
            Label lblK = new Label();
            lblK.ForeColor = Color.Red;
            lblK.Text = "k";
            lblK.AutoSize = false;
            lblK.Size = new Size(25, 25);
            lblK.Location = new Point(42, 15);
            lblK.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            formula.Controls.Add(lblK);
        }

        private void setLblN(Panel formula)
        {
            Label lblN = new Label();
            lblN.ForeColor = Color.Red;
            lblN.Text = "n";
            lblN.AutoSize = false;
            lblN.Size = new Size(25, 25);
            lblN.Location = new Point(42, 45);
            lblN.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            formula.Controls.Add(lblN);
        }

        private void setLblEgal(Panel formula)
        {
            Label lblEgal = new Label();
            lblEgal.ForeColor = Color.Red;
            lblEgal.Text = "=";
            lblEgal.AutoSize = false;
            lblEgal.Size = new Size(30, 30);
            lblEgal.Location = new Point(60, 30);
            lblEgal.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);

            formula.Controls.Add(lblEgal);
        }

        private void setPanelEgal(Panel formula)
        {
            Panel panel = new Panel();
            panel.Size = new Size(75, 2);
            panel.Location = new Point(85, 45);
            panel.BackColor = Color.Red;

            formula.Controls.Add(panel);
        }

        private void setLblNFac(Panel formula)
        {
            Label lblN = new Label();
            lblN.ForeColor = Color.Red;
            lblN.Text = "n!";
            lblN.AutoSize = false;
            lblN.Size = new Size(30, 25);
            lblN.Location = new Point(110, 17);
            lblN.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            formula.Controls.Add(lblN);
        }

        private void setLblNMK(Panel formula)
        {
            Label lblN = new Label();
            lblN.ForeColor = Color.Red;
            lblN.Text = "(n-k)!";
            lblN.AutoSize = false;
            lblN.Size = new Size(60, 25);
            lblN.Location = new Point(97, 50);
            lblN.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            formula.Controls.Add(lblN);
        }

        private void setLblA()
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "A";
            lblP.AutoSize = false;
            lblP.Size = new Size(45, 45);
            lblP.Location = new Point(90, 160);
            lblP.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Regular);

            Controls.Add(lblP);
        }

        public void setNumarN()
        {
            TextBox txtN = new TextBox();
            txtN.Name = "txtN";
            txtN.Size = new Size(30, 22);
            txtN.Location = new Point(140, 200);
            txtN.BackColor = Color.FromArgb(255, 70, 70);
            txtN.ForeColor = Color.FromArgb(20, 20, 20);
            txtN.BorderStyle = BorderStyle.None;
            txtN.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            txtN.KeyPress += TxtN_KeyPress;
            txtN.TextChanged += TxtN_TextChanged;

            Controls.Add(txtN);
        }

        public void setNumarM()
        {
            TextBox txtM = new TextBox();
            txtM.Name = "txtM";
            txtM.Size = new Size(30, 22);
            txtM.Location = new Point(140, 150);
            txtM.BackColor = Color.FromArgb(255, 70, 70);
            txtM.ForeColor = Color.FromArgb(20, 20, 20);
            txtM.BorderStyle = BorderStyle.None;
            txtM.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            txtM.KeyPress += TxtN_KeyPress;
            txtM.TextChanged += TxtM_TextChanged;

            Controls.Add(txtM);
        }

        private void TxtM_TextChanged(object sender, EventArgs e)
        {
            TextBox txtN = new TextBox();
            TextBox txtM = sender as TextBox;
            TextBox txtTotal = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
                if (x.Name == "txtTotal")
                    txtTotal = x as TextBox;
            }

            if (txtM.Text.Length != 0 && txtN.Text.Length != 0)
            {
                int nr = int.Parse(txtM.Text);
                int nr2 = int.Parse(txtN.Text);

                if (nr > 15)
                {
                    txtM.Text = "15";
                }

                if (nr > nr2)
                {
                    nr = nr2;
                    txtM.Text = nr.ToString();
                }
                Lista<int> lista = new Lista<int>();
                for (int i = 0; i < nr2; i++)
                {
                    lista.addFinish(i);
                }
                Aranjamente<int> aranj = new Aranjamente<int>(lista, nr);
                aranj.back(0);
                txtTotal.Text = aranj.solutii.size().ToString();
                aranj.solutii.clear();
            }
            else
            {
                txtTotal.Text = "";
            }
        }

        private void TxtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtN = sender as TextBox;
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtN.Text.Length == 0)
                if (e.KeyChar == '0')
                    e.Handled = true;
        }

        private void TxtN_TextChanged(object sender, EventArgs e)
        {
            TextBox txtN = sender as TextBox;
            TextBox txtM = new TextBox();
            TextBox txtTotal = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtM")
                    txtM = x as TextBox;
                if (x.Name == "txtTotal")
                    txtTotal = x as TextBox;
            }

            if (txtM.Text.Length != 0 && txtN.Text.Length != 0)
            {
                int nr = int.Parse(txtN.Text);
                int nr2 = int.Parse(txtM.Text);

                if (nr > 15)
                {
                    txtM.Text = "15";
                }

                if (nr2 > nr) 
                {
                    txtM.Text = nr.ToString();
                    /*Lista<int> lista = new Lista<int>();
                    for (int i = 0; i < nr; i++)
                    {
                        lista.addFinish(i);
                    }
                    Permutari<int> permutari = new Permutari<int>(lista);
                    txtTotal.Text = permutari.solutii.size().ToString();
                    permutari.solutii.clear();*/
                }
                else
                {
                    Lista<int> lista = new Lista<int>();
                    for (int i = 0; i < nr; i++)
                    {
                        lista.addFinish(i);
                    }
                    Aranjamente<int> aranj = new Aranjamente<int>(lista, nr2);
                    aranj.back(0);
                    txtTotal.Text = aranj.solutii.size().ToString();
                    aranj.solutii.clear();
                }
            }
            else
            {
                txtTotal.Text = "";
            }
        }

        private void setRezultat()
        {
            Label lblRezultat = new Label();
            lblRezultat.ForeColor = Color.Red;
            lblRezultat.Text = "Rezultat:";
            lblRezultat.AutoSize = false;
            lblRezultat.Size = new Size(140, 30);
            lblRezultat.Location = new Point(220, 175);
            lblRezultat.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);

            Controls.Add(lblRezultat);
        }

        private void setCalculTotal()
        {
            TextBox txtTotal = new TextBox();
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(50, 22);
            txtTotal.Location = new Point(360, 180);
            txtTotal.ReadOnly = true;
            txtTotal.BackColor = Color.FromArgb(255, 70, 70);
            txtTotal.ForeColor = Color.FromArgb(20, 20, 20);
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            Controls.Add(txtTotal);
        }
    }
}
