using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolumeMixer.library.app;

namespace VolumeMixer.library.data
{

    public static class ToolMgr
    {
        static List<ToolBoxList> tool = new List<ToolBoxList>();

        public static void CreateTool(Form main, KeyboardHook kh)
        {
            for (int i = 0; i < AudioMgr.audioSession.Count; i++)
            {
                string p_name = AudioMgr.audioSession[i].Process.ProcessName;
                int p_id = AudioMgr.audioSession[i].Process.Id;
                IntPtr base_adress = AudioMgr.audioSession[i].Process.MainModule.BaseAddress;

                RootObject obj = ProcessMgr.GetRow(base_adress.ToString());

                float master_volume = AudioMixer.GetApplicationVolume(p_id);
                GroupBox box = new GroupBox();
                box.Name = "Group_Box_" + base_adress;
                box.Width = main.Width - 40;
                box.Height = AppProperties.G_HEIGHT;
                box.Location = new Point(AppProperties.G_LOCATION_X, AppProperties.G_LOCATION_Y + i > 0 ? (i * AppProperties.G_HEIGHT) + 15 : 0);
                box.Text = p_name + " [PID: " + base_adress + "]";

                ProgressBar progressBar = new ProgressBar();
                progressBar.Name = "Progress_Bar_" + base_adress;
                progressBar.Width = box.Width - 15;
                progressBar.Height = box.Height - 90;
                progressBar.Location = new Point(AppProperties.T_LOCATION_X, AppProperties.T_LOCATION_Y);
                progressBar.Value = (int)master_volume;

                Label label = new Label();
                label.Name = "Label_" + base_adress;
                label.BackColor = Color.Transparent;
                label.Location = new Point(box.Width - 45, box.Height - 57);
                label.Text = "%" + ((int)master_volume);

                Button button = new Button();
                button.Name = "Button_" + base_adress;
                button.Width = box.Width - 60;
                button.Height = 23;
                button.Location = new Point(AppProperties.T_LOCATION_X, AppProperties.T_LOCATION_Y + 20);
                button.Text = "click and set key [Key: " + obj.ProcessData.Key + "]";
                button.MouseClick += (sender, e) => {
                    Control control = (Control)sender;
                    string rowID = control.Name.Split('_')[1];
                    SetKey setkey = new SetKey(rowID, kh);
                    setkey.Show();
                    main.Hide();
                };

                main.Controls.Add(box);
                box.Controls.Add(progressBar);
                box.Controls.Add(label);
                box.Controls.Add(button);

                tool.Add(new ToolBoxList
                {
                    groupBox = box,
                    progressBar = progressBar,
                    label = label,
                    audioSession = AudioMgr.audioSession[i],
                    Volume = (int)master_volume
                });
            }
        }
        public static ToolBoxList GetRow(string baseAdress, string name)
        {
            return tool.FirstOrDefault(A => A.audioSession.Process.ProcessName == name && A.audioSession.Process.MainModule.BaseAddress.ToString() == baseAdress);
        }
    }
}
