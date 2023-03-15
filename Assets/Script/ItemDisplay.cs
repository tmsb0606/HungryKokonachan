using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemDisplay : MonoBehaviour
{
    public ItemDataBase itemDataBase;
    public ItemType itemType;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        var itemList = itemDataBase.itemList
                 .Where(item => item.GetComponent<ItemData>().itemType == itemType)
                 .Select(item => item);

        foreach(var item in itemList)
        {
            GameObject prefab = (GameObject)Instantiate(image);
            prefab.GetComponent<Image>().sprite = item.GetComponent<ItemData>().itemSprite;
            prefab.transform.SetParent(this.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
