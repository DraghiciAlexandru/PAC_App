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
    class EcuatiiCombinari : Panel
    {

        public EcuatiiCombinari()
        {
            layout();
        }

        private void layout()
        {
            this.Size = new Size(525, 360);
            this.Location = new Point(0, 0);
            this.BackColor = Color.FromArgb(40, 40, 40);


            setLblC();
            setLblC2();
            setNumarN();
            setNumarM();
            setBtnRezolvaN();
            setLblEgal1();
            setLblEgal2();
            setBtnRezolvaM();
            setTotalN();
            setTotalM();
            setSolutieN();
            setSolutieM();

        }

        private void setLblC()
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "C";
            lblP.AutoSize = false;
            lblP.Size = new Size(45, 45);
            lblP.Location = new Point(70, 100);
            lblP.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Regular);

            Controls.Add(lblP);
        }

        private void setLblC2()
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "C";
            lblP.AutoSize = false;
            lblP.Size = new Size(45, 45);
            lblP.Location = new Point(70, 220);
            lblP.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Regular);

            Controls.Add(lblP);
        }

        public void setNumarN()
        {
            TextBox txtN = new TextBox();
            txtN.Name = "txtN";
            txtN.Size = new Size(30, 22);
            txtN.Location = new Point(120, 95);
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
            txtM.Location = new Point(120, 255);
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
            TextBox txtM = new TextBox();
            TextBox txtTotalM = new TextBox();
            Button btnRezM = new Button();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtM")
                    txtM = x as TextBox;
                if (x.Name == "txtTotalM")
                    txtTotalM = x as TextBox;
                if (x.Name == "btnRezM")
                    btnRezM = x as Button;
            }

            if (txtM.Text.Length > 0 && txtTotalM.Text.Length > 0)
            {
                btnRezM.Enabled = true;
            }
            else
            {
                btnRezM.Enabled = false;
            }
        }

        private void TxtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtN = sender as TextBox;
            
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtN.TextLength == 2 && !char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) 
                e.Handled = true;
            if (txtN.Text.Length == 0)
                if (e.KeyChar == '0')
                    e.Handled = true;
        }

        private void TxtN_TextChanged(object sender, EventArgs e)
        {
            TextBox txtN = new TextBox();
            TextBox txtTotalN = new TextBox();
            Button btnRezN = new Button();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
                if (x.Name == "txtTotalN")
                    txtTotalN = x as TextBox;
                if(x.Name== "btnRezN")
                    btnRezN=x as Button;
            }

            if (txtN.Text.Length > 0 && txtTotalN.Text.Length > 0) 
            {
                btnRezN.Enabled = true;
            }
            else
            {
                btnRezN.Enabled = false;
            }

        }

        private void setLblEgal1()
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "=";
            lblP.AutoSize = false;
            lblP.Size = new Size(30, 30);
            lblP.Location = new Point(155, 115);
            lblP.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Regular);

            Controls.Add(lblP);
        }

        private void setLblEgal2()
        {
            Label lblP = new Label();
            lblP.ForeColor = Color.Red;
            lblP.Text = "=";
            lblP.AutoSize = false;
            lblP.Size = new Size(30, 30);
            lblP.Location = new Point(155, 235);
            lblP.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Regular);

            Controls.Add(lblP);
        }

        private void setBtnRezolvaN()
        {
            String path = Application.StartupPath;
            Button btnRezN = new Button();
            btnRezN.Location = new Point(240, 115);
            btnRezN.Size = new Size(120, 30);
            btnRezN.Text = "  Rezolva";
            btnRezN.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            btnRezN.ForeColor = Color.Red;
            btnRezN.FlatStyle = FlatStyle.Flat;
            btnRezN.Image = Image.FromFile(path + @"\resources\xamarin_20px.png");

            btnRezN.Name = "btnRezN";

            btnRezN.TextAlign = ContentAlignment.MiddleRight;
            btnRezN.ImageAlign = ContentAlignment.TopLeft;
            btnRezN.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRezN.Enabled = false;

            btnRezN.Click += BtnRezN_Click;

            this.Controls.Add(btnRezN);
        }

        private void BtnRezN_Click(object sender, EventArgs e)
        {
            TextBox txtN = new TextBox();
            TextBox txtTotalN = new TextBox();
            Label lblSN = new Label();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
                if (x.Name == "txtTotalN")
                    txtTotalN = x as TextBox;
                if (x.Name == "lblSN")
                    lblSN = x as Label;
            }

            Lista<int> lista = new Lista<int>();
            Lista<int> solutie = new Lista<int>();

            for (int i = 0; i < int.Parse(txtN.Text); i++) 
            {
                lista.addFinish(i);
            }

            for (int i = int.Parse(txtN.Text); i <= 7; i++) 
            {
                Combinari<int> combinari = new Combinari<int>(lista, int.Parse(txtN.Text));
                combinari.back(0);
                if (combinari.solutii.size() == int.Parse(txtTotalN.Text)) 
                {
                    solutie.addFinish(i);
                }
                combinari.solutii.clear();
                lista.addFinish(i);
            }

            if(solutie.size()==0)
            {
                lblSN.Text = "Nu exista solutii";
            }
            else
            {
                lblSN.Text += "Solutii:" + Environment.NewLine;
                lblSN.Text += solutie.getAtPosition(0).ToString();
                for (int i=1; i<solutie.size(); i++)
                {
                    lblSN.Text += ", " + solutie.getAtPosition(i).ToString();
                    lblSN.Text += Environment.NewLine;
                }
            }
        }

        private void setBtnRezolvaM()
        {
            String path = Application.StartupPath;
            Button btnRezM = new Button();
            btnRezM.Location = new Point(240, 245);
            btnRezM.Size = new Size(120, 30);
            btnRezM.Text = "  Rezolva";
            btnRezM.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            btnRezM.ForeColor = Color.Red;
            btnRezM.FlatStyle = FlatStyle.Flat;
            btnRezM.Image = Image.FromFile(path + @"\resources\xamarin_20px.png");

            btnRezM.Name = "btnRezM";

            btnRezM.TextAlign = ContentAlignment.MiddleRight;
            btnRezM.ImageAlign = ContentAlignment.TopLeft;
            btnRezM.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRezM.Enabled = false;

            btnRezM.Click += BtnRezM_Click;

            this.Controls.Add(btnRezM);
        }

        private void BtnRezM_Click(object sender, EventArgs e)
        {
            TextBox txtM = new TextBox();
            TextBox txtTotalM = new TextBox();
            Label lblSM = new Label();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtM")
                {
                    txtM = x as TextBox;
                }
                if (x.Name == "txtTotalM")
                {
                    txtTotalM = x as TextBox;
                }
                if (x.Name == "lblSM")
                {
                    lblSM = x as Label;
                }
            }

            Lista<int> lista = new Lista<int>();
            Lista<int> solutie = new Lista<int>();

            for (int i = 0; i < int.Parse(txtM.Text); i++) 
            {
                lista.addFinish(i);
            }

            for (int i = 1; i <= int.Parse(txtM.Text); i++) 
            {
                Combinari<int> combinari = new Combinari<int>(lista, i);
                combinari.back(0);
                if (combinari.solutii.size() == int.Parse(txtTotalM.Text))
                {
                    solutie.addFinish(i);
                }
                combinari.solutii.clear();
                
            }

            if (solutie.size() == 0)
            {
                lblSM.Text = "Nu exista solutii";
            }
            else
            {
                lblSM.Text += "Solutii:" + Environment.NewLine;
                lblSM.Text += solutie.getAtPosition(0).ToString();
                for (int i = 1; i < solutie.size(); i++)
                {
                    lblSM.Text += ", " + solutie.getAtPosition(i).ToString();
                    lblSM.Text += Environment.NewLine;
                }
            }
        }

        private void setTotalN()
        {
            TextBox txtTotalN = new TextBox();
            txtTotalN.Name = "txtTotalN";
            txtTotalN.Size = new Size(30, 22);
            txtTotalN.Location = new Point(190, 120);
            txtTotalN.BackColor = Color.FromArgb(255, 70, 70);
            txtTotalN.ForeColor = Color.FromArgb(20, 20, 20);
            txtTotalN.BorderStyle = BorderStyle.None;
            txtTotalN.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            txtTotalN.KeyPress += TxtN_KeyPress;
            txtTotalN.TextChanged += TxtN_TextChanged;

            Controls.Add(txtTotalN);
        }

        private void setTotalM()
        {
            TextBox txtTotalM = new TextBox();
            txtTotalM.Name = "txtTotalM";
            txtTotalM.Size = new Size(30, 22);
            txtTotalM.Location = new Point(190, 240);
            txtTotalM.BackColor = Color.FromArgb(255, 70, 70);
            txtTotalM.ForeColor = Color.FromArgb(20, 20, 20);
            txtTotalM.BorderStyle = BorderStyle.None;
            txtTotalM.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            txtTotalM.KeyPress += TxtN_KeyPress;
            txtTotalM.TextChanged += TxtM_TextChanged;

            Controls.Add(txtTotalM);
        }

        private void setSolutieN()
        {
            Label lblSN = new Label();
            lblSN.ForeColor = Color.Red;
            lblSN.Text = "";
            lblSN.AutoSize = false;
            lblSN.Size = new Size(125, 70);
            lblSN.Location = new Point(390, 95);
            lblSN.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            lblSN.Name = "lblSN";

            Controls.Add(lblSN);
        }

        private void setSolutieM()
        {
            Label lblSM = new Label();
            lblSM.ForeColor = Color.Red;
            lblSM.Text = "";
            lblSM.AutoSize = false;
            lblSM.Size = new Size(125, 70);
            lblSM.Location = new Point(390, 230);
            lblSM.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            lblSM.Name = "lblSM";

            Controls.Add(lblSM);
        }
    }
}
