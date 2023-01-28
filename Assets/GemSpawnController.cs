using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawnController : MonoBehaviour
{
    public GameObject Gem1;
    public GameObject Gem2;
    public float spawn_rate = 0.5f;
    private float spawn_timer = 0.0f;

    private GameObject[] gems;

    // Start is called before the first frame update
    void Start()
    {
        gems = new GameObject[] { Gem1, Gem2 };
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

            GameObject gem_choice = gems[Random.Range(0, 2)];

            float x = Random.Range(-w + 0.2f, w - 0.2f);
            Vector3 p = transform.position;
            Instantiate(gem_choice, new Vector3(x, p.y, p.z), transform.rotation);
        }
    }
}
