using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudControls : MonoBehaviour
{

    bool showItemInventory;


    GameObject InventoryPanel;

    public bool ShowItemInventory
    {
        get
        {
            return showItemInventory;
        }

        set
        {
            showItemInventory = value;
            gameObject.SetActive(value);            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
