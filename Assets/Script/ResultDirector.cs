using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResultDirector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rankText;
    public GameObject saveButton;
    public GameObject saveText;
    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = Manager.myScore.ToString() + "ì_";
        GetComponent<Ranking>().GetRank(100, rankText);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveText()
    {
        saveButton.GetComponent<Button>().interactable = false;
        saveText.SetActive(true);
        StartCoroutine(closeText(5f));
    }
    IEnumerator closeText(float delay)
    {
        //delayïbë“Ç¬
        yield return new WaitForSeconds(delay);
        /*èàóù*/
        saveText.SetActive(false);
    }
}
