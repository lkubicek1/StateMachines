using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        idle, walking, swimming, climbing
    }

    public State currentState = State.idle;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    void CheckState()
    {
        switch (currentState)
        {
            case State.idle: Idle(); break;
            case State.walking: Walking(); break;
            case State.swimming: Swimming(); break;
            case State.climbing: Climbing(); break;
            default: break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        switch (other.name)
        {
            case "WaterTrigger":
                currentState = State.swimming;
                break;
            case "MountainTrigger":
                currentState = State.climbing;
                break;
            default: break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        currentState = State.walking;
    }

    void Swimming()
    {
        Debug.Log("I am swimming.");
    }

    void Climbing()
    {
        Debug.Log("I am climbing.");
    }

    void Idle()
    {
        Debug.Log("I am idle.");
        if (lastPosition != transform.position)
        {
            Debug.Log("Moving...");
            currentState = State.walking;
        }
        lastPosition = transform.position;
    }

    void Walking()
    {
        Debug.Log("I a walking.");
        if (lastPosition == transform.position)
        {
            Debug.Log("Stopped.");
            currentState = State.idle;
        }
        lastPosition = transform.position;
    }
}
