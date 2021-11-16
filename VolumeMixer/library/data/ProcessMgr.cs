using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolumeMixer.library.app;

namespace VolumeMixer.library.data
{
    public class ProcessMgr
    {
        static List<RootObject> data = new List<RootObject>();

        public static void LoadList()
        {
            try
            {
                StreamReader r = new StreamReader(AppProperties.DATA_PATH + AppProperties.DATA_NAME);
                string response = r.ReadToEnd();
                if (response != null && response != "") { data = JsonConvert.DeserializeObject<List<RootObject>>(response); }
                r.Close();
            }
            catch (Exception ex)
            {
               
            }
        }
        public static List<RootObject> GetList()
        {
            return data;
        }
        public static void AddList(ProcessData p_data)
        {
            data.Add(new RootObject() { 
            Id = (data == null ? 1 : data.Count + 1),
            ProcessData = p_data
            });
            SaveList();
        }
        public static bool CheckRow(string baseAdress)
        {
           return data  != null ? (data.Where(A => A.ProcessData.BaseAdress == baseAdress).ToList().Count > 0 ? true : false) : false;
        }
        public static void UpdateRow(string baseAdress, ProcessData p_data)
        {
            RootObject obj = data.FirstOrDefault(A => A.ProcessData.BaseAdress == baseAdress);
            obj.ProcessData = p_data;
            SaveList();
        }
        public static RootObject GetRow(string baseAdress)
        {
            return data.FirstOrDefault(A => A.ProcessData.BaseAdress == baseAdress);
        }
        public static bool CheckKey(string Key)
        {
            return data.Where(A => A.ProcessData.Key == Key).ToList().Count > 0 ? false : true;
        }
        public static RootObject GetBaseAdress(string key)
        {
            return data.FirstOrDefault(A => A.ProcessData.Key == key);
        }
        public static void SaveList()
        {
            using (StreamWriter file = File.CreateText(AppProperties.DATA_PATH + AppProperties.DATA_NAME))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
            LoadList();
        }
    }
}
