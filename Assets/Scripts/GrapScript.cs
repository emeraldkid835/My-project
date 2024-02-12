using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GrapScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _Player;
    [SerializeField]
    private GameObject _GrabbedObject;
    [SerializeField]
    private bool grabbed = false;
    [SerializeField]
	public TextMeshProUGUI UI;



    private void start()
    {
        UI.text = "";
    }

    private void FixedUpdate()
    {
        if (_GrabbedObject != null)
        {
            if (grabbed == true)
            {
                if (_GrabbedObject.GetComponent<BoxScript>()._Respawning == true)
                {
                    Debug.Log("Box Respawned");
                    grabbed = false;
                    _GrabbedObject.GetComponent<BoxScript>().RespawnBox();
                }
                _GrabbedObject.transform.position = this.transform.position;
                _GrabbedObject.transform.rotation = this.transform.rotation;
                _GrabbedObject.GetComponent<Rigidbody>().useGravity = false;
                Physics.IgnoreCollision(_GrabbedObject.GetComponent<BoxCollider>(), _Player.GetComponent<Collider>(),true);
            }
            else
            {
                _GrabbedObject.GetComponent<Rigidbody>().useGravity = true;
                Physics.IgnoreCollision(_GrabbedObject.GetComponent<Collider>(), _Player.GetComponent<Collider>(),false);
            }
        }
        else
        {
            grabbed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (grabbed == false)
        {
            if (other.gameObject.tag == "Grabbable")
            {
                _GrabbedObject = other.gameObject;
                UI.text = "E";
            } 
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (grabbed == false)
        {
            if (other.gameObject == _GrabbedObject)
            {
                _GrabbedObject = null;
                UI.text = "";
            }
        }
    }
    public void Grab()
    {
        grabbed = !grabbed;
    }
}
