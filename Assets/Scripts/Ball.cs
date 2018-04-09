using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	// Use this for initialization

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Start () {
		// yo
		rb.velocity = new Vector2(1,1)*speed;

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
