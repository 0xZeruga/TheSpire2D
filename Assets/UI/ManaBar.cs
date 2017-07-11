using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {

    private Character C;

    public Texture2D bgImage;
    public Texture2D fgImage;

    public float manaBarLength;

    // Use this for initialization
    void Start()
    {
        manaBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentMana(0);
    }

    void OnGUI()
    {
        // Create one Group to contain both images
        // Adjust the first 2 coordinates to place it somewhere else on-screen
        GUI.BeginGroup(new Rect(Screen.width / 2 - manaBarLength / 2, Screen.height / 2 - 170, manaBarLength, 32));

        // Draw the background image
        GUI.Box(new Rect(0, 0, manaBarLength, 32), bgImage);

        // Create a second Group which will be clipped
        // We want to clip the image and not scale it, which is why we need the second Group
        GUI.BeginGroup(new Rect(0, 0, C.Mana / C.MAXMANA * manaBarLength, 32));

        // Draw the foreground image
        GUI.Box(new Rect(0, 0, manaBarLength, 32), fgImage);

        // End both Groups
        GUI.EndGroup();

        GUI.EndGroup();
    }

    public void AddjustCurrentMana(int adj)
    {

        C.Mana += adj;

        if (C.Mana < 0)
            C.Mana = 0;

        if (C.Mana > C.MAXMANA)
            C.Mana = C.MAXMANA;

        if (C.MAXMANA < 1)
            C.MAXMANA = 1;

        manaBarLength = (Screen.width / 2) * (C.Mana / (float)C.MAXMANA);
    }
}