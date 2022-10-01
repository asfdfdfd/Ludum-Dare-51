using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentPathController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private float enoughDistance;
    
    [SerializeField] private Transform[] points;

    private int _currentDestinationIndex = -1;

    private Transform _currentDestination;

    private void Start()
    {
        _currentDestinationIndex = 0;
        _currentDestination = points[_currentDestinationIndex];

        _navMeshAgent.destination = _currentDestination.position;
    }

    private void Update()
    {
        if (_navMeshAgent.remainingDistance <= enoughDistance)
        {
            _currentDestinationIndex++;

            if (_currentDestinationIndex == points.Count())
            {
                _currentDestinationIndex = 0;
            }

            _currentDestination = points[_currentDestinationIndex];

            _navMeshAgent.destination = _currentDestination.transform.position;
        }
    }
}
