using UnityEngine;
using System.Collections;

public class NewTurret : MonoBehaviour {

    private Transform target;
    public Transform bulletSpawnpoint;
    public Transform Bullet;
    private float cooldown;
    private float cooldownTime = 1;
    public static bool waitingforTarget = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(waitingforTarget == false)
        {
            setNewTarget();
        }
        if (Singleton.singleton.listTargets.Count > 0 && cooldown < Time.time && target != null)
        {
            cooldown = Time.time + cooldownTime;
            transform.LookAt(target);
            Instantiate(Bullet, bulletSpawnpoint.position, this.transform.rotation);

        }
        else if (Singleton.singleton.listTargets.Count > 0 && target != null)
        {
            transform.LookAt(target);
        }
	}

    public void setNewTarget() 
    {
        for (int i = 0; i < Singleton.singleton.listTargets.Count; i++)
        {
            if (target != null)
            {
                if (Vector3.Distance(Singleton.singleton.listTargets[i].position, transform.position) < Vector3.Distance(target.position, transform.position))
                {
                    target = Singleton.singleton.listTargets[i];
                    Debug.Log("set new target");
                }
            }
            else if (Singleton.singleton.listTargets.Count > 0)
            {
                target = Singleton.singleton.listTargets[0];
            }
            else 
            {
                waitingforTarget = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Bullet")
        {
            Singleton.singleton.listTargets.Add(other.transform);
            waitingforTarget = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Bullet")
        {
            Singleton.singleton.listTargets.Remove(other.transform);
        }
        if(other == target)
        {
            setNewTarget();
        }
    }
}
