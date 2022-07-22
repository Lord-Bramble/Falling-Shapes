using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject yellowObject;
    public GameObject blueObject;
    public GameObject redObject;



    public void FreezeObjectYellow()
    {
        //yellowObject.GetComponent<Rigidbody>().freezeRotation = true;
        yellowObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

        //Debug.Log("fired");
    }
    public void FreezeObjectRed()
    {
        redObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

        //Debug.Log("fired");
    }
    public void UnfreezeObjectYellow()
    {
        yellowObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    public void UnfreezeObjectRed()
    {
        redObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
