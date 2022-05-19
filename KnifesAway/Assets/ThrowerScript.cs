using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerScript : MonoBehaviour
{
    public GameObject mainCamera;

    void Throw()
    {
        BroadcastMessage("Throw1");
        ChangeCamera();
    }

    void ChangeCamera()
    {
        mainCamera.BroadcastMessage("Switch");
    }
}
