using System;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{

    [SerializeField] float death_speed = 8;
    [SerializeField] Sprite dead_sprite;
    [SerializeField] ParticleSystem particle_system;

    private bool has_died = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(ShouldDieFromCollision(collision)) { StartCoroutine(Die()); }

    }

    bool ShouldDieFromCollision(Collision2D collision)
    {

        if (has_died) { return false; }

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null) { return true; }
        if (collision.contacts[0].normal.y < -0.5) { return true; }
        if (Speed(collision) > death_speed) { return true; }

        return false;

    }

    IEnumerator Die()
    {

        has_died = true;
        GetComponent<SpriteRenderer>().sprite = dead_sprite;
        //yield return new WaitForSeconds(1);
        particle_system.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);

    }

    float Speed (Collision2D collision)
    {

        float value = Mathf.Sqrt(Exp(collision.contacts[0].relativeVelocity.x, 2) + Exp(collision.contacts[0].relativeVelocity.y, 2));
        Debug.Log(value);
        return value;

    }

    private float Exp(float x, int y)
    {

        if (y < 0) { return 1; }
        float value = 1;
        for(int i = 0; i < y; i++)
        {

            value *= x;

        }

        return value;

    }

}
