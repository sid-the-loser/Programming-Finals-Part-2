using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatforms : MonoBehaviour
{
    private float _fallDelay = 0.5f;
    private float _deletionDelay = 2;
    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartFall());
        }
    }

    private IEnumerator StartFall()
    {
        yield return new WaitForSeconds(_fallDelay);
        _rb.useGravity = true;
        StartCoroutine(StartDestroy());
    }

    private IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(_deletionDelay);
        Destroy(gameObject);
    }
}
