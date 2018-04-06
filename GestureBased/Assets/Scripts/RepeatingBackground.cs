using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D bgCollder;
    private float bgVerticalLength;

    // Use this for initialization
    void Start()
    {

        bgCollder = GetComponent<BoxCollider2D>();
        bgVerticalLength = bgCollder.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -bgVerticalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 bgOffset = new Vector2(0, bgVerticalLength * 2);
        transform.position = (Vector2)transform.position + bgOffset;
    }
}