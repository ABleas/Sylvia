using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    foreach (Transform child in transform)
    {
      if (child.position.y < Globals.DESPAWN_Y)
      {
        Object.Destroy(child.gameObject);
      }
    }

    if (transform.childCount == 0)
    {
      Object.Destroy(this.gameObject);
    }
  }
}
