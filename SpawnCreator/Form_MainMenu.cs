﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpawnCreator
{
    public partial class Form_MainMenu : Form
    {
      //+++++++++++++++++++++++++++++++++++++++++++++++++++
      //                                                  +
               public string version = "v2.5"; //         +
      //                                                  +
      //+++++++++++++++++++++++++++++++++++++++++++++++++++

        public Form_MainMenu()
        {
            InitializeComponent();
        }

        public bool StartWithoutMySQL(string name = "mysqld")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    label_mysql_status.Visible = true;
                    lbl_MySQL_Status.Visible = true;
                    return true;
                }
            }

            label_mysql_status.Visible = false;
            lbl_MySQL_Status.Visible = false;
            return false;
        }

        //==================================================
        public string GetHost()
        {
            string host = textbox_mysql_hostname.Text;
            return host;
        }
        public string GetPort()
        {
            return textbox_mysql_port.Text;
        }
        public string GetUser()
        {
            string user = textbox_mysql_username.Text;
            return user;
        }
        public string GetPass()
        {
            string password = textbox_mysql_pass.Text;
            return password;
        }
        public string GetAuthDB()
        {
            string auth = textBox_mysql_authDB.Text;
            return auth;
        }
        public string GetCharDB()
        {
            string characters = textBox_mysql_charactersDB.Text;
            return characters;
        }
        public string GetWorldDB()
        {
            string world = textbox_mysql_worldDB.Text;
            return world;
        }

        //======================================================

        private bool mouseDown;
        private Point lastLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Firebrick;
            label2.ForeColor = Color.White;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gainsboro;
            label2.ForeColor = Color.Black;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Form_ItemCreator form2 = new Form_ItemCreator(this);
            form2.Show();
            Hide();

            // this shouldn't be here - move it to Form_ItemCreator_Load
            //form2.timer1.Enabled = true;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Firebrick;
            label_Npc_creator.ForeColor = Color.White;
            //label_Npc_creator.Text = "working..";
        }

        internal bool button1_Click()
        {
            throw new NotImplementedException();
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Gainsboro;
            label_Npc_creator.ForeColor = Color.Black;
            //label_Npc_creator.Text = "NPC Creator";
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Firebrick;
            label_GO_creator.ForeColor = Color.White;
            //label_GO_creator.Text = "working..";
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Gainsboro;
            label_GO_creator.ForeColor = Color.Black;
            //label_GO_creator.Text = "GameObject Creator";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
             label7.BackColor = Color.Firebrick;
            label7.ForeColor = Color.White;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.IndianRed;
            label7.ForeColor = Color.Black;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Firebrick;
            label8.ForeColor = Color.White;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.IndianRed;
            label8.ForeColor = Color.Black;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://emucraft.com");
        }

        //------------------------------------]
        

        private void label5_Click(object sender, EventArgs e)
        {
            Hide();
            NPC_Creator npc = new NPC_Creator(this);
            npc.Show();
        }

        private void label_GO_creator_Click(object sender, EventArgs e)
        {
            Hide();
            GameObject_Creator go = new GameObject_Creator(this);
            go.Show();
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            label_Quest_creator.BackColor = Color.Gray;
            label_Quest_creator.ForeColor = Color.White;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            label_Quest_creator.BackColor = Color.IndianRed;
            label_Quest_creator.ForeColor = Color.Black;
        }

        private void label_Quest_creator_MouseEnter(object sender, EventArgs e)
        {
            panel_Quest_Creator.BackColor = Color.Firebrick;
            label_Quest_creator.ForeColor = Color.White;
            //label_Quest_creator.Text = "working..";
        }

        private void label_Quest_creator_MouseLeave(object sender, EventArgs e)
        {
            panel_Quest_Creator.BackColor = Color.Gainsboro;
            label_Quest_creator.ForeColor = Color.Black;
            //label_Quest_creator.Text = "Quest Creator";
        }

        private void label_Quest_creator_Click(object sender, EventArgs e)
        {
            Hide();

            QuestTemplate quest = new QuestTemplate(this);
            quest.Show();
        }

        private void button_mysql_connect_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.mysql_pass     = textbox_mysql_pass.Text;
            Properties.Settings.Default.mysql_username = textbox_mysql_username.Text;
            Properties.Settings.Default.mysql_hostname = textbox_mysql_hostname.Text;
            Properties.Settings.Default.mysql_port     = textbox_mysql_port.Text;
            Properties.Settings.Default.mysql_worldDB  = textbox_mysql_worldDB.Text;
            Properties.Settings.Default.mysql_authDB   = textBox_mysql_authDB.Text;
            Properties.Settings.Default.mysql_charactersDB = textBox_mysql_charactersDB.Text;
            Properties.Settings.Default.Save();

            try
            {
                string myConnection = "datasource=" + textbox_mysql_hostname.Text + 
                                      ";port=" + textbox_mysql_port.Text + 
                                      ";username=" + textbox_mysql_username.Text + 
                                      ";password=" + textbox_mysql_pass.Text;

                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                DataSet ds = new DataSet();

                tabControl1.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label_Npc_creator.Visible = true;
                label_GO_creator.Visible = true;
                label_Quest_creator.Visible = true;
                
                label15.Visible = true; // Mail Sender
                label11.Visible = true;
                label12.Visible = true;
                label14.Visible = true;               
                label_version.Visible = true;
                
                label_Account_Creator.Visible = true;
                panel_Account_Creator.Visible = true;
                panel_Quest_Creator.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true; //Mail sender

                button1.Visible = false;

                
                label_mysql_status.Text = "Connected!";
                label_mysql_status.ForeColor = Color.Lime;

                CB_NoMySQL.Visible = false;

                textbox_mysql_username.Visible = true;
                textbox_mysql_pass.Visible = true;
                

                timer1.Enabled = true;
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_clearAll_Click(object sender, EventArgs e)
        {
            textbox_mysql_hostname.Clear();
            textbox_mysql_port.Clear();
            textbox_mysql_username.Clear();
            textbox_mysql_worldDB.Clear();
            textbox_mysql_pass.Clear();
            textBox_mysql_authDB.Clear();
            textBox_mysql_charactersDB.Clear();
        }

        private void button_fill_default_Click(object sender, EventArgs e)
        {
            textbox_mysql_hostname.Text = "127.0.0.1";
            textbox_mysql_port.Text     = "3306";
            textbox_mysql_username.Text = "root";
            textbox_mysql_worldDB.Text  = "world";
            textBox_mysql_authDB.Text   = "auth";
            textBox_mysql_charactersDB.Text = "characters";
            //textbox_mysql_pass.Text     = "";
        }

        public bool IsProcessOpen(string name = "mysqld")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    label_mysql_status.Text = "Connected!";
                    label_mysql_status.ForeColor = Color.LawnGreen;
                    label2.Enabled = true; // Item Creator
                    panel2.Enabled = true; // Item Creator
                    label_Npc_creator.Enabled = true;
                    panel3.Enabled = true; // npc creator
                    label_GO_creator.Enabled = true;
                    panel4.Enabled = true; // Go creator
                    label_Quest_creator.Enabled = true;
                    panel_Quest_Creator.Enabled = true;
                    label_Account_Creator.Enabled = true;
                    panel_Account_Creator.Enabled = true;
                    label11.Enabled = true; // Disable Form
                    panel5.Enabled = true; // Disable Form
                    label12.Enabled = true; // Conditions
                    panel6.Enabled = true; // Conditions
                    label14.Enabled = true; // Smart Scripts
                    panel7.Enabled = true; // Smart Scripts
                    label15.Enabled = true; // Mail Sender
                    panel8.Enabled = true; // Mail Sender
                    return true;
                }
            }

            label_mysql_status.Text = "Connection Lost - MySQL is not running";
            label_mysql_status.ForeColor = Color.Black;
            label2.Enabled = false; // Item Creator
            panel2.Enabled = false; // Item Creator
            label_Npc_creator.Enabled = false;
            panel3.Enabled = false; // npc creator
            label_GO_creator.Enabled = false;
            panel4.Enabled = false; // Go creator
            label_Quest_creator.Enabled = false;
            panel_Quest_Creator.Enabled = false;
            label_Account_Creator.Enabled = false;
            panel_Account_Creator.Enabled = false;
            label11.Enabled = false; // Disable Form
            panel5.Enabled = false; // Disable Form
            label12.Enabled = false; // Conditions
            panel6.Enabled = false; // Conditions
            label14.Enabled = false; // Smart Scripts
            panel7.Enabled = false; // Smart Scripts
            label15.Enabled = false; // Mail Sender
            panel8.Enabled = false; // Mail Sender
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    string myConnection = "datasource=" + textbox_mysql_hostname.Text + ";port=" + textbox_mysql_port.Text + ";username=" + textbox_mysql_username.Text + ";password=" + textbox_mysql_pass.Text;
            //    MySqlConnection myConn = new MySqlConnection(myConnection);
            //    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
            //    //myDataAdapter.SelectCommand = new MySqlCommand("select * from auth.account;");
            //    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
            //    myConn.Open();
            //    DataSet ds = new DataSet();

            //    //Form_ItemCreator form_itemCreator = new Form_ItemCreator();
            //    //form_itemCreator.label_mysql_status2.Text = "Connected!";
            //    //form_itemCreator.label_mysql_status2.ForeColor = Color.Green;

            //    label_mysql_status.Text = "Connected!";
            //    label_mysql_status.ForeColor = Color.LawnGreen;

            //    myConn.Close();
            //}
            //catch (Exception /*ex*/)
            //{
            //    //MessageBox.Show(ex.Message);
            //    label_mysql_status.Text = "Connection Lost - MySQL is not running";
            //    label_mysql_status.ForeColor = Color.Black;
            //}

            IsProcessOpen();
        }

        private void Form_MainMenu_Load(object sender, EventArgs e)
        {
            /// size = 491, 398 

            textbox_mysql_pass.Text     = Properties.Settings.Default.mysql_pass;
            textbox_mysql_username.Text = Properties.Settings.Default.mysql_username;
            textbox_mysql_hostname.Text = Properties.Settings.Default.mysql_hostname;
            textbox_mysql_port.Text     = Properties.Settings.Default.mysql_port;
            textbox_mysql_worldDB.Text  = Properties.Settings.Default.mysql_worldDB;
            textBox_mysql_authDB.Text   = Properties.Settings.Default.mysql_authDB;
            textBox_mysql_charactersDB.Text = Properties.Settings.Default.mysql_charactersDB;
     
            label_version.Text = version;

        }

        private void Form_MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.mysql_pass     = textbox_mysql_pass.Text;
            Properties.Settings.Default.mysql_username = textbox_mysql_username.Text;
            Properties.Settings.Default.mysql_hostname = textbox_mysql_hostname.Text;
            Properties.Settings.Default.mysql_port     = textbox_mysql_port.Text;
            Properties.Settings.Default.mysql_worldDB  = textbox_mysql_worldDB.Text;
            Properties.Settings.Default.mysql_authDB   =  textBox_mysql_authDB.Text;
            Properties.Settings.Default.mysql_charactersDB = textBox_mysql_charactersDB.Text;
            Properties.Settings.Default.Save();
        }

        private void textbox_mysql_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void panel_Account_Creator_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void panel_Account_Creator_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label_Account_Creator_MouseLeave(object sender, EventArgs e)
        {
            panel_Account_Creator.BackColor = Color.Gainsboro;
            label_Account_Creator.ForeColor = Color.Black;
        }

        private void label_Account_Creator_MouseEnter(object sender, EventArgs e)
        {
            panel_Account_Creator.BackColor = Color.Firebrick;
            label_Account_Creator.ForeColor = Color.White;
        }

        private void label_Account_Creator_Click(object sender, EventArgs e)
        {
            AccountCreator acc = new AccountCreator(this);
            acc.Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textbox_mysql_port_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_mysql_port_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textbox_mysql_hostname_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_MouseEnter_1(object sender, EventArgs e)
        {
            //panel5.BackColor = Color.Firebrick;
            //label11.ForeColor = Color.White;
        }

        private void panel5_MouseLeave_1(object sender, EventArgs e)
        {
            //panel5.BackColor = Color.Gainsboro;
            //label11.ForeColor = Color.Black;
        }
        //=============================================================
        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            //panel6.BackColor = Color.Firebrick;
            //label12.ForeColor = Color.White;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            //panel6.BackColor = Color.Gainsboro;
            //label12.ForeColor = Color.Black;
        }
        //==========================================================
        private void label11_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Firebrick;
            label11.ForeColor = Color.White;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Gainsboro;
            label11.ForeColor = Color.Black;
            
        }
        //==========================================================
        private void label12_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Firebrick;
            label12.ForeColor = Color.White;
            
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Gainsboro;
            label12.ForeColor = Color.Black;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            //Disable - Click
            Disable_Form disable = new Disable_Form(this);
            disable.Show();
            Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            //Conditions button - Click

            //Hide Main Menu Form
            Hide();

            //And then Show Conditions Form
            Conditions_Form con = new Conditions_Form(this);
            con.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Firebrick;
            label14.ForeColor = Color.White;
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Gainsboro;
            label14.ForeColor = Color.Black;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Hide();
            SmartScripts smart = new SmartScripts(this);
            smart.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Firebrick;
            label15.ForeColor = Color.White;
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Gainsboro;
            label15.ForeColor = Color.Black;
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            Hide();

            MailSender mail = new MailSender(this);
            mail.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Visible = true;
            //label2.Visible = true;
            //label_Npc_creator.Visible = true;
            //label_GO_creator.Visible = true;
            //label_Quest_creator.Visible = true;
            //panel1.Visible = true;
            //panel2.Visible = true;
            //panel3.Visible = true;
            //panel4.Visible = true;
            //panel5.Visible = true;
            //panel6.Visible = true;
            //panel7.Visible = true;
            //panel8.Visible = true; //Mail sender
            //label15.Visible = true; // Mail Sender
            //label11.Visible = true;
            //label12.Visible = true;
            //label14.Visible = true;
            //label_version.Visible = true;
            //panel_Quest_Creator.Visible = true;
            //label_Account_Creator.Visible = true;
            //panel_Account_Creator.Visible = true;

            //lbl_MySQL_Status.Visible = false;
            //label_mysql_status.Visible = false;

            //textbox_mysql_username.Visible = true;
            //textbox_mysql_pass.Visible = true;
            //tabControl1.Visible = false;          

            if (CB_NoMySQL.CheckState == CheckState.Unchecked)
                CB_NoMySQL.Checked = true;
            else
                CB_NoMySQL.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hide();
            ControlPanel cp = new ControlPanel();
            cp.Show();
        }

        private void textbox_mysql_pass_TextChanged(object sender, EventArgs e)
        {
            //NPC_Creator npc = new NPC_Creator();

            //npc.textBox_MySQL_Password.Text = textbox_mysql_pass.Text;
        }

        private void CB_NoMySQL_CheckedChanged(object sender, EventArgs e)
        {
            StartWithoutMySQL();
            if (CB_NoMySQL.Checked)
            {
                label1.Visible = true;
                label2.Visible = true;
                label_Npc_creator.Visible = true;
                label_GO_creator.Visible = true;
                label_Quest_creator.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true; //Mail sender
                label15.Visible = true; // Mail Sender
                label11.Visible = true;
                label12.Visible = true;
                label14.Visible = true;
                label_version.Visible = true;
                panel_Quest_Creator.Visible = true;
                label_Account_Creator.Visible = true;
                panel_Account_Creator.Visible = true;

                button1.Visible = false;
                tabControl1.Visible = false;

                //CB_NoMySQL.Visible = false;

                label_mysql_status.Visible = false;
                lbl_MySQL_Status.Visible = false;
            }
            else
            {
                label_mysql_status.Visible = true;
                lbl_MySQL_Status.Visible = true;

                label1.Visible = false;
                label2.Visible = false;
                label_Npc_creator.Visible = false;
                label_GO_creator.Visible = false;
                label_Quest_creator.Visible = false;
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false; //Mail sender
                label15.Visible = false; // Mail Sender
                label11.Visible = false;
                label12.Visible = false;
                label14.Visible = false;
                label_version.Visible = false;
                panel_Quest_Creator.Visible = false;
                label_Account_Creator.Visible = false;
                panel_Account_Creator.Visible = false;

                //button1.Visible = false;
                tabControl1.Visible = true;
            }

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void CB_NoMySQL_MouseEnter(object sender, EventArgs e)
        {
            CB_NoMySQL.BackColor = Color.ForestGreen;
        }

        private void CB_NoMySQL_MouseLeave(object sender, EventArgs e)
        {
            CB_NoMySQL.BackColor = Color.DimGray;
        }
    }
}
