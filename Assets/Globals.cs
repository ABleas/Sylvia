using UnityEngine;

public class Globals : MonoBehaviour
{
    public const float INITIAL_SCROLL_SPEED = -2.0f;
    public const float DESPAWN_Y = -10.0f;

    public float scroll_speed = INITIAL_SCROLL_SPEED;

    // Static singleton instance
    private static Globals _instance;

    // Static singleton property
    public static Globals Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return _instance ?? (_instance = new GameObject("Globals").AddComponent<Globals>()); }
    }

    private Globals() {}

    void Start()
    {
      // Fixes stutter on Android devices
      Application.targetFrameRate = 61;
    }
}