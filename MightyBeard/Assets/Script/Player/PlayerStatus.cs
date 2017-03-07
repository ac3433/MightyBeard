using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    [SerializeField]
    private float health = 100f;
	
	// Update is called once per frame
	void Update () {
	    if(health < 0)
        {
            Destroy(gameObject);
        }
	}

    public void decreaseHealth(float number)
    {
        health -= number;
    }
}
