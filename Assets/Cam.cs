using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    float aspect = (3f / 4f);
    Camera cam = Camera.main;
    Debug.Log(aspect);
    Debug.Log(cam.aspect);
    Camera.main.orthographicSize = cam.orthographicSize * (aspect / cam.aspect);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
