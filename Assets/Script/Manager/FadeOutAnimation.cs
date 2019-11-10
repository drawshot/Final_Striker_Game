using UnityEngine;
using System.Collections;

/// <summary>
/// FadeOutAnimation script.
/// when load new scene, this script is loaded.
/// </summary>
public class FadeOutAnimation : MonoBehaviour
{
    public float colorChangeSpeed = 1f;    
    private float _alpha = 0f;             // check whether scene loading started.

    private SpriteRenderer _fadeOutSprite;      // SpriteRenderer Component used alpha fade out animation.

    // Initialization.
    void Awake()
    {
        // Get Image Component.
        _fadeOutSprite = GetComponent<SpriteRenderer>();
        
        // Set Color to Non.
        _fadeOutSprite.color = new Color(0f, 0f, 0f, 0f);

        // Set not to destroy this game object till the alpha animation finished.
    }

    

    // Alpha animation. ( Fade Out )
    void Update()
    {
        _alpha += colorChangeSpeed * Time.deltaTime;
        float sinAlpha = Mathf.Sin(_alpha);
        _fadeOutSprite.color = new Color(1f, 1f, 1f, sinAlpha);

        if (sinAlpha < 0f)
        {
            Destroy(gameObject);
        }
    }
}