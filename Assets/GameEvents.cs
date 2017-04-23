using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

    private ArrayList tiles;
    private ArrayList hand;
    private System.Random random;
    private bool waiting;
    public int discard;
    private int timer;
    private int turn;
    private int[] discardCount;

	// Use this for initialization
	void Start () {
        tiles = new ArrayList();
        hand = new ArrayList();
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
        discard = 0;
        timer = 0;
        turn = 0;
        discardCount = new int[4];
	}
	
	// Update is called once per frame
	void Update () {
        if (waiting)
        {
            if (discard != 0)
            {
                GameObject.Find("discard0/discard0."+discardCount[0]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/"+hand[discard-1]);
                hand.RemoveAt(discard-1);
                hand.Sort();
                for (int i = 1; i <= 13; i++)
                {
                    GameObject.Find("cards/card" + i).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[i - 1]);
                }
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = null;
                discardCount[0]++;
                waiting = false;
                turn = 1;
                discard = 0;
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
                turn++;
                if(turn == 4)
                {
                    turn = 0;
                    id = random.Next(0, tiles.Count);
                    hand.Add(tiles[id]);
                    tiles.RemoveAt(id);
                    GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/" + hand[13]);
                    waiting = true;
                }
            }
        }
		
	}
}
