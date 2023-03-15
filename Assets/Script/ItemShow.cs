using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShow : MonoBehaviour
{
    public ItemDataBase itemDataBase;
    public GameObject canvas;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = (GameObject)Instantiate(image);
        prefab.GetComponent<Image>().sprite = itemDataBase.itemList[0].GetComponent<ItemData>().itemSprite;
        prefab.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
