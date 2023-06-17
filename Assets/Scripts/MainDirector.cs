using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

enum GameState
{
    Start,
    Game,
    End,
    Null,
}
public class MainDirector : MonoBehaviour
{
    public ItemDataBase itemDataBase;
    private float time = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public Slider hpGauge;
    private float itemTime = 0f;
    private float itemLimitTime = 1f;
    private float itemLastTime = 1f;
    private float gameTime = 0f;
    private float gameLastTime = 0f;
    private float feverTime = 0f;
    private int gameLevel = 1;
    private float damage = 100f;
    [SerializeField] GameState gameState=GameState.Start;
    [SerializeField] private PlayableDirector endCutIn;
    [SerializeField] private GameObject bgmManager;
    [SerializeField] private SpriteRenderer bg;


    // Start is called before the first frame update
    void Start()
    {
        //Managerの初期化
        Manager.InitializeManager();
        hpGauge.value = Manager.hp;
        endCutIn.Stop();


    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Start:
                //StartGame();
                break;
            case GameState.Game:
                PlayGame();
                break;
            case GameState.End:
                EndCunIn();
                break;
        }

    }

    //タイムラインからシグナルを受け取ったらゲームスタート
    public void StartGame()
    {
        gameState = GameState.Game;
        bgmManager.SetActive(true);
    }
    public void EndCunIn()
    {
        endCutIn.Play();
    }
    public void EndGame()
    {
        ChangeScene();
    }
    public void PlayGame()
    {
        time += Time.deltaTime;
        //print(hungryTime);
        //フィーバー中にHPが減らないようにするかどうか。

        //hungryLastTime = hungryTime;
        Manager.hp -= (damage * Time.deltaTime);
        hpGauge.value = Manager.hp;

        if (time - itemLastTime > itemLimitTime)
        {
            int itemIndex = Random.Range(0, itemDataBase.itemList.Count);
            itemLastTime = time;
            GameObject prefab = (GameObject)Instantiate(itemDataBase.itemList[itemIndex]);
            prefab.transform.position = new Vector3(Random.Range(-3, 3), prefab.transform.position.y, prefab.transform.position.z);

        }
        if (time -gameLastTime>= 10)
        {
            
            itemLimitTime -= 0.05f;
            gameLastTime = time;
            gameLevel++;
            print("レベルアップ" + gameLevel);
        }
        if(gameLevel == 7)
        {
            //damage = 200;
        }
        if (Manager.combo != 0 && Manager.combo % 15 == 0 && !Manager.isFever)
        {
            Manager.isFever = true;
            print("フィーバー");
            bg.color = new Color(255f, 255f, 0f);
            StartCoroutine(EndFever(5f));
        }
        //print(Manager.myScore);
        if (Manager.hp <= 0)
        {
            gameState = GameState.End;
        }
    }
    public void ChangeScore()
    {

        scoreText.text = Manager.myScore.ToString();
        comboText.text = Manager.combo.ToString();
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    IEnumerator EndFever(float delay)
    {
        //delay秒待つ
        yield return new WaitForSeconds(delay);
        /*処理*/
        print("フィーバー終了");
        bg.color = new Color(255f, 255f, 255f);
        Manager.isFever = false ;
    }

}
