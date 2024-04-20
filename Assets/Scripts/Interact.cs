using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Material highlightMaterial;
    public Material originalMaterial;
    public bool isLookedAt = false;
    // Update is called once per frame
    void Update()
    {
        if(isLookedAt)
        {
            transform.GetComponent<Renderer>().material = highlightMaterial;
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacted with: "+transform.name);
            }
        }
        else{
            transform.GetComponent<Renderer>().material = originalMaterial;
        }
    }
    public void LookingAt()
    {
        isLookedAt = true;
    }
    public void NotLookingAt()
    {
        isLookedAt = false;
    }
}
