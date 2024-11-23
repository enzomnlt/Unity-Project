using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struct : MonoBehaviour
{
    private Transform entrance;
    private Transform exit;
    private Queue<Visitor> waitingQueue;
    private Queue<Visitor> visitingQueue;
    private Queue<float> visitingTimes;
    private int maxVisitors = 1;
    private int waitingTime = 5;
    private Vector3 lastWaiterPosition;

    // Getters
    public Transform Entrance => entrance;
    public Transform Exit => exit;
    public Vector3 LastWaiterPosition => lastWaiterPosition;

    void Start()
    {
        waitingQueue = new Queue<Visitor>(); // Visitors waiting to enter the structure
        visitingQueue = new Queue<Visitor>(); // Visitors currently inside the structure
        visitingTimes = new Queue<float>(); // Times of visitors in the structure
    
        entrance = transform.Find("Entrance");
        exit = transform.Find("Exit");

        lastWaiterPosition = entrance.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5)) // Press 5 to increase max visitors
        {
            maxVisitors++;
        }

        if (waitingQueue.Count == 0) // If no visitors waiting, the position is the entrance
        {
            lastWaiterPosition = entrance.position;
        }

        ProcessVisitors();
        UpdateQueueDestinations();
    }

    private void ProcessVisitors()
    {
        if(visitingQueue.Count < maxVisitors && waitingQueue.Count > 0)
        {
            var newVisitor = waitingQueue.Dequeue();
            visitingQueue.Enqueue(newVisitor);
            visitingTimes.Enqueue(Time.time);
            newVisitor.Visiting = true;
        }

        if (visitingTimes.Count > 0 && Time.time - visitingTimes.Peek() > waitingTime)
        {
            var oldVisitor = visitingQueue.Dequeue();
            visitingTimes.Dequeue();
            oldVisitor.Visiting = false;
            oldVisitor.agent.enabled = true;
            oldVisitor.agent.Warp(exit.position);
        }
    }

    public void PutInQueue(Visitor capsule)
    {
        waitingQueue.Enqueue(capsule);
        lastWaiterPosition = capsule.agent.transform.position;
    }

    public void UpdateQueueDestinations()
    {
        if(waitingQueue.Count == 0)
        {
            return;
        }
        var previousWaiter = waitingQueue.Peek();
        // Keep destinations of visitors in the queue updated :
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
