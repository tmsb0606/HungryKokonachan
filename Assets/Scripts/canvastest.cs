using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvastest : MonoBehaviour
{
    public GameObject canvas;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = (GameObject)Instantiate(UI);
        prefab.AddComponent<RectTransform>();
        prefab.AddComponent<CanvasRenderer>();
        prefab.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
