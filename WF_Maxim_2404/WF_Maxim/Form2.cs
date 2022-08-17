using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Maxim
{
    public partial class Form2 : Form
    {
        bool flag = false;
        int x = -10; //
        int y =  90; // сдвиг 
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Galochka.Checked & checkBox2.Checked)
            { // если обе галочки выделены
               if( MessageBox.Show("Обе галочки нажаты! Окрасить форму в зеленый цвет?","Важное сообщение", 
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BackColor = Color.Green;
                }
            }
            else // если не обе галочки выделены
            {
                /* System.Drawing.Drawing2D.GraphicsPath myPath = 
                    new System.Drawing.Drawing2D.GraphicsPath();
                myPath.AddEllipse(0,0,Width,Height);
                Region myRegion = new Region(myPath);               
                Region = myRegion;*/
               // timer1.Enabled = true;
                pictureBox1.Image = Image.FromFile("ЛОГО.jpg");

            }
        }

        private void Form2_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            
        }

        private void Form2_MaximumSizeChanged(object sender, EventArgs e)
        {
            BackColor = Color.Coral;
        }

        private void Form2_StyleChanged(object sender, EventArgs e)
        {
            
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // парабола У = x^2 + x

            pictureBox1.Left = pictureBox1.Location.X + 1;
            pictureBox1.Top = pictureBox1.Location.Y + x * x;
            y = x * x ;
            x++;
            //-----------------------------------------------
            if (pictureBox1.Location.X > Size.Width)
            {
                pictureBox1.Left = - pictureBox1.Size.Width;
                pictureBox1.Top = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                pictureBox1.Left = e.X;
                pictureBox1.Top = e.Y;
            }
            
            
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            flag = !flag;
            pictureBox1.Left = pictureBox1.Location.X + 1;
        
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (flag)
            {
                pictureBox1.Left = e.X;
                pictureBox1.Top = e.Y;
            }
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Graph = new Form3();
            Graph.ShowDialog();
        }
    }
}
