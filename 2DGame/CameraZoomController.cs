using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    public Action<Vector2> EventTouch;
    
    private const float ZOOM_SENS = 0.01f;
    private const int _inertionPointsCount = 5;
    
    [SerializeField] private float _inertion = 0.98f;
    [SerializeField] private bool _isEnabled = true;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Bounds _bounds;
    
    private float _maxOrthographicSize;
    private Vector3 _prevMousePosition;

    private float _prewDistance;

    private Camera _camera;
    private Vector3 _cameraPrevPosition;
    private Vector3 _damPosition;
    private List<Vector3> _pointsList;
    private int _currentInertionPoint;
    
    private void Awake()
    {
        _camera = Camera.main;

        if (_spriteRenderer != null)
            _bounds = _spriteRenderer.bounds;

        CalculateBounds();

        GoBounds();
        
        _pointsList = new List<Vector3>();
        for (int i = 0; i < _inertionPointsCount; i++)
        {
            _pointsList.Add(new Vector3());
        }
    }

    public void SetEnabled(bool isEnabled)
    {
        _isEnabled = isEnabled;
        if (_isEnabled == false)
        {
            StopInertion();
        }
    }

    private void Update()
    {
        if (_isEnabled == false)
            return;
        
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _prevMousePosition = Input.mousePosition;
                _prewDistance = Vector2.Distance(Input.mousePosition, Vector3.zero);
                InvokeTouch(Input.mousePosition);
                
                StopInertion();
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                SetInertionOnUp();
            }

            if (Input.GetMouseButton(0))
            {
                if (Input.GetKey(KeyCode.Space))
                    ZoomIt(Input.mousePosition, Vector3.zero);
                else
                {
                    Vector3 dPos = Input.mousePosition - _prevMousePosition;
                    Bounds cameraArea = CameraShowArea();
                    _prevMousePosition = Input.mousePosition;

                    Vector2 dPosition = dPos / Screen.width * cameraArea.size.x;
                    //_camera.transform.Translate(-dPosition);
                    
                    SetInertionValue(dPosition);
                }
            }

            
        }

        Touch touch1 = new Touch();
        
        if (Input.touchCount > 0)
        {
            touch1 = Input.GetTouch(0);

            if (Input.touchCount == 1)
            {
                Bounds cameraArea = CameraShowArea();
                
                if (touch1.phase == TouchPhase.Began)
                {
                    InvokeTouch(touch1.position);
                    StopInertion();
                }
                
                if (touch1.phase == TouchPhase.Ended)
                {   
                    SetInertionOnUp();
                }
                
                if (touch1.phase == TouchPhase.Moved)
                {
                    Vector2 dPosition = touch1.deltaPosition / Screen.width * cameraArea.size.x;
                    SetInertionValue(dPosition);
                }
            }

        }

        
        if (Input.touchCount == 2)
        {
            Touch touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                _prewDistance = Vector2.Distance(touch1.position, touch2.position);
                StopInertion();
            }
            
            if (touch2.phase == TouchPhase.Moved)
            {
                ZoomIt(touch1.position, touch2.position);
            }
            
        }
        
        _camera.transform.Translate(_damPosition*=_inertion);
        GoBounds();

    }

    private void OnOrientationChange()// TODO - On Orientation Change 
    {
        CalculateBounds();
        Debug.Log("!!!!!!!!");
    }
    

    private void CalculateBounds()
    {
        _maxOrthographicSize = MaxSize(_bounds.size);
    }

    private void StopInertion()
    {
        _damPosition = Vector3.zero;
        for (int i = 0; i < _inertionPointsCount; i++)
        {
            _pointsList[i] *= 0;
        }
    }

    private void SetInertionOnUp()
    {
        Vector3 sum = Vector3.zero;
        for (int i = 0; i < _pointsList.Count; i++)
        {
            sum += _pointsList[i];
        }

        sum = sum / _pointsList.Count;
        _damPosition = sum;
    }

    private void SetInertionValue(Vector2 dPosition)
    {
        _damPosition = -dPosition;
        _currentInertionPoint = (_currentInertionPoint + 1) % _inertionPointsCount;
        _pointsList[_currentInertionPoint] = _damPosition;
    }

    private void InvokeTouch(Vector2 position)
    {
        EventTouch?.Invoke(position);
    }

    private void ZoomIt(Vector3 first, Vector3 second)
    {
        var distance = Vector2.Distance(first, second);

        var dDistance = distance - _prewDistance;
        _prewDistance = distance;
        _camera.orthographicSize -= dDistance * ZOOM_SENS;
    }

    void GoBounds()
    {
        if (_camera.orthographicSize > _maxOrthographicSize) 
            _camera.orthographicSize = _maxOrthographicSize;
        
        if (_camera.orthographicSize < 0.1f) 
            _camera.orthographicSize = 0.1f;
        
        Bounds cameraArea = CameraShowArea();

        Vector3 camPosition = _camera.transform.position;
        if (cameraArea.min.x < _bounds.min.x)
        {
            camPosition.x = _bounds.min.x + cameraArea.extents.x;
        }else if(cameraArea.max.x > _bounds.max.x)
        {
            camPosition.x = _bounds.max.x - cameraArea.extents.x;
        }
        
        if (cameraArea.min.y < _bounds.min.y)
        {
            camPosition.y = _bounds.min.y + cameraArea.extents.y;
        }else if(cameraArea.max.y > _bounds.max.y)
        {
            camPosition.y = _bounds.max.y - cameraArea.extents.y;
        }
        
        _camera.transform.position = camPosition;
    }

    private Bounds CameraShowArea()
    {
        float sizeY = _camera.orthographicSize*2;
        float sizeX = _camera.aspect * sizeY;
        Vector3 size = new Vector3(sizeX, sizeY, 10);
        return new Bounds(_camera.transform.position, size);
    }

    float MaxSize(Vector2 size)
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float spriteRatio = size.x / size.y;
        float difference = spriteRatio / screenRatio;
        float maxSize;
        if (screenRatio <= spriteRatio)
            maxSize = size.y * 0.5f;
        else
            maxSize = size.y * difference * 0.5f;

        return maxSize;
    }
    
    
}
