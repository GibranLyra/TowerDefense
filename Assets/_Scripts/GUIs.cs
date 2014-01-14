﻿using UnityEngine;
using System.Collections;

public class GUIs : MonoBehaviour 
{
    public Rect windowRect = new Rect(20, 20, 430, 400);

    int counter = 0;

    string text = "ABCD";

    bool toggle = false;

    public GUISkin myskin = null;

    public float widthPercent = 0.3f;
    public float heightPercent = 0.3f;
    public Texture2D logo = null;
    void OnGUI()
    {
        GUI.skin = myskin;

        // calculate the menu rect first (its needed in the logo)
        Rect r = new Rect(Screen.width * (1 - widthPercent) / 2,
                          Screen.height * (1 - heightPercent) / 2,
                          Screen.width * widthPercent,
                          Screen.height * heightPercent);

        // draw logo, centered at the top right of the menu
        if (logo != null)
        {
            Rect l = new Rect(r.x + r.width - logo.width / 2,
                              r.y - logo.height / 2,
                              logo.width,
                              logo.height);
            GUI.DrawTexture(l, logo);
        }
        

        // draw the menu
        GUILayout.BeginArea(r);
        GUILayout.BeginVertical("box");

        if (GUILayout.Button("Play"))
            Application.LoadLevel("scene_main");

        if (GUILayout.Button("Quit"))
            Application.Quit();

        GUILayout.EndVertical();
        GUILayout.EndArea();     
        
    }    
}