using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    /*
    To make the ball always move on the X axis.
    Start the ball movement when “LMB” or Left Mouse Button is pressed.
    Change movement direction to Z axis when “LMB” is pressed. By each LMB click, switch from Z axis to X axis and vice versa.
    Make the ball fall when it’s not on the platform and the game should be over.
    */

    [SerializeField] private float ballSpeed = 10;

    private bool _axis; // false: x, true: z
    private bool _started;
    private bool _stopped;

    private Vector3 _movDir;

    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
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
        }
    }
}
