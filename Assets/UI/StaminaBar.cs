using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {

    private Character C;

    public Texture2D bgImage;
    public Texture2D fgImage;

    public float staminaBarLength;

    // Use this for initialization
    void Start()
    {
        staminaBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentStamina(0);
    }

    void OnGUI()
    {
        // Create one Group to contain both images
        // Adjust the first 2 coordinates to place it somewhere else on-screen
        GUI.BeginGroup(new Rect(Screen.width / 2 - staminaBarLength / 2, Screen.height / 2 - 200, staminaBarLength, 32));

        // Draw the background image
        GUI.Box(new Rect(0, 0, staminaBarLength, 32), bgImage);

        // Create a second Group which will be clipped
        // We want to clip the image and not scale it, which is why we need the second Group
        GUI.BeginGroup(new Rect(0, 0, C.Stamina / C.MAXSTAMINA * staminaBarLength, 32));

        // Draw the foreground image
        GUI.Box(new Rect(0, 0, staminaBarLength, 32), fgImage);

        // End both Groups
        GUI.EndGroup();

        GUI.EndGroup();
    }

    public void AddjustCurrentStamina(int adj)
    {

        C.Stamina += adj;

        if (C.Stamina < 0)
            C.Stamina = 0;

        if (C.Stamina > C.MAXSTAMINA)
            C.Stamina = C.MAXSTAMINA;

        if (C.MAXSTAMINA < 1)
            C.MAXSTAMINA = 1;

        staminaBarLength = (Screen.width / 2) * (C.Stamina / (float)C.MAXSTAMINA);
    }
}