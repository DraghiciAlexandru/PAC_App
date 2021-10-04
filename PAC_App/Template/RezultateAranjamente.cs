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
    class RezultateAranjamente : Panel
    {
        private Lista<String> lista;

        public RezultateAranjamente()
        {
            lista = new Lista<string>();

            layout();
        }

        private void layout()
        {
            this.Size = new Size(525, 360);
            this.Location = new Point(0, 0);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.ForeColor = Color.Red;

            setLbl();
            setTxtElement();
            setBtnEnter();
            setBtnAfisare();
            setTxtSolutii();
            setCopy();
            setLblA();
            setNumarN();
            setNumarM();
        }

        private void setLbl()
        {
            Label lblText = new Label();
            lblText.Text = "Introduceti un element:";
            lblText.AutoSize = false;
            lblText.Size = new Size(180, 20);
            lblText.Location = new Point(285, 35);
            lblText.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            Controls.Add(lblText);
        }

        private void setTxtElement()
        {
            TextBox txtElement = new TextBox();
            txtElement.Name = "txtElement";
            txtElement.BackColor = Color.FromArgb(255, 70, 70);
            txtElement.Size = new Size(135, 26);
            txtElement.Location = new Point(305, 60);
            txtElement.ForeColor = Color.FromArgb(20, 20, 20);
            txtElement.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            txtElement.Enabled = false;

            txtElement.KeyDown += TxtElement_KeyDown;

            Controls.Add(txtElement);
        }

        private void TxtElement_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtElement = new TextBox();
            Button btnAfisare = new Button();
            TextBox txtN = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtElement")
                    txtElement = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
                if (x.Name == "txtN")
                    txtN = x as TextBox;
            }

            if (e.KeyData == Keys.Enter && txtElement.Text != "")
            {
                if (lista.position(txtElement.Text) == -1)
                {
                    lista.addFinish(txtElement.Text);
                    txtElement.Text = "";
                    if (lista.size() == int.Parse(txtN.Text))
                        btnAfisare.Enabled = true;
                }
            }
        }

        private void setBtnEnter()
        {
            String path = Application.StartupPath;
            Button btnEnter = new Button();
            btnEnter.Size = new Size(24, 24);
            btnEnter.Location = new Point(445, 62);
            btnEnter.BackgroundImage = Image.FromFile(path + @"\resources\ok_20px.png");
            btnEnter.BackgroundImageLayout = ImageLayout.Center;
            btnEnter.FlatStyle = FlatStyle.Flat;
            btnEnter.Name = "btnEnter";
            btnEnter.Enabled = false;

            btnEnter.Click += BtnEnter_Click;

            Controls.Add(btnEnter);
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            TextBox txtElement = new TextBox();
            Button btnAfisare = new Button();
            TextBox txtN = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtElement")
                    txtElement = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
                if (x.Name == "txtN")
                    txtN = x as TextBox;
            }

            if (txtElement.Text != "")
            {
                if (lista.position(txtElement.Text) == -1)
                {
                    lista.addFinish(txtElement.Text);
                    txtElement.Text = "";
                    if (lista.size() == int.Parse(txtN.Text)) 
                        btnAfisare.Enabled = true;
                }
            }
        }

        private void setLblA()
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "A";
            lblP.AutoSize = false;
            lblP.Size = new Size(45, 45);
            lblP.Location = new Point(125, 40);
            lblP.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Regular);

            Controls.Add(lblP);
        }

        public void setNumarN()
        {
            TextBox txtN = new TextBox();
            txtN.Name = "txtN";
            txtN.Size = new Size(30, 22);
            txtN.Location = new Point(175, 75);
            txtN.BackColor = Color.FromArgb(255, 70, 70);
            txtN.ForeColor = Color.FromArgb(20, 20, 20);
            txtN.BorderStyle = BorderStyle.None;
            txtN.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            txtN.KeyPress += TxtN_KeyPress;
            txtN.TextChanged += TxtN_TextChanged;

            Controls.Add(txtN);
        }

        private void TxtN_TextChanged(object sender, EventArgs e)
        {
            TextBox txtElement = new TextBox();
            TextBox txtM = new TextBox();
            TextBox txtN = new TextBox();
            Button btnAfisare = new Button();
            Button btnEnter = new Button();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtElement")
                    txtElement = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
                if (x.Name == "txtM")
                    txtM = x as TextBox;
                if (x.Name == "txtN")
                    txtN = x as TextBox;
                if (x.Name == "btnEnter")
                    btnEnter = x as Button;
            }

            if (txtM.Text.Length != 0 && txtN.Text.Length != 0)
            {
                int nr = int.Parse(txtN.Text);
                int nr2 = int.Parse(txtM.Text);

                txtElement.Enabled = true;
                btnEnter.Enabled = true;

                if (nr2 > nr)
                {
                    txtM.Text = nr.ToString();
                }
                if (lista.size() == nr) 
                {
                    btnAfisare.Enabled = true;
                }
            }
            else
            {
                txtElement.Enabled = false;
                btnEnter.Enabled = false;
                btnAfisare.Enabled = false;
            }
        }

        public void setNumarM()
        {
            TextBox txtM = new TextBox();
            txtM.Name = "txtM";
            txtM.Size = new Size(30, 22);
            txtM.Location = new Point(175, 35);
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
            TextBox txtElement = new TextBox();
            TextBox txtM = new TextBox();
            TextBox txtN = new TextBox();
            Button btnAfisare = new Button();
            Button btnEnter = new Button();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtElement")
                    txtElement = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
                if (x.Name == "txtM")
                    txtM = x as TextBox;
                if (x.Name == "txtN")
                    txtN = x as TextBox;
                if (x.Name == "btnEnter")
                    btnEnter = x as Button;
            }

            if (txtM.Text.Length != 0 && txtN.Text.Length != 0)
            {
                int nr = int.Parse(txtM.Text);
                int nr2 = int.Parse(txtN.Text);

                txtElement.Enabled = true;
                btnEnter.Enabled = true;

                if (nr > nr2)
                {
                    nr = nr2;
                    txtM.Text = nr.ToString();
                }
                if (lista.size() == nr2)
                {
                    btnAfisare.Enabled = true;
                }
            }
            else
            {
                txtElement.Enabled = false;
                btnEnter.Enabled = false;
                btnAfisare.Enabled = false;
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

        private void setBtnAfisare()
        {
            String path = Application.StartupPath;
            Button btnAfisare = new Button();
            btnAfisare.Name = "btnAfisare";
            btnAfisare.Size = new Size(135, 50);
            btnAfisare.Location = new Point(195, 125);
            btnAfisare.Image = Image.FromFile(path + @"\resources\calculator.png");
            btnAfisare.FlatStyle = FlatStyle.Flat;
            btnAfisare.Enabled = false;
            btnAfisare.Text = "Afiseaza solutii";
            btnAfisare.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            btnAfisare.ForeColor = Color.Red;
            btnAfisare.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnAfisare.Click += BtnAfisare_Click;

            Controls.Add(btnAfisare);
        }

        private void BtnAfisare_Click(object sender, EventArgs e)
        {
            TextBox txtSolutii = new TextBox();
            Button btnAfisare = new Button();
            TextBox txtM = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtSolutii")
                    txtSolutii = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
                if (x.Name == "txtM")
                    txtM = x as TextBox;
            }

            txtSolutii.Text = "";

            Aranjamente<String> aranj = new Aranjamente<string>(lista, int.Parse(txtM.Text));
            aranj.back(0);

            for (int i = 0; i < aranj.solutii.size(); i++)
            {
                txtSolutii.Text += aranj.solutii.getAtPosition(i) + Environment.NewLine;
            }
        }

        private void setTxtSolutii()
        {
            TextBox txtSolutii = new TextBox();
            txtSolutii.Name = "txtSolutii";
            txtSolutii.BackColor = Color.FromArgb(40, 40, 40);
            txtSolutii.Multiline = true;
            txtSolutii.Size = new Size(495, 140);
            txtSolutii.Location = new Point(15, 195);
            txtSolutii.ForeColor = Color.Red;
            txtSolutii.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            txtSolutii.ReadOnly = true;
            txtSolutii.ScrollBars = ScrollBars.Vertical;

            Controls.Add(txtSolutii);
        }

        private void setCopy()
        {
            String path = Application.StartupPath;
            Button btnCopy = new Button();
            btnCopy.Size = new Size(24, 24);
            btnCopy.Location = new Point(485, 165);
            btnCopy.BackgroundImage = Image.FromFile(path + @"\resources\pencil_20px.png");
            btnCopy.BackgroundImageLayout = ImageLayout.Center;
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.Name = "btnCopy";

            btnCopy.Click += BtnCopy_Click;

            Controls.Add(btnCopy);
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            TextBox txtSolutii = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtSolutii")
                    txtSolutii = x as TextBox;
            }


            Clipboard.SetText(txtSolutii.Text);

        }
    }
}
