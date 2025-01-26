using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode Player_1_LeftKey;
    public KeyCode Player_1_AltLeftKey;
    public KeyCode Player_1_RightKey;
    public KeyCode Player_1_AltRightKey;
    public KeyCode Player_1_ActionKey;
    public KeyCode Player_1_AltActionKey;
    public KeyCode Player_2_LeftKey;
    public KeyCode Player_2_AltLeftKey;
    public KeyCode Player_2_RightKey;
    public KeyCode Player_2_AltRightKey;
    public KeyCode Player_2_JumpKey;
    public KeyCode Player_2_AltJumpKey;
    
    public float GetAxis_Player_1()
    {
        return (Input.GetKey(Player_1_LeftKey) || Input.GetKey(Player_1_AltLeftKey) ? -1f : (Input.GetKey(Player_1_RightKey) || Input.GetKey(Player_1_AltRightKey))  ? 1f : 0f);
    }
    public float GetAxis_Player_2()
    {
        return (Input.GetKey(Player_2_LeftKey) || Input.GetKey(Player_2_AltLeftKey) ? -1f : (Input.GetKey(Player_2_RightKey) || Input.GetKey(Player_2_AltRightKey)) ? 1f : 0f);
    }
    public bool GetActionPlayer_1()
    {
        return (Input.GetKeyDown(Player_1_ActionKey) || Input.GetKeyDown(Player_1_AltActionKey) );
    }
    public bool GetJumpPlayer_2()
    {
        return (Input.GetKeyDown(Player_2_JumpKey) || Input.GetKeyDown(Player_2_AltJumpKey));
    }
}
[System.Serializable]
public enum PlayerType{
    Player_1,
    Player_2,
}
