using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Singleton : MonoBehaviour {

    public static Singleton singleton;
    public List<Transform> listTargets = new List<Transform>();
	// Use this for initialization
	void Awake () 
    {
        singleton = this;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
