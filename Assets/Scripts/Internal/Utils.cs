using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace InventoryTest
{
    public static class Utils
    {
        public static void SaveFileInDataPath<T>(T data, string fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/"+fileName);
            bf.Serialize(file, data);
            file.Close();
        }
        public static T RetrieveFromDataPath<T>(string fileName)
        {
            if (File.Exists(Application.persistentDataPath + "/"+fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/"+fileName, FileMode.Open);
                var res = bf.Deserialize(file);
                file.Close();
                return (T)Convert.ChangeType(res, typeof(T));
            }
            return default(T);
        }
        public static void DeleteDataFile(string fileName)
        {
            File.Delete(Application.persistentDataPath + "/" + fileName);
        }
    }
}
