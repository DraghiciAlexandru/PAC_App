using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.Template
{
    class ButtonPAC : Panel 
    {
        private bool collapsed;
        private Timer timer;
        private Panel Main;

        public ButtonPAC(Panel Main)
        {
            this.Main = Main;
            collapsed = true;
            timer = new Timer();
            layout();
        }

        private void layout()
        {
            this.Size = new Size(150, 40);
            this.MaximumSize = new Size(150, 115);
            this.MinimumSize = new Size(150, 40);

            setBtnProbleme();
            setBtnPermutari();
            setBtnAranjamente();
            setBtnCombinari();
            setTimer();

        }

        private void setBtnProbleme()
        {
            String path = Application.StartupPath;
            Button btnProbleme = new Button();
            btnProbleme.Size = new Size(150, 40);
            btnProbleme.Location = new Point(0, 0);
            btnProbleme.FlatStyle = FlatStyle.Flat;
            btnProbleme.Name = "btnProbleme";
            btnProbleme.Text = "Probleme simple";
            btnProbleme.Image = Image.FromFile(path + @"\resources\calculator_20px.png");

            btnProbleme.ForeColor = Color.Red;
            btnProbleme.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            btnProbleme.FlatAppearance.BorderSize = 0;

            btnProbleme.TextAlign = ContentAlignment.MiddleLeft;
            btnProbleme.ImageAlign = ContentAlignment.MiddleLeft;
            btnProbleme.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnProbleme.Click += BtnProbleme_Click;

            this.Controls.Add(btnProbleme);
        }

        private void BtnProbleme_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void setBtnPermutari()
        {
            String path = Application.StartupPath;
            Button btnPermutari = new Button();
            btnPermutari.Size = new Size(150, 25);
            btnPermutari.Location = new Point(0, 40);
            btnPermutari.FlatStyle = FlatStyle.Flat;
            btnPermutari.Name = "btnPermutari";
            btnPermutari.Text = "Permutari";
            btnPermutari.BackColor = Color.FromArgb(255, 70, 70);
            btnPermutari.ForeColor = Color.FromArgb(20, 20, 20);
            btnPermutari.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            btnPermutari.FlatAppearance.BorderSize = 0;

            btnPermutari.Click += BtnPermutari_Click;

            this.Controls.Add(btnPermutari);
        }

        private void BtnPermutari_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            PSPermutari perm = new PSPermutari();
            perm.Location = new Point(0, 0);
            Main.Controls.Add(perm);
        }

        private void setBtnAranjamente()
        {
            String path = Application.StartupPath;
            Button btnAranjamente = new Button();
            btnAranjamente.Size = new Size(150, 25);
            btnAranjamente.Location = new Point(0, 65);
            btnAranjamente.FlatStyle = FlatStyle.Flat;
            btnAranjamente.Name = "btnAranjamente";
            btnAranjamente.Text = "Aranjamente";
            btnAranjamente.BackColor = Color.FromArgb(255, 70, 70);
            btnAranjamente.ForeColor = Color.FromArgb(20, 20, 20);
            btnAranjamente.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            btnAranjamente.FlatAppearance.BorderSize = 0;

            btnAranjamente.Click += BtnAranjamente_Click;

            this.Controls.Add(btnAranjamente);
        }

        private void BtnAranjamente_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            PSAranjamente aranj = new PSAranjamente();
            aranj.Location = new Point(0, 0);
            Main.Controls.Add(aranj);
        }

        private void setBtnCombinari()
        {
            String path = Application.StartupPath;
            Button btnCombinari = new Button();
            btnCombinari.Size = new Size(150, 25);
            btnCombinari.Location = new Point(0, 90);
            btnCombinari.FlatStyle = FlatStyle.Flat;
            btnCombinari.Name = "btnCombinari";
            btnCombinari.Text = "Combinari";
            btnCombinari.BackColor = Color.FromArgb(255, 70, 70);
            btnCombinari.ForeColor = Color.FromArgb(20, 20, 20);
            btnCombinari.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            btnCombinari.FlatAppearance.BorderSize = 0;

            btnCombinari.Click += BtnCombinari_Click;

            this.Controls.Add(btnCombinari);
        }

        private void BtnCombinari_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            PSCombinari comb = new PSCombinari();
            comb.Location = new Point(0, 0);
            Main.Controls.Add(comb);
        }

        private void setTimer()
        {
            timer.Interval = 15;

            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (collapsed == true) 
            {
                this.Height += 10;
                if (this.Size == this.MaximumSize) 
                {
                    timer.Stop();
                    collapsed = false;
                }
            }
            else
            {
                this.Height -= 10;
                if (this.Size == this.MinimumSize)
                {
                    timer.Stop();
                    collapsed = true;
                }
            }
        }
    }
}
