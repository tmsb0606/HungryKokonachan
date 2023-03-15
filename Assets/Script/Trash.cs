using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private GameObject director;
    private MainDirector mainDirector;
    [SerializeField] private AudioClip eatSound;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        director = GameObject.Find("Director");
        mainDirector = director.GetComponent<MainDirector>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        ItemData item = other.gameObject.GetComponent<ItemData>();

        if (item.itemType == ItemType.Hate)
        {

            Manager.myScore += (float)item.score + (item.score * ((float)Manager.combo / 10f));
            Manager.combo++;
            //Manager.hp += 50;
        }
        else
        {
            Manager.myScore -= item.score;
            Manager.combo = 0;
            //Manager.hp += 50;
        }
        audioSource.PlayOneShot(eatSound);
        mainDirector.ChangeScore();
        other.gameObject.SetActive(false);
    }
}
