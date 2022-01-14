using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static bool loaded = false;
    private static string save = "player1.txt";

    public static void SavePlayer(Player player){


        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "player1.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        // On écrit dans le fichier
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData loadPlayer(string save){

        string path = Application.persistentDataPath + "player1.txt";
        if(File.Exists(path)){

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            // On lit le fichier et on stocke dans data
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else{
            Debug.Log("Fichier non trouvé");
            return null;
        }

    }

    public static void setScene(){

    }

    public static string getSave(){
        return save;
    }
    
}
