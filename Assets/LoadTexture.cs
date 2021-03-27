using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;

public class LoadTexture : MonoBehaviour
{
    string filePath;
    byte[] fileData; // load data inside a byte array 0x89,0x50,0x4E,0x47,0x0D...
    Texture oldtex;
    Texture2D tex;
    private KeyCode last;

    void Start()
    {
        filePath = Application.dataPath + "\\..\\texture-sphere.jpg";                   // the path of the image
        fileData = System.IO.File.ReadAllBytes(filePath);              // 1.read all the bytes array
        tex = new Texture2D(2, 2);                 // 2.make a texture named tex
        tex.LoadImage(fileData);                             // 3.load inside tex all the bytes 
        Texture oldtex = this.GetComponent<Renderer>().material.mainTexture;
    }

    void ToggleKey(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            if (last == key)
            {
                this.GetComponent<Renderer>().material.mainTexture = oldtex; // apply previous tex to material.mainTexture 
                last = KeyCode.None;
            }
            else
            {
                this.GetComponent<Renderer>().material.mainTexture = tex; // 4.apply tex to material.mainTexture 
                last = key;
            }
        
        }
    }
    

    void Update()
    {
        ToggleKey(KeyCode.T);   
    }

  



}
