using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaController : MonoBehaviour
{
    private Vector2 accel = Vector2.zero;
    public Vector2 vel = Vector2.zero;
    public float speed = 1f;
    public float decel = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKeyDown(KeyCode.W);
        bool down = Input.GetKeyDown(KeyCode.S);
        bool left = Input.GetKeyDown(KeyCode.A);
        bool right = Input.GetKeyDown(KeyCode.D);

        if (!up && !down)
            accel.y *= decel * Time.deltaTime;

        if (!left && !right)
            accel.x *= decel * Time.deltaTime;

        if (up)
        {
            accel += Vector2.up * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            accel += Vector2.down * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            accel += Vector2.left * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            accel += Vector2.right * speed * Time.deltaTime;
        }

        accel = Vector2.ClampMagnitude(accel, 2);

        vel += accel;
        vel = Vector2.ClampMagnitude(vel, 20);

        transform.position += new Vector3(vel.x, vel.y, 0);

    }
}
