using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float amplitude = 0.5f;   // висота підстрибування
    public float frequency = 1.0f;   // швидкість підстрибування
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // запам’ятовуємо початкову позицію
    }

    void Update()
    {
        float y = Mathf.Abs(Mathf.Sin(Time.time * frequency)) * amplitude;
        transform.position = startPos + Vector3.up * y;
    }

}
