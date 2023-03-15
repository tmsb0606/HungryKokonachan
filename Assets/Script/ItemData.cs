using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Like,
    Hate,
}


public class ItemData : MonoBehaviour
{
    [field: SerializeField] public string itemName { get; private set; }
    [field: SerializeField] public Sprite itemSprite{ get; private set; }
    [field: SerializeField] public ItemType itemType { get; private set; }
    [field: SerializeField] public int score { get; private set; }

}
