using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 _setPoint;
    public Vector3 SetPoint { get { return _setPoint; }  set { _setPoint = value; } }

    public void SetPosition()
    {
        transform.position = _setPoint;
    }
}
