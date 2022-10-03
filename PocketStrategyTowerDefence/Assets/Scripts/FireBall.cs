using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(Cooldown());
        
    }

    IEnumerator Cooldown()
    {
        
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }
}
