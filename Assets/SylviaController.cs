using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaController : MonoBehaviour
{
    private Vector2 dir = Vector2.zero;
    public Vector2 vel = Vector2.zero;
    public float acceleration = 0.25f;
    public float decel = 0.99f;
    public float max_speed = 5.0f;

    public float max_height = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updatePos();
        setPosBounds();
    }

    void updatePos()
    {
        bool up = Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);

        if (up)
        {
            dir = Vector2.up;
        }
        else if (down)
        {
            dir = Vector2.down;
        }

        if (left)
        {
            dir = new Vector2(-1.0f, dir.y);
        }
        else if (right)
        {
            dir = new Vector2(1.0f, dir.y);
        }

        dir = Vector2.ClampMagnitude(dir, acceleration);

        if (!up && !down)
        {
            dir = new Vector2(dir.x, 0.0f);
            vel *= new Vector2(1.0f, decel);
        }

        if (!left && !right)
        {
            dir = new Vector2(0.0f, dir.y);
            vel *= new Vector2(decel, 1.0f);
        }

        if (up || down || left || right)
        {
            vel += dir;
            vel = Vector2.ClampMagnitude(vel, max_speed * Time.deltaTime);
        }

        transform.position += new Vector3(vel.x, vel.y, 0);

    }

    void setPosBounds()
    {
        // Calculate orthographic camera bounds
        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        float h = cam.orthographicSize;
        float w = h * cam.aspect;
        Vector3 p = transform.position;
        float safe_pad = 0.5f;


        if (transform.position.x < -w + safe_pad)
        {
            transform.position = new Vector3(-w + safe_pad, p.y, p.z);
        }
        if (transform.position.x > w - safe_pad)
        {
            transform.position = new Vector3(w - safe_pad, p.y, p.z);
        }

        float bottom = -h + safe_pad;
        if (transform.position.y < bottom)
        {
            transform.position = new Vector3(p.x, bottom, p.z);
        }
        float top = (-h * max_height) - safe_pad;
        if (transform.position.y > top)
        {
            transform.position = new Vector3(p.x, top, p.z);
        }
    }
}
