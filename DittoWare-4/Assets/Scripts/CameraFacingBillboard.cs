using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
    public Camera m_Camera;

    void Update()
    {
        transform.forward = m_Camera.transform.forward;
        //transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
        //    m_Camera.transform.rotation * Vector3.up);
    }
}