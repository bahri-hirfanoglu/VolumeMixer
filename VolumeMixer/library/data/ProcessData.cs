using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeMixer.library.data
{
    public class ProcessData
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Key { get; set; }
        public float Volume { get; set; }
        public bool IsMute { get; set; }
        public int LastPid { get; set; }
        public string BaseAdress { get; set; }
    }
}
