using UnityEngine;

public class Globals : MonoBehaviour
{
    public const float INITIAL_SCROLL_SPEED = -2.0f;
    public const float DESPAWN_Y = -10.0f;

    public float scroll_speed = INITIAL_SCROLL_SPEED;

    // Static singleton instance
    private static Globals _instance;

    public static Globals Instance
    {
        get { return _instance ?? (_instance = new GameObject("Globals").AddComponent<Globals>()); }
    }

    private Globals() {}

    void Start()
    {
      // Fixes stutter on Android devices
      Application.targetFrameRate = 61;
    }
}