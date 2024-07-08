using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent Monster;
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private int FloorXSize;
    [SerializeField] 
    private int FloorZSize;

    Vector3 RandomPosition;

    void Start()
    {
        
    }

    void Update()
    {
        RandomPosition = new Vector3(Random.Range(-FloorXSize, FloorXSize), 0, 
            Random.Range(-FloorZSize, FloorZSize));
        Monster.destination = Target.transform.position;
    }
}
