using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drop();
    }

    void drop()
    {
        float speed = Globals.Instance.scroll_speed;
        transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f), Space.World);
    }
}
