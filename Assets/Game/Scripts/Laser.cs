using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    [SerializeField]private float speed = 10.0f;
    [SerializeField]private int damage = 2;
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.y > 6)
        {
            if (transform.parent != null && transform.parent.GetComponentsInChildren<Laser>().Length <= 2)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
            if (transform.parent != null && transform.parent.GetComponentsInChildren<Laser>().Length <= 1)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
