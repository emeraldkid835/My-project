using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GrapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _GrabbedObject;
    [SerializeField]
    private bool grabbed = false;
    [SerializeField]
	public TextMeshProUGUI UI;


    private void start()
    {
    }

    private void FixedUpdate()
    {
        if (_GrabbedObject != null)
        {
            if (grabbed == true)
            {
            _GrabbedObject.transform.position = this.transform.position;
            _GrabbedObject.transform.rotation = this.transform.rotation;
            _GrabbedObject.GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                _GrabbedObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        else
        {
            grabbed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Grabbable")
        {
            _GrabbedObject = other.gameObject;
            UI.text = "E";
        } 
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _GrabbedObject)
        {
            _GrabbedObject = null;
            UI.text = "";
        }
    }
    public void Grab()
    {
        Debug.Log("Test");
        grabbed = !grabbed;
    }
}
