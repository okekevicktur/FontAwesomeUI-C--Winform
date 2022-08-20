using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022UIfontawesome.Forms
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            //Reduce the flickering in the form graphics
            this.DoubleBuffered = true;
            //FIt maximize screen to full screen size
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
    }
}
