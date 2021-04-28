using MVVMPairs.Models;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Services
{
    class SaveSystem
    {
        private static readonly string path = @"C:\Users\Ina\Desktop\MVVM-DemoGame\MVVMPairs\MVVMPairs\Utils\game.dat";
        public static void SaveData(List<List<CellData>> data)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            binaryFormatter.Serialize(stream, data);

            stream.Close();
        }

        public static List<List<CellData>> LoadData()
        {
            List<List<CellData>> data = null;
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                data = binaryFormatter.Deserialize(stream) as List<List<CellData>>;

                stream.Close();
            }

            return data;
        }
    }
}
