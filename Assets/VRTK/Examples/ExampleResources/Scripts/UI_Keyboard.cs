namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UI_Keyboard : MonoBehaviour
    {
        //private InputField input;

        public GameObject go;
        public void Enter()
        {
            //input.text = "";
            go.SetActive(!go.activeSelf);
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
}