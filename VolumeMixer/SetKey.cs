using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolumeMixer.library;
using VolumeMixer.library.data;

namespace VolumeMixer
{
    public partial class SetKey : Form
    {
        string baseAdress;
        Keys Key;
        public SetKey(string baseAdress, KeyboardHook kh)
        {
            InitializeComponent();
            kh.KeyDown += Kh_KeyDown;
            this.baseAdress = baseAdress;
        }
        private void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            lblKey.Text = "KeyPress {" + key + "}";
            this.Key = key;
        }
       
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ProcessMgr.CheckKey(this.Key.ToString()))
            {
                RootObject obj = ProcessMgr.GetRow(this.baseAdress);
                obj.ProcessData.Key = this.Key.ToString();
                ProcessMgr.UpdateRow(baseAdress, obj.ProcessData);
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Invalid, pls try again","Error");
            }
        }
    }
}
