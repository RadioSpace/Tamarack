
using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sack : MonoBehaviour, IDictionary<string, ItemData>
{
    Dictionary<string, ItemData> Items = new Dictionary<string, ItemData>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {

    }

    #region events

    public event EventHandler<SackEventArgs> ItemAdded;
    void OnItemAdded(SackEventArgs e) { if (ItemAdded != null) ItemAdded(this, e); }

    public event EventHandler<SackEventArgs> ItemRemoved;
    void OnItemRemoved(SackEventArgs e) { if (ItemRemoved != null) ItemRemoved(this, e); }

    public event EventHandler SackCleared;
    void OnSackCleared() { if (SackCleared != null) SackCleared(this,EventArgs.Empty); }

    #endregion
    
    #region IDictionary
    public ItemData this[string key] { get => Items[key]; set => throw new NotImplementedException(); }

    public ICollection<string> Keys => Items.Keys;

    public ICollection<ItemData> Values => Items.Values;

    public int Count => Items.Count;

    public bool IsReadOnly => false;
    /// <summary>
    /// add the QTY to the existing item or just add the item
    /// </summary>
    /// <param name="key">the item</param>
    /// <param name="value">the value to add ItemData.Qty</param>
    public void Add(string key, ItemData value)
    {


        if (Items.ContainsKey(key))
        {


            Items[key].Qty += value.Qty;

            OnItemAdded(new SackEventArgs(key, value.Qty));

            value.DestroyGameObject();

            
        }
        else
        {

            
            Items.Add(key, value);
            OnItemAdded(new SackEventArgs(key, value.Qty));

        }
    }

    /// <summary>
    /// add to the existing or add the item
    /// </summary>
    /// <param name="item">the key value pair</param>
    public void Add(KeyValuePair<string, ItemData> item)
    {
        if (Items.ContainsKey(item.Key))
        {
            Items[item.Key].Qty += item.Value.Qty;

            OnItemAdded(new SackEventArgs(item.Key, item.Value.Qty));

            item.Value.DestroyGameObject();
        }
        else
        {
            Items.Add(item.Key, item.Value);

            OnItemAdded(new SackEventArgs(item.Key, item.Value.Qty));
        }
    }

    /// <summary>
    /// clear the list
    /// </summary>
    public void Clear()
    {
        Items.Clear();
        OnSackCleared();
    }

    public bool Contains(KeyValuePair<string, ItemData> item)
    {
        return Items.ContainsKey(item.Key) && Items.ContainsValue(item.Value);
    }
    public bool Contains(string key)
    {
        return Items.ContainsKey(key);
    }

    public bool ContainsKey(string key)
    {
        return Items.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<string, ItemData>[] array, int arrayIndex)
    {
        throw new NotImplementedException("you will have to do this yourself");
    }

    public IEnumerator<KeyValuePair<string, ItemData>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// removes an item from the sack
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Remove(string key)
    {
        if (Items.ContainsKey(key))
        {
            Items[key].DestroyGameObject();

            Items.Remove(key);

            OnItemRemoved(new SackEventArgs(key,0));

            return true;
        }
        else return false;
    }


    /// <summary>
    /// removes a quantity from the entry
    /// </summary>
    /// <param name="item">the key value pair</param>
    /// <returns>true if something happned</returns>
    public bool Remove(KeyValuePair<string, ItemData> item)
    {
        if (Items.ContainsKey(item.Key))
        {
            if (Items[item.Key].Qty <= item.Value.Qty)
            {
                Items[item.Key].DestroyGameObject();//i suck
                item.Value.DestroyGameObject();

                Remove(item.Key);

                OnItemRemoved(new SackEventArgs(item.Key, item.Value.Qty));
            }
            else
            {
                Items[item.Key].Qty -= item.Value.Qty;
                OnItemRemoved(new SackEventArgs(item.Key, item.Value.Qty));
            }



            return true;
        }
        else return false;
    }

    public bool TryGetValue(string key, out ItemData value)
    {
        ItemData result;
        if (Items.TryGetValue(key, out result))
        {
            value = result;
            return true;
        }
        else
        {
            value = null;
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Items.GetEnumerator();
    }


    #endregion
}

/// <summary>
/// information for sack events
/// </summary>
public class SackEventArgs : EventArgs
{
    /// <summary>
    /// the key the item that was added  was placed under
    /// </summary>
    public readonly string Key;

    /// <summary>
    /// The amount of changed in the Sack
    /// </summary>
    public readonly int Qty;

    /// <summary>
    /// creates a SackEventArgs
    /// </summary>
    /// <param name="key">the string the item is stored by</param>
    /// <param name="value">the amount of change to the item in the sack</param>
    public SackEventArgs(string key,int qty)
    {
        Key = key;
        Qty = qty;
    }

}

/// <summary>
/// data needed to interact with the sack
/// </summary>
public class ItemData
{
    /// <summary>
    /// the amount of this item being held
    /// </summary>
    public int Qty { get; set; }
    /// <summary>
    /// a reference to the game object so we can use its effects
    /// </summary>
    GameObject Obj;

    public ItemData(int q, GameObject o)
    {
        Qty = q;
        Obj = o;

        Obj.SetActive(false);
    }

    
    public void DestroyGameObject()
    {
        UnityEngine.GameObject.Destroy(Obj);
    }

    public override string ToString()
    {
        return Qty.ToString();
    }
}
