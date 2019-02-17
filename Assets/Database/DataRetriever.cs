using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;




/// <summary>
/// sets up taling to the database
/// </summary>
public class DataRetriever : MonoBehaviour
{




    static SqliteConnection connection;

    static DataSet data;
    
    static SqliteDataAdapter ItemAdapter;
    static SqliteDataAdapter PlayerAdapter;
    static SqliteDataAdapter PlayerItemAdapterAdapter;

    static void StartDatabase()
    {
        data = new DataSet();

        SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
        builder.DataSource = "GamePlayDatabase.db";

        //SqliteFactory.Instance.CreateDataAdapter

        connection = new SqliteConnection(builder.ToString());

        try
        {
            connection.Open();
        }
        catch (Exception EX)
        {
            Debug.Log($"open connection failed: {EX.Message}");
        }


        SqliteCommand PlayerCommand = new SqliteCommand("select * from player", connection);
        PlayerAdapter = new SqliteDataAdapter(PlayerCommand);
        PlayerAdapter.Fill(data, "Player");


        SqliteCommand Itemcommand = new SqliteCommand("select * from item;", connection);
        ItemAdapter = new SqliteDataAdapter(Itemcommand);
        ItemAdapter.Fill(data, "Item");


        foreach (DataTable Table in data.Tables)
        {
            print($"TABLE NAME : {Table.TableName}  ###################################");

            foreach (DataRow row in Table.Rows)
            {
                print($"{row["name"]}");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        StartDatabase();       
            
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void RegisterPlayer(string name)
    {
        //name has to be unique. datbase is setup this way

        string insertSQL = $@"insert into Player(name) value({name})";
        

    }
}

