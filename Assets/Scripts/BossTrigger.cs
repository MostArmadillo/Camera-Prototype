using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossTrigger : MonoBehaviour {
    public CinemachineVirtualCamera Camera;

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.name == "Player") {
            Camera.Follow = GameObject.Find("BossRoomCamera").transform;
            Camera.m_Lens.OrthographicSize = 16;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        } 
    }
}
