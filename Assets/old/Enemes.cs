using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemes : MonoBehaviour {

    public List<Transform> targets;
    private int i = 0;
    public int speed = 5;
	// Use this for initialization
	void Start ()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < temp.Length; i++)
        {
           targets.Add(temp[i].transform); 
        }
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.MoveTowards(transform.position, targets[i].position, speed*Time.deltaTime);
        if (Vector3.Distance(targets[i].position, transform.position) < 1)
        {
            i++;
            if(i > targets.Count -1)
            {
                i = 0;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            //listTargets.rem(other.transform);
            Turret.listTargets.Remove(this.transform);
            Turret.newTarget = true;
            Debug.Log("i should be removed");
            Destroy(this.gameObject);
        }
    }
}
