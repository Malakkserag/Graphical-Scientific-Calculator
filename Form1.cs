using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace calculator
{


    public partial class Form1 : Form
    {
        float a, b;
        string operation;


        public Form1()
        {
            InitializeComponent();

            textBox2.Multiline = true;
            textBox2.Height = 60;
            textBox2.Font = new Font("Microsoft Sans Serif", 18);
            textBox2.BackColor = Color.LightBlue;
            this.BackColor = Color.Gray;

        }



        void NumberPressed(object M, EventArgs K)
        {
            textBox2.Text = textBox2.Text + (M as Button).Text;
        }



        void Operation(object S, EventArgs H)
        {
            a = float.Parse(textBox2.Text);
            textBox2.Text = "";
            operation = (S as Button).Text;
        }

        void Equal(object sender, EventArgs e)
        {
            string input = textBox2.Text.Trim();


            if (input.StartsWith("e"))
            {
                string num = input.Substring(1);
                if (double.TryParse(num, out double exp))
                    textBox2.Text = Math.Exp(exp).ToString();
                else

                    new CustomMessageBox("Invalid number after 'e'").ShowDialog();

                return;
            }


            if (input.Contains("^"))
            {
                CalculatePower();

                return;
            }


            if (input.StartsWith("√"))
            {
                string num = input.Substring(1);
                if (double.TryParse(num, out double val))
                    textBox2.Text = Math.Sqrt(val).ToString();
                else


                    new CustomMessageBox("Invalid number after '√'").ShowDialog();

                return;
            }


            if (input.StartsWith("sin(") && input.EndsWith(")"))
            {
                string inner = input.Substring(4, input.Length - 5).Trim();
                if (double.TryParse(inner, out double angle))
                    textBox2.Text = Math.Sin(angle).ToString();
                else

                    new CustomMessageBox("Invalid angle").ShowDialog();
                return;
            }


            if (input.StartsWith("tan(") && input.EndsWith(")"))
            {
                string inner = input.Substring(4, input.Length - 5).Trim();
                if (double.TryParse(inner, out double angle))
                    textBox2.Text = Math.Tan(angle).ToString();
                else


                    new CustomMessageBox("Invalid angle").ShowDialog();
                return;
            }


            if (input.StartsWith("cos(") && input.EndsWith(")"))
            {
                string inner = input.Substring(4, input.Length - 5).Trim();
                if (double.TryParse(inner, out double angle))
                    textBox2.Text = Math.Cos(angle).ToString();
                else
                    new CustomMessageBox("Invalid angle").ShowDialog();

                return;
            }



            if (!float.TryParse(input, out b))
            {
                new CustomMessageBox("Invalid number").ShowDialog();
                return;
            }

            switch (operation)
            {
                case "+": a += b; break;
                case "-": a -= b; break;
                case "*": a *= b; break;
                case "/": a /= b; break;
                default:
                    new CustomMessageBox("Select an operation").ShowDialog();
                    return;
            }

            textBox2.Text = a.ToString();
        }


        void delete(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text)) //lazem elTB yb'a fyh haga ashan tshtghl
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }
        }

        void AC(object R, EventArgs T)
        {
            textBox2.Text = "";

        }

        void decimall(object O, EventArgs P)
        {


            string text = textBox2.Text;
            int lastOp = text.LastIndexOfAny("+-*/".ToCharArray());
            int lastDot = text.LastIndexOf('.');


            if (lastDot <= lastOp)   //lazem akher dot tb'a abl akher op

                textBox2.Text += ".";
            else new CustomMessageBox("you can't enter two decimails").ShowDialog();

        }

        void CalculatePower()
        {
            string[] parts = textBox2.Text.Split('^');


            if (parts.Length == 2)
            {

                double baseNum = Convert.ToDouble(parts[0]);
                double power = Convert.ToDouble(parts[1]);


                double result = Math.Pow(baseNum, power);

                textBox2.Text = result.ToString();
            }
            else
            {

                new CustomMessageBox("wrong try again").ShowDialog();
            }
        }


        void Power(object G, EventArgs P)
        {
            textBox2.Text += "^";
        }


        void Root(object sender, EventArgs e)
        {
            textBox2.Text += "√";
        }


        void exponential(object sender, EventArgs e)
        {
            textBox2.Text += "e";
        }

        void sin(object sender, EventArgs e)
        {

            textBox2.Text += "sin(";

        }

        void cos(object sender, EventArgs e)
        {

            textBox2.Text += "cos(";

        }


        void tan(object sender, EventArgs e)
        {

            textBox2.Text += "tan(";

        }

        void rightbracket(object sender, EventArgs e)
        {

            textBox2.Text += ")";

        }

        void leftbracket(object sender, EventArgs e)
        {

            textBox2.Text += "(";

        }


        void X(object sender, EventArgs e)
        {

            textBox2.Text += "x";

        }


        private void graph(object sender, EventArgs e)
        {
            string equation = textBox2.Text;

            if (equation.ToLower().Contains("x"))
            {
                Graph graphWindow = new Graph(equation);
                graphWindow.ShowDialog();
            }
            else
            {
                new CustomMessageBox("Please enter an equation that includes 'x'.").ShowDialog();
            }
        }



    }

}


