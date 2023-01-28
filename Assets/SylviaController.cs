using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaController : MonoBehaviour
{
    private Vector2 accel = Vector2.zero;
    public Vector2 vel = Vector2.zero;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            accel += Vector2.up * Time.deltaTime;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            accel += Vector2.down * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            accel += Vector2.left * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            accel += Vector2.right * Time.deltaTime;
        }
    }
}
