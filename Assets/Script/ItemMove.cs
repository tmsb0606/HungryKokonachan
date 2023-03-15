using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField] private float downSpeed;
     private MainDirector director;
    private bool isClick = false;
    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("Director").GetComponent<MainDirector>();
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
            //print("click");
            Vector3 touchScreenPosition = Input.mousePosition;
            touchScreenPosition.z = 10.0f;

            Camera gameCamera = Camera.main;
            Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);

            //print(touchWorldPosition);
            pos = touchWorldPosition;
        }
        else
        {
            pos.y -= downSpeed * Time.deltaTime;
        }
        myTransform.position = pos;

        if (myTransform.position.y < -10)
        {
            Manager.combo = 0;
            director.ChangeScore();
            this.gameObject.SetActive(false);
            
        }
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
