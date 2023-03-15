using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item : MonoBehaviour
{
    
    [field: SerializeField] public string itemName { get; private set; }
    [field: SerializeField] public ItemType itemType { get; private set; }
    [field: SerializeField] public int score { get; private set; }
    [SerializeField] private float downSpeed;
    private bool isClick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        MoveItem();
    }

    private void MoveItem()
    {
        Transform myTransform = this.transform;

        // ç¿ïWÇéÊìæ
        Vector3 pos = myTransform.position;
        if (isClick)
        {
            print("click");
            Vector3 touchScreenPosition = Input.mousePosition;
            touchScreenPosition.z = 10.0f;

            Camera gameCamera = Camera.main;
            Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);

            print(touchWorldPosition);
            pos = touchWorldPosition;
        }
        else
        {
            pos.y -= downSpeed;
        }


        myTransform.position = pos;
    }

    void OnMouseDrag()
    {
        isClick = true;
    }
    void OnMouseUp()
    {
        isClick = false;
    }

    public bool IsClickItem()
    {
        return isClick;
    }

}
