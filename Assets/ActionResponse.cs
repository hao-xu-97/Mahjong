using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionResponse : MonoBehaviour {

	public void pong()
    {
        GameObject.Find("EventSystem").GetComponent<GameEvents>().actionTaken = "pong";
    }

    public void kang()
    {
        GameObject.Find("EventSystem").GetComponent<GameEvents>().actionTaken = "kang";
    }

    public void chi()
    {
        GameObject.Find("EventSystem").GetComponent<GameEvents>().actionTaken = "chi";
    }

    public void cancel()
    {
        GameObject.Find("EventSystem").GetComponent<GameEvents>().actionTaken = "cancel";
    }
}
