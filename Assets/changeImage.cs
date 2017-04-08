using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour {

    private int counter;

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
            counter++;
        }
		
	}
}
