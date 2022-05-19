using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour{

    public GameObject parent;
    public Animator deadGuyAnimator;
    public GameObject placeholder;
    public GameObject mainCamera;
    public GameObject particle;
    public AudioSource music1;
    public AudioSource music2;

    void Start()
    {
        music1.playOnAwake = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Knife")
            return;
        mainCamera.BroadcastMessage("Switch");
        deadGuyAnimator.SetBool("isDead", true);
        collision.gameObject.transform.SetParent(placeholder.transform);
        collision.gameObject.BroadcastMessage("Throw1");
        collision.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.gameObject.transform.rotation = Quaternion.EulerAngles(new Vector3(40, 90, 180));
        particle.SetActive(true);
        music1.Stop();
        music2.Play();
    }

    public void SwitchCamera()
    {
        mainCamera.BroadcastMessage("Switch");
    }
}
