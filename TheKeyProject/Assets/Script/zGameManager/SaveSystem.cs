using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem{
    
    public static T Load<T>(string filename) where T : class
    {
        string path = PATH(filename);
        Debug.Log(path);
        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream stream = new FileStream(path, FileMode.Open);
                T data = formatter.Deserialize(stream) as T;
                stream.Close();

                return data;
                
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        else
        {
            Debug.Log("File not exists");
        }
        return default(T);
    }

    public static void Save<T>(string filename, T data) where T : class
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = PATH(filename);
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log(path);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static bool IsFileExist(string filename)
    {
        string path = PATH(filename);
        return File.Exists(path);
    }

    private static string PATH(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }
}
