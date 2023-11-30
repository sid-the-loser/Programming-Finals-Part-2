using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject gemPrefab;

    private bool _generateMore = true;

    private Vector3 _movDir;
    private Vector3 _grid = new Vector3(2, 0, 2);
    private Vector3 _virtualPos;

    private float _genDelay = 0.2f;

    private float _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        _virtualPos = transform.position;
        
        for (int i = 0; i < 20; i++)
        {
            MoveAndGen();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
            _timer += Time.deltaTime;

            if (_timer >= _genDelay)
            {
                _timer = 0;
                if (_generateMore)
                {
                    MoveAndGen();
                }
            }

    }
    
    

    private void MoveAndGen()
    {
        var axis = Random.Range(0, 2);
        if (axis < 1)
        {
            _movDir.x = _grid.x;
            _movDir.z = 0;
        }
        else
        {
            _movDir.x = 0;
            _movDir.z = _grid.z;
        }

        if (Random.Range(0, 2) < 1)
        {
            Instantiate(gemPrefab, new Vector3(_virtualPos.x, 1.2f, _virtualPos.z), transform.rotation);
            //print("Spawned");
        }
        
        Instantiate(platformPrefab, _virtualPos, transform.rotation);
        _virtualPos += _movDir;
    }

    public void SetGenerator(bool value)
    {
        _generateMore = value;
    }
}
