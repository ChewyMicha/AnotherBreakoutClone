using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
    [Range(0, 8.0f)]
    public float deviateAmount = 3.0f;
    GameObject player;
    private bool ToShoot = true;

    private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Start () {
        // yo
        //rb.velocity = new Vector2(1,1)*speed;
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if (ToShoot)
        {
            // check if we have a reference to the player object
            if (player != null)
            {
                transform.position = player.transform.position + Vector3.up * 0.95f;
            }

            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                Launch();
                ToShoot = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            float deviateFactor;

            deviateFactor = transform.position.x - collision.gameObject.transform.position.x;
            deviateFactor /= collision.collider.bounds.size.x / 2.0f;
           

            Vector2 direction = rb.velocity + Vector2.right * deviateFactor * deviateAmount;
            direction.Normalize();

            rb.velocity = direction * speed;
        }

    }

    void Launch()
    {
        rb.velocity = Vector2.up * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        ToShoot = false;
        rb.velocity = direction.normalized * speed;
    }
}
