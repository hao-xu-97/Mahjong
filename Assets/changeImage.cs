﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeImage : MonoBehaviour {

    public int counter;

	// Use this for initialization
	void Start () {
        //load initial instruction
        GetComponent<Image>().sprite = Resources.Load<Sprite>("instructions/s1");
        counter = 2;
    }
	
	// Update is called once per frame
	void Update () {
        //update instruction on every mouse click and change game state accordingly
        if (Input.GetMouseButtonDown(0))
        {
            if(counter == 35)
            {
                SceneManager.LoadScene("menu");
            }
            string s = "instructions/s" + counter;
            GetComponent<Image>().sprite = Resources.Load<Sprite>(s);
            if(counter == 10)
            {
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man6");
            }
            if(counter == 13)
            {
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = null;
                GameObject.Find("cards/card5").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man6");
                GameObject.Find("discard0").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man9");
                GameObject.Find("discard1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man1");
            }
            if(counter == 15)
            {
                GameObject.Find("discard1").GetComponent<SpriteRenderer>().sprite = null;
                GameObject.Find("set1.1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man1");
                GameObject.Find("set1.2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man1");
                GameObject.Find("set1.3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man1");
                GameObject.Find("cards/card1").GetComponent<SpriteRenderer>().sprite = null;
                GameObject.Find("cards/card2").GetComponent<SpriteRenderer>().sprite = null;
            }
            if (counter == 18)
            {
                GameObject.Find("discard0.1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/pin7");
                for (int i = 9; i >=4; i--)
                {
                    string cardB = "cards/card" + i;
                    string cardA = "cards/card" + (i - 1);
                    GameObject.Find(cardB).GetComponent<SpriteRenderer>().sprite = GameObject.Find(cardA).GetComponent<SpriteRenderer>().sprite;
                }
                GameObject.Find("cards/card3").GetComponent<SpriteRenderer>().sprite = null;
            }
            if(counter == 19)
            {
                GameObject.Find("discard1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/wind-north");
            }
            if (counter == 20)
            {
                GameObject.Find("discard2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/pin7");
            }
            if (counter == 21)
            {
                GameObject.Find("discard3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man7");
            }
            if (counter == 22)
            {
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/bamboo2");
            }
            if(counter == 24)
            {
                GameObject.Find("discard0.2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/bamboo2");
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = null;
            }
            if (counter == 25)
            {
                GameObject.Find("discard1.1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/bamboo8");
            }
            if (counter == 26)
            {
                GameObject.Find("discard2.1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/bamboo4");
            }
            if (counter == 27)
            {
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/bamboo4");
                GameObject.Find("discard2.1").GetComponent<SpriteRenderer>().sprite = null;
            }
            counter++;
        }
		
	}

}
