using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struct : MonoBehaviour
{
    [SerializeField] private Transform entrance;
    [SerializeField] private Transform exit;
    private Queue<Capsule> waitingQueue;
    private Queue<Capsule> visitingQueue;
    private Queue<float> visitingTimes;
    private int maxVisitors = 1;
    private Capsule lastWaiter;
    private Vector3 lastWaiterPosition;

    public Transform Entrance
    {
        get { return entrance; }
    }

    public Transform Exit
    {
        get { return exit; }
    }

    public Vector3 LastWaiterPosition
    {
        get { return lastWaiterPosition; }
    }

    void Start()
    {
        waitingQueue = new Queue<Capsule>(); // Queue of capsules waiting to enter the structure
        visitingQueue = new Queue<Capsule>(); // Queue of capsules currently inside the structure
        visitingTimes = new Queue<float>(); // Queue of times when capsules entered the structure
    
        entrance = transform.Find("Entrance");
        exit = transform.Find("Exit");

        lastWaiterPosition = entrance.position; // 
    }

    void Update()
    {
        if(visitingQueue.Count < maxVisitors && waitingQueue.Count > 0)
        {
            var newVisitor = waitingQueue.Dequeue();
            visitingQueue.Enqueue(newVisitor);
            visitingTimes.Enqueue(Time.time);
            newVisitor.Visiting = true;
        }

        if (visitingTimes.Count > 0 && Time.time - visitingTimes.Peek() > 5)
        {
            var oldVisitor = visitingQueue.Dequeue();
            visitingTimes.Dequeue();
            oldVisitor.Visiting = false;
            oldVisitor.agent.enabled = true;
            oldVisitor.agent.Warp(exit.position);
        }

        if(waitingQueue.Count == 0)
        {
            lastWaiterPosition = entrance.position;
        } else
        {
            lastWaiterPosition = lastWaiter.agent.transform.position;
        }

        UpdateQueueDestinations();
    }

    public void PutInQueue(Capsule capsule)
    {
        waitingQueue.Enqueue(capsule);
        lastWaiter = capsule;
        lastWaiterPosition = capsule.agent.transform.position;
    }

    public void UpdateQueueDestinations()
    {
        if(waitingQueue.Count == 0)
        {
            return;
        }
        var previousWaiter = waitingQueue.Peek();
        foreach (var waiter in waitingQueue)
        {
            if(waiter == previousWaiter)
            {
                previousWaiter.agent.SetDestination(entrance.position);
            }
            else
            {
                waiter.agent.SetDestination(previousWaiter.agent.transform.position);
                previousWaiter = waiter;
            }
        }
    }
}
