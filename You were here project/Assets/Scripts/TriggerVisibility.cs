using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVisibility : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        text.GetComponent<Animator>().SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        text.GetComponent<Animator>().SetBool("isOpen", false);
    }
}
