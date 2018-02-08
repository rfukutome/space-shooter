using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]private int powerupID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.up * _speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player)
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotPowerupOn();
                        break;
                    case 1:
                        player.SpeedBoostOn();
                        break;
                    case 2:
                        break;

                }
                

            Destroy(this.gameObject);
        }
    }
}
