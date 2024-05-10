using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [Header("Stats")]
    [SerializeField] float MaxDistance;
    [SerializeField] float MaxSpeed;
    
    float TargetSpeed;
    float ActualSpeed;
    
    GameObject Player;

    void Start() {
        Player = GameObject.Find("Player");
    }
    
    void Update() {
        if(Player != null) {
            //Behavior
            float Distance = (transform.position - Player.transform.position).magnitude;

            if(Distance < MaxDistance) {
                TargetSpeed = 0f;
            } else {
                TargetSpeed = MaxSpeed;
            }

            //Movement
            ActualSpeed = Mathf.MoveTowards(ActualSpeed, TargetSpeed, 8 * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, ActualSpeed * Time.deltaTime);
        } else {
            //Keep Searching for Player
            Debug.Log("Failed to find Player");
            Player = GameObject.Find("Player");
        }
    }
}
