using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEat : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject director;
    private MainDirector mainDirector;
    public Sprite nomalFace;
    public Sprite smileFace;
    public Sprite cryFace;
    private Coroutine coroutine;

    [SerializeField]private  AudioClip eatSound;
    [SerializeField]private AudioSource audioSource;
    void Start()
    {
        director = GameObject.Find("Director");
        mainDirector = director.GetComponent<MainDirector>();
        coroutine = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (coroutine!=null)
        {
            StopCoroutine(coroutine);
        }
        //StopCoroutine(coroutine);
        ItemData item = other.gameObject.GetComponent<ItemData>();
        if (Manager.isFever)
        {
            ChanheSprite(smileFace);
            print(item.itemType);
            Manager.myScore += ((float)item.score+(item.score*((float)Manager.combo/10f)))*2;
            Manager.combo++;
            Manager.hp += 100;
            
        }
        else
        {
            if (item.itemType == ItemType.Like)
            {
                ChanheSprite(smileFace);
                Manager.myScore += (float)item.score + (item.score * ((float)Manager.combo / 10f));
                Manager.combo++;
                Manager.hp += 50;
            }
            else
            {
                ChanheSprite(cryFace);
                Manager.myScore -= item.score;
                Manager.combo = 0;
                Manager.hp += 50;
            }
        }
        audioSource.PlayOneShot(eatSound);
        mainDirector.ChangeScore();
        other.gameObject.SetActive(false);
        coroutine = StartCoroutine(DelayChangeface(1f, nomalFace));


    }

    private void ChanheSprite(Sprite sprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    IEnumerator DelayChangeface(float delay, Sprite sprite)
    {
        //delayïbë“Ç¬
        yield return new WaitForSeconds(delay);
        /*èàóù*/
        this.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
