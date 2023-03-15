using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private TMP_InputField field;
    
    void Start()
    {
        //LoadScore(2);
        //ResultRank(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveScore()
    {
        NCMBObject scoreClass = new NCMBObject("ScoreClass");
        scoreClass["score"] = Manager.myScore;
        scoreClass["name"] = field.text.ToString();
        scoreClass.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("Error: " + e.ErrorMessage);
            }
            else
            {
                Debug.Log("success");
            }
        });
        print("save");
        GameObject.Find("Director").GetComponent<ResultDirector>().SaveText();
    }
    public void LoadScore(int limit)
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
                    rank = i + 1;
                    Debug.Log("ScoreRanking " + rank + "ˆÊ" + objList[i]["name"]+":"+ objList[i]["score"]+"“_");
                }
            }
        });

    }
    public void GetRank(int limit, TextMeshProUGUI text)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreClass");
        query.OrderByDescending("score");
        query.Limit = limit;
        int rank = 1;
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
                    int score = int.Parse(objList[i]["score"].ToString());
                    if (score  > Manager.myScore)
                    {
                        rank ++ ;
                    }
                }
                text.text = rank.ToString() + "ˆÊ";
                if (rank > limit)
                {
                    text.text = "Œ—ŠO";
                }
            }
        });

    }
}
