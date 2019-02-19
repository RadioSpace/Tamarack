using System.Collections;
using System.Collections.Generic;
using System.Linq;


using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour
{
    Sack sack;
    
    
    
    

    

    // Start is called before the first frame update
    void Start()
    {
        sack = GetComponentInParent<Sack>();

        sack.ItemAdded += Sack_ItemAdded;
        sack.ItemRemoved += Sack_ItemRemoved;
        sack.SackCleared += Sack_SackCleared;
        

        

        
    }

    private void Sack_SackCleared(object sender, System.EventArgs e)
    {
        RefreshList();
    }

    private void Sack_ItemRemoved(object sender, SackEventArgs e)
    {
        RefreshList();
    }

    private void Sack_ItemAdded(object sender, SackEventArgs e)
    {
        RefreshList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RefreshList()
    {
        //clear list

        for(int x = 0;x < transform.childCount;x++)
        {
            Transform child = transform.GetChild(x);

            Destroy(child.gameObject);
        }

        foreach (string key in sack.Keys)
        {
            

            GameObject itemTemplate = Resources.Load<GameObject>("ListItem");
            GameObject newitem = Instantiate(itemTemplate);
            
            ListItemDataBind newItemData = newitem.GetComponent<ListItemDataBind>();

            newItemData.SackKey = key;

            newitem.transform.SetParent(transform);
            


        }
    }
    
}
