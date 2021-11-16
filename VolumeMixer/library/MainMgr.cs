using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolumeMixer.library.data;

namespace VolumeMixer.library
{
    public static class MainMgr
    {
        public static void LoadAllData(Form main, KeyboardHook kh)
        {
            ProcessMgr.LoadList();
            AudioMgr.LoadList();
            ToolMgr.CreateTool(main, kh);
        }
    }
}
