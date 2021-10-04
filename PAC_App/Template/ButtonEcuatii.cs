using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.Template
{
    class ButtonEcuatii : Button
    {
        private bool collapsed;
        private Timer timer;
        private Panel Main;

        public ButtonEcuatii(Panel Main)
        {
            this.Main = Main;
            collapsed = true;
            timer = new Timer();
            layout();
        }

        private void layout()
        {
            this.Size = new Size(150, 40);
            this.MaximumSize = new Size(150, 90);
            this.MinimumSize = new Size(150, 40);

            setBtnProbleme();
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
            btnProbleme.Text = "Ecuatii";
            btnProbleme.Image = Image.FromFile(path + @"\resources\x_coordinate_20px.png");

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


        private void setBtnAranjamente()
        {
            String path = Application.StartupPath;
            Button btnAranjamente = new Button();
            btnAranjamente.Size = new Size(150, 25);
            btnAranjamente.Location = new Point(0, 40);
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
            EcuatiiAranjamente ecuatii = new EcuatiiAranjamente();
            ecuatii.Location = new Point(0, 0);
            Main.Controls.Add(ecuatii);
        }

        private void setBtnCombinari()
        {
            String path = Application.StartupPath;
            Button btnCombinari = new Button();
            btnCombinari.Size = new Size(150, 25);
            btnCombinari.Location = new Point(0, 65);
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
            EcuatiiCombinari ecuatii = new EcuatiiCombinari();
            ecuatii.Location = new Point(0, 0);
            Main.Controls.Add(ecuatii);
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
