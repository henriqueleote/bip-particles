using Cinemachine;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraSwitch : MonoBehaviour
{
    public GameObject thrower;
    public GameObject deadGuy;
    public GameObject cart;
    public CinemachineVirtualCamera[] cameras;
    private int currentIdx;

    // Start is called before the first frame update
    void Start()
    {
        currentIdx = 0;
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
                if (currentIdx == cameras.Length - 1) HandleCart();
                break;
            }
        }
    }

    public float GetAxisCustom(string axisName)
    {
        return 0;
    }

    public void HandleCart()
    {
        cart.SetActive(true);
    }

    public void ReloadScene()
    {
        StartCoroutine(HandleSceneRestart());
    }

    IEnumerator HandleSceneRestart()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("SampleScene");
    }
}
