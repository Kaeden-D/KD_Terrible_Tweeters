using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] float launch_force = 500;
    [SerializeField] float max_drag_distance = 5;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Transform pos;
    private Vector2 start_pos;

    public bool is_dragging { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        pos = transform;
        start_pos = rb.position;
        rb.gravityScale = 0;

    }

    void OnMouseDown()
    {

        sprite.color = Color.red;
        is_dragging = true;

    }

    void OnMouseUp()
    {

        Vector2 current_pos = rb.position;
        Vector2 direction = start_pos - current_pos;
        direction.Normalize();

        rb.gravityScale = 1;
        rb.AddForce(direction * launch_force);

        sprite.color = Color.white;

        is_dragging = false;

    }

    void OnMouseDrag()
    {

        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desired_pos = mouse_pos;

        float distance = Vector2.Distance(desired_pos, start_pos);
        if (distance > max_drag_distance)
        {

            Vector2 direction = desired_pos - start_pos;
            direction.Normalize();
            desired_pos = start_pos + direction * max_drag_distance;

        }

        if (desired_pos.x > start_pos.x)
        {
            desired_pos.x = start_pos.x;
        }

        rb.position = desired_pos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        StartCoroutine(ResetAfterDelay());

    }

    IEnumerator ResetAfterDelay()
    {

        yield return new WaitForSeconds(3);
        pos.position = start_pos;
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;

    }

}
