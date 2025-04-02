using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
