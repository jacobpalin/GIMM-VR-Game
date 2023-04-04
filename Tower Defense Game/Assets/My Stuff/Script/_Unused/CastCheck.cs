using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CastCheck : MonoBehaviour
{
    //CODE STILL NEEDS PERCENTAGE CHECK THING
    public GameObject spellSymbol;
    private Texture2D spellSymbolTexture;
    Color32[] pixels;
    Color32 originalColor;
    private bool setValuesInUpdateOnce = true;
    public bool[,] pixelTrueCheck;
    private float checkPixelsInterval = 2f;
    private float originalTime;
    public GameObject currentSpell;
    void Awake()
    {
        originalTime = checkPixelsInterval;
    }
    void Update()
    {
        if(setValuesInUpdateOnce == true)
        {
            setValuesInUpdateOnce = false;
            //all these need to be set in update because of the line below which doesn't seem to work in Awake or Start
            spellSymbolTexture = spellSymbol.GetComponent<Whiteboard>().texture;
            //makes the size of this bool array = to the size of the pixels array for checking if it has been changed
            pixelTrueCheck = new bool[spellSymbolTexture.width, spellSymbolTexture.height];
            pixels = spellSymbolTexture.GetPixels32(); //gets pixel values from texture
            //original texture colors in rgb values
            originalColor.r = pixels[spellSymbolTexture.width].r; 
            originalColor.g = pixels[spellSymbolTexture.width].g;
            originalColor.b = pixels[spellSymbolTexture.width].b;
        }
        checkPixelsInterval -= Time.deltaTime; //count down the timer before next pixel check
        if (checkPixelsInterval <= 0f && IsComplete() == true) //calls IsComplete every length of 'checkPixelsInterval'
        {
            //Debug.Log("spell can be cast");
            if (currentSpell.CompareTag("Spell1"))
            {
                currentSpell.GetComponent<Spell1>().canCast = true;
            }
            else if (currentSpell.CompareTag("Spell2"))
            {
                currentSpell.GetComponent<Spell2>().canCast = true;
            }
            else if (currentSpell.CompareTag("Spell3"))
            {
                currentSpell.GetComponent<Spell3>().canCast = true;
            }
            else if (currentSpell.CompareTag("Spell4"))
            {
                currentSpell.GetComponent<Spell4>().canCast = true;
            }
            Destroy(GameObject.FindWithTag("SymbolPrefab"), .5f);
        }
    }
    //looping through each pixel on spell's texture and checking the color at those pixels for changes from the original color and returning true or false if changed or not
    public bool IsComplete()
    {
        pixels = spellSymbolTexture.GetPixels32(); //gets pixel values from texture
        checkPixelsInterval = originalTime; //reset timer
        for (int i = 0, j = spellSymbolTexture.width; i < j; i += 1)
        {
            for (int k = 0, l = spellSymbolTexture.height; k < l; k += 1)
            {
                pixelTrueCheck[i, k] = false;
                Color32 col = pixels[k + i * spellSymbolTexture.width]; //sets current pixel array value to a new value to check it against the rgb values of the originalColor rgb values
                //Debug.Log(col + " at: " + k + ", " + i);
                if (col.r != originalColor.r || col.g != originalColor.g || col.b != originalColor.b)
                {
                    //Debug.Log("pixel true");
                    pixelTrueCheck[i, k] = true; //set current pixel to true to indicate it has been changed
                }
                //this if statement returns false if the pixel has not been changed, if everything else has been colored except for the first pixel that the code checks, it will still return false. I need to somehow get a way to check for a percentage of the pixels to be colored and if it's above a certain percent then it should return true.
                if (pixelTrueCheck[i,k] == false)
                {
                    //Debug.Log("pixel false");
                    return false;
                }
            }
        }
        //Debug.Log("pixel true");
        return true;
    }
    //unity docs that helped me figure this out
    //https://forum.unity.com/threads/solved-loop-through-and-setting-textures-pixels-in-groups-of-4.418526/
    //https://answers.unity.com/questions/1674312/getpixel-optimisation.html
    //https://docs.unity3d.com/ScriptReference/Color32.html
    //https://docs.unity3d.com/ScriptReference/Texture2D.GetPixels32.html
    //https://answers.unity.com/questions/1509375/how-can-i-check-how-many-pixels-on-a-texture-are-t.html
}