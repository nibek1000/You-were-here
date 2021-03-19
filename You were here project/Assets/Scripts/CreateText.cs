using UnityEngine;
using UnityEngine.UI;

public class CreateText : MonoBehaviour
{
    public GameObject player;
    public GameObject dataBaseController;

    public GameObject createTextObj;
    public bool isPreparingMessage = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPreparingMessage = true;
            createTextObj.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    public void CreateThisText(InputField inpf)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPreparingMessage = false;
        dataBaseController.GetComponent<textConnector>().CreateText(inpf.text, player.transform.position.x, player.transform.position.y, player.transform.position.z);
        inpf.text = "";
    }
}
