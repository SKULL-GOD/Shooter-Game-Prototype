using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float orbitSpeed = 20f;

    private float angle = 0f;

    void Start()
    {
        if (target == null) return;

        Vector3 toCamera = transform.position - target.position;
        angle = Mathf.Atan2(toCamera.x, toCamera.z) * Mathf.Rad2Deg+180f;
    }

    void Update()
    {
        if (target == null) return;

        angle += orbitSpeed * Time.deltaTime;
        float radians = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Sin(radians) * distance, height, Mathf.Cos(radians) * distance);
        transform.position = target.position + offset;

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
