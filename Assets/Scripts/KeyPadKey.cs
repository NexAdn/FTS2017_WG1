using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class KeyPadKey : MonoBehaviour {

    [Header("KeyPadKey Settings")]
    public Bomb bomb;
    public EKeyPadKey key;

    public void OnKeyPress()
    {
        Debug.Log(key);
        bomb.OnKeyPress(key);
    }
}
