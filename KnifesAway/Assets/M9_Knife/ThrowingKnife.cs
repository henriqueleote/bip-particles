using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{

    public Rigidbody rigidBody;
    public float speed = 500.0F;
    public bool isActive = false;
    public GameObject placeholder;
    public GameObject mainCamera;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isActive)
        {
            transform.SetParent(null);
            rigidBody.velocity = new Vector3(7, -0.3F ,0);
            transform.Rotate(0, 90.0f, 10.0f, Space.World);
        }

    }

    void Throw1()
    {
        isActive = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mainCamera.BroadcastMessage("Switch");
            isActive = false;
            other.transform.SetParent(placeholder.transform);
            rigidBody.velocity = new Vector3(0, 0, 0);
            rigidBody.angularVelocity = Vector3.zero;
            other.gameObject.SetActive(false);
        }

    }
}
