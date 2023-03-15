using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using UnityEngine.UI;
using TMPro;

public class RankingDisplay : MonoBehaviour
{
    [SerializeField] private GameObject rankingText;
    // Start is called before the first frame update
    void Start()
    {
        LoadRanking(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadRanking(int limit)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreClass");
        query.OrderByDescending("score");
        query.Limit = limit;
        int rank = 0;
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogWarning("error: " + e.ErrorMessage);
            }
            else
            {
                for (int i = 0; i < objList.Count; i++)
                {
                    rank++;
                    GameObject prefab = (GameObject)Instantiate(rankingText);
                    prefab.transform.SetParent(this.transform, false);
                    prefab.GetComponent<TextMeshProUGUI>().text = rank + "ˆÊ" + objList[i]["name"] + ":" + objList[i]["score"] + "“_";
                    
                    Debug.Log("ScoreRanking " + rank + "ˆÊ" + objList[i]["name"] + " : " + objList[i]["score"] + "“_");
                }
            }
        });

    }
}
