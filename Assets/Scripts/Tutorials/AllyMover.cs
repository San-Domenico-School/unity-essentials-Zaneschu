using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMover : MonoBehaviour
{
    private float maxX = 10;
    private float maxZ = 10;
    private float timeBetweenMoves = 5;

    [SerializeField] UnityEngine.AI.NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        InvokeRepeating("MoveAlly", 0, timeBetweenMoves);        
    }

    // Update is called once per frame
    void MoveAlly()
    {
        float x = Random.Range(-maxX, maxX);
        float y = 0;
        float z = Random.Range(-maxZ, maxZ);
        Vector3 point = new Vector3(x, y, z);
        navMeshAgent.SetDestination(point);
    }
}
