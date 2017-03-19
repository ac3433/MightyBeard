using UnityEngine;
using System.Collections;

public class DarkMechanic : MonoBehaviour {

    SpriteRenderer sr;

    bool isDark = false;

    [SerializeField]
    float darkRate = 15f;

    float timer;

	void Start () {
        sr = GetComponent<SpriteRenderer>();
        isDark = true;
        timer = darkRate;
	}
	
	// Update is called once per frame
	void Update () {
	    if(!isDark)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timer = darkRate;
                sr.enabled = true;
                isDark = true;
            }
        }
        
    }

   public void setDark(bool isDark)
    {
        if(!isDark)
        { 
            this.isDark = isDark;
            sr.enabled = false;
        }
    }

    public bool getDarkState()
    {
        return isDark;
    }

}
