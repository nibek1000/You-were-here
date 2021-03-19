using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }
}
