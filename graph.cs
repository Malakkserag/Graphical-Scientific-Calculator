using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using CodingSeb.ExpressionEvaluator;


namespace calculator
{
    public class Graph : Form
    {
        private PlotView plotView1;

        public Graph(string equation)
        {
            // Form settings
            this.Text = "Graph of " + equation;
            this.ClientSize = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // PlotView setup
            plotView1 = new PlotView { Dock = DockStyle.Fill };
            this.Controls.Add(plotView1);

            // Plot the equation
            PlotEquation(equation);
        }
        private string ConvertPowerToMathPow(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(
                input,
                @"(\([^()]+\)|[a-zA-Z0-9.]+)\s*\^\s*([0-9.]+)",
                "Math.Pow($1,$2)"
            );
        }
        private void PlotEquation(string eq)
        {
            var model = new PlotModel
            {
                Title = "y = " + eq,
                TitleFontSize = 18,
                Background = OxyColors.White
            };

            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "X",
                AxislineColor = OxyColors.Black,
                AxislineThickness = 2,
                MajorGridlineStyle = LineStyle.Solid,
                MajorGridlineColor = OxyColors.LightGray
            });

            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Y",
                AxislineColor = OxyColors.Black,
                AxislineThickness = 2,
                MajorGridlineStyle = LineStyle.Solid,
                MajorGridlineColor = OxyColors.LightGray
            });

            var series = new LineSeries
            {
                Color = OxyColors.Purple,
                StrokeThickness = 2
            };

            var evaluator = new ExpressionEvaluator();

            string processedEq = ConvertPowerToMathPow(eq);

            

            for (double x = -10; x <= 10; x += 0.1)
            {
                try
                {
                    evaluator.Variables["x"] = x;
                    double y = Convert.ToDouble(evaluator.Evaluate(processedEq));
                    series.Points.Add(new DataPoint(x, y));
                }
                catch
                {
                    // skip invalid points
                }
            }

            model.Series.Add(series);
            plotView1.Model = model;
        }

    }
}
