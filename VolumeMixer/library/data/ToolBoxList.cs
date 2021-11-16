using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeMixer.library.data
{
    public class ToolBoxList
    {
        public GroupBox groupBox { get; set; }
        public Label label { get; set; }
        public ProgressBar progressBar { get; set; }
        public AudioSession audioSession { get; set; }
        public Keys keys { get; set; }
        public int Volume { get; set; }

    }
}
