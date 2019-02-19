using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

public class ListItemDataBind : MonoBehaviour
{

    public string SackKey;
    Text label;
    Text qty;


    // Start is called before the first frame update
    void Start()
    {
        Sack sack = GetComponentInParent<Sack>();

        Text[] labels = GetComponentsInChildren<Text>();



        label = labels.Where(a => a.name == "Label").First();
        qty = labels.Where(a => a.name == "Qty").First();


        if (sack != null)
        {
            label.text = SackKey;
            qty.text = sack[SackKey].Qty.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

