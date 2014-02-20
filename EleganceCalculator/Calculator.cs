using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;

namespace EleganceCalculator
{
    public partial class Calculator : Form
    {
        List<string> Equation = new List<String>();
        bool nextNumber = true;
        bool more = false;
        bool dot = false;
        double memory = 0.0;
        public Calculator()
        {
            InitializeComponent();

            #region FORM RESHAPER
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            this.Region = BitmapToRegion.getRegionFast((Bitmap)this.BackgroundImage, Color.FromArgb(0, 255, 0), 100);
            #endregion

        }

        PrivateFontCollection pfc = new PrivateFontCollection();
        int x = 2;

        private void buttonOFF_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Elegance Calculator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    Environment.Exit(0);
                    break;
                default:
                    return;
            }
        }

        #region NUMBERS BUTTONS
        private void button0_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "0";
                more = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "1";
                more = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "2";
                more = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "3";
                more = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "4";
                more = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "5";
                more = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "6";
                more = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "7";
                more = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "8";
                more = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (nextNumber == true)
            {
                labelNumbers.Text = "";
                nextNumber = false;
            }
            if (labelNumbers.Text.Length < 8)
            {
                labelNumbers.Text += "9";
                more = false;
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (nextNumber == true && labelNumbers.Text.Length < 7 && dot == false)
                labelNumbers.Text = "0.";
            else if (nextNumber == false && labelNumbers.Text.Length < 7 && dot == false)
                labelNumbers.Text += ".";
            nextNumber = false;
            more = false;
            dot = true;
        }
        #endregion

        #region OP BUTTONS
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (more == true)
            {
                nextNumber = false;
                more = false;
            }
            if (nextNumber == false)
            {
                Equation.Add(labelNumbers.Text);
                Equation.Add("+");
                if (Equation.Count == 4)
                {
                    if (Equation[1] == "+")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) + Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "-")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) - Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "*")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) * Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "/")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) / Convert.ToDouble(Equation[2]));
                    Equation.RemoveRange(1, 2);
                    labelNumbers.Text = Equation[0];
                    if (labelNumbers.Text.Length > 8 && dot == false)
                    {
                        if (labelMemory.Visible == false)
                        {
                            labelDivide.Visible = false;
                            labelError.Visible = false;
                        }
                        else
                            labelError.Visible = false;
                        labelNumbers.Text = "ERROR";
                        button0.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        buttonDot.Enabled = true;
                        buttonC.Enabled = false;
                        buttonPlus.Enabled = false;
                        buttonMinus.Enabled = false;
                        buttonMultiply.Enabled = false;
                        buttonDivide.Enabled = false;
                        buttonSquareRoot.Enabled = false;
                        buttonPercent.Enabled = false;
                        buttonEqual.Enabled = false;
                        buttonMRC.Enabled = false;
                        buttonMPlus.Enabled = false;
                        buttonMMinus.Enabled = false;
                        if (Equation.Count == 4)
                            Equation.RemoveRange(0, 4);
                    }
                    else if (labelNumbers.Text.Length > 8 && dot == true)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (labelNumbers.Text[i] == '.')
                                labelNumbers.Text = labelNumbers.Text.Substring(0, 8);
                            else
                            {
                                if (labelMemory.Visible == false)
                                {
                                    labelDivide.Visible = false;
                                    labelError.Visible = false;
                                }
                                else
                                    labelError.Visible = false;
                                labelNumbers.Text = "ERROR";
                                button0.Enabled = false;
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;
                                button6.Enabled = false;
                                button7.Enabled = false;
                                button8.Enabled = false;
                                button9.Enabled = false;
                                buttonDot.Enabled = true;
                                buttonC.Enabled = false;
                                buttonPlus.Enabled = false;
                                buttonMinus.Enabled = false;
                                buttonMultiply.Enabled = false;
                                buttonDivide.Enabled = false;
                                buttonSquareRoot.Enabled = false;
                                buttonPercent.Enabled = false;
                                buttonEqual.Enabled = false;
                                buttonMRC.Enabled = false;
                                buttonMPlus.Enabled = false;
                                buttonMMinus.Enabled = false;
                                if (Equation.Count == 4)
                                    Equation.RemoveRange(0, 4);
                            }
                        }
                    }
                }
            }
            nextNumber = true;
            dot = false;
            if (Equation.Count == 2)
                Equation[1] = "+";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (more == true)
            {
                nextNumber = false;
                more = false;
            }
            if (nextNumber == false)
            {
                Equation.Add(labelNumbers.Text);
                Equation.Add("-");
                if (Equation.Count == 4)
                {
                    if (Equation[1] == "+")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) + Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "-")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) - Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "*")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) * Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "/")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) / Convert.ToDouble(Equation[2]));
                    Equation.RemoveRange(1, 2);
                    labelNumbers.Text = Equation[0];
                }
            }
            nextNumber = true;
            dot = false;
            if (Equation.Count == 2)
                Equation[1] = "-";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (more == true)
            {
                nextNumber = false;
                more = false;
            }
            if (nextNumber == false)
            {
                Equation.Add(labelNumbers.Text);
                Equation.Add("*");
                if (Equation.Count == 4)
                {
                    if (Equation[1] == "+")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) + Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "-")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) - Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "*")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) * Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "/")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) / Convert.ToDouble(Equation[2]));
                    Equation.RemoveRange(1, 2);
                    labelNumbers.Text = Equation[0];
                    if (labelNumbers.Text.Length > 8 && dot == false)
                    {
                        if (labelMemory.Visible == false)
                        {
                            labelDivide.Visible = false;
                            labelError.Visible = false;
                        }
                        else
                            labelError.Visible = false;
                        labelNumbers.Text = "ERROR";
                        button0.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        buttonDot.Enabled = true;
                        buttonC.Enabled = false;
                        buttonPlus.Enabled = false;
                        buttonMinus.Enabled = false;
                        buttonMultiply.Enabled = false;
                        buttonDivide.Enabled = false;
                        buttonSquareRoot.Enabled = false;
                        buttonPercent.Enabled = false;
                        buttonEqual.Enabled = false;
                        buttonMRC.Enabled = false;
                        buttonMPlus.Enabled = false;
                        buttonMMinus.Enabled = false;
                        if (Equation.Count == 4)
                            Equation.RemoveRange(0, 4);
                    }
                    else if (labelNumbers.Text.Length > 8 && dot == true)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (labelNumbers.Text[i] == '.')
                                labelNumbers.Text = labelNumbers.Text.Substring(0, 8);
                            else
                            {
                                if (labelMemory.Visible == false)
                                {
                                    labelDivide.Visible = false;
                                    labelError.Visible = false;
                                }
                                else
                                    labelError.Visible = false;
                                labelNumbers.Text = "ERROR";
                                button0.Enabled = false;
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;
                                button6.Enabled = false;
                                button7.Enabled = false;
                                button8.Enabled = false;
                                button9.Enabled = false;
                                buttonDot.Enabled = true;
                                buttonC.Enabled = false;
                                buttonPlus.Enabled = false;
                                buttonMinus.Enabled = false;
                                buttonMultiply.Enabled = false;
                                buttonDivide.Enabled = false;
                                buttonSquareRoot.Enabled = false;
                                buttonPercent.Enabled = false;
                                buttonEqual.Enabled = false;
                                buttonMRC.Enabled = false;
                                buttonMPlus.Enabled = false;
                                buttonMMinus.Enabled = false;
                                if (Equation.Count == 4)
                                    Equation.RemoveRange(0, 4);
                            }
                        }
                    }
                }
            }
            nextNumber = true;
            dot = false;
            if (Equation.Count == 2)
                Equation[1] = "*";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (more == true)
            {
                nextNumber = false;
                more = false;
            }
            if (nextNumber == false)
            {
                Equation.Add(labelNumbers.Text);
                Equation.Add("/");
                if (Equation.Count == 4)
                {
                    if (Equation[1] == "+")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) + Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "-")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) - Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "*")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) * Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "/")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) / Convert.ToDouble(Equation[2]));
                    Equation.RemoveRange(1, 2);
                    labelNumbers.Text = Equation[0];
                }
            }
            nextNumber = true;
            dot = false;
            if (Equation.Count == 2)
                Equation[1] = "/";
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            labelNumbers.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(labelNumbers.Text)));
            nextNumber = true;
            dot = false;
            more = true;
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (Equation.Count == 0)
                labelNumbers.Text = Convert.ToString(Convert.ToDouble(labelNumbers.Text) / 100);
            if (Equation.Count == 2)
                labelNumbers.Text = Convert.ToString(Convert.ToDouble(Equation[0]) * Convert.ToDouble(labelNumbers.Text) / 100.0);
            nextNumber = true;
            dot = false;
            more = true;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (more == true)
            {
                nextNumber = false;
                more = false;
            }
            if (nextNumber == false)
            {
                if (Equation.Count == 2)
                {
                    Equation.Add(labelNumbers.Text);
                    if (Equation[1] == "+")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) + Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "-")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) - Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "*")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) * Convert.ToDouble(Equation[2]));
                    else if (Equation[1] == "/")
                        Equation[0] = Convert.ToString(Convert.ToDouble(Equation[0]) / Convert.ToDouble(Equation[2]));
                    labelNumbers.Text = Equation[0];
                    Equation.RemoveRange(0, 3);
                    if (labelNumbers.Text.Length > 8 && dot == false)
                    {
                        if (labelMemory.Visible == false)
                        {
                            labelDivide.Visible = false;
                            labelError.Visible = false;
                        }
                        else
                            labelError.Visible = false;
                        labelNumbers.Text = "ERROR";
                        if (Equation.Count == 4)
                            Equation.RemoveRange(0, 4);
                        nextNumber = true;
                    }
                }
            }
            nextNumber = true;
            dot = false;
            more = true;
        }

        #endregion

        #region CLEAR BUTTONS
        private void buttonC_Click(object sender, EventArgs e)
        {
            labelNumbers.Text = "0";
            nextNumber = true;
            more = false;
            dot = false;
        }

        private void buttonAC_Click(object sender, EventArgs e)
        {
            labelNumbers.Text = "0";
            if (Equation.Count == 2)
                Equation.RemoveRange(0, 2);
            nextNumber = true;
            more = false;
            dot = false;
            labelMemory.Visible = true;
            labelDivide.Visible = true;
            labelError.Visible = true;
            button0.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            buttonDot.Enabled = true;
            buttonC.Enabled = true;
            buttonPlus.Enabled = true;
            buttonMinus.Enabled = true;
            buttonMultiply.Enabled = true;
            buttonDivide.Enabled = true;
            buttonSquareRoot.Enabled = true;
            buttonPercent.Enabled = true;
            buttonEqual.Enabled = true;
            buttonMRC.Enabled = true;
            buttonMPlus.Enabled = true;
            buttonMMinus.Enabled = true;
        }
        #endregion

        #region MEMORY BUTTONS
        private void buttonMRC_Click(object sender, EventArgs e)
        {
            labelMemory.Visible = true;
            labelNumbers.Text = Convert.ToString(memory);
            memory = 0.0;
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            labelMemory.Visible = false;
            memory = memory + Convert.ToDouble(labelNumbers.Text);
            nextNumber = true;
            more = true;
            dot = false;
        }

        private void buttonMMinus_Click(object sender, EventArgs e)
        {
            labelMemory.Visible = false;
            memory = memory - Convert.ToDouble(labelNumbers.Text);
            nextNumber = true;
            more = true;
            dot = false;
        }
        #endregion

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            switch (x)
            {
                case 0:
                    this.BackgroundImage = Properties.Resources.EleganceCalculatorBlack;
                    btnChangeColor.BackgroundImage = Properties.Resources.ChangeColorBlack;
                    btnChangeColor.FlatAppearance.BorderColor = Color.Black;
                    btnChangeColor.BackColor = Color.Black;
                    x++;
                    break;
                case 1:
                    this.BackgroundImage = Properties.Resources.EleganceCalculatorWhite;
                    btnChangeColor.BackgroundImage = Properties.Resources.ChangeColorWhite;
                    btnChangeColor.FlatAppearance.BorderColor = Color.White;
                    btnChangeColor.BackColor = Color.White;
                    x++;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.EleganceCalculatorGray;
                    btnChangeColor.BackgroundImage = Properties.Resources.ChangeColorGray;
                    btnChangeColor.FlatAppearance.BorderColor = Color.Gray;
                    btnChangeColor.BackColor = Color.Gray;
                    x = 0;
                    break;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("EleganceCalculator.digital-7.ttf");

            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            fontStream.Close();
            unsafe
            {
                fixed (byte* pFontData = fontdata)
                {
                    pfc.AddMemoryFont((System.IntPtr)pFontData, fontdata.Length);
                }
            }

            labelNumbers.Font = new Font(pfc.Families[0], 20, FontStyle.Bold);
        }
    }
}