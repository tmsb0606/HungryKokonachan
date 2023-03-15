using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class ItemDataBase : ScriptableObject
{
    public List<GameObject> itemList = new List<GameObject>();
}
