using UnityEngine;

public class EnemyData : ScriptableObject
{
    [Header("Patrol Settings")]
    public GameObject pointA;
    public GameObject pointB;
    public float patrolSpeed = 2f;
}
