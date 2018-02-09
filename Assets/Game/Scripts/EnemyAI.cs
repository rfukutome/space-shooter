using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private int _health = 50;
    
    [SerializeField] private GameObject explosionPrefab;

    private UIManager _canvas;
	// Use this for initialization
	void Start () {
        _canvas = GameObject.FindObjectOfType<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.up * _speed * Time.deltaTime);
        if(transform.position.y < -6.5)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 6.5f);
        }
	}

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            _canvas.UpdateScore();
            Destroy(this.gameObject);
        }
    }
}
