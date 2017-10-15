using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EKeyPadKey
{
    Key0,
    Key1,
    Key2,
    Key3,
    Key4,
    Key5,
    Key6,
    Key7,
    Key8,
    Key9,
    KeyDelete,
    KeyEnter,
}
public class Bomb : MonoBehaviour
{

    public GameObject WinScreen;
    public GameObject LoseScreen;


    public float TimeTillExplosion;
    public float TimePunishment;
    public GameObject TimerDisplay;
    public Text TimerLabel;
    public GameObject Keypad;
    public Text KeypadLabel;
    public String KeypadBlank;

    public GameObject LampA;
    private Material MatA;
    public GameObject LampB;
    private Material MatB;
    public GameObject LampC;
    private Material MatC;
    public GameObject LampD;
    private Material MatD;


    private bool interrupted = false;
    private bool audioFirstStop = true;
    private int numInput = 0;
    private int activatedCodes = 0x0;

    // Use this for initialization
    void Start()
    {
        // Status lamps
        MatA = LampA.GetComponent<Renderer>().material;
        MatB = LampB.GetComponent<Renderer>().material;
        MatC = LampC.GetComponent<Renderer>().material;
        MatD = LampD.GetComponent<Renderer>().material;
        KeypadLabel.text = KeypadBlank;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioFirstStop)
        {
            TimerDisplay.GetComponent<AudioSource>().Play();
            audioFirstStop = false;
        }
        if (!interrupted)
        {
            TimeTillExplosion -= Time.deltaTime;
            int seconds = (int)Math.Floor(TimeTillExplosion) % 60;
            int minutes = (int)(Math.Floor(TimeTillExplosion) - seconds) / 60;
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
                Time.timeScale = 0;
                LoseScreen.SetActive(true);
                GetComponent<AudioSource>().Play();
                // Verloren
            }
        }
        else
        {
            TimerDisplay.GetComponent<AudioSource>().Stop();
        }
    }

    public void OnKeyPress(EKeyPadKey key)
    {
        Keypad.GetComponent<AudioSource>().Play();
        switch (key)
        {
            case EKeyPadKey.Key0:
                InputNum(0);
                break;
            case EKeyPadKey.Key1:
                InputNum(1);
                break;
            case EKeyPadKey.Key2:
                InputNum(2);
                break;
            case EKeyPadKey.Key3:
                InputNum(3);
                break;
            case EKeyPadKey.Key4:
                InputNum(4);
                break;
            case EKeyPadKey.Key5:
                InputNum(5);
                break;
            case EKeyPadKey.Key6:
                InputNum(6);
                break;
            case EKeyPadKey.Key7:
                InputNum(7);
                break;
            case EKeyPadKey.Key8:
                InputNum(8);
                break;
            case EKeyPadKey.Key9:
                InputNum(9);
                break;
            case EKeyPadKey.KeyEnter:
                KeypadEnter();
                break;
            case EKeyPadKey.KeyDelete:
                KeypadDel();
                break;

            default:
                throw new NotImplementedException();
        }
    }

    private void InterruptTimer()
    {
        interrupted = true;
    }

    public void StartTimer()
    {
        interrupted = false;
    }

    private void InputNum(int num)
    {
        numInput = numInput * 10 + num;
        // OPTIONAL: Länge des Codes begrenzen
        if (numInput > 999)
            numInput = 999;
        KeypadLabel.text = numInput.ToString();
    }

    private void KeypadEnter()
    {
        KeypadLabel.text = KeypadBlank;
        switch (numInput)
        {
            // CODES KONFIGURIEREN
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
        numInput = (numInput - numInput % 10) / 10;
        KeypadLabel.text = numInput.ToString();
        if (numInput == 0)
            KeypadLabel.text = KeypadBlank;
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
        if (activatedCodes == (0x08 | 0x04 | 0x02 | 0x01))
        {
            InterruptTimer();
            Time.timeScale = 0;
            WinScreen.SetActive(true);
            // Gewonnen
        }
    }
}
