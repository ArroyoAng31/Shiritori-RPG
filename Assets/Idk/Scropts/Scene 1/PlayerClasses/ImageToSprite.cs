using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageToSprite
{
    private protected string pngPath = @"Assets/TestingSHit";
    private protected string playerPng = "";
    private protected Sprite playerSprite;

    public Sprite LoadSpriteFromImage(string playerImg)
    {
        playerPng = playerImg;

        string[] allFilePaths = Directory.GetFiles(pngPath, playerPng, SearchOption.AllDirectories); //SearchOption.AllDirectories goes through all subfolders

        foreach (string filePath in allFilePaths)
        {
            byte[] newPngFileData;
            newPngFileData = File.ReadAllBytes(filePath); //Loads PNG into memory

            Texture2D newTexture2D = new Texture2D(1, 1);
            newTexture2D.LoadImage(newPngFileData); // Loads PNG into a unity 2DTexture

            Sprite newSprite = Sprite.Create(newTexture2D, new Rect(0, 0, newTexture2D.width, newTexture2D.height), new Vector2(0, 0), 1); //Creates a Unity Sprite from the Texture
            playerSprite = newSprite;

        }
        return playerSprite;
    }
}
