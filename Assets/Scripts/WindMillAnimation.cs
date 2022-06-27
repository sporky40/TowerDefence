using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float framerate = .05f;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {

        GameManager.instance.windMillList.Add(this);
    }
    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= framerate)
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }

}
