﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Restaurant_Application
{
    public partial class frmMenuADD : Form
    {
        bool closeFlag = false;
        int closeCount = 0;
        bool SliderOpen = false;
        int newWidth = 1;
        int ScreenHeight = 0;
        int ScreenWidth = 0;
        public frmMenuADD()
        {
            InitializeComponent();
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            cat.SelectedIndex = 0;
            setFullScreen();
            setMainPanelPosition();
            setRightPamelFullHeight();
            this.Opacity = 0.0;
            frmOpacity.Enabled = true;
            frmOpacity.Start();
            BookingCheck.Enabled = true;
            BookingCheck.Start();
        }
        public void nill() {
            fname.Text = "";
            price.Text = "";
            descrip.Text = "";
            ImageName.Text = "";
            ctime.Text = "";
            cat.SelectedIndex = 0;
            picProfile.ImageLocation = null;
            
        }

        private void setRightPamelFullHeight()
        {
            ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            pnlRightHide.MaximumSize = new Size(pnlRightHide.Width, ScreenHeight);
            pnlRightHide.Size = new Size(pnlRightHide.Width, ScreenHeight);
            pnlTop.MaximumSize = new Size(pnlTop.Width, ScreenHeight);
            pnlTop.Size = new Size(pnlTop.Width, ScreenHeight);
        }

        private void setMainPanelPosition()
        {
            int mX = (Width - pnlMain.Width) / 2;
            int mY = (Height - pnlMain.Height) / 2;
            int lX = (Width - copyright.Width) / 2;
            int lY = (Height - copyright.Height);
            int SideY = (pnlTop.Height - pnlRightCenter.Height+100) / 2;
            int pnlRightHideX = Width - pnlRightHide.Width;
            pnlMain.Location = new Point(mX, mY);
            pnlRightCenter.Location = new Point(0, SideY);
            pnlRightHide.Location = new Point(pnlRightHideX, 0);
            copyright.Location = new Point(lX, lY-70);
        }

        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Location = new Point(0, 0);
            Size = new Size(x, y);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            pnlRightHide.Visible = false;
            pnlTop.Location = new Point(ScreenWidth, 0);
            pnlTop.Visible = true;
            SliderOpen = true;
            topPnlEffect.Enabled = true;
            topPnlEffect.Start();
        }
        private void CoomonTopMouseLeave()
        {        
        }
        
        private void topPnlEffect_Tick(object sender, EventArgs e)
        {

            if (SliderOpen)
            {
                pnlTop.Location = new Point(ScreenWidth+newWidth, 0);
                newWidth -= 2;
                if (newWidth <=-75)
                {
                    topPnlEffect.Stop();
                }
                SliderClose.Enabled = true;
                SliderClose.Start();
            }
            else
            {
                pnlTop.Location = new Point(ScreenWidth + newWidth, 0);
                newWidth += 2;
                if (newWidth >= 75)
                {
                    topPnlEffect.Stop();
                    pnlTop.Visible = false;
                   
                    pnlRightHide.Visible = true;
                }
            }
        }

        private void frmOpacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 1.0)
            {
                this.Opacity += 0.1;
            }
            else
            {
                frmOpacity.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void picLock_Click(object sender, EventArgs e)
        {
            closeFlag = true;
            pnlLock.BackColor = Color.FromArgb(0,190,240);
            frmClose.Enabled = true;
            frmClose.Start();
            SliderClose.Stop();
            frmLogin n = new frmLogin();
            n.Show();
        }

        private void picLock_MouseHover(object sender, EventArgs e)
        {
            pnlLock.BackColor = Color.FromArgb(88, 214, 141);
        }

        private void picLock_MouseLeave(object sender, EventArgs e)
        {
            pnlLock.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            pnlHome.BackColor = Color.FromArgb(0, 190, 240);
        }

        private void picHome_MouseHover(object sender, EventArgs e)
        {
            pnlHome.BackColor = Color.FromArgb(88, 214, 141);
        }

        private void picHome_MouseLeave(object sender, EventArgs e)
        {
            pnlHome.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void picPower_Click(object sender, EventArgs e)
        {
            pnlPower.BackColor = Color.FromArgb(0, 190, 240);
            SliderClose.Stop();
            Application.Exit();
        }

        private void picPower_MouseHover(object sender, EventArgs e)
        {
            pnlPower.BackColor = Color.FromArgb(88, 214, 141);
        }

        private void picPower_MouseLeave(object sender, EventArgs e)
        {
            pnlPower.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void SliderClose_Tick(object sender, EventArgs e)
        {
            int MouseX = Cursor.Position.X;
            if (MouseX <= ScreenWidth-pnlTop.Width)
            {
                SliderOpen = false;
                topPnlEffect.Enabled = true;
                topPnlEffect.Start();
                SliderClose.Stop();
            }
        }

        private void frmClose_Tick(object sender, EventArgs e)
        {
            if (closeCount >= 2 && closeFlag)
            {
                closeCount = 0;
                closeFlag = false;
                frmClose.Stop();
                this.Hide();
            }
            else
                closeCount++;
        }

        private void picHome_Click_1(object sender, EventArgs e)
        {
            frmChefIndex n = new frmChefIndex();
            n.Show();
            closeCount = 0;
            closeFlag = true;
            frmClose.Enabled = true;
            frmClose.Start();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            pnlBrouse.BackColor = Color.FromArgb(0, 0, 0);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|JPEG Files (*.jpeg)|*.jpeg";
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "Please select an image file.";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string url = ofd.FileName.ToString();
                picProfile.ImageLocation = url;
                ImageName.Text = System.IO.Path.GetFileName(url);
            }  

        }

        private void label9_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string newFileNmae = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + ImageName.Text;
            System.IO.File.Copy(picProfile.ImageLocation, path + "\\image\\" + newFileNmae);

            string connStr = "server=localhost;user=root;database=ra;password=;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sql = "insert into menu (Name,Description,Price,CookingTime,Image,catalog) values ('"
                          + fname.Text + "','" + descrip.Text + "','" + price.Text + "','"
                          + ctime.Text + "','" + newFileNmae + "','" + (cat.SelectedIndex + 1) + "')";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Food Added successfully...");
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error: " + ex);
            }

        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            pnlBrouse.BackColor = Color.FromArgb(0, 200, 240);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            nill();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
