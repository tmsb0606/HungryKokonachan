using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Twitter : MonoBehaviour
{
    [SerializeField] private Button tweetButton;
    private string link = "https://unityroom.com/games/hungrykokonachan";
    private string hashtag = "ハングリーココナちゃん";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tweet()
    {
        var url = "https://twitter.com/intent/tweet?"+ "text=" +Manager.myScore+ "点獲得！%0a" + "&url=" + link+ "&hashtags=" + hashtag;
#if UNITY_EDITOR
        Application.OpenURL(url);
#elif UNITY_WEBGL
            // WebGLの場合は、ゲームプレイ画面と同じウィンドウでツイート画面が開かないよう、処理を変える
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", url));
#else
            Application.OpenURL(url);
#endif
    }
}
