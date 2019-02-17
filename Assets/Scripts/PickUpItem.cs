using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public string Name = "Item";
    public int Qty = 1;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Sack sack = other.gameObject.GetComponent<Sack>();

        if (sack != null)
        {
            GameObject go = Instantiate(gameObject, transform);

            sack.Add(Name,new ItemData(Qty,go));

            Destroy(gameObject);
        }
        
    }

    
}
