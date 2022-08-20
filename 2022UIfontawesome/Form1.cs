 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using _2022UIfontawesome.Forms;

namespace _2022UIfontawesome
{
    public partial class Form1 : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
       // FormDashboard formDashboard=   new FormDashboard() ;
        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Clear Native Title Bar
            this.Text = string.Empty;
            this.ControlBox = false;
            //Reduce the flickering in the form graphics
            this.DoubleBuffered = true;
            //FIt maximize screen to full screen size
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;



        }
        //Structure to store the RGB colors
        private struct RGBColors
        {
            public static Color color1= Color.FromArgb( 172, 126, 241);

            public static Color color2= Color.FromArgb( 249,118, 176);

            public static Color color3= Color.FromArgb( 253, 138, 114);
            public static Color color4= Color.FromArgb( 95, 77, 221);
            public static Color color5= Color.FromArgb( 249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);

        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {

                //invoke default settings for the button
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign =    ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //lEFT bORDER bUTTON
                leftBorderBtn.BackColor= color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconCurrentChildForm.IconChar= currentBtn.IconChar;

                 iconCurrentChildForm.IconColor= color;
                 lblTitleChildForm.Text = currentBtn.Tag.ToString();
                 lblTitleChildForm.ForeColor = Color.Gainsboro;
                
            }
        }


        private void DisableButton()
        {
            if (currentBtn != null)
            {
                  //return the button to dfault
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void openChildForm(Form childform)
        {
            if (currentChildForm != null)
            {
                //Open only 1form
                currentChildForm.Close();
            }
            currentChildForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childform);
            panelDesktop.Tag = childform;
            childform.BringToFront();
            childform.Show();

            lblTitleChildForm.Text = childform.Text;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            openChildForm(new FormDashboard());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            openChildForm(new FormOrders());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            openChildForm(new FormProducts());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            openChildForm(new FormCustomers());
        }

        private void btnMarketing_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            openChildForm(new FormMarketing());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            openChildForm(new FormSetting());
        }

        private void btnHome_Click(object sender, EventArgs e)
        { 
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
                    iconCurrentChildForm.IconChar = IconChar.Home;

                    iconCurrentChildForm.IconColor = Color.MediumPurple;
                    lblTitleChildForm.Text = "Home";
           
        }

        //Form Drag functionality  


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
      
        ////Close-Maximize-Minimize
        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
        //private void btnMaximize_Click(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Normal)
        //        WindowState = FormWindowState.Maximized;
        //    else
        //        WindowState = FormWindowState.Normal;
        //}
        //private void btnMinimize_Click(object sender, EventArgs e)
        //{
        //    WindowState = FormWindowState.Minimized;
        //}
        ////Remove transparent border in maximized state
        //private void FormMainMenu_Resize(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Maximized)
        //        FormBorderStyle = FormBorderStyle.None;
        //    else
        //        FormBorderStyle = FormBorderStyle.Sizable;
        //}

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
