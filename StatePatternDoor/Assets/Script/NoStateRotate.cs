using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoStateRotate : MonoBehaviour
{
    public GameObject m_Door;
    public Button m_Button;
    public Text m_Text;

    void Start()
    {
        m_Text.text = "Open";
        m_Button.onClick.AddListener(OnClickOpenDoor);
    }

    public void OnClickOpenDoor()
    {
        StartCoroutine("OpenDoor");
    }

    public void OnClickCloseDoor()
    {
        StartCoroutine("CloseDoor");
    }

    public IEnumerator OpenDoor()
    {
        m_Button.enabled = false;
        while (Mathf.Abs(m_Door.transform.localEulerAngles.y - 90) >= 1)
        {
            m_Door.transform.localRotation = Quaternion.Lerp(m_Door.transform.localRotation, Quaternion.Euler(0, 90, 0), 0.05f);
            yield return null;
        }
        m_Door.transform.localEulerAngles = new Vector3(0, 90, 0);
        m_Button.onClick.RemoveListener(OnClickOpenDoor);
        m_Button.onClick.AddListener(OnClickCloseDoor);
        m_Text.text = "Close";
        m_Button.enabled = true;
        StopCoroutine("OpenDoor");
    }

    public IEnumerator CloseDoor()
    {
        m_Button.enabled = false;
        while (Mathf.Abs(m_Door.transform.localEulerAngles.y) >= 1)
        {
            m_Door.transform.localRotation = Quaternion.Lerp(m_Door.transform.localRotation, Quaternion.Euler(0, 0, 0), 0.05f);
            yield return null;
        }
        m_Door.transform.localEulerAngles = new Vector3(0, 0, 0);
        m_Button.onClick.RemoveListener(OnClickCloseDoor);
        m_Button.onClick.AddListener(OnClickOpenDoor);
        m_Text.text = "Open";
        m_Button.enabled = true;
        StopCoroutine("CloseDoor");
    }
}