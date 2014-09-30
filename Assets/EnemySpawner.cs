using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy1;
    public Transform fastEnemy;
	// Use this for initialization
	void Start () 
    {
        Invoke("createEnemy", 2);
	}

    void createEnemy() 
    {
        int temp = Random.Range(0,2);
        if (temp == 0)
        {
            Instantiate(enemy1, transform.position, transform.rotation);
        }
        else 
        {
            Instantiate(fastEnemy, transform.position, transform.rotation);
        }
        
        Invoke("createEnemy", 2);
    }

}
