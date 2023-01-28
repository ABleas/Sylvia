using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentController : MonoBehaviour
{
    public float spawn_rate = 2.0f;
    private float spawn_timer = 0.0f;

    private GameObject[] fragments;

    // Start is called before the first frame update
    void Start()
    {
        fragments = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g => g.CompareTag("LevelFragment")).toArray();
        Debug.Log(fragments);
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime;
        if (spawn_timer <= 0.0f)
        {
            spawn_timer = spawn_rate;

            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            float h = cam.orthographicSize;
            float w = h * cam.aspect;

            GameObject fragment = fragments[Random.Range(0, fragments.Length)];
            Instantiate(fragment, transform.position, transform.rotation);
        }
    }
}
