using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{

    PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        

        stats = GetComponent<PlayerStats>();
        stats.Add(new KeyValuePair<string, PlayerStat>("Magic",new PlayerStat("Magic","How much magical energy you have",100,100)));
        stats.Add(new KeyValuePair<string, PlayerStat>("Hunger", new PlayerStat("Hunger", "How much food you have eatin", 20,20)));
        stats.Add(new KeyValuePair<string, PlayerStat>("Thirst", new PlayerStat("Thirst", "how much water you have drank", 100,100)));
        stats.Add(new KeyValuePair<string, PlayerStat>("Blood", new PlayerStat("Blood", "How much blood is in the body", 100,100)));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
