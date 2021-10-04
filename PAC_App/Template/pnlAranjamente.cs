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
    class pnlAranjamente : Panel, IPanel
    {
        public bool Valid { get; private set; }
        public int Value { get; set; }
        public int Id { get; private set; }

        public pnlAranjamente()
        {
            Id = 2;
            layout();
        }

        private void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Size = new Size(80, 80);
            this.Name = "pnlAranjamente";

            this.MouseDown += PnlPermutari_MouseDown;

            setLblP();
            setTxtN();
            setTxtM();

            foreach (Control x in Controls)
            {
                x.MouseDown += PnlPermutari_MouseDown;
            }
        }

        private void PnlPermutari_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Copy);
            }
        }

        private void setLblP()
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "A";
            lblP.AutoSize = false;
            lblP.Size = new Size(45, 45);
            lblP.Location = new Point(-5, 13);
            lblP.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Regular);

            Controls.Add(lblP);
        }

        public void setTxtN()
        {
            TextBox txtN = new TextBox();
            txtN.Name = "txtN";
            txtN.Size = new Size(30, 22);
            txtN.Location = new Point(45, 45);
            txtN.BackColor = Color.FromArgb(255, 70, 70);
            txtN.ForeColor = Color.FromArgb(20, 20, 20);
            txtN.BorderStyle = BorderStyle.None;
            txtN.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            txtN.KeyPress += TxtN_KeyPress;
            txtN.TextChanged += TxtN_TextChanged;

            txtN.Enabled = false;

            Controls.Add(txtN);
        }

        private void TxtN_TextChanged(object sender, EventArgs e)
        {
            TextBox txtN = new TextBox();
            TextBox txtM = new TextBox();

            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
                if (x.Name == "txtM")
                    txtM = x as TextBox;
            }

            if (txtN.Text.Length != 0 && txtM.Text.Length != 0) 
            {
                int nr = int.Parse(txtN.Text);
                int nr2 = int.Parse(txtM.Text);

                if (nr > 7)
                {
                    nr = 7;
                    txtN.Text = nr.ToString();
                }

                if (nr2 > nr)
                {
                    txtM.Text = nr.ToString();
                }
                else
                {
                    Valid = true;

                    Lista<int> lista = new Lista<int>();
                    for (int i = 0; i < nr; i++)
                    {
                        lista.addFinish(i);
                    }
                    Aranjamente<int> aranj = new Aranjamente<int>(lista, nr2);
                    aranj.back(0);

                    Value = aranj.solutii.size();
                    aranj.solutii.clear();
                }
            }
            else
            {
                Valid = false;
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

        public void setTxtM()
        {
            TextBox txtM = new TextBox();
            txtM.Name = "txtM";
            txtM.Size = new Size(30, 22);
            txtM.Location = new Point(45, 10);
            txtM.BackColor = Color.FromArgb(255, 70, 70);
            txtM.ForeColor = Color.FromArgb(20, 20, 20);
            txtM.BorderStyle = BorderStyle.None;
            txtM.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            txtM.KeyPress += TxtN_KeyPress;
            txtM.TextChanged += TxtM_TextChanged;

            txtM.Enabled = false;

            Controls.Add(txtM);
        }

        private void TxtM_TextChanged(object sender, EventArgs e)
        {
            TextBox txtN = new TextBox();
            TextBox txtM = sender as TextBox;
            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
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
                else
                {
                    Valid = true;

                    Lista<int> lista = new Lista<int>();
                    for (int i = 0; i < nr2; i++)
                    {
                        lista.addFinish(i);
                    }
                    Aranjamente<int> aranj = new Aranjamente<int>(lista, nr);
                    aranj.back(0);

                    Value = aranj.solutii.size();
                    aranj.solutii.clear();
                }
            }
            else
            {
                Valid = false;
            }
        }

        public int getValue()
        {
            return Value;
        }

        public bool valid()
        {
            return Valid;
        }

        public void droped()
        {
            TextBox txtN = new TextBox();
            TextBox txtM = new TextBox();

            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
                if (x.Name == "txtM")
                    txtM = x as TextBox;
            }
            txtM.Enabled = true;
            txtN.Enabled = true;

            this.MouseDown -= PnlPermutari_MouseDown;
            foreach (Control x in Controls)
            {
                x.MouseDown -= PnlPermutari_MouseDown;
            }
        }
    }
}
