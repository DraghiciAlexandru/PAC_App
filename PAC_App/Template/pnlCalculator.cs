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
    class pnlCalculator : Panel
    {
        private ListaSimpla<Panel> lista;

        public pnlCalculator()
        {
            lista = new ListaSimpla<Panel>();
            layout();
        }

        private void layout()
        {
            this.Size = new Size(525, 360);
            this.Location = new Point(0, 0);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.ForeColor = Color.Red;
            this.MaximumSize = new Size(1000, 360);

            setPAC();
            setSimbol();
            setMaker();
            setNecunoscuta();
            setNumar();
            setBtnCalcul();
            setSolutieN();
        }


        private void setPAC()
        {
            btnPAC btnPAC = new btnPAC();
            btnPAC.Location = new Point(15, 15);

            this.Controls.Add(btnPAC);
        }

        private void setSimbol()
        {
            btnSimbol btnSimbol = new btnSimbol();
            btnSimbol.Location = new Point(225, 15);

            this.Controls.Add(btnSimbol);
        }

        private void setNecunoscuta()
        {
            pnlNecunoscuta pnlNecunoscuta = new pnlNecunoscuta();
            pnlNecunoscuta.Location = new Point(435, 15);
            this.Controls.Add(pnlNecunoscuta);
        }

        private void setMaker()
        {
            FlowLayoutPanel pnlMaker = new FlowLayoutPanel();
            pnlMaker.Name = "pnlMaker";
            pnlMaker.BorderStyle = BorderStyle.Fixed3D;
            pnlMaker.Size = new Size(300, 115);
            pnlMaker.Location = new Point(15, 195);
            pnlMaker.AllowDrop = true;
            pnlMaker.AutoScroll = true;
            pnlMaker.WrapContents = false;

            pnlMaker.DragEnter += PnlMaker_DragEnter;
            pnlMaker.DragDrop += PnlMaker_DragDrop;

            Controls.Add(pnlMaker);
        }

        private void setNumar()
        {
            TextBox txtNumar = new TextBox();
            txtNumar.Name = "txtNumar";
            txtNumar.Size = new Size(70, 22);
            txtNumar.Location = new Point(430, 235);
            txtNumar.BackColor = Color.FromArgb(255, 70, 70);
            txtNumar.ForeColor = Color.FromArgb(20, 20, 20);
            txtNumar.BorderStyle = BorderStyle.None;
            txtNumar.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            txtNumar.Visible = false;

            Controls.Add(txtNumar);
        }

        private void PnlMaker_DragDrop(object sender, DragEventArgs e)
        {
            FlowLayoutPanel pnlMaker = new FlowLayoutPanel();

            foreach(Control x in Controls)
            {
                if (x.Name == "pnlMaker")
                    pnlMaker = x as FlowLayoutPanel;
            }

            if (e.Data.GetDataPresent(typeof(pnlPermutari))) 
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlPermutari)) as Panel);
                pnlPermutari pnlPermutari = (pnlPermutari)e.Data.GetData(typeof(pnlPermutari));
                pnlPermutari.droped();
            }
            else if (e.Data.GetDataPresent(typeof(pnlPlus))) 
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlPlus)) as Panel);
                pnlPlus pnlPlus = (pnlPlus)e.Data.GetData(typeof(pnlPlus));
                pnlPlus.droped();
            }
            else if (e.Data.GetDataPresent(typeof(pnlMinus)))
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlMinus)) as Panel);
                pnlMinus pnlMinus = (pnlMinus)e.Data.GetData(typeof(pnlMinus));
                pnlMinus.droped();
            }
            else if (e.Data.GetDataPresent(typeof(pnlInmultit)))
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlInmultit)) as Panel);
                pnlInmultit pnlInmultit = (pnlInmultit)e.Data.GetData(typeof(pnlInmultit));
                pnlInmultit.droped();
            }
            else if (e.Data.GetDataPresent(typeof(pnlImpartire)))
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlImpartire)) as Panel);
                pnlImpartire pnlImpartire = (pnlImpartire)e.Data.GetData(typeof(pnlImpartire));
                pnlImpartire.droped();
            }
            else if (e.Data.GetDataPresent(typeof(pnlAranjamente)))
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlAranjamente)) as Panel);
                pnlAranjamente pnlAranjamente = (pnlAranjamente)e.Data.GetData(typeof(pnlAranjamente));
                pnlAranjamente.droped();
            }
            else if (e.Data.GetDataPresent(typeof(pnlCombinari)))
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlCombinari)) as Panel);
                pnlCombinari pnlCombinari = (pnlCombinari)e.Data.GetData(typeof(pnlCombinari));
                pnlCombinari.droped();
            }
            else if (e.Data.GetDataPresent(typeof(pnlNecunoscuta)))
            {
                pnlMaker.Controls.Add(e.Data.GetData(typeof(pnlNecunoscuta)) as Panel);
                pnlNecunoscuta pnlNecunoscuta = (pnlNecunoscuta)e.Data.GetData(typeof(pnlNecunoscuta));
                pnlNecunoscuta.droped();

                TextBox txtNumar = new TextBox();


                foreach (Control x in Controls)
                {
                    if (x.Name == "txtNumar")
                        txtNumar = x as TextBox;
                }

                txtNumar.Visible = true;
            }
        }

        private void PnlMaker_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(pnlPermutari)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlPermutari)) as Panel;

                if (lista.size() > 0)
                {
                    if (lista.getLast().Data.Name != "pnlPermutari" && lista.getLast().Data.Name != "pnlAranjamente" && lista.getLast().Data.Name != "pnlCombinari") 
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
                else
                {
                    lista.addFinish(pnlDrag);
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else if (e.Data.GetDataPresent(typeof(pnlPlus)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlPlus)) as Panel;

                if (lista.size() == 0) 
                {
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    if (lista.getLast().Data.Name != "pnlMinus" && lista.getLast().Data.Name != "pnlPlus")
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
            else if(e.Data.GetDataPresent(typeof(pnlAranjamente)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlAranjamente)) as Panel;

                if (lista.size() > 0)
                {
                    if (lista.getLast().Data.Name != "pnlPermutari" && lista.getLast().Data.Name != "pnlAranjamente" && lista.getLast().Data.Name != "pnlCombinari")
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
                else
                {
                    lista.addFinish(pnlDrag);
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else if (e.Data.GetDataPresent(typeof(pnlCombinari)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlCombinari)) as Panel;

                if (lista.size() > 0)
                {
                    if (lista.getLast().Data.Name != "pnlPermutari" && lista.getLast().Data.Name != "pnlAranjamente" && lista.getLast().Data.Name != "pnlCombinari")
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
                else
                {
                    lista.addFinish(pnlDrag);
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else if (e.Data.GetDataPresent(typeof(pnlMinus)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlMinus)) as Panel;

                if (lista.size() == 0)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    Console.WriteLine("ok");
                    if (lista.getLast().Data.Name != "pnlMinus" && lista.getLast().Data.Name != "pnlPlus") 
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
            else if (e.Data.GetDataPresent(typeof(pnlInmultit)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlInmultit)) as Panel;

                if (lista.size() == 0)
                {
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    if (lista.getLast().Data.Name != "pnlMinus" && lista.getLast().Data.Name != "pnlPlus" && lista.getLast().Data.Name != "pnlInmultit" && lista.getLast().Data.Name != "pnlImpartire") 
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
            else if (e.Data.GetDataPresent(typeof(pnlImpartire)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlImpartire)) as Panel;

                if (lista.size() == 0)
                {
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    if (lista.getLast().Data.Name != "pnlMinus" && lista.getLast().Data.Name != "pnlPlus" && lista.getLast().Data.Name != "pnlInmultit" && lista.getLast().Data.Name != "pnlImpartire")
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
            else if (e.Data.GetDataPresent(typeof(pnlNecunoscuta)))
            {
                Panel pnlDrag = e.Data.GetData(typeof(pnlNecunoscuta)) as Panel;

                if (lista.size() > 0)
                {
                    if (lista.getLast().Data.Name != "pnlPermutari" && lista.getLast().Data.Name != "pnlAranjamente" && lista.getLast().Data.Name != "pnlCombinari")
                    {
                        lista.addFinish(pnlDrag);
                        e.Effect = DragDropEffects.Copy;
                    }
                }
                else
                {
                    lista.addFinish(pnlDrag);
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void setBtnCalcul()
        {
            String path = Application.StartupPath;
            Button btnCalcul = new Button();
            btnCalcul.Location = new Point(350, 225);
            btnCalcul.Size = new Size(45, 45);
            btnCalcul.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            btnCalcul.ForeColor = Color.Red;
            btnCalcul.FlatStyle = FlatStyle.Flat;
            btnCalcul.BackgroundImage = Image.FromFile(path + @"\resources\calculator_20px.png");
            btnCalcul.BackgroundImageLayout = ImageLayout.Center;
            btnCalcul.Name = "btnCalcul";

            btnCalcul.Click += BtnCalcul_Click;

            this.Controls.Add(btnCalcul);
        }

        private void BtnCalcul_Click(object sender, EventArgs e)
        {
            int suma = 0, flag = 0, flagNecunoscuta = 0;

            for(int i=0; i<lista.size(); i++)
            {
                if (lista.getAtPosition(i) is pnlNecunoscuta)
                    flagNecunoscuta = 1;
            }

            if (flagNecunoscuta == 0)
            {
                for (int i = 0; i < lista.size(); i++)
                {
                    if (lista.getAtPosition(i) is pnlPermutari)
                    {
                        pnlPermutari pnlPermutari = lista.getAtPosition(i) as pnlPermutari;

                        if (pnlPermutari.Valid == false)
                            flag = 1;
                        else
                        {
                            if (i > 1 && lista.getAtPosition(i - 1) is pnlMinus)
                            {
                                pnlPermutari.Value = -pnlPermutari.Value;
                                lista.deletePosition(i - 1);
                                i--;
                            }
                        }
                    }
                    else if (lista.getAtPosition(i) is pnlAranjamente)
                    {
                        pnlAranjamente pnlAranjamente = lista.getAtPosition(i) as pnlAranjamente;

                        if (pnlAranjamente.Valid == false)
                            flag = 1;
                        else
                        {
                            if (i > 1 && lista.getAtPosition(i - 1) is pnlMinus)
                            {
                                pnlAranjamente.Value = -pnlAranjamente.Value;
                                lista.deletePosition(i - 1);
                                i--;
                            }
                        }
                    }
                    else if (lista.getAtPosition(i) is pnlCombinari)
                    {
                        pnlCombinari pnlCombinari = lista.getAtPosition(i) as pnlCombinari;

                        if (pnlCombinari.Valid == false)
                            flag = 1;
                        else
                        {
                            if (i > 1 && lista.getAtPosition(i - 1) is pnlMinus)
                            {
                                pnlCombinari.Value = -pnlCombinari.Value;
                                lista.deletePosition(i - 1);
                                i--;
                            }
                        }
                    }
                }

                if (flag == 0)
                {
                    Console.WriteLine("Merge");

                    TextBox txtNumar = new TextBox();

                    foreach (Control x in Controls)
                    {
                        if (x.Name == "txtNumar")
                            txtNumar = x as TextBox;
                    }

                    txtNumar.Visible = true;

                    for (int i = 0; i < lista.size(); i++)
                    {
                        if (lista.getAtPosition(i) is pnlPermutari && lista.getAtPosition(i + 1) is pnlInmultit == false && lista.getAtPosition(i + 1) is pnlImpartire == false) 
                        {
                            pnlPermutari pnlPermutari = lista.getAtPosition(i) as pnlPermutari;

                            suma += pnlPermutari.Value;

                        }
                        else if (lista.getAtPosition(i) is pnlAranjamente && lista.getAtPosition(i + 1) is pnlInmultit == false && lista.getAtPosition(i + 1) is pnlImpartire == false)
                        {
                            pnlAranjamente pnlAranjamente = lista.getAtPosition(i) as pnlAranjamente;
                            suma += pnlAranjamente.Value;

                        }
                        else if (lista.getAtPosition(i) is pnlCombinari && lista.getAtPosition(i + 1) is pnlInmultit == false && lista.getAtPosition(i + 1) is pnlImpartire == false)
                        {
                            pnlCombinari pnlCombinari = lista.getAtPosition(i) as pnlCombinari;
                            suma += pnlCombinari.Value;

                        }

                        if (lista.getAtPosition(i) is pnlInmultit || lista.getAtPosition(i) is pnlImpartire) 
                        {
                            int value1 = 0;
                            int value2 = 0;

                            if (lista.getAtPosition(i - 1) is pnlPermutari)
                            {
                                pnlPermutari pnlPermutari = lista.getAtPosition(i - 1) as pnlPermutari;
                                value1 = pnlPermutari.Value;
                            }
                            else if (lista.getAtPosition(i - 1) is pnlAranjamente)
                            {
                                pnlAranjamente pnlAranjamente = lista.getAtPosition(i - 1) as pnlAranjamente;
                                value1 = pnlAranjamente.Value;
                            }
                            else if (lista.getAtPosition(i - 1) is pnlCombinari)
                            {
                                pnlCombinari pnlCombinari = lista.getAtPosition(i - 1) as pnlCombinari;
                                value1 = pnlCombinari.Value;
                            }

                            if (lista.getAtPosition(i + 1) is pnlPermutari)
                            {
                                pnlPermutari pnlPermutari = lista.getAtPosition(i + 1) as pnlPermutari;
                                value2 = pnlPermutari.Value;
                            }
                            else if (lista.getAtPosition(i + 1) is pnlAranjamente)
                            {
                                pnlAranjamente pnlAranjamente = lista.getAtPosition(i + 1) as pnlAranjamente;
                                value2 = pnlAranjamente.Value;
                            }
                            else if (lista.getAtPosition(i + 1) is pnlCombinari)
                            {
                                pnlCombinari pnlCombinari = lista.getAtPosition(i + 1) as pnlCombinari;
                                value2 = pnlCombinari.Value;
                            }


                            if (lista.getAtPosition(i) is pnlInmultit)
                                suma += value1 * value2;
                            else
                            {
                                suma += value1 / value2;
                            }
                            i++;
                        }

                    }

                    txtNumar.Text = suma.ToString();
                }
            }
            else
            {
                TextBox txtNumar = new TextBox();
                Label lblSN = new Label();
                bool minus = false;

                foreach (Control x in Controls)
                {
                    if (x.Name == "txtNumar")
                        txtNumar = x as TextBox;
                    if (x.Name == "lblSN")
                        lblSN = x as Label;
                }

                if (txtNumar.Text.Length == 0)
                    flag = 1;

                for (int i = 0; i < lista.size(); i++)
                {
                    if (lista.getAtPosition(i) is pnlPermutari)
                    {
                        pnlPermutari pnlPermutari = lista.getAtPosition(i) as pnlPermutari;

                        if (pnlPermutari.Valid == false)
                            flag = 1;
                        else
                        {
                            if (i > 1 && lista.getAtPosition(i - 1) is pnlMinus)
                            {
                                pnlPermutari.Value = -pnlPermutari.Value;
                                lista.deletePosition(i - 1);
                                i--;
                            }
                        }
                    }
                    else if (lista.getAtPosition(i) is pnlAranjamente)
                    {
                        pnlAranjamente pnlAranjamente = lista.getAtPosition(i) as pnlAranjamente;

                        if (pnlAranjamente.Valid == false)
                            flag = 1;
                        else
                        {
                            if (i > 1 && lista.getAtPosition(i - 1) is pnlMinus)
                            {
                                pnlAranjamente.Value = -pnlAranjamente.Value;
                                lista.deletePosition(i - 1);
                                i--;
                            }
                        }
                    }
                    else if (lista.getAtPosition(i) is pnlCombinari)
                    {
                        pnlCombinari pnlCombinari = lista.getAtPosition(i) as pnlCombinari;

                        if (pnlCombinari.Valid == false)
                            flag = 1;
                        else
                        {
                            if (i > 1 && lista.getAtPosition(i - 1) is pnlMinus)
                            {
                                pnlCombinari.Value = -pnlCombinari.Value;
                                lista.deletePosition(i - 1);
                                i--;
                            }
                        }
                    }
                    else if(lista.getAtPosition(i) is pnlNecunoscuta)
                    {
                        pnlNecunoscuta pnlNecunoscuta = lista.getAtPosition(i) as pnlNecunoscuta;

                        if(lista.getAtPosition(i-1) is pnlMinus)
                        {
                            pnlNecunoscuta.Minus = true;
                            minus = true;
                        }
                    }
                }

                if (flag == 0)
                {
                    int numar = int.Parse(txtNumar.Text);
                    for (int i = 0; i < lista.size(); i++)
                    {
                        if (lista.getAtPosition(i) is pnlPermutari && lista.getAtPosition(i + 1) is pnlInmultit == false && lista.getAtPosition(i + 1) is pnlImpartire == false && lista.getAtPosition(i - 1) is pnlInmultit == false && lista.getAtPosition(i - 1) is pnlImpartire == false)
                        {
                            pnlPermutari pnlPermutari = lista.getAtPosition(i) as pnlPermutari;
                            numar -= pnlPermutari.Value;
                        }
                        else if (lista.getAtPosition(i) is pnlAranjamente && lista.getAtPosition(i + 1) is pnlInmultit == false && lista.getAtPosition(i + 1) is pnlImpartire == false && lista.getAtPosition(i - 1) is pnlInmultit == false && lista.getAtPosition(i - 1) is pnlImpartire == false)
                        {
                            pnlAranjamente pnlAranjamente = lista.getAtPosition(i) as pnlAranjamente;
                            numar -= pnlAranjamente.Value;

                        }
                        else if (lista.getAtPosition(i) is pnlCombinari && lista.getAtPosition(i + 1) is pnlInmultit == false && lista.getAtPosition(i + 1) is pnlImpartire == false && lista.getAtPosition(i - 1) is pnlInmultit == false && lista.getAtPosition(i - 1) is pnlImpartire == false)
                        {
                            pnlCombinari pnlCombinari = lista.getAtPosition(i) as pnlCombinari;
                            numar -= pnlCombinari.Value;

                        }
                    }

                    ListaSimpla<Panel> necunoscuta = new ListaSimpla<Panel>();
                    int nec = 0;
                    int inceput = 0, sfarsit = 0;

                    for (int i = 0; i < lista.size(); i++)
                    {
                        if (lista.getAtPosition(i) is pnlNecunoscuta)
                        {
                            nec = i;
                            inceput = i;
                            sfarsit = i;
                        }
                    }

                    for (int i = nec - 1; i > 0; i--)
                    {
                        if (lista.getAtPosition(i) is pnlPlus)
                            break;
                        else
                        {
                            inceput = i;
                        }
                    }

                    for (int i = nec + 1; i < lista.size(); i++)
                    {
                        if (lista.getAtPosition(i) is pnlPlus)
                            break;
                        else
                        {
                            sfarsit = i;
                        }
                    }

                    for (int i = 0; i < lista.size(); i++)
                    {
                        if (i < inceput || i > sfarsit)
                        {
                            if (lista.getAtPosition(i) is pnlInmultit || lista.getAtPosition(i) is pnlImpartire)
                            {
                                int value1 = 0;
                                int value2 = 0;

                                if (lista.getAtPosition(i - 1) is pnlPermutari)
                                {
                                    pnlPermutari pnlPermutari = lista.getAtPosition(i - 1) as pnlPermutari;
                                    value1 = pnlPermutari.Value;
                                }
                                else if (lista.getAtPosition(i - 1) is pnlAranjamente)
                                {
                                    pnlAranjamente pnlAranjamente = lista.getAtPosition(i - 1) as pnlAranjamente;
                                    value1 = pnlAranjamente.Value;
                                }
                                else if (lista.getAtPosition(i - 1) is pnlCombinari)
                                {
                                    pnlCombinari pnlCombinari = lista.getAtPosition(i - 1) as pnlCombinari;
                                    value1 = pnlCombinari.Value;
                                }

                                if (lista.getAtPosition(i + 1) is pnlPermutari)
                                {
                                    pnlPermutari pnlPermutari = lista.getAtPosition(i + 1) as pnlPermutari;
                                    value2 = pnlPermutari.Value;
                                }
                                else if (lista.getAtPosition(i + 1) is pnlAranjamente)
                                {
                                    pnlAranjamente pnlAranjamente = lista.getAtPosition(i + 1) as pnlAranjamente;
                                    value2 = pnlAranjamente.Value;
                                }
                                else if (lista.getAtPosition(i + 1) is pnlCombinari)
                                {
                                    pnlCombinari pnlCombinari = lista.getAtPosition(i + 1) as pnlCombinari;
                                    value2 = pnlCombinari.Value;
                                }


                                if (lista.getAtPosition(i) is pnlInmultit)
                                    numar -= value1 * value2;
                                else
                                {
                                    numar -= value1 / value2;
                                }
                            }
                        }
                    }

                    for (int i = inceput; i < nec; i++)
                    {
                        if (lista.getAtPosition(i) is pnlInmultit || lista.getAtPosition(i) is pnlImpartire)
                        {
                            int value1 = 0;

                            if (lista.getAtPosition(i - 1) is pnlPermutari)
                            {
                                pnlPermutari pnlPermutari = lista.getAtPosition(i - 1) as pnlPermutari;
                                value1 = pnlPermutari.Value;
                            }
                            else if (lista.getAtPosition(i - 1) is pnlAranjamente)
                            {
                                pnlAranjamente pnlAranjamente = lista.getAtPosition(i - 1) as pnlAranjamente;
                                value1 = pnlAranjamente.Value;
                            }
                            else if (lista.getAtPosition(i - 1) is pnlCombinari)
                            {
                                pnlCombinari pnlCombinari = lista.getAtPosition(i - 1) as pnlCombinari;
                                value1 = pnlCombinari.Value;
                            }

                            if (lista.getAtPosition(i) is pnlInmultit)
                                numar /= value1;
                            else
                                numar *= value1;
                        }
                    }

                    for (int i = nec; i < sfarsit; i++)
                    {
                        if (lista.getAtPosition(i) is pnlInmultit || lista.getAtPosition(i) is pnlImpartire)
                        {
                            int value1 = 0;

                            if (lista.getAtPosition(i + 1) is pnlPermutari)
                            {
                                pnlPermutari pnlPermutari = lista.getAtPosition(i + 1) as pnlPermutari;
                                value1 = pnlPermutari.Value;
                            }
                            else if (lista.getAtPosition(i + 1) is pnlAranjamente)
                            {
                                pnlAranjamente pnlAranjamente = lista.getAtPosition(i + 1) as pnlAranjamente;
                                value1 = pnlAranjamente.Value;
                            }
                            else if (lista.getAtPosition(i + 1) is pnlCombinari)
                            {
                                pnlCombinari pnlCombinari = lista.getAtPosition(i + 1) as pnlCombinari;
                                value1 = pnlCombinari.Value;
                            }

                            if (lista.getAtPosition(i) is pnlInmultit)
                                numar /= value1;
                            else
                                numar *= value1;
                        }
                    }

                    if (minus == true)
                        numar = -numar;
                    lblSN.Visible = true;
                    lblSN.Text = "X este " + numar.ToString();

                }
            }
        }

        private void setSolutieN()
        {
            Label lblSN = new Label();
            lblSN.ForeColor = Color.Red;
            lblSN.Text = "";
            lblSN.AutoSize = false;
            lblSN.Size = new Size(125, 70);
            lblSN.Location = new Point(420, 270);
            lblSN.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            lblSN.Visible = false;
            lblSN.Name = "lblSN";

            Controls.Add(lblSN);
        }

    }
}
