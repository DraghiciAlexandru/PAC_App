﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.Template
{
    class pnlInmultit : Panel
    {
        public int Id { get; private set; }

        public pnlInmultit()
        {
            Id = 6;
            layout();
        }

        private void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Size = new Size(80, 80);
            this.Name = "pnlInmultit";

            this.MouseDown += PnlPlus_MouseDown;

            setLblP();

            foreach (Control x in Controls)
            {
                x.MouseDown += PnlPlus_MouseDown;
            }
        }

        private void PnlPlus_MouseDown(object sender, MouseEventArgs e)
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
            lblP.Text = "*";
            lblP.AutoSize = false;
            lblP.Size = new Size(45, 45);
            lblP.Location = new Point(20, 20);
            lblP.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Regular);

            Controls.Add(lblP);
        }

        public void droped()
        {
            this.MouseDown -= PnlPlus_MouseDown;
            foreach (Control x in Controls)
            {
                x.MouseDown -= PnlPlus_MouseDown;
            }
        }
    }
}
