using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float playerSpeed = 5.0f;

    private float input_x = 0;
    private float input_y = 0;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        input_x = Input.GetAxis("Horizontal");
        input_y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * input_x * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.up * input_y * Time.deltaTime * playerSpeed);
    }

    private void Movement()
    {
        if (transform.position.x > 8.5)
        {
            transform.position = new Vector3(8.5f, transform.position.y);
        }
        else if (transform.position.x < -8.5)
        {
            transform.position = new Vector3(-8.5f, transform.position.y);
        }

        if (transform.position.y > 4.5)
        {
            transform.position = new Vector3(transform.position.x, 4.5f);
        }
        else if (transform.position.y < -4.5)
        {
            transform.position = new Vector3(transform.position.x, -4.5f);
        }
    }
}
