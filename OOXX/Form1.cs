using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week05_1
{
    public partial class Form1 : Form
    {
        Button[] buttons = new Button[9];
        Button temp;
        bool[] click = new bool[9];
        int count,temp1;
        char c;
        //enum but { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

        public Form1()
        {
            InitializeComponent();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            count = 0;
            for (int i = 0; i < 9; ++i)
            {
                click[i] = false;
                buttons[i].Text = "";
            }

            for (int i = 1; i < 9; ++i)
                buttons[i].Click += button1_Click;

            button10.Text = "重置按鈕";

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp = (Button)sender; 
            temp1 = temp.Name[6] - 49;

            if(!click[temp1])
            {
                if (count % 2 == 1)
                {
                    temp.Text = "X";
                    temp.ForeColor = Color.Red;
                }
                else
                {
                    temp.Text = "O";
                    temp.ForeColor = Color.Blue;
                }
                click[temp1] = true;
                ++count;
            }

            c = check();

            if (c != 'G')
            {
                if (c == 'N')
                    MessageBox.Show("平手!!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show(c + "贏哩!!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Form1_Load(this,e);
            }

            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            count = 0;
            for (int i = 0; i < 9; ++i)
            {
                click[i] = false;
                buttons[i].Text = "";
            }

            return;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1_Load(this, e);

            return;
        }

        private char check()
        {
            for(int i = 0; i<3; ++i)
            {
                //row
                if(buttons[3*i].Text != "" && buttons[3*i].Text == buttons[3*i+1].Text && buttons[3*i].Text == buttons[3*i+2].Text)
                {
                    //someone win
                    return buttons[3*i].Text[0];
                }

                //col
                if (buttons[i].Text != "" && buttons[i].Text == buttons[i+3].Text && buttons[i].Text == buttons[i+6].Text)
                {
                    //someone win
                    return buttons[i].Text[0];
                }
            }

            if (buttons[0].Text != "" && buttons[0].Text == buttons[4].Text && buttons[0].Text == buttons[8].Text)
            {
                return buttons[0].Text[0];
            }

            if (buttons[2].Text != "" && buttons[2].Text == buttons[4].Text && buttons[2].Text == buttons[6].Text)
            {
                return buttons[2].Text[0];
            }
            if (count >= 9)
                return 'N';

            return 'G';
        }
    }
}
