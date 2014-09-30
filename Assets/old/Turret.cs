using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour {

    public Transform bulletSpawnpoint;
    public Transform Bullet;
    public static List<Transform> listTargets;
    public static Transform target;
    private int test = 1;
    private float cooldown;
    private float cooldownTime = 1;
    public static bool newTarget;
	// Use this for initialization
	void Start () 
    {
        listTargets = new List<Transform>();

       
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(newTarget == true)
        {
            if (listTargets.Count > 0)
            {
                int tempCount = listTargets.Count;
                for (int i = tempCount; i >= 1; i--)
                {
                    Debug.Log(i);
                    if (listTargets[i] == null)
                    {
                        listTargets.Remove(listTargets[i]);
                        Debug.Log(listTargets.Count);
                    }
                }
                target = listTargets[0];
            }
            else
            {
                target = null;
            }
            newTarget = false;
        }


        if (listTargets.Count > 0) 
        {
            for (int i = 0; i < listTargets.Count; i++)
            {
                if (target != null)
                {
                    if (Vector3.Distance(listTargets[i].position, transform.position) < Vector3.Distance(target.position, transform.position))
                    {
                        target = listTargets[i];
                        Debug.Log("set new target");
                    }
                }
                else
                {
                    target = listTargets[0];
                }
            }
        }
        if (listTargets.Count > 0 && cooldown < Time.time && target != null)
        {
            cooldown = Time.time + cooldownTime;
            transform.LookAt(target);
            Instantiate(Bullet, bulletSpawnpoint.position, this.transform.rotation);

        }
        else if (listTargets.Count > 0 && target != null) 
        {
            transform.LookAt(target); 
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag != "Bullet")
        {
            listTargets.Add(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Bullet")
        {
            listTargets.Remove(other.transform);
        }
    }
    /*public static void setTarget() 
    {
        
        if(listTargets.Count > 0)
        {
            int tempCount = listTargets.Count;
            for (int i = tempCount; i > 0; i--)
            {
                if (listTargets[i] == null)
                {
                    listTargets.Remove(listTargets[i]);
                }
            }
            target = listTargets[0];
        }
        else
        {
            target = null;
        }
    }*/
}
