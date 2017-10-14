using UnityEngine;
using UnityEngine.UI;

public class UI_Keyboard : MonoBehaviour
{
    //private InputField input;

    public GameObject TopWallText;
    public GameObject RoomLight;
    public void Enter()
    {
        //input.text = "";
        TopWallText.SetActive(!TopWallText.activeSelf);
        RoomLight.SetActive(!TopWallText.activeSelf);
    }

    private void Start()
    {
        //input = GetComponentInChildren<InputField>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
        {
            Enter();
        }
    }
}