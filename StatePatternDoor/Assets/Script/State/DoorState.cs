using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState
{
    public virtual void EnterState()
    {

    }

    public virtual IEnumerator StayState()
    {
        yield return null;
    }

    public virtual IEnumerator LeaveState()
    {
        yield return null;
    }
}