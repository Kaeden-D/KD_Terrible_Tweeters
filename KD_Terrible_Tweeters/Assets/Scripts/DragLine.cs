using UnityEngine;

public class DragLine : MonoBehaviour
{

    private LineRenderer line_renderer;
    private Bird bird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        line_renderer = GetComponent<LineRenderer>();
        bird = FindObjectOfType<Bird>();
        line_renderer.SetPosition(0, bird.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        if (bird.is_dragging)
        {

            line_renderer.enabled = true;
            line_renderer.SetPosition(1, bird.transform.position);

        }
        else
        {

            line_renderer.enabled = false;

        }

    }
}
