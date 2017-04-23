using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardResponse : MonoBehaviour {

    public int cardIndex;

    void OnMouseDown()
    {
        GameObject.Find("EventSystem").GetComponent<GameEvents>().discard = cardIndex;
    }
}
