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
    class RezultatPermutari : Panel
    {
        private Lista<String> lista;

        public RezultatPermutari()
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
        }

        private void setLbl()
        {
            Label lblText = new Label();
            lblText.Text = "Introduceti un element:";
            lblText.AutoSize = false;
            lblText.Size = new Size(180, 20);
            lblText.Location = new Point(175, 35);
            lblText.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            Controls.Add(lblText);
        }

        private void setTxtElement()
        {
            TextBox txtElement = new TextBox();
            txtElement.Name = "txtElement";
            txtElement.BackColor = Color.FromArgb(255, 70, 70);
            txtElement.Size = new Size(135, 26);
            txtElement.Location = new Point(195, 60);
            txtElement.ForeColor = Color.FromArgb(20, 20, 20);
            txtElement.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            txtElement.KeyDown += TxtElement_KeyDown;

            Controls.Add(txtElement);
        }

        private void TxtElement_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtElement = new TextBox();
            Button btnAfisare = new Button();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtElement")
                    txtElement = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
            }

            if (e.KeyData == Keys.Enter && txtElement.Text != "") 
            {
                if (lista.position(txtElement.Text) == -1)
                {
                    lista.addFinish(txtElement.Text);
                    txtElement.Text = "";
                    if (lista.size() > 1)
                        btnAfisare.Enabled = true;
                }
            }
        }

        private void setBtnEnter()
        {
            String path = Application.StartupPath;
            Button btnEnter = new Button();
            btnEnter.Size = new Size(24, 24);
            btnEnter.Location = new Point(335, 62);
            btnEnter.BackgroundImage = Image.FromFile(path + @"\resources\ok_20px.png");
            btnEnter.BackgroundImageLayout = ImageLayout.Center;
            btnEnter.FlatStyle = FlatStyle.Flat;

            btnEnter.Click += BtnEnter_Click;

            Controls.Add(btnEnter);
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            TextBox txtElement = new TextBox();
            Button btnAfisare = new Button();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtElement")
                    txtElement = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
            }

            if (txtElement.Text != "")
            {
                if (lista.position(txtElement.Text) == -1)
                {
                    lista.addFinish(txtElement.Text);
                    txtElement.Text = "";
                    if (lista.size() > 1)
                        btnAfisare.Enabled = true;
                }
            }
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
            foreach (Control x in Controls)
            {
                if (x.Name == "txtSolutii")
                    txtSolutii = x as TextBox;
                if (x.Name == "btnAfisare")
                    btnAfisare = x as Button;
            }

            txtSolutii.Text = "";

            Permutari<String> permutari = new Permutari<string>(lista);
            permutari.back(0);

            for (int i = 0; i < permutari.solutii.size(); i++) 
            {
                txtSolutii.Text += permutari.solutii.getAtPosition(i) + Environment.NewLine;
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
            //
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
