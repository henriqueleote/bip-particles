using Cinemachine;
using System;
using UnityEngine;
using System.Linq;

public class CameraSwitch : MonoBehaviour
{
    public GameObject thrower;
    public GameObject deadGuy;
    public CinemachineVirtualCamera[] cameras;
    private int currentIdx;
    private bool lastCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentIdx = 0;
        lastCamera = false;
        foreach (var item in cameras) item.gameObject.SetActive(true);
        CinemachineCore.GetInputAxis = GetAxisCustom;
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
                if (i == cameras.Length - 1) RotateAroundPlayer();
                break;
            }
        }
    }

    public float GetAxisCustom(string axisName)
    {
        return 0;
    }

    private void LateUpdate()
    {
        if (!lastCamera) return;
        var camera = cameras.Last();
        //camera.transform.RotateAround(deadGuy.transform.position, new Vector3(0, 1, 0), 2 * Time.deltaTime);
    }

    private void RotateAroundPlayer()
    {
        lastCamera = true;
    }
}
