using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayNight;

public class BlackSphere : MonoBehaviour
{
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(forOpacity == true)
        {
            this.sr.material.color = new Color(0,0,0,0);
           // sr.color.a = 1;
        }
        else
        {
            this.sr.material.color = new Color(0, 0, 0, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            Destroy(this.gameObject);
        }
    }
}
