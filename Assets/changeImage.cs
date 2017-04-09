using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour {

    public int counter;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("instructions/s1");
        counter = 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            string s = "instructions/s" + counter;
            GetComponent<Image>().sprite = Resources.Load<Sprite>(s);
            if(counter == 10)
            {
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man/man6");
            }
            if(counter == 13)
            {
                GameObject.Find("cards/card14").GetComponent<SpriteRenderer>().sprite = null;
                GameObject.Find("cards/card5").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man/man6");
                GameObject.Find("discard0").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man/man9");
                GameObject.Find("discard1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("icons/man/man1");
            }
            counter++;
        }
		
	}

}
