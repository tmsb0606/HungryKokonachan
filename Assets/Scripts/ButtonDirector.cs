using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ButtonDirector : MonoBehaviour
{
    public GameObject descriptionPanel;
    public GameObject rulePanel;
    public GameObject itemPanel;
    public GameObject rankingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void DisplayDescription()
    {
        descriptionPanel.SetActive(true);
    }
    public void CloseDescription()
    {
        descriptionPanel.SetActive(false);
        rulePanel.SetActive(true);
        itemPanel.SetActive(false);
    }
    public void changePanel()
    {
        rulePanel.SetActive(!rulePanel.activeSelf);
        itemPanel.SetActive(!itemPanel.activeSelf);
    }
    public void OpenRranking()
    {
        rankingPanel.SetActive(true);
    }
    public void CloseRanking()
    {
        rankingPanel.SetActive(false);
    }
}
