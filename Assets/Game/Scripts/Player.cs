using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTripleShot = false;

    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleLaserPrefab;
    [SerializeField] private float _fireRate = 0.25f;

    [SerializeField] private float playerSpeed = 5.0f;
    private float input_x = 0;
    private float input_y = 0;
    private float canFire = 0.0f;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > canFire)
            {
                if (canTripleShot)
                {
                    Instantiate(_tripleLaserPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, .5f), Quaternion.identity);
                    canFire = Time.time + _fireRate;
                }

            }

        }
    }

    private void Movement()
    {
        input_x = Input.GetAxis("Horizontal");
        input_y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * input_x * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.up * input_y * Time.deltaTime * playerSpeed);

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

    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedBoostOn()
    {
        playerSpeed *= 1.5f;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }
    private IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    private IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        playerSpeed /= 1.5f;
    }
}
