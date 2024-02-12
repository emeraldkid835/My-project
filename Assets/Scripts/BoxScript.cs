using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Vector3 _SpawnPosition;
    public bool _Respawning = false;
    public bool hasRespawned = true;
    // Start is called before the first frame update
    void Start()
    {
        _SpawnPosition = transform.position;
    }


    private void FixedUpdate()
    {
        if (hasRespawned == false)
        {
            RespawnBox();
        }
    }

    public void RespawnBox()
    {
        
        this.GetComponent<Rigidbody>().useGravity = false;
        transform.position = _SpawnPosition;
        this.GetComponent<Rigidbody>().useGravity = true;
        _Respawning = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deathzone")
        {
            _Respawning = true;
            RespawnBox();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ExitDeathzone")
        {
            _Respawning = true;
            RespawnBox();
        }
    }
}
