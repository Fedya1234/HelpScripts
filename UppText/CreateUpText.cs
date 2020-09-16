using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUpText : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] UpText _upText;
    public void Execute()
    {
        Instantiate(_upText, transform.position+Vector3.up*2f, Quaternion.identity).GetComponent<UpText>().SetText(_score.ToString());
    }
}
