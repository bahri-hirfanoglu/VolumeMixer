using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeMixer.library.app
{
    public static class AppProperties
    {
        public static int G_LOCATION_X = 11;
        public static int G_LOCATION_Y = 12;
        public static int G_HEIGHT = 100;

        public static int T_LOCATION_X = 4;
        public static int T_LOCATION_Y = 19;

        public static string DATA_PATH = Application.StartupPath + @"/";
        public static string DATA_NAME = "data.json";
    }
}
