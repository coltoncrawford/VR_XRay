using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Wander : MonoBehaviour {

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetRandomPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if(agent.remainingDistance < 0.5f)
        {
            agent.destination = GetRandomPoint();
        }
	}

    Vector3 GetRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10.0f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10.0f, 1);
        return hit.position;
    }
}
