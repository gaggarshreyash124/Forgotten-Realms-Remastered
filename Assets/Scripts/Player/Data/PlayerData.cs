using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float jumpForce = 15;    
    public float moveSpeed = 7;
    public int maxHealth = 100;
}
