using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentController : MonoBehaviour
{
    public float spawn_rate = 2.0f;
    private float spawn_timer = 0.0f;

    public GameObject fragment1;
    public GameObject fragment2;
    public GameObject fragment3;
    public GameObject fragment4;

    private GameObject[] fragments;

    // Start is called before the first frame update
    void Start()
    {
        fragments = new GameObject[] { fragment1, fragment2, fragment3, fragment4 };
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime;
        if (spawn_timer <= 0.0f)
        {
            spawn_timer = spawn_rate;

            GameObject fragment = fragments[Random.Range(0, fragments.Length)];
            Instantiate(fragment, transform.position, transform.rotation);
        }
    }
}
