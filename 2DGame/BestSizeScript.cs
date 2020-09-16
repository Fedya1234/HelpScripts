using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestSizeScript : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer boundsSprite;
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = boundsSprite.bounds.size.x / boundsSprite.bounds.size.y;

        if (screenRatio < targetRatio)
        {
            Camera.main.orthographicSize = boundsSprite.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = boundsSprite.bounds.size.y / 2 * differenceInSize;
        }
    }

}
