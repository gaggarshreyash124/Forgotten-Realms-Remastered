using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float jumpForce = 15;
    public float CyoteeTime = 0.2f;
    public float moveSpeed = 7;
    public int maxHealth = 100;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    public float FallAcceleration = 2.5f;

}
