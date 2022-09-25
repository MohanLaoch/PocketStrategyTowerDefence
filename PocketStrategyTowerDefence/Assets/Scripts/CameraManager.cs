using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<GameObject> children = new List<GameObject>();
    public int currentCam = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform tr in transform) children.Add(tr.gameObject);
        children[currentCam].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            children[currentCam].SetActive(false);

            if (currentCam == 4)
            {
                currentCam = 0;
            }
            else
            {
                currentCam++;
            }
            children[currentCam].SetActive(true);

        }
    }
}
