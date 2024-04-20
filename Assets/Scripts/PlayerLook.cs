using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //camera behavior
    public float mouseSensitivity =  100f;
    public Transform playerBody;
    public float xRotation = 0f;
    Object objectLookedAt;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mousex);
        
        //shoot a raycast to see what we are looking at
        Shoot();


    }
    //Check what we are looking at and highlights interactable objects
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100)&& hit.transform.tag == "Interactable")
        {
            Debug.Log(hit.transform.name);
            objectLookedAt=hit.transform.gameObject;
            objectLookedAt.GetComponent<Highlight>().LookingAt();
        }
        else{
            if(objectLookedAt != null)
            {
                objectLookedAt.GetComponent<Highlight>().NotLookingAt();
            }
        }
    }
}
