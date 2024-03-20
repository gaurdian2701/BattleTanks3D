using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> where T : class
{
    private List<PooledItem> pooledItems = new List<PooledItem>();

    public virtual T GetItemFromPool<U>() where U : T
    {
        if(pooledItems.Count > 0)
        {
            PooledItem item = pooledItems.Find((itemToFind) => !itemToFind.IsUsed && itemToFind.Item is U);

            if(item != null)
            {
                item.IsUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem<U>();
    }

    private T CreateNewPooledItem<U>() where U : T
    {
        PooledItem newItem = new PooledItem();
        newItem.Item = CreateItem<U>(); 
        newItem.IsUsed = true;
        pooledItems.Add(newItem);
        return newItem.Item;
    }

    protected virtual T CreateItem<U>() where U : T
    {
        throw new System.Exception("Method not Implemented!");
    }

    public virtual void ReturnItemToPool(T item)
    {
        PooledItem itemFound = pooledItems.Find((itemToFind) => itemToFind.Item.Equals(item));
        Debug.Log(itemFound.Item);
        if (itemFound != null)
            itemFound.IsUsed = false;
    }

    public class PooledItem
    {
        public T Item;
        public bool IsUsed;
    }
}


