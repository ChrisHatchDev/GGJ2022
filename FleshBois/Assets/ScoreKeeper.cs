using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class ScoreKeeper : MonoBehaviour
{
    public bool LocalDB;
    public float MaxTumorSize;
    public string ConnectionString;
    public string PlayerName;
    List<float> ListOfTumorSizes;
    IDbConnection dbcon;
    string connection = "URI=file:" + Application.persistentDataPath + "/" + "GameData";
    
    void Start(){
        createHighscoresTable();

    }

    void createHighscoresTable(){
        dbcon.Open();
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS highscores (id INTEGER PRIMARY KEY, playername TEXT , score INTEGER )";
		dbcmd.ExecuteReader();
        dbcon.Close();
    }

    void saveScore(int score){
        dbcon.Open();
		IDbCommand cmnd = dbcon.CreateCommand();
		cmnd.CommandText = string.Format("INSERT INTO my_table (playername, score) VALUES ({0}, {1})", PlayerName, score);
		cmnd.ExecuteNonQuery();
        dbcon.Close();
    }

    void logDBValues(){
        dbcon.Open();
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query ="SELECT * FROM my_table";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
		{
			Debug.Log("id: " + reader[0].ToString());
			Debug.Log("val: " + reader[1].ToString());
		}
        dbcon.Close();
    }

    void addTumor(float size){
        ListOfTumorSizes.Add(size);
    }
    void startTimer(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
