﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : DoorState
{
    public StateManager m_Manager;
    public OpenDoor(StateManager _manager)
    {
        m_Manager = _manager;
    }

    public void OnClickButton()
    {
        m_Manager.m_Button.enabled = false;
        m_Manager.StartStayState();
    }

    public override void EnterState()
    {
        base.EnterState();
        m_Manager.m_Text.text = "Open";
        m_Manager.m_Button.onClick.AddListener(OnClickButton);
        m_Manager.m_Button.enabled = true;
    }

    public override IEnumerator StayState()
    {
        base.StayState();
        while (Mathf.Abs(m_Manager.m_Door.transform.localEulerAngles.y - 90) >= 1)
        {
            m_Manager.m_Door.transform.localRotation = Quaternion.Lerp(m_Manager.m_Door.transform.localRotation, Quaternion.Euler(0, 90, 0), 0.05f);
            yield return null;
        }
        m_Manager.m_Door.transform.localEulerAngles = new Vector3(0, 90, 0);
    }

    public override IEnumerator  LeaveState()
    {
        base.LeaveState();
        yield return StayState();
        m_Manager.m_Button.onClick.RemoveListener(OnClickButton);
        m_Manager.SetState(m_Manager.m_CloseDoorState);
    }
}