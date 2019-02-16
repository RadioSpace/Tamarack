using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    public float ThristDecayRate = 0.001157407f;
    public float HungerDecayRate = ;




    // Start is called before the first frame update
    void Start()
    {        
        DontDestroyOnLoad(this);
        

        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
