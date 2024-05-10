using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {
    [SerializeField] GameObject Bullet;

    [Header("Shooting")]
    [SerializeField] float Firerate;
    [SerializeField] float Range;

    GameObject Player;
    float Cooldown;
    float Angle;

    //References
    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        Cooldown = Firerate;
    }

    void Update() {
        Cooldown += Time.deltaTime;

        Vector3 PlayerDirection = Player.transform.position - transform.position;
        Angle = Mathf.Atan2(PlayerDirection.y, PlayerDirection.x) * Mathf.Rad2Deg;

        if(Cooldown > Firerate && PlayerDirection.magnitude < Range) {
            Cooldown = 0f;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack() {
        for(int i = 0; i<4; i++) {
            FireBullet(Angle);
            yield return new WaitForSeconds(0.5f);
        }
        
        FireBullet(Angle - 35);
        FireBullet(Angle);
        FireBullet(Angle + 35);
        yield return new WaitForSeconds(1.5f);
    }
    
    void FireBullet(float Angle) {
        StartCoroutine(Flash());
        GameObject BulletClone = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, Angle));
    }

    IEnumerator Flash() {
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
