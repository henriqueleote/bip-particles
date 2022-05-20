using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{

    private Rigidbody rigidBody;
    public float speed = 500.0F;
    public bool isActive = false;
    public GameObject placeholder;
    public GameObject mainCamera;
    private int time = 3;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isActive)
        {
            transform.SetParent(null);
            rigidBody.velocity = new Vector3(7, -0.10F ,0);
            transform.Rotate(0, 0, 5f, Space.World);
        } 
    }

    void Throw1()
    {
        isActive = !isActive;
        transform.rotation = new Quaternion(80, 75, 0, 1);
    }

}
