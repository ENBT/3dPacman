using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellets : MonoBehaviour {

    public GameObject owner = null;             //Owner of the pellet. Used to keep track of which enemy spawned the pellet.


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
                GameManager.score += 100;
                Debug.Log(gameObject.name + "Collided with " + obj.gameObject.name);
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "BadPellet")
        {
            if (obj.gameObject.tag == "Player")
            {
                Debug.Log(gameObject.name + "Collided with " + obj.gameObject.name);

                if (owner != null)
                    owner.GetComponent<Enemy>().DeletePellet(this.gameObject);

                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "Fruit")
        {
            if (obj.gameObject.tag == "Player")
            {
                GameManager.score += 1500;
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
