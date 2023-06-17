using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Item Item;
    // Start is called before the first frame update
    void Start()
    {
        Item = this.GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        Item.enabled = false;
        print(Item.itemType);
        print(Item.score);
    }
}
