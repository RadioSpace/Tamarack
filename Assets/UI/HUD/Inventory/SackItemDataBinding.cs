using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

public class SackItemDataBinding : MonoBehaviour
{

    

    Sack sack;
    Text[] ItemLabels = new Text[4];
    Text[] QtyLabels = new Text[4];

    


    

    // Start is called before the first frame update
    void Start()
    {

        sack = gameObject.GetComponent<Sack>();
        if (sack != null)
        {
     
            
            for (int x = 0; x < 4; x++)
            {
                ItemLabels[x] = gameObject.GetComponents<Text>().Where(a => a.canvas.name == $"HB_{x}").Where(b => b.name == "Label").First();
                QtyLabels[x] = gameObject.GetComponents<Text>().Where(a => a.canvas.name == $"HB_{x}").Where(b => b.name == "Qty").First();


            }
        }
    }

    private void Sack_SackCleared(object sender, System.EventArgs e)
    {
        for (int x = 0; x < 4; x++)
        {
            ItemLabels[x].text = "";
            QtyLabels[x].text = "0";
            

        }
    }

    private void Sack_ItemRemoved(object sender, SackEventArgs e)
    {
        if(ItemLabels.Select(a=> a.text ).Contains(e.Key))
        {
            //find index
            int index = -1;

            for (int x = 0; x < 4; x++)
            {
                if(ItemLabels[x].text == e.Key)
                {
                    index = x;
                    break;
                }
            }


            //deal with it
            if(index != -1)
            {
                if(sack.ContainsKey(e.Key))
                {//we have not removed the item completly
                    QtyLabels[index].text = sack[e.Key].Qty.ToString();
                }
                else
                {//the item is all gone
                    QtyLabels[index].text = "0";
                    ItemLabels[index].text = "";
                    
                }

             

            }
        }
    }

    private void Sack_ItemAdded(object sender, SackEventArgs e)
    {

        //find index
        int index = -1;

        for (int x = 0; x < 4; x++)
        {
            if(ItemLabels[x].text == e.Key)
            {
                index = x;
                break;
            }
        }

        if (index != -1)
        {//update quantity
            QtyLabels[index].text = sack[e.Key].Qty.ToString();
          
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    


        
    }

    public void SetHotbarItem(string name,int slot)
    {

        if (slot > -1 && slot < 5)
        {
            if (sack != null)
            {
                if (sack.Contains(name))
                {
                    ItemLabels[slot].text = name;
                    QtyLabels[slot].text = sack[name].Qty.ToString();
                }
            }
        }
    }


}
