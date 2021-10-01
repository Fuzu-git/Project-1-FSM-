using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public static EnemyVision EnemyVision;

    private NavMeshAgent _navMeshAgent;
    private Camera _mainCamera;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (Camera.main) _mainCamera = Camera.main;
        else throw new Exception("No main camera found");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hit);
            _navMeshAgent.SetDestination(hit.point);
        }
        //if (EnemyVision.PlayerInSight) Debug.Log("Je vois le player");
    }

    public enum State
    {
        Idle, 
        Patrol, 
        Chase
    }

    public class Enemy : MonoBehaviour
    {
        public State currentState;
        
        public void Update()
        {
            if (currentState == State.Idle)
            {
                if (currentState != null)
                {
                    currentState = State.Patrol;
                }
            }
            else if (currentState == State.Patrol)
            {
                if (EnemyVision.PlayerInSight)
                {
                    currentState = State.Chase;
                }
            }
            else if (currentState == State.Chase)
            {
                if (!EnemyVision.PlayerInSight)
                {
                    currentState = State.Patrol;
                }
            }
        }
        
    }
    
}

