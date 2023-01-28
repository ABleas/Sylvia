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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
