using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private SpriteRenderer sp;
    public Sprite newSP;
    public float maxHp;
    private float hp;
	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
        hp = maxHp;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            sp.sprite = newSP;
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
