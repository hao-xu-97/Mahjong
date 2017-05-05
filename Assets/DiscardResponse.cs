using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardResponse : MonoBehaviour {

    public int cardIndex;

    //check which tile is selected for discard
    void OnMouseDown()
    {
        GameObject.Find("EventSystem").GetComponent<GameEvents>().discard = cardIndex;
    }
}
