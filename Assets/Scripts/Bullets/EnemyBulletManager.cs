using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    [Header("Stats")]
    public float Speed;
    
    void Start() {
        Destroy(gameObject, 15f);
    }

    void Update() {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Speed);
    }

    //Damage
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        } 
    }
}
