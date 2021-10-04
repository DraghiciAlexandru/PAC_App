using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.Template
{
    class pnlNecunoscuta : Panel
    {
        public int Id { get; private set; }
        public bool Minus { get; set; }

        public pnlNecunoscuta()
        {
            Id = 8;
            Minus = false;
            layout();
        }

        private void layout()
        {
            String path = Application.StartupPath;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Size = new Size(80, 80);
            this.Name = "pnlNecunoscuta";

            this.MouseDown += PnlPlus_MouseDown;
            this.BackgroundImage = Image.FromFile(path + @"\resources\x_coordinate.png");
            this.BackgroundImageLayout = ImageLayout.Center;

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
