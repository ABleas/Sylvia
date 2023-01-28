using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFragmentController : MonoBehaviour
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
        transform.Translate(new Vector3(0.0f, -2 * Time.deltaTime, 0.0f), Space.World);
    }
}
