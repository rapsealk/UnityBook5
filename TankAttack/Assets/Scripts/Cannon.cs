using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float speed = 6000f;
    public GameObject expEffect;

    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.AddForce(transform.forward * speed);

        StartCoroutine(ExplosionCannon(3.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        StartCoroutine(ExplosionCannon(0.0f));
    }

    IEnumerator ExplosionCannon(float time)
    {
        yield return new WaitForSeconds(time);

        _collider.enabled = false;
        _rigidbody.isKinematic = true;

        GameObject obj = (GameObject) Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);

        Destroy(this.gameObject, 1.0f);
    }
}
