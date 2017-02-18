using System;
using UnityEngine;
using System.Collections;
 
public class MoveDown : MonoBehaviour
{    
    public bool Active;
    public int Speed;
    public AnchorPositions Anchor;
    private float LimitY = 0;
    private float StartY = 0;
    private float AbsLimitY = 0;
    private float AbsStartY = 0;

	void Start () {
        var pos = new Vector3();
	    switch (Anchor)
	    {
            case AnchorPositions.Left:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 1));
	            break;
            case AnchorPositions.Right:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 1));
                break;
            case AnchorPositions.TopLeft:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 1));
	            break;
            case AnchorPositions.Top:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 1));
	            break;
            case AnchorPositions.TopRight:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
	            break;
            case AnchorPositions.Center:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1));
	            break;
            case AnchorPositions.BottomLeft:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
	            break;
            case AnchorPositions.BottomRight:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 1));
	            break;
            case AnchorPositions.Bottom:
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 1));
	            break;
	    }
        gameObject.transform.position = pos;
        LimitY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1)).y;
        StartY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 1)).y;
	    AbsLimitY = Mathf.Abs(LimitY);
        AbsStartY = Mathf.Abs(StartY);
        var sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;
        //transform.localScale = new Vector3(1, 1, 1);
        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;
        var worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
	    transform.localScale = new Vector3(transform.localScale.x, worldScreenHeight/height, 1);        
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Active)
        {
            var p = gameObject.transform.position;
            gameObject.transform.position = new Vector2(p.x, p.y - Mathf.Abs(LimitY) / 100 * Speed);
            if (p.y < LimitY*3)
            {
                gameObject.transform.position = new Vector2(p.x, StartY);
            }
        }
	}   
}
