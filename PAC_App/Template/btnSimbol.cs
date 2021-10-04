using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.Template
{
    class btnSimbol : FlowLayoutPanel
    {
        private bool collapsed;
        private Timer timer;



        public btnSimbol()
        {
            collapsed = true;
            timer = new Timer();
            layout();
        }

        private void layout()
        {
            this.Size = new Size(195, 40);
            this.MaximumSize = new Size(195, 160);
            this.MinimumSize = new Size(195, 40);

            setBtnProbleme();
            setTimer();
            setPnlMinus();
            setPnlPlus();
            setPnlInmultit();
            setPnlImpartire();
        }

        private void setBtnProbleme()
        {
            String path = Application.StartupPath;
            Button btnProbleme = new Button();
            btnProbleme.Size = new Size(165, 40);
            btnProbleme.Location = new Point(0, 0);
            btnProbleme.FlatStyle = FlatStyle.Flat;
            btnProbleme.Name = "btnProbleme";
            btnProbleme.Text = "Semne";
            btnProbleme.Image = Image.FromFile(path + @"\resources\expand_arrow_20px.png");

            btnProbleme.ForeColor = Color.Red;
            btnProbleme.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            btnProbleme.FlatAppearance.BorderSize = 0;

            btnProbleme.TextAlign = ContentAlignment.MiddleRight;
            btnProbleme.TextImageRelation = TextImageRelation.TextBeforeImage;

            btnProbleme.Click += BtnProbleme_Click;

            this.Controls.Add(btnProbleme);
        }

        private void BtnProbleme_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void setTimer()
        {
            timer.Interval = 15;

            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            String path = Application.StartupPath;
            Button btn = new Button();
            foreach (Control x in Controls)
            {
                if (x.Name == "btnProbleme")
                    btn = x as Button;
            }
            if (collapsed == true)
            {
                this.AutoScroll = true;
                this.Height += 10;
                btn.Image = Image.FromFile(path + @"\resources\collapse_arrow_20px.png");
                if (this.Size == this.MaximumSize)
                {
                    timer.Stop();
                    collapsed = false;
                }
            }
            else
            {
                this.AutoScroll = false;
                this.Height -= 10;
                btn.Image = Image.FromFile(path + @"\resources\expand_arrow_20px.png");
                if (this.Size == this.MinimumSize)
                {
                    timer.Stop();
                    collapsed = true;
                }
            }
        }

        private void setPnlPlus()
        {
            pnlPlus pnlPlus = new pnlPlus();
            this.Controls.Add(pnlPlus);
        }

        private void setPnlMinus()
        {
            pnlMinus pnlMinus = new pnlMinus();
            this.Controls.Add(pnlMinus);
        }

        private void setPnlInmultit()
        {
            pnlInmultit pnlInmultit = new pnlInmultit();
            this.Controls.Add(pnlInmultit);
        }

        private void setPnlImpartire()
        {
            pnlImpartire pnlImpartire = new pnlImpartire();
            this.Controls.Add(pnlImpartire);
        }
    }
}
