using System.Collections;
using UnityEngine;

public class destroyAfterSec : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(dest());
    }

    IEnumerator dest()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
