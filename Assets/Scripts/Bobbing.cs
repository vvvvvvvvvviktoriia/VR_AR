using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float amplitude = 0.5f;   // ������ �������������
    public float frequency = 1.0f;   // �������� �������������
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // ������������ ��������� �������
    }

    void Update()
    {
        float y = Mathf.Abs(Mathf.Sin(Time.time * frequency)) * amplitude;
        transform.position = startPos + Vector3.up * y;
    }

}
