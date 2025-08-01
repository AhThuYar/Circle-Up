using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public GameObject target;
    public float Speed;
    public float maxSpeed;


    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.back, Speed * Time.deltaTime);
        if (Speed < maxSpeed)
        {
            Speed += 0.05f * Time.deltaTime;
        }
    }
}
