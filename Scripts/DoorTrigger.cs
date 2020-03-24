using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    void OnTriggerEnter(Collider col)
    {
        door.transform.position += new Vector3(0, -6, 0);//Færir hurðina niður í jörðina þegar hluturinn er snertur
    }
}
