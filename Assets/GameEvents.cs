using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

    private ArrayList tiles;
    private ArrayList hand;
    private System.Random random;
    private bool waiting;
    private bool action;
    public int discard;
    public string actionTaken;
    public GameObject pong;
    public GameObject kang;
    public GameObject chi;
    public GameObject cancel;
    private int timer;
    private int turn;
    private int offset;
    private int[] discardCount;
    private string[] pongSet;
    private string[] chiSet;

	// Use this for initialization
	void Start () {
        tiles = new ArrayList();
        hand = new ArrayList();
        pongSet = new string[2];
        chiSet = new string[2];
        for(int i=0; i<4; i++)
        {
            for(int j=1; j<=9; j++)
            {
                tiles.Add("man" + j);
                tiles.Add("bamboo" + j);
                tiles.Add("pin" + j);
            }
            tiles.Add("dragon-chun");
            tiles.Add("dragon-green");
            tiles.Add("dragon-haku");
            tiles.Add("wind-east");
            tiles.Add("wind-north");
            tiles.Add("wind-south");
            tiles.Add("wind-west");
        }
        random = new System.Random();
        for(int i=0; i<13; i++)
        {
            int index = random.Next(0, tiles.Count);
            hand.Add(tiles[index]);
            tiles.RemoveAt(index);
        }
        hand.Sort();
        for(int i=1; i<=13; i++)
        {
            GameObject.Find("cards/card" + i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[i - 1]);
        }
        int id = random.Next(0, tiles.Count);
        hand.Add(tiles[id]);
        tiles.RemoveAt(id);
        GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[13]);
        waiting = true;
        action = false;
        discard = 0;
        timer = 0;
        turn = 0;
        offset = 1;
        discardCount = new int[4];
        pong.SetActive(false);
        chi.SetActive(false);
        kang.SetActive(false);
        cancel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (waiting)
        {
            if (action)
            {
                if (actionTaken == "pong")
                {
                    int from = (turn - 1) % 4;
                    int setN = offset / 3 + 1;
                    GameObject.Find("sets/set" + setN + ".1").GetComponent<SpriteRenderer>().sprite =
                        GameObject.Find("discard" + from + "/discard" + from + "." + (discardCount[from]-1)).GetComponent<SpriteRenderer>().sprite;
                    GameObject.Find("sets/set" + setN + ".2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + pongSet[0]);
                    GameObject.Find("sets/set" + setN + ".3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + pongSet[1]);
                    offset += 2;
                    hand.Remove(pongSet[0]);
                    hand.Remove(pongSet[1]);
                    GameObject.Find("cards/card" + (offset - 2)).SetActive(false);
                    GameObject.Find("cards/card" + (offset - 1)).SetActive(false);
                    for (int i = offset; i <= 13; i++)
                    {
                        GameObject.Find("cards/card" + i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[i - offset]);
                    }
                    action = false;
                    pong.SetActive(false);
                    kang.SetActive(false);
                    chi.SetActive(false);
                    cancel.SetActive(false);
                    turn = 0;
                    actionTaken = null;
                }
                else if (actionTaken == "kang")
                {
                    int from = (turn - 1) % 4;
                    int setN = offset / 3 + 1;
                    GameObject.Find("sets/set" + setN + ".1").GetComponent<SpriteRenderer>().sprite =
                        GameObject.Find("discard" + from + "/discard" + from + "." + (discardCount[from] - 1)).GetComponent<SpriteRenderer>().sprite;
                    GameObject.Find("sets/set" + setN + ".2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + pongSet[0]);
                    GameObject.Find("sets/set" + setN + ".3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + pongSet[1]);
                    offset += 2;
                    hand.Remove(pongSet[0]);
                    hand.Remove(pongSet[1]);
                    hand.Remove(pongSet[1]);
                    GameObject.Find("cards/card" + (offset - 2)).SetActive(false);
                    GameObject.Find("cards/card" + (offset - 1)).SetActive(false);
                    for (int i = offset; i <= 13; i++)
                    {
                        GameObject.Find("cards/card" + i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[i - offset]);
                    }
                    action = false;
                    pong.SetActive(false);
                    kang.SetActive(false);
                    chi.SetActive(false);
                    cancel.SetActive(false);
                    turn = 0;
                    actionTaken = null;
                }
                else if (actionTaken == "chi")
                {
                    int from = (turn - 1) % 4;
                    int setN = offset / 3 + 1;
                    GameObject.Find("sets/set" + setN + ".1").GetComponent<SpriteRenderer>().sprite =
                        GameObject.Find("discard" + from + "/discard" + from + "." + (discardCount[from] - 1)).GetComponent<SpriteRenderer>().sprite;
                    GameObject.Find("sets/set" + setN + ".2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + chiSet[0]);
                    GameObject.Find("sets/set" + setN + ".3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + chiSet[1]);
                    setN++;
                    offset += 2;
                    hand.Remove(chiSet[0]);
                    hand.Remove(chiSet[1]);
                    GameObject.Find("cards/card" + (offset - 2)).SetActive(false);
                    GameObject.Find("cards/card" + (offset - 1)).SetActive(false);
                    for (int i = offset; i <= 13; i++)
                    {
                        GameObject.Find("cards/card" + i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[i - offset]);
                    }
                    action = false;
                    pong.SetActive(false);
                    kang.SetActive(false);
                    chi.SetActive(false);
                    cancel.SetActive(false);
                    turn = 0;
                    actionTaken = null;
                }
                else if (actionTaken == "cancel")
                {
                    action = false;
                    pong.SetActive(false);
                    kang.SetActive(false);
                    chi.SetActive(false);
                    cancel.SetActive(false);
                    if (turn == 4 && !action)
                    {
                        turn = 0;
                        int id = random.Next(0, tiles.Count);
                        hand.Add(tiles[id]);
                        tiles.RemoveAt(id);
                        GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[14 - offset]);
                        waiting = true;
                    }
                    actionTaken = null;
                }
            }
            else
            {
                if (discard != 0)
                {
                    GameObject.Find("discard0/discard0." + discardCount[0]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[discard - offset]);
                    hand.RemoveAt(discard - offset);
                    hand.Sort();
                    if (offset % 3 != 1)
                    {
                        offset++;
                        GameObject.Find("cards/card" + (offset - 1)).SetActive(false);
                    }
                    for (int i = offset; i <= 13; i++)
                    {
                        GameObject.Find("cards/card" + i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[i - offset]);
                    }
                    GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = null;
                    discardCount[0]++;
                    if (discardCount[0] == 13)
                        discardCount[0] = 0;
                    waiting = false;
                    turn = 1;
                    discard = 0;
                }
            }
        }else
        {
            timer++;
            if (timer == 60)
            {
                timer = 0;
                int id = random.Next(0, tiles.Count);
                string s = (string)tiles[id];
                tiles.RemoveAt(id);
                GameObject.Find("discard"+turn+"/discard"+turn+"." + discardCount[turn]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + s);
                discardCount[turn]++;
                if (discardCount[turn] == 12)
                    discardCount[turn] = 0;
                checkHand(s);
                turn++;
                if(turn == 4 && !action)
                {
                    turn = 0;
                    id = random.Next(0, tiles.Count);
                    hand.Add(tiles[id]);
                    tiles.RemoveAt(id);
                    GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[14-offset]);
                    waiting = true;
                }
            }
        }
		
	}

    void checkHand(string s)
    {
        string pre = s.Substring(0, s.Length - 1);
        int number;
        try
        {
            number = Int32.Parse(s.Substring(s.Length - 1));
        }
        catch
        {
            number = 0;
        }
        int pkcounter = 0;
        for(int i=0; i<13-offset; i++)
        {
            if (hand[i].Equals(s))
            {
                pkcounter++;
                if(pkcounter == 2)
                {
                    waiting = true;
                    action = true;
                    pong.SetActive(true);
                    cancel.SetActive(true);
                    pongSet[0] = s;
                    pongSet[1] = s;
                }
                if(pkcounter == 3)
                {
                    waiting = true;
                    action = true;
                    kang.SetActive(true);
                    cancel.SetActive(true);
                    pongSet[0] = s;
                    pongSet[1] = s;
                }
            }
        }
        if (turn == 3 && number!=0) {
            string sm2 = pre + (number - 2);
            string sm1 = pre + (number - 1);
            string sp1 = pre + (number + 1);
            string sp2 = pre + (number + 2);
            if ((hand.Contains(sm2) && hand.Contains(sm1)) || (hand.Contains(sm1) && hand.Contains(sp1)) || (hand.Contains(sp1) && hand.Contains(sp2))){
                waiting = true;
                action = true;
                chi.SetActive(true);
                cancel.SetActive(true);
                if (hand.Contains(sm2) && hand.Contains(sm1))
                {
                    chiSet[0] = sm2;
                    chiSet[1] = sm1;
                }
                if (hand.Contains(sm1) && hand.Contains(sp1))
                {
                    chiSet[0] = sm1;
                    chiSet[1] = sp1;
                }
                if(hand.Contains(sp1) && hand.Contains(sp2))
                {
                    chiSet[0] = sp1;
                    chiSet[1] = sp2;
                }
            }
        }

    }
}
