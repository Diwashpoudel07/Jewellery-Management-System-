﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System
{
    public partial class Jewellery : Form
    {
        public Jewellery()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            Myprogress.Value = startpoint;
            lblPercentage.Text = startpoint + "%";
            if (Myprogress.Value == 100)
            {
                Myprogress.Value = 0;
                
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void Jewellery_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
