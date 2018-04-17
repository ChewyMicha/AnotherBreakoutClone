using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private SpriteRenderer sp;
    public Sprite newSP;
    public float maxHp;
    private float hp;
	Camera cam;
	ScreenShake screenshake;
	// Use this for initialization
	private void Awake()
	{
		cam = Camera.main.GetComponent<Camera>();
		screenshake = cam.GetComponent<ScreenShake>();
	}
	void Start () {
        sp = GetComponent<SpriteRenderer>();
        hp = maxHp;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
			StartCoroutine(screenshake.Shake(0.5f, .5f));
            sp.sprite = newSP;
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
