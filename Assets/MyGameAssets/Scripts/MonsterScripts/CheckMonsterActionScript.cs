using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckMonsterActionScript : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent Monster;
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private Animator MonsterAnimator;
    [SerializeField]
    private float distance;
    private float discoveryRange = 6.0f;


    private int FloorXSize;
    [SerializeField]
    private int FloorZSize;

    Vector3 randomPosition;

    public enum ActionType
    {
        Patrol,
        Chase,
    }

    ActionType actionType;
    void Start()
    {
        actionType = ActionType.Patrol;
    }

    void Update()
    {
        switch (actionType)
        {
            case ActionType.Patrol:
                {
                    Patrol();
                }
                break;
            case ActionType.Chase:
                {
                    Chase();
                }
                break;
        }

        if (SearchPlayerScript.IsDiscovery == true)
        {
            actionType = ActionType.Chase;
        }
        if (distance > discoveryRange) 
        {
            actionType = ActionType.Patrol;
            distance = 0;
            SearchPlayerScript.IsDiscovery = false;
        }

        Debug.Log(distance);
        Debug.Log(actionType);
    }

    void Patrol()
    {
        if (Monster.remainingDistance < 0.5f)
        {
            randomPosition = new Vector3(Random.Range(-FloorXSize, FloorXSize), 0,
                Random.Range(-FloorZSize, FloorZSize));
            Monster.destination = randomPosition;
        }
    }

    void Chase()
    {
        // ƒvƒŒƒCƒ„[‚Æ‚Ì‹——£
        distance = Vector3.Distance(transform.position, Target.transform.position);
        Monster.destination = Target.transform.position;
        MonsterAnimator.SetFloat("Speed", Monster.velocity.sqrMagnitude);
    }
}
