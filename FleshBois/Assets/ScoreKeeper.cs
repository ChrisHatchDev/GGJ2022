using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class ScoreKeeper : MonoBehaviour
{
    public bool Local;
    public string ConnectionString;

    
    // Start is called before the first frame update
    void Start(){
        string connection = "URI=file:" + Application.persistentDataPath + "/My_Database";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        string q_createTable = 
        "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";
        
        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }

    void startTimer(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
