using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Visitor : MonoBehaviour
{
    public NavMeshAgent agent;

    [SerializeField] public Struct[] structures;

    private Collider capsuleCollider;
    private Renderer capsuleRenderer;

    private int destIndex = -1;
    private bool visiting = false;
    private bool waiting = false;

    public bool Visiting
    {
        get { return visiting; }
        set { visiting = value; }
    }

    void Start()
    {
        capsuleCollider = GetComponent<Collider>();
        capsuleRenderer = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(agent.hasPath && !agent.pathPending && agent.remainingDistance < 1.75f)
        {
            if(!waiting) {
                waiting = true;
                structures[destIndex].PutInQueue(this);
            }
            agent.isStopped = true;
        }

        if(agent.hasPath && !agent.pathPending && agent.remainingDistance > 1.75f)
        {
            agent.isStopped = false;
            if (!waiting)
            {
                agent.SetDestination(structures[destIndex].LastWaiterPosition);
            }
        }

        if(visiting)
        {
            capsuleCollider.enabled = false;
            capsuleRenderer.enabled = false;
            agent.enabled = false;
            waiting = false;
            destIndex = -1;
        }

        if(destIndex == -1 && !visiting)
        {
            capsuleCollider.enabled = true;
            capsuleRenderer.enabled = true;
            destIndex = Random.Range(0, structures.Length);
            agent.SetDestination(structures[destIndex].LastWaiterPosition);
        }
    }
}