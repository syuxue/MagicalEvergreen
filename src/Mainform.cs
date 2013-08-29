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

//遇到的问题
/*
	
 * 1.目前save按钮的功能里面,还没有搞清楚字符串复制给文本框为什么能够消除尾部的\0,而通过了textbox1来传递.
 * 来消除本应给Str_full的末尾的\0.
 * -------------
 * 通过搜索,在TCP/IP中也经常遇到这个问题....好吧,解决方法很简单..就是str=str.trimend('\0');
 * 
 * 2.通过release发布之后的第一个版本,在遇到找不到evergreens.lua的时候,会出现未处理异常.
 * -------------
 * 通过搜索,C#各种退出的方式里面.备注如下:
 * 1.this.Close();   只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出；
 * 2.Application.Exit();  强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出；
 * 3.Application.ExitThread(); 强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题；
 * 4.System.Environment.Exit(0);   这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。
 * 选择第四项,感觉上很干净地解决了.
 * 
 
 */

namespace src
{


    public partial class Mainform : Form
    {
        static int FileLenthUpper = 30000;
        //String[] en_set = { "log", "cutgrass", "rocks", "charcoal" };
        //String[] cn_set = { "木头", "草", "岩石", "木炭" };
		String[] en_set = { "log", "cutgrass", "rocks", "charcoal","twigs",
							  "goldnugget", "pumpkin","rope","boards","cutstone", /*5-9*/
							  "pigskin", "carrot","papyrus","seeds","marble",
							  "beefalowool","poop","honeycomb","bee","gears",/*15-19*/
							  "silk","spidergland","ash","flint","fireflies",
							  "lightbulb","honey","nightmarefuel","nitre","rottenegg",/*25-29*/
							  "livinglog","purplegem","redgem","cookedmeat","mandrake",
							  "cutreeds","batwing","spear","bluegem","petals_evil",/*35-39*/
							  "nightsword","armor_sanity","amulet","blueamulet","purpleamulet",
							  "firestaff","icestaff","telestaff","meat","stinger",/*45-49*/
							  "feather_crow","feather_robin","feather_robin_winter","houndstooth","boomerang",
							  "blowdart_sleep","blowdart_fire","blowdart_pipe","petals","horn",/*55-59*/
							  "tentaclespots","cane","walrus_tusk","sweatervest","trunkvest_summer",
							  "trunkvest_winter","orangeamulet","yellowamulet","orangegem","yellowgem",/*65-69*/
							  "orangestaff","yellowstaff","greengem","greenamulet","multitool_axe_pickaxe",
							  "ruins_bat","armorruins","slurper_pelt","armorslurper","thulecite"};/*75-79*/

		String[] cn_set = { "木头", "草", "岩石", "木炭","树枝",/*0-4*/
							  "金块", "南瓜","绳子","木板","砖头",
							  "猪皮","胡萝卜","纸张","种子","大理石",/*10-14*/
							  "牛毛","粪便","蜂巢","蜜蜂","齿轮",
							  "蜘蛛丝","蜘蛛腺体","灰烬","燧石","萤火虫",/*20-24*/
							  "灯泡","蜂蜜","噩梦燃料","硝石","破鸡蛋",
							  "生命之木","紫宝石","红宝石","熟肉","曼德拉草",/*30-34*/
							  "种子","蝙蝠翅膀","长矛","蓝宝石","恶魔花瓣",
							  "暗影剑","暗影盔甲","生命护符","寒冰护符","噩梦护符",/*40-44*/
							  "火魔杖","冰魔杖","传送杖","肉","蜂刺",
							  "乌鸦羽毛","红雀羽毛","冬雀羽毛","狗牙","回力标",/*50-54*/
							  "麻醉吹箭","燃烧吹箭","吹箭","花瓣","牛角",
							  "斑点触手皮","疾行手杖","海象牙","小巧背心","夏日背心",/*60-64*/
							  "冬季背心",/*Index 66,Version:18*/"懒人护符","黄色护符","橙宝石","黄宝石",
							  "橙色魔杖","黄色魔杖",/*Index73, Version:19*/"绿宝石","绿色护符","多功能斧头",/*70-74*/
							  "远古短棍","远古战甲","啜食者皮","啜食者盔甲","铥矿石"};

		string Str_full;
		public string URL_app;
		public int game_version;

