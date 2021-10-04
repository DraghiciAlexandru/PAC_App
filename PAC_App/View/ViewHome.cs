using PAC_App.Template;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_App.View
{
    class ViewHome : Form
    {
        private Panel Header;
        private FlowLayoutPanel Aside;
        private Panel Main;

        private bool move;
        private int x;
        private int y;
        
        public ViewHome()
        {
            Header = new Panel();
            Aside = new FlowLayoutPanel();
            Main = new Panel();
            move = false;
            x = 0;
            y = 0;

            layout();
        }

        private void layout()
        {
            setForm();
            setHeader(Header);
            setAside(Aside);
            setMain(Main);
        }

        private void setForm()
        {
            String path = Application.StartupPath;
            this.Size = new Size(700, 400);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Icon = new Icon(path + @"\resources\math.ico");
        }

        private void setHeader(Panel header)
        {
            header.Location = new Point(0, 0);
            header.Size = new Size(700, 40);
            header.BackColor = Color.FromArgb(20, 20, 20);
            header.BorderStyle = BorderStyle.FixedSingle;

            header.MouseDown += Header_MouseDown;
            header.MouseMove += Header_MouseMove;
            header.MouseUp += Header_MouseUp;

            setExit(header);
            setMinimize(header);
            setIcon(header);
            setNume(header);

            Controls.Add(header);
        }

        private void Header_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if(move==true)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                move = true;
                x = e.X;
                y = e.Y;
            }
        }

        private void setIcon(Panel header)
        {
            String path = Application.StartupPath;
            PictureBox picture = new PictureBox();
            picture.BackgroundImage = Image.FromFile(path + @"\resources\math_32.png");
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.Size = new Size(32, 32);
            picture.Location = new Point(15, 4);

            header.Controls.Add(picture);
        }

        private void setNume(Panel header)
        {
            Label lblSN = new Label();
            lblSN.ForeColor = Color.Red;
            lblSN.Text = "PAC";
            lblSN.Location = new Point(55, 5);
            lblSN.Font = new Font("Modern No. 20", 20, FontStyle.Bold);

            lblSN.Name = "lblSN";

            header.Controls.Add(lblSN);
        }

        private void setExit(Panel header)
        {
            String path = Application.StartupPath;
            Button btnExit = new Button();
            btnExit.Size = new Size(25, 25);
            btnExit.Location = new Point(675, -1);

            btnExit.BackgroundImage = Image.FromFile(path + @"\resources\exit.png");
            btnExit.BackgroundImageLayout = ImageLayout.Stretch;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.BackColor = Color.Transparent;

            btnExit.Click += BtnExit_Click;

            header.Controls.Add(btnExit);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setMinimize(Panel header)
        {
            String path = Application.StartupPath;
            Button btnMin = new Button();
            btnMin.Size = new Size(25, 25);
            btnMin.Location = new Point(650, -1);

            btnMin.BackgroundImage = Image.FromFile(path + @"\resources\compress.png");
            btnMin.BackgroundImageLayout = ImageLayout.Center;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.BackColor = Color.Transparent;

            btnMin.Click += BtnMin_Click;

            header.Controls.Add(btnMin);
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void setAside(FlowLayoutPanel aside)
        {
            aside.Location = new Point(0, 40);
            aside.Size = new Size(175, 360);
            aside.BackColor = Color.FromArgb(20, 20, 20);
            aside.AutoScroll = true;

            setBtnPAC(aside);
            setBtnEcuatii(aside);
            setBtnRezultat(aside);
            setBtnMake(aside);

            Controls.Add(aside);
        }

        private void setBtnPAC(FlowLayoutPanel aside)
        {
            ButtonPAC btnPAC = new ButtonPAC(Main);
            btnPAC.Location = new Point(10, 0);
            aside.Controls.Add(btnPAC);
        }

        private void setBtnEcuatii(FlowLayoutPanel aside)
        {
            ButtonEcuatii btnEcuatii = new ButtonEcuatii(Main);
            btnEcuatii.Location = new Point(5, 40);
            aside.Controls.Add(btnEcuatii);
        }

        private void setBtnRezultat(FlowLayoutPanel aside)
        {
            ButtonRezultat btnRezultat = new ButtonRezultat(Main);
            btnRezultat.Location = new Point(5, 40);
            aside.Controls.Add(btnRezultat);
        }

        private void setBtnMake(FlowLayoutPanel aside)
        {
            String path = Application.StartupPath;
            Button btnMake = new Button();
            btnMake.Size = new Size(150, 40);
            btnMake.Location = new Point(5, 0);
            btnMake.FlatStyle = FlatStyle.Flat;
            btnMake.Name = "btnMake";
            btnMake.Text = "Calculeaza";
            btnMake.Image = Image.FromFile(path + @"\resources\photomath_20px.png");

            btnMake.ForeColor = Color.Red;
            btnMake.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            btnMake.FlatAppearance.BorderSize = 0;

            btnMake.TextAlign = ContentAlignment.MiddleLeft;
            btnMake.ImageAlign = ContentAlignment.MiddleLeft;
            btnMake.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnMake.Click += BtnMake_Click;

            aside.Controls.Add(btnMake);
        }

        private void BtnMake_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            pnlCalculator pnlCalculator = new pnlCalculator();
            pnlCalculator.Location = new Point(0, 0);
            Main.Controls.Add(pnlCalculator);
        }

        private void setMain(Panel main)
        {
            main.Location = new Point(175, 40);
            main.Size = new Size(525, 360);
            main.BackColor = Color.FromArgb(40, 40, 40);


            Controls.Add(main);
        }

    }
}
