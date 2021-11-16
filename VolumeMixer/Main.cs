using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolumeMixer.library;
using VolumeMixer.library.data;
using VolumeMixer.library.app;

namespace VolumeMixer
{
    public partial class Main : Form
    {
        KeyboardHook kh = new KeyboardHook(true);

        public Main()
        {
            InitializeComponent();
            MainMgr.LoadAllData(this, kh);
            kh.KeyDown += Kh_KeyDown;
        }
        private void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            RootObject obj = ProcessMgr.GetBaseAdress(key.ToString());
            if (obj != null)
            {
                AudioSession session = AudioMgr.GetRow(obj.ProcessData.BaseAdress, obj.ProcessData.Name);
                if (session != null)
                {
                    float master_volume = AudioMixer.GetApplicationVolume(session.Process.Id);
                    if (Shift)
                    {
                        if (master_volume < 100)
                        {
                            master_volume += 1;
                            AudioMixer.SetApplicationVolume(session.Process.Id, (master_volume));
                        }
                    }
                    else if (Ctrl)
                    {
                        if (master_volume > 0)
                        {
                            master_volume -= 1;
                            AudioMixer.SetApplicationVolume(session.Process.Id, (master_volume));
                        }
                    }
                    ToolBoxList tool = ToolMgr.GetRow(obj.ProcessData.BaseAdress, obj.ProcessData.Name);
                    if(tool != null)
                    {
                        tool.progressBar.Value = (int)master_volume;
                        tool.label.Text = "%" + ((int)master_volume);
                    }
                }
            }
        }

    }
}
