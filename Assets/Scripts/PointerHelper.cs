using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PointerHelper : MonoBehaviour
{

    public void OnPointerSelect(object sender, ControllerInteractionEventArgs args)
    {
        Debug.Log(sender.ToString());
    }
}
