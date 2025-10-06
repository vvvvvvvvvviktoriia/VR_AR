using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 speed = new Vector3(0f, 45f, 0f); // градуси за секунду

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
