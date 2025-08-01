using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;
    public float smoothSpeed = 0.5f;
    new Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (target.position.y > -1)
        {
            // transform.position = new Vector3(transform.position.x, target.position.y, -10);
            // Debug.Log("Camera Start Following Player: ");

            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(.5f, .5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);
        }
    }
}
