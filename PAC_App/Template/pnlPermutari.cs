﻿using PAC_App.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.Template
{
    class pnlPermutari : Panel, IPanel
    {
        public bool Valid { get; private set; }
        public int Value { get; set; }
        public int Id { get; private set; }

        public pnlPermutari()
        {
            Id = 1;
            layout();
        }

        private void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Size = new Size(80, 80);
            this.Name = "pnlPermutari";

            this.MouseDown += PnlPermutari_MouseDown;

            setLblP();
            setTxtN();

            foreach(Control x in Controls)
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
            lblP.Text = "P";
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
            txtN.Location = new Point(45, 29);
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
            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
            }

            if (txtN.Text.Length != 0) 
            {
                int nr = int.Parse(txtN.Text);
                if (nr > 7) 
                {
                    nr = 7;
                    txtN.Text = nr.ToString();
                }
                Valid = true;

                Lista<int> lista = new Lista<int>();

                for(int i=0; i<nr; i++)
                {
                    lista.addFinish(i);
                }

                Permutari<int> permutari = new Permutari<int>(lista);
                permutari.back(0);
                Value = permutari.solutii.size();
                permutari.solutii.clear();
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
            foreach (Control x in Controls)
            {
                if (x.Name == "txtN")
                    txtN = x as TextBox;
            }
            txtN.Enabled = true;
            this.MouseDown -= PnlPermutari_MouseDown;
            foreach (Control x in Controls)
            {
                x.MouseDown -= PnlPermutari_MouseDown;
            }
        }
    }
}
