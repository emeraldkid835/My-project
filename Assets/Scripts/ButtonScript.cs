using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _Door;
    [SerializeField]
    private GameObject _MovePosition;
    [SerializeField]
    private bool _Triggered;
    [SerializeField]
    private float _Speed = 0.1f;
    [SerializeField]
    private bool _Toggle = true;
    private Vector3 startPosition;
    private Vector3 buttonStartPosition;

    private void Start()
    {
        startPosition = _Door.transform.position;
        buttonStartPosition = this.transform.position;
    }


    private void Update()
    {
        if (_Triggered == true)
        {
            _Door.transform.position = Vector3.Lerp(_Door.transform.position,_MovePosition.transform.position,_Speed);
        }
        else
        {
            _Door.transform.position = Vector3.Lerp(_Door.transform.position,startPosition,_Speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.layer == 6)
        {
            if (_Toggle == true)
            {
                _Triggered = !_Triggered;
            }
            else
            {
                _Triggered = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_Toggle == false)
        {
            _Triggered = false;
        }
    }
}
