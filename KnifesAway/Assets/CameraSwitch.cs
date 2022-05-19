using Cinemachine;
using System;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject thrower;
    public CinemachineVirtualCamera[] cameras;
    private int currentIdx;

    // Start is called before the first frame update
    void Start()
    {
        currentIdx = 0;
        foreach (var item in cameras) item.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Switch();
    }

    private void Switch()
    {
        if (currentIdx == cameras.Length) 
            return;

        for(int i=0; i<cameras.Length; i++)
        {
            if (i <= currentIdx)
            {
                cameras[i].Priority = 0;
            } else
            {
                currentIdx++;
                cameras[i].Priority = 1;
                break;
            }
        }
        
    }
}
