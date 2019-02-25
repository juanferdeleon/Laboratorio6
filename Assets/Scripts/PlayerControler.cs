using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private bool isBig = false;

    public Sprite sprite2;

    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody;

    private bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.005f)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * 2;
        float vertical = Input.GetAxis("Vertical");
        Flip(horizontal);
        Vector2 vector2 = new Vector2(horizontal, vertical);
        rigidbody.AddForce(vector2 * 10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mushroom") {
            SoundManager.PlaySound("powerUp");
            spriteRenderer.sprite = sprite2;
            Destroy(other.gameObject);
            isBig = true;
        }

        if (other.gameObject.tag == "Goomba")
        {
            if (isBig)
            {
                Destroy(other.gameObject);
                SoundManager.PlaySound("kill");
            }
            else {
                SoundManager.PlaySound("die");
                Destroy(gameObject);
            }
        }
    }

    public void Flip(float horizontal)
    {
        if (horizontal > 0 && !right || horizontal < 0 && right)
        {
            right = !right;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void Jump()
    {
        SoundManager.PlaySound("jump");
        rigidbody.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
    }
}

