using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellets : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.name == "Player")
        {
            Debug.Log("AH HA!~");
            Destroy(gameObject);
        }
    }
}
