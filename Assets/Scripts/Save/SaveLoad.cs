using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using SOData;
using UnityEngine;

namespace Save
{
    public static class SaveLoad
    {
        private static readonly string Path = Application.persistentDataPath + "/GameSave.currentGame"; //add save path
        private static readonly BinaryFormatter Formatter = new BinaryFormatter(); //create serializer

        public static void SaveGame(TankInfo tankInfo)
        {
            var fs = new FileStream(Path,FileMode.Create); //create file
            var data = new SaveData(tankInfo); //get data
            Formatter.Serialize(fs,data); // serialize data
            fs.Close(); 
        }

        public static SaveData LoadGame()
        {
            if (File.Exists(Path))
            {
                var fs = new FileStream(Path,FileMode.Open);
                var data = Formatter.Deserialize(fs) as SaveData;
                fs.Close();
                return data;
            }
            else
            {
                return null;
            }
        }
        
    }
}
