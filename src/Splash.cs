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
	public partial class Splash : Form
	{
		public int game_version = 0;

		public Splash()
		{
			InitializeComponent();
		}

		private void Splash_Load(object sender, EventArgs e)
		{
			//detect directory
			label1.Text = "Detecting don't starve directory...";
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			string mainFileName = "dontstarve_steam.exe";
			timer1.Enabled = false;
			FileInfo file_chk = new FileInfo(mainFileName);
			if (file_chk.Exists)
			{
				//file exists
				DateTime file_time;
				int doy;		//day of year, use to judge version
				//int game_version = 0;
				file_time = file_chk.LastWriteTimeUtc;
				doy=file_time.DayOfYear;
				//MessageBox.Show(doy.ToString());
				switch (doy)
				{
					case 183:
						game_version = 17;
						break;
					case 207:
						game_version = 18;
						break;
					case 233: 
						game_version = 19;
						break;
					default:
						game_version = 0;
						break;
				}
				if (game_version !=0)
					label1.Text = "Your game Version is Probably:" + game_version.ToString() + "\nBut you still need to mind the incident of your modification.";
				else
					label1.Text = "Cannot detect your game version.\n please make sure there is no changes of your game files and mind the incident of your modification.";
				
				//label1.Text = file_chk.CreationTime;
				button1.Visible = true;
				//label1.Text = System.Environment.CurrentDirectory;
			}
			else
			{
 				//not exists
				label1.Text = "Please put the file to where you launch game and run again.";
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
            //Application.Run(new Mainform());
			this.Hide();
			Mainform fm = new Mainform();
			fm.Show();
			//fm.URL_app = Application.ExecutablePath;
			fm.URL_app = System.Environment.CurrentDirectory;
			fm.game_version = game_version;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
