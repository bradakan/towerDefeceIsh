using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dictionairy : MonoBehaviour {

    private Dictionary<string, List<Leerling>> map = new Dictionary<string, List<Leerling>>();

	// Use this for initialization
	void Start () 
    {
        Leerling student = new Leerling("Ramses", 18 , Gender.Male);
        Debug.Log(student.name);

	}
	

}
