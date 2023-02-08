using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
  private float wobble_timer = 0.0f;
  private bool wobble_on = true;
  public float wobble_speed = 180.0f;
  private Vector3 axis = Vector3.forward;

  // Start is called before the first frame update
  void Start()
  {
    wobble_timer = Random.Range(0.0f, 1.0f);
  }

  // Update is called once per frame
  void Update()
  {
    drop();

    wobbleUpdate();
  }

  void drop()
  {
    float speed = Globals.Instance.scroll_speed;
    transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f), Space.World);
  }

  void wobbleUpdate()
  {
    wobble_timer -= Time.deltaTime;
    if (wobble_timer <= 0.0f)
    {
      wobble_on = !wobble_on;
      if (!wobble_on)
      {
        transform.localRotation = Quaternion.identity;
        wobble_timer = Random.Range(2.0f, 3.0f);
      }
      else
      {
        wobble_timer = 1.0f;
      }
    }

    if (wobble_on == true)
    {
      wobble();
    }

  }

  void wobble()
  {
    Vector3 center = GetComponent<Renderer>().bounds.center;
    transform.RotateAround(center, axis, wobble_speed * Time.deltaTime);
    float z_deg = transform.localRotation.eulerAngles.z;
    if (z_deg > 15.0f && z_deg < 180.0f)
    {
      axis = Vector3.back;
    }
    if (z_deg < 345.0f && z_deg > 180.0f)
    {
      axis = Vector3.forward;
    }
  }
}
