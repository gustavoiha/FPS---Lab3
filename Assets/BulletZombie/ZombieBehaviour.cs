using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonoBehaviour {

    public enum State
    {
        Idle,
        Follow,
        Attack,
        Die,
    }

    public State state;

    public float distance;

    GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        Vector3 distanceP = (transform.position - player.transform.position);


    }

}


