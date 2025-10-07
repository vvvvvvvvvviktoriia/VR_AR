using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TagActions : MonoBehaviour
{
    public Color defaultColor = Color.white;
    public Color hitEnemyColor = Color.red;

    Rigidbody rb;
    Renderer rend;

    bool isGrounded = false;
    int enemyContacts = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponentInChildren<Renderer>();
        if (rend) rend.material.color = defaultColor;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Enemy"))
        {
            enemyContacts++;
            if (rend) rend.material.color = hitEnemyColor;
            Debug.Log("Куб зіткнувся з Enemy: " + c.collider.name);
        }
        else if (c.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);   // ✅ було linearVelocity
            Debug.Log("Куб стоїть на Ground");
            TryResetColor();
        }
    }

    // ✅ додаємо підтримку постійного контакту з Ground
    void OnCollisionStay(Collision c)
    {
        if (c.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            // прибираємо випадкову вертикальну складову щоразу, поки стоїмо
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            TryResetColor();
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.collider.CompareTag("Enemy"))
        {
            enemyContacts = Mathf.Max(0, enemyContacts - 1);
            Debug.Log("Куб перестав торкатись Enemy: " + c.collider.name);
            TryResetColor();
        }
        else if (c.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Куб покинув Ground");
        }
    }

    void TryResetColor()
    {
        if (rend && isGrounded && enemyContacts == 0)
            rend.material.color = defaultColor;
    }
}
