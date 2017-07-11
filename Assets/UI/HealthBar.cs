using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

        private Character C;
        public Texture2D bgImage;
        public Texture2D fgImage;

        public float healthBarLength;

        // Use this for initialization
        void Start()
        {
            healthBarLength = Screen.width / 2;
        }

        // Update is called once per frame
        void Update()
        {
            AddjustCurrentHealth(0);
        }

        void OnGUI()
        {
            // Create one Group to contain both images
            // Adjust the first 2 coordinates to place it somewhere else on-screen
            GUI.BeginGroup(new Rect(Screen.width/2 - healthBarLength/2, Screen.height/2 -230, healthBarLength, 32));

            // Draw the background image
            GUI.Box(new Rect(0, 0, healthBarLength, 32), bgImage);

            // Create a second Group which will be clipped
            // We want to clip the image and not scale it, which is why we need the second Group
            GUI.BeginGroup(new Rect(0, 0, C.Health / C.MAXHEALTH * healthBarLength, 32));

            // Draw the foreground image
            GUI.Box(new Rect(0, 0, healthBarLength, 32), fgImage);

            // End both Groups
            GUI.EndGroup();

            GUI.EndGroup();
        }

        public void AddjustCurrentHealth(int adj)
        {

            C.Health += adj;

            if (C.Health < 0)
                C.Health = 0;

            if (C.Health > C.MAXHEALTH)
                C.Health = C.MAXHEALTH;

            if (C.MAXHEALTH < 100)
                C.MAXHEALTH = 100;

            healthBarLength = (Screen.width / 2) * (C.Health / (float)C.MAXHEALTH);
        }
    }