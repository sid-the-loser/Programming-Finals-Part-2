using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private bool followState;
    [SerializeField] private Vector3 stayAwayPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followState)
        {
            transform.position = followObject.transform.position + stayAwayPos;
        }
    }

    public void SetFollowState(bool state)
    {
        followState = state;
    }
}
