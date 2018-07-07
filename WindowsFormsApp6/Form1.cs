﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Today is Saturday", "This is caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if(result==DialogResult.Yes)
            {
                MessageBox.Show("Yes");
            }

            if(result==DialogResult.No)
            {
                MessageBox.Show("No");
            }

            if(result==DialogResult.Cancel)
            {
                MessageBox.Show("Cancel");
            }
        }
    }
}
