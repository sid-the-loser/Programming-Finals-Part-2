using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BallController : MonoBehaviour
{

    [SerializeField] private float ballSpeed = 10;
    [SerializeField] private CameraControls followCam;
    [FormerlySerializedAs("_spawner")] [SerializeField] private PlatformSpawner spawner;

    private bool _axis; // false: x, true: z
    private bool _started;
    private bool _stopped;

    private Vector3 _movDir;

    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        followCam.SetFollowState(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_stopped)
        {
            {
                if (_started)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _axis = !_axis;
                        if (_axis)
                        {
                            _movDir.x = 1;
                            _movDir.z = 0;
                        }
                        else
                        {
                            _movDir.z = 1;
                            _movDir.x = 0;
                        }
                    }

                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _started = true;
                    }
                }
            }
        }
        else
        {
            // what happens if stopped
        }
    }

    private void FixedUpdate()
    {
        if (!_stopped) transform.position += _movDir * (ballSpeed * Time.deltaTime);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _stopped = true;
            _rb.useGravity = true;
            followCam.SetFollowState(false);
            spawner.SetGenerator(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("diamond"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _stopped = false;
            _rb.useGravity = false;
            followCam.SetFollowState(true);
            spawner.SetGenerator(true);
        }
    }
}
