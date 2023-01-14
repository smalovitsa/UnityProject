using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (HeroMovement.HP == 3)
                 sr.sprite = sprites[0];
        if (HeroMovement.HP == 2)
                 sr.sprite = sprites[1];
        if (HeroMovement.HP == 1)
                 sr.sprite = sprites[2];
        if (HeroMovement.HP == 0)
                 sr.sprite = sprites[3];
    }
}
