using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ButtonInvisible : MonoBehaviour
{
    public static ButtonInvisible Stance { get; private set; }
    public GameObject Button;
    public bool Invisible = true;

    void Update()
    {
    }


    public void ButtonPressed()
    {
        Invisible = false;
        Button.SetActive(false);
    }
}
