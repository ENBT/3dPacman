using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellets : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    

    void OnTriggerEnter(Collider obj)
    {
        if(gameObject.tag == "GoodPellet")
        {
            if(obj.gameObject.tag == "Player")
            {
                Debug.Log(gameObject.name + "Collided with " + obj.gameObject.name);
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "BadPellet")
        {
            if (obj.gameObject.tag == "Player")
            {
                Debug.Log(gameObject.name + "Collided with " + obj.gameObject.name);
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "Fruit")
        {
            if (obj.gameObject.tag == "Player")
            {
                Debug.Log(gameObject.name + "Collided with " + obj.gameObject.name);
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "Super")
        {
            if (obj.gameObject.tag == "Player")
            {
                Debug.Log(gameObject.name + "Collided with " + obj.gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
