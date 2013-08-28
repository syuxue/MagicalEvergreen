using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace src
{


    public partial class Mainform : Form
    {
        static int FileLenthUpper = 20000;
        String[] en_set = { "log", "cutgrass", "rocks", "charcoal" };
        String[] cn_set = { "木头", "草", "岩石", "木炭" };

        //direction=T-> EN->CN, F-> CN->EN 
        public string trans(string str, bool direction)
        {
            int i = 0;

            if (direction)
            {
                for (i=0;i < en_set.Length;i++)
                {
                    if (en_set[i] == str)
                        return cn_set[i];
                }
                return str;
            }
            else
            {
                for (i = 0; i < cn_set.Length; i++)
                {
                    if (cn_set[i] == str)
                        return en_set[i];
                }
                return str;
            }
        }

        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
        }

       private void button2_Click(object sender, EventArgs e)
        {
            byte[] byData = new byte[FileLenthUpper];
            char[] byChar = new char[FileLenthUpper];

            try
            {
                FileStream aFile = new FileStream("evergreens.lua", FileMode.Open);
                //FileStream aFile = new FileStream("test.txt", FileMode.Open);
                //aFile.Seek(1, SeekOrigin.Begin);
                aFile.Read(byData, 0, (int)aFile.Length);
                aFile.Close();
            }
            catch (IOException err)
            {
                MessageBox.Show("An IO error has been thrown!");
                MessageBox.Show("Error Message:\n" + err.ToString());
                return;
            }

            Decoder d = Encoding.UTF8.GetDecoder();
            d.GetChars(byData, 0, byData.Length, byChar, 0);
            string str = new string(byChar);
            textBox1.Text = str ;
 
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] byData;//=new byte[FileLenthUpper];
            char[] byChar;//=new char[FileLenthUpper];

            try
            {
                FileStream aFile = new FileStream("testwrite.txt", FileMode.Create);
                byChar = textBox1.Text.ToCharArray();
                //byChar = "test string.".ToCharArray();
                byData = new byte[byChar.Length];
                Encoder en = Encoding.UTF8.GetEncoder();
                en.GetBytes(byChar, 0, byChar.Length, byData, 0, true);

                //begin to write
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(byData, 0, byData.Length);
                aFile.Close();
            }
            catch(IOException err) 
            { 
                MessageBox.Show("An IO error has been thrown!");
                MessageBox.Show("Error Message:\n" + err.ToString());
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tofind;
            string wholeStr = textBox1.Text;
            tofind = textBox2.Text;
            int beginpos = 0;
            int current_pos = 0;
            current_pos = wholeStr.IndexOf(tofind, current_pos);
            if (current_pos == -1)
                textBox2.Text = "";
            else
                textBox3.Text = wholeStr.Substring(current_pos);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tofind;
            string wholeStr = textBox1.Text;
			string dropthing, dropthing_transed;
            int pos_begin = 0;
            int pos_left = 0;
            int pos_right = 0;
            
            tofind = "inst.components.lootdropper:SpawnLootPrefab";
            //locate in the function
            pos_begin = wholeStr.IndexOf("local function chop_down_burnt_tree(inst, chopper)");
            //ready
            listBox1.Items.Clear();
            //search
            while ((pos_begin = wholeStr.IndexOf(tofind, pos_begin+1)) != -1)
            {
                pos_left = wholeStr.IndexOf("\"", pos_begin);
                pos_right = wholeStr.IndexOf("\"", pos_left+1);
                dropthing = wholeStr.Substring(pos_left+1, pos_right - pos_left - 1);
                //Translate
				dropthing_transed = trans(dropthing, true);
                listBox1.Items.Add(dropthing_transed);

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count>0)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

    }
}
