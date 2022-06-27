using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEnemy : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float framerate = .1f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {

        GameManager.instance.enemyList.Add(this);
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if(timer >= framerate)
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }

    public void RemoveEnemy()
    {
        GameManager.instance.enemyList.Remove(this);
    }


 
}
