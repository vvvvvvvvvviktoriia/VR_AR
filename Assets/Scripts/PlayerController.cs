using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // швидкість руху

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D або ← →
        float moveZ = Input.GetAxis("Vertical");   // W/S або ↑ ↓

        // рух по XZ (по підлозі)
        Vector3 move = new Vector3(moveX, 0, moveZ);

        // рух відносно світу
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