        //toCn=T-> EN->CN, F-> CN->EN 
        public string trans(string str, bool toCn)
        {
            int i = 0;

            if (toCn)
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

		public string str_add(string str_up, string str_down)
		{
			string str;		//to save all
			string str_base = "inst.components.lootdropper:SpawnLootPrefab(\"charcoal\")";
			string str_transed;

			str = str_up + "\r\n" + str_base + "\r\n";
			foreach (string items in listBox1.Items)
			{
				str_transed = trans(items, false);
				str = str + str_base.Replace("charcoal",str_transed) + "\r\n";
			}
			str = str + "\r\n" + str_down;
			return str;
		}

		public string str_rebuild()
		{
			int pos_begin, pos_end;
			string str_up, str_down;
			string eigen_str1 = "inst:ListenForEvent(\"animover\", function() inst:Remove() end)";
			string eigen_str2 = "inst.components.lootdropper:DropLoot()";

			if (Str_full.Length == 0)
			{
				MessageBox.Show("Unknow Error. In module rebuild");
				this.Dispose();
			}
			//Str_full should be some contents in it from the first time loaded.
			//Str_full = textBox1.Text;
			pos_begin = Str_full.IndexOf(eigen_str1);
			pos_begin += eigen_str1.Length;
			pos_end = Str_full.IndexOf(eigen_str2, pos_begin);
			str_up = Str_full.Substring(0, pos_begin);
			str_down = Str_full.Substring(pos_end);
			//textBox4.Text = str_up+str_down;
			//begin to add
			return str_add(str_up,str_down);
			//return str_up +"\n" + str_down;
		}

		//load file into Str_full
		public void load_magicTree()	
		{
			string file_name = @"..\data\scripts\prefabs\evergreens.lua";
			//exists? Evergreen.lua	
			FileInfo file_chk = new FileInfo(file_name);
			if (file_chk.Exists)
			{
				byte[] byData = new byte[FileLenthUpper];
				char[] byChar = new char[FileLenthUpper];

				try
				{
					FileStream aFile = new FileStream(file_name, FileMode.Open);
					//FileStream aFile = new FileStream("test.txt", FileMode.Open);
					//aFile.Seek(1, SeekOrigin.Begin);
					aFile.Read(byData, 0, (int)aFile.Length);
					aFile.Close();
				}
				catch (IOException err)
				{
					MessageBox.Show("An IO error has been thrown!");
					MessageBox.Show("Error Message:\r\n" + err.ToString());
					return;
				}

				Decoder d = Encoding.UTF8.GetDecoder();
				d.GetChars(byData, 0, byData.Length, byChar, 0);
				string str = new string(byChar);
				str = str.TrimEnd('\0');					//这句是关键.去除字符串莫非的\0,通过互联网解决.
				//MessageBox.Show(str.Length.ToString());
				//textBox1.Text = str;
				Str_full = str;
				//
				//textBox1.Text = str ;
				//MessageBox.Show(Str_full.Length.ToString());
 

			}
			else
			{
				MessageBox.Show("神奇的木炭模块无法载入,程序即将退出.\r\n这通常由于游戏文件受到损坏或者没有将程序放入游戏目录中导致的.");
				System.Environment.Exit(0);
				return;
			}
			//open?

			//list

		}

		//load what will out currently by cutting the burnt tree.
		public void load_current_mTout()
		{
			string tofind;
            string wholeStr = Str_full;
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
		
		//load what can be drop in listbox2
		public void load_ableOutList()
		{ 
			foreach (string str in cn_set)
				listBox2.Items.Add(str);
		
		}

		//rebuilt Str_full and save it.
		public void load_save()
		{
			string towrite;
			string file_name = @"..\data\scripts\prefabs\evergreens.lua";
			byte[] byData;
            char[] byChar;
			//rebuilt the Str_full from listbox1
			towrite = str_rebuild();
			//Save it to evergreens.lua
			//textBox4.Text = towrite;

            try
            {
                FileStream aFile = new FileStream(file_name, FileMode.Create);
                byChar = towrite.ToCharArray();
                //byChar = "test string.".ToCharArray();
                byData = new byte[byChar.Length];
                Encoder en = Encoding.UTF8.GetEncoder();
                en.GetBytes(byChar, 0, byChar.Length, byData, 0, true);

                //begin to write
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(byData, 0, byData.Length);
                aFile.Close();
				button10.Enabled = false;
				button10.Text = "Saved!";

            }
            catch(IOException err) 
            { 
                MessageBox.Show("An IO error has been thrown!");
                MessageBox.Show("Error Message:\r\n" + err.ToString());
                return;
            }
		}

        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
			//load cn_set to listbox2
			listBox2.Items.Clear();
        }

       private void button2_Click(object sender, EventArgs e)
        {
           
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
			if (listBox1.SelectedItems.Count > 0)
			{
				listBox1.Items.RemoveAt(listBox1.SelectedIndex);
				button10.Text = "Save";
				button10.Enabled = true;
			}

        }

		private void button7_Click(object sender, EventArgs e)
		{
			if (listBox2.SelectedItems.Count > 0)
			{
				listBox1.Items.Add(listBox2.SelectedItem);
				button10.Enabled = true;
				button10.Text = "Save";
			}
		}


		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			label2.Text = "当前游戏版本:" + game_version.ToString()+ "\r\n" + URL_app ;
			//载入神奇的木炭模块
			load_magicTree();
			//分析文件,获取当前爆的东西
			load_current_mTout();
			//读入可以爆的列表.根据版本号读入支持的物品
			load_ableOutList();

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}


		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if (listBox1.Items.Count > 0)
			{
				button10.Text = "Save";
				button10.Enabled = true;
			}
			listBox1.Items.Clear();
		}


		private void button10_Click(object sender, EventArgs e)
		{
			//load to save
			load_save();
		}


		


    }
}
