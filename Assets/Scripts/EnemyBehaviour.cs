using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public enum State {
        Idle,
        Follow,
        Die,
    }

    public State state;

    public Transform target; //Enemy's target

    //Speeds
    public float moveSpeed = 3;
    public float rotateSpeed = 3;

    //Following range
    public float followRange = 10;

    //Range for idle
    public float idleRange = 10;

    public float health = 100;
    float currentHealth;

    // Use this for initialization
    void Start () {
        GoToNextState();
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {

    }

    void GoToNextState() {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    public float GetDistance() {
        return (transform.position - target.transform.position).magnitude;
    }

    public void TakeDamage() {
        float damageToDo = 100 - GetDistance() * 5;
        if (damageToDo < 0)
            damageToDo = 0;
        if (damageToDo > health)
            damageToDo = health;
        currentHealth -= damageToDo;
        if (currentHealth <= 0)
            state = State.Die;
        else {
            followRange = Mathf.Max(GetDistance(), followRange);
            state = State.Follow;
        }
        print("Ow! - Current Health =" + currentHealth.ToString());
    }

    private void RotateTowardsTarget() {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotateSpeed * Time.deltaTime);
    }

    IEnumerator IdleState() {
        print("Idle:Enter");
        while(state == State.Idle) {
            if (GetDistance() < followRange)
                state = State.Follow;
            yield return 0;
        }
        print("Idle:Exit");
        GoToNextState();
    }

    IEnumerator FollowState() {
        print("Follow:Enter");
        while(state == State.Follow) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * moveSpeed);
            RotateTowardsTarget();
            if (GetDistance() > idleRange)
                state = State.Idle;
            yield return 0;
        }
        print("Follow:Exit");
        GoToNextState();
    }

    IEnumerator DieState() {
        print("Die:Enter");
        Destroy(gameObject);
        yield return 0;
    }
}
