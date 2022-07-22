using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class genericRaycast : MonoBehaviour
{
    private Ray g_ray = new Ray(); // Define a ray for this check 
    private RaycastHit g_hitObject; // Use the RaycastHit type to get an object hit 
    private bool g_isHit = false;
    public LayerMask redLayer; // Defining a layer that will be detected with our raycast
    public LayerMask yellowLayer;
    public LayerMask blueLayer;
    public float g_rayLength = 10f; // Length of the ray 
    public KeyCode g_boundKey; // store the key that executes raycast \
    public UnityEvent g_onObjectClicked;
    public ObjectController objectController;
    public bool yellowFrozen = false;
    public bool redFrozen = false;
    void Update()
    {
        if (Input.GetKeyDown(g_boundKey))
            CastRay();
        else if (Input.GetKeyUp(g_boundKey))
            g_isHit = false;
    }

    private void CastRay()
    {
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Creates a ray from the camera at the X & Y point of the mouse position 
        // Only really gets the direction of the ray - 'point to' <thing> 

        
        if (Physics.Raycast(g_ray, out g_hitObject, g_rayLength, redLayer)) //if its the red object
        {
            if (g_isHit == false)
            {
                if (redFrozen == false)
                {
                    objectController.FreezeObjectRed();
                    redFrozen = true;
                    Debug.Log("red freeze fired");
                }
                else if (redFrozen == true)
                {
                    objectController.UnfreezeObjectRed();
                    redFrozen = false;
                    Debug.Log("red unfreeze fired");
                }
                g_isHit = true;
            }
        }

        if (Physics.Raycast(g_ray, out g_hitObject, g_rayLength, yellowLayer)) //if its the yellow object
        {
            if (g_isHit == false)
            {
                if (yellowFrozen == false)
                {
                    objectController.FreezeObjectYellow();
                    yellowFrozen = true;
                    Debug.Log("yellow freeze fired");
                }
                else if (yellowFrozen == true)
                { 
                    objectController.UnfreezeObjectYellow(); 
                    yellowFrozen=false;
                    Debug.Log("yellow unfreeze fired");
                }
                g_isHit = true;
                //Debug.Log("fired");
            }
        }

        if (Physics.Raycast(g_ray, out g_hitObject, g_rayLength, blueLayer)) //if its the blue object
        {
            if (g_isHit == false)
            {
                g_onObjectClicked?.Invoke();
                g_isHit = true;
            }
        }
    }
}
