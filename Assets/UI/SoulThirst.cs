using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulThirst : MonoBehaviour {

    private Character C;

    public Texture2D bgImage;
    public Texture2D fgImage;

    public float SoulThirstBar;

    // Use this for initialization
    void Start()
    {
        SoulThirstBar = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentSoulThirst(0);
    }

    void OnGUI()
    {
        // Create one Group to contain both images
        // Adjust the first 2 coordinates to place it somewhere else on-screen
        GUI.BeginGroup(new Rect(Screen.width / 2 - SoulThirstBar / 2, Screen.height / 2 - 140, SoulThirstBar, 32));

        // Draw the background image
        GUI.Box(new Rect(0, 0, SoulThirstBar, 32), bgImage);

        // Create a second Group which will be clipped
        // We want to clip the image and not scale it, which is why we need the second Group
        GUI.BeginGroup(new Rect(0, 0, C.SoulFragments / C.MAXSOULTHIRST * SoulThirstBar, 32));

        // Draw the foreground image
        GUI.Box(new Rect(0,0 , SoulThirstBar, 32), fgImage);

        // End both Groups
        GUI.EndGroup();

        GUI.EndGroup();
    }

    public void AddjustCurrentSoulThirst(int adj)
    {

        C.SoulFragments += adj;

        if (C.SoulFragments < 0)
            C.SoulFragments = 0;

        if (C.SoulFragments > C.MAXSOULTHIRST)
            C.SoulFragments = C.MAXSOULTHIRST;

        if (C.MAXSOULTHIRST < 1)
            C.MAXSOULTHIRST = 1;

        SoulThirstBar = (Screen.width / 2) * (C.SoulFragments / (float)C.MAXSOULTHIRST);
    }
}