using UnityEngine;
using UnityEngine.UI;

public class Lightswitch : MonoBehaviour
{
    //private InputField input;

    public GameObject TopWallText;
    public GameObject RoomLight;
    public void ToggleLight()
    {
        //input.text = "";
        TopWallText.SetActive(!TopWallText.activeSelf);
        RoomLight.SetActive(!TopWallText.activeSelf);
        GetComponent<AudioSource>().Play();
    }

    private void Start()
    {
        //input = GetComponentInChildren<InputField>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
        {
            ToggleLight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Body")
        {
            ToggleLight();
        }
        
    }
}