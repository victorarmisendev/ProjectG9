using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class RecordHolder
{
   public static void SaveRecord (inGameRecord IR)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/record.enti";
        FileStream file = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(IR);

        formatter.Serialize(file, data);
        file.Close();
    }

    public static PlayerData LoadRecord ()
    {
        string path = Application.persistentDataPath + "/record.enti";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(file) as PlayerData;
            file.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file no found");

            return null;
        }
    }
}
