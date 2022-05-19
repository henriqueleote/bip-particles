using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour{

    public GameObject parent;
    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Knife")
            return;

        _animator.enabled = false;
    }
}
