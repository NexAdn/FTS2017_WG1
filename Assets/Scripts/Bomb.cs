using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour {

    public float TimeTillExplosion;
    public float TimePunishment;
    public Text TimerLabel;
    public Text KeypadLabel;

    public GameObject LampA;
    private Material MatA;
    public GameObject LampB;
    private Material MatB;
    public GameObject LampC;
    private Material MatC;
    public GameObject LampD;
    private Material MatD;


    private bool interrupted = false;
    private int numInput = 0;
    private int activatedCodes = 0x0;

	// Use this for initialization
	void Start () {
        MatA = LampA.GetComponent<Renderer>().material;
        MatB = LampB.GetComponent<Renderer>().material;
        MatC = LampC.GetComponent<Renderer>().material;
        MatD = LampD.GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update ()
    {
        if (!interrupted)
        {
            TimeTillExplosion -= Time.deltaTime;
            int seconds = (int)Math.Floor(TimeTillExplosion)%60;
            int minutes = (int)(Math.Floor(TimeTillExplosion) - seconds)/60;
            TimerLabel.text = "";
            if (minutes < 10)
                TimerLabel.text += "0";
            TimerLabel.text += minutes.ToString() + ":";
            if (seconds < 10)
                TimerLabel.text += "0";
            TimerLabel.text += seconds.ToString();
            if (TimeTillExplosion <= 0)
            {
                TimerLabel.text = "00:00";
                InterruptTimer();
                // Verloren
            }
        }

        if (Input.GetKeyUp(KeyCode.Keypad0))
            InputNum(0);
        if (Input.GetKeyUp(KeyCode.Keypad1))
            InputNum(1);
        if (Input.GetKeyUp(KeyCode.Keypad2))
            InputNum(2);
        if (Input.GetKeyUp(KeyCode.Keypad3))
            InputNum(3);
        if (Input.GetKeyUp(KeyCode.Keypad4))
            InputNum(4);
        if (Input.GetKeyUp(KeyCode.Keypad5))
            InputNum(5);
        if (Input.GetKeyUp(KeyCode.Keypad6))
            InputNum(6);
        if (Input.GetKeyUp(KeyCode.Keypad7))
            InputNum(7);
        if (Input.GetKeyUp(KeyCode.Keypad8))
            InputNum(8);
        if (Input.GetKeyUp(KeyCode.Keypad9))
            InputNum(9);
        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
            KeypadEnter();
        if (Input.GetKeyUp(KeyCode.Delete))
            KeypadDel();
    }

    private void InterruptTimer()
    {
        interrupted = true;
    }

    public void StartTimer()
    {
        interrupted = false;
    }

    public void InputNum(int num)
    {
        numInput = numInput * 10 + num;
        KeypadLabel.text = numInput.ToString();
    }

    public void KeypadEnter()
    {
        KeypadLabel.text = "";
        switch (numInput)
        {
            case 351://Leuchtfarbe
                activatedCodes |= 0x01;
                UpdateLamps();
                break;
            case 472://Kamin
                activatedCodes |= 0x02;
                UpdateLamps();
                break;
            case 958://Wand
                activatedCodes |= 0x04;
                break;
            case 260://Karton
                activatedCodes |= 0x08;
                break;
            default:
                // Code falsch
                TimeTillExplosion -= TimePunishment;
                break;
        }
        UpdateLamps();
        numInput = 0;
    }

    void KeypadDel()
    {
        numInput = (numInput - numInput % 10)/10;
        KeypadLabel.text = numInput.ToString();
    }

    void UpdateLamps()
    {
        if ((activatedCodes & 0x01) > 0)
        {
            MatA.color = Color.green;
        }
        if ((activatedCodes & 0x02) > 0)
        {
            MatB.color = Color.green;
        }
        if ((activatedCodes & 0x04) > 0)
        {
            MatC.color = Color.green;
        }
        if ((activatedCodes & 0x08) > 0)
        {
            MatD.color = Color.green;
        }
        if (activatedCodes == (0x08|0x04|0x02|0x01))
        {
            InterruptTimer();
            // Gewonnen
        }
    }
}
