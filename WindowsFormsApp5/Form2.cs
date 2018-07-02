using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==string.Empty || textBox2.Text==string.Empty)
            {
                MessageBox.Show("信息禁止为空！", "登录提示");
                textBox1.Clear();
                textBox2.Clear();
                textBox2.Focus();
                return;
            }

            if(!textBox1.Text.Equals("admin") || !textBox2.Text.Equals("admin"))
            {
                MessageBox.Show("用户名或密码为空!", "登录提示");

                textBox1.Clear();
                textBox2.Clear();
                textBox2.Focus();
                return;
            }

            else
            {
                MessageBox.Show("欢迎您登录本系统!", "消息提示");
                textBox1.Clear();
                textBox2.Clear();
                textBox2.Focus();
                this.Hide();

               
                for(int i=0;i<Application.OpenForms.Count;i++)
                {
                    if(Application.OpenForms[i] is Form2)
                    {
                        ((Form2)(Application.OpenForms[i])).Close();
                    }
                }

                for(int i=0;i<Application.OpenForms.Count;i++)
                {
                    if(Application.OpenForms[i] is Form1)
                    {
                        ((Form1)(Application.OpenForms[i])).Show();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox2.Focus();
        }
    }
}
