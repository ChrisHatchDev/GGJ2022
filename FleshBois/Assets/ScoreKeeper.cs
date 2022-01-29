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
    const string TableName = "highscores";
    List<float> ListOfTumorSizes;
    IDbConnection dbcon;
    string connection;
    
    void Start(){
        connection = "URI=file:" + Application.persistentDataPath + "/" + "GameData";
        //Debug.Log(connection);
        dbcon = new SqliteConnection(connection);
        createHighscoresTable();
        // PlayerName = "test";
        // saveScore(69);
        // saveScore(420);
        // logDBValues();

    }

    void createHighscoresTable(){
        dbcon.Open();
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		dbcmd.CommandText = string.Format("CREATE TABLE IF NOT EXISTS {0} (id INTEGER PRIMARY KEY, playername TEXT , score INTEGER )", TableName) ;
		dbcmd.ExecuteReader();
        dbcon.Close();
    }

    void saveScore(int score){
        dbcon.Open();
		IDbCommand cmnd = dbcon.CreateCommand();
        //Debug.Log(string.Format("INSERT INTO {0} (playername, score) VALUES ('{1}', {2})", TableName, PlayerName, score));
		cmnd.CommandText = string.Format("INSERT INTO {0} (playername, score) VALUES ('{1}', {2})", TableName, PlayerName, score);
		cmnd.ExecuteNonQuery();
        dbcon.Close();
    }

    void logDBValues(){
        dbcon.Open();
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query =string.Format("SELECT * FROM {0}", TableName);
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
		{
            Debug.Log(reader.ToString());
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
