using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode Player_1_LeftKey;
    public KeyCode Player_1_RightKey;
    public KeyCode Player_1_ActionKey;
    public KeyCode Player_2_LeftKey;
    public KeyCode Player_2_RightKey;
    public KeyCode Player_2_JumpKey;
    
    public float GetAxis_Player_1()
    {
        return (Input.GetKey(Player_1_LeftKey) ? -1f : (Input.GetKey(Player_1_RightKey)) ? 1f : 0f);
    }
    public float GetAxis_Player_2()
    {
        return (Input.GetKey(Player_2_LeftKey) ? -1f : (Input.GetKey(Player_2_RightKey)) ? 1f : 0f);
    }
    public bool GetActionPlayer_1()
    {
        return (Input.GetKeyDown(Player_1_ActionKey) );
    }
    public bool GetJumpPlayer_2()
    {
        return (Input.GetKeyDown(Player_2_JumpKey));
    }
}
[System.Serializable]
public enum PlayerType{
    Player_1,
    Player_2,
}
