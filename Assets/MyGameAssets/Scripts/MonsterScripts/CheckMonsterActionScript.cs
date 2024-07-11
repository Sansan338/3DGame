using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckMonsterActionScript : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent monster;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Animator monsterAnimator;
    [SerializeField]
    private float discoveryRange = 6.0f;
    [SerializeField]
    private float chaseSpeed;

    private float distance;

    [SerializeField]
    private int FloorXSize;
    [SerializeField]
    private int FloorZSize;
    [SerializeField]
    private float patrolSpeed;

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
    }

    void Patrol()
    {
        if (monster.remainingDistance < 0.5f)
        {
            monster.speed = patrolSpeed;
            randomPosition = new Vector3(Random.Range(-FloorXSize, FloorXSize), 0,
                Random.Range(-FloorZSize, FloorZSize));
            monster.destination = randomPosition;
        }
    }

    void Chase()
    {
        monster.speed = chaseSpeed;
        // ƒvƒŒƒCƒ„[‚Æ‚Ì‹——£
        distance = Vector3.Distance(transform.position, target.transform.position);
        monster.destination = target.transform.position;
        monsterAnimator.SetFloat("Speed", monster.velocity.sqrMagnitude);
    }
}
