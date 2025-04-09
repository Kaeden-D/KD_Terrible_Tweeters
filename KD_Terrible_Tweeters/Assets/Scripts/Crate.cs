using UnityEngine;

public class Crate : MonoBehaviour
{

    [SerializeField] AudioClip[] clips;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.relativeVelocity.magnitude > 5f)
        {

            AudioClip clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);

        }
        else
        {

            Debug.Log("Collision was too slow to play a sound " + collision.relativeVelocity.magnitude);

        }

    }

}
