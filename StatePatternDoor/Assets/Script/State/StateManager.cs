using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public GameObject m_Door;
    public Button m_Button;
    public Text m_Text;

    public DoorState m_OpenDoorState;
    public DoorState m_CloseDoorState;

    public DoorState m_CurrentState;

    public void Start()
    {
        m_OpenDoorState = new OpenDoor(this);
        m_CloseDoorState = new CloseDoor(this);

        SetState(m_OpenDoorState);
    }

    public void SetState(DoorState _state)
    {
        m_CurrentState = _state;
        m_CurrentState.EnterState();
    }

    public void StartStayState()
    {
        StartCoroutine(m_CurrentState.LeaveState());
    }

    public void StopStayState()
    {
        StopCoroutine(m_CurrentState.LeaveState());
    }
}