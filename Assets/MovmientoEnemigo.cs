using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovmientoEnemigo : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _navM;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _navM = GetComponent<NavMeshAgent>();
        _navM.updateRotation = false;
        _navM.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //_navM.SetDestination(_player.position);
    }
}
