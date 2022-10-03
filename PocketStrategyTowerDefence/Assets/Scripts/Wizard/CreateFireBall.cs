using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFireBall : MonoBehaviour
{
    public GameObject fireball;
    public Camera mainCamera;

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);

                Instantiate(fireball, new Vector3(pointToLook.x, 0, pointToLook.z), Quaternion.identity);
                
                
            }
        }

    }

    


}

