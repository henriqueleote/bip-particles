using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour{

    public GameObject parent;
    public Animator deadGuyAnimator;
    public GameObject placeholder;
    public GameObject mainCamera;
    public GameObject particle;
    public GameObject explosion;
    public GameObject explosionPlaceholder;
    public AudioSource music1;
    public AudioSource music2;
    private bool toExplode;
    private int timeToExplode;

    void Start()
    {
        music1.playOnAwake = true;
        toExplode = false;
        timeToExplode = 15 * 60;
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
        collision.gameObject.transform.eulerAngles = new Vector3(90, 90, 180);
        particle.SetActive(true);
        music1.Stop();
        music2.Play();
        Explosion();
    }

    public void Update()
    {
        if (!toExplode) return;
        if (timeToExplode < 0)
        {
            StartCoroutine(HandleExplosion());
        }
        timeToExplode--;
    }

    public void SwitchCamera()
    {
        mainCamera.BroadcastMessage("Switch");
    }

    public void Explosion()
    {
        toExplode = true;
    }

    IEnumerator HandleExplosion()
    {
        Instantiate(explosion, explosionPlaceholder.transform);
        toExplode = false;
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindWithTag("deadGuy"));
    }
}
