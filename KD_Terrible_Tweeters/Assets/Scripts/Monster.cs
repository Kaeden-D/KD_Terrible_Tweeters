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

    IEnumerator Start()
    {

        while(!has_died)
        {
            float delay = UnityEngine.Random.Range(5, 30);
            yield return new WaitForSeconds(delay);
            if (!has_died){ GetComponent<AudioSource>().Play(); };
        }

    }

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }

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
        if (collision.relativeVelocity.magnitude > death_speed) { return true; }

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

}
