using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Vector3 _SpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        _SpawnPosition = transform.position;
    }

    private void RespawnBox()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        transform.position = _SpawnPosition;
        this.GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deathzone")
        {

            RespawnBox();
        }
    }
}
