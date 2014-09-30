using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Invoke("destroyThis",1);
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime *20);
	}

    void destroyThis() 
    {
        Destroy(this.gameObject);
    }
}
