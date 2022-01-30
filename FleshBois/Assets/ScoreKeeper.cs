using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.Events;
using System.Linq;

public class ScoreKeeper : MonoBehaviour
{
    const string TableName = "highscores";
    public bool LocalDB;
    public float MaxTumorSize = 10.0f;
    public string ConnectionString;
    public string PlayerName;
    int currentScore = 0;
    bool validScore = true;

    List<float> ListOfTumorSizes = new List<float>();
    List<float> ListOfDamage = new List<float>();

    IDbConnection dbcon;
    string connection;

    public UnityEvent UpdatedScore = new UnityEvent();
    
    void Start(){

        ListOfDamage.Add(0f);
        ListOfTumorSizes.Add(0f);

        connection = "URI=file:" + Application.persistentDataPath + "/" + "GameData";
        dbcon = new SqliteConnection(connection);
        createHighscoresTable();
        //test();
    }
    void Update(){
        
    }

    void test(){
        PlayerName = "test";
        saveScore(69);
        saveScore(420);
        logDBValues();
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

    public void addTumor(float size){
        Debug.Log("TUMOR ADDED");

        validScore = false;
        ListOfTumorSizes.Add(MaxTumorSize/size);
        UpdatedScore.Invoke();
    }
    public void addDamage(float damage){
        Debug.Log("DAMAGE ADDED");

        validScore = false;
        ListOfDamage.Add(damage);
        UpdatedScore.Invoke();
    }

    public int getCurrentScore(){
        if(validScore){
            return currentScore;
        }
        else{
            currentScore = ((int)((ListOfTumorSizes.Sum() - ListOfDamage.Sum()) * 0.1f));
            validScore = true;
            return currentScore;
        }
    }
    public void clearScore(){
        currentScore = 0;
        validScore = true;
        ListOfDamage.Clear();
        ListOfTumorSizes.Clear();
    }
}
