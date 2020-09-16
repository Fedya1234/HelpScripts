using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : MonoBehaviour
{
    [SerializeField] Transform[] _wayPoints;
    [SerializeField] float _speed;
    int _currentPoint;
    private void Start()
    {
        _currentPoint = 0;
        RotateToPoint();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _wayPoints[_currentPoint].position) < _speed*2 * Time.deltaTime)
        {
            _currentPoint++;
            if (_currentPoint >= _wayPoints.Length)
            {
                _currentPoint = 0;
            }
            RotateToPoint();
        }
        
        transform.Translate(transform.forward * Time.deltaTime * _speed,Space.World);

    }

    void RotateToPoint()
    {
        Vector3 lookPoint = new Vector3(_wayPoints[_currentPoint].position.x, transform.position.y, _wayPoints[_currentPoint].position.z);
        transform.LookAt(lookPoint);
    }

    
}
