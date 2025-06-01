using System;
using System.Drawing;
using System.Windows.Forms;

namespace calculator
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();            
            label1.Text = message;       
            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);  
            label1.TextAlign = ContentAlignment.MiddleCenter;         
        }
    }
}
