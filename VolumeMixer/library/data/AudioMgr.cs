using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeMixer.library.data
{
    public static class AudioMgr
    {
        public static IList<AudioSession> audioSession = new List<AudioSession>();

        public static void LoadList()
        {
            audioSession = AudioMixer.GetAllSessions().Where(A => A.Process != null).ToList();
            foreach (var item in audioSession)
            {
                if (!ProcessMgr.CheckRow(item.Process.MainModule.BaseAddress.ToString()))
                {
                    int p_id = item.Process.Id;
                    float master_volume = AudioMixer.GetApplicationVolume(p_id);

                    ProcessData data = new ProcessData();
                    data.Name = item.Process.ProcessName;
                    data.FilePath = item.Process.MainModule.FileName;
                    data.IsMute = false;
                    data.Volume = master_volume;
                    data.Key = "NaN";
                    data.LastPid = p_id;
                    data.BaseAdress = item.Process.MainModule.BaseAddress.ToString();
                    ProcessMgr.AddList(data);
                }
            }
        }
        public static AudioSession GetRow(string baseAdress, string name)
        {
          return  audioSession.FirstOrDefault(A => A.Process.MainModule.BaseAddress.ToString() == baseAdress && A.Process.ProcessName == name);
        }
    }
}
