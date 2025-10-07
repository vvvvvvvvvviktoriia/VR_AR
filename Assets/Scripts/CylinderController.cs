using UnityEngine;

public class CylinderController : MonoBehaviour
{
    public float speed = 5f; // швидкість руху

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // керування тільки стрілками
        if (Input.GetKey(KeyCode.RightArrow)) moveX += 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX -= 1f;
        if (Input.GetKey(KeyCode.UpArrow)) moveZ += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) moveZ -= 1f;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}

