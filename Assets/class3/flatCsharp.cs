using UnityEngine;
using System.Collections;

public class flatCsharp : MonoBehaviour {

    private Color c;
    private Texture origPic;
    private int index;

    private Vector3 screenPoint;
    private Vector3 scanPos;
    private Vector3 offset;
    private Vector3 origPos;

    static public bool bDrag;
    // Use this for initialization
    void Start()
    {
        c = renderer.material.color;
        origPic = renderer.material.mainTexture;
        //pic = new Texture2D[4];
        index = 0;
        scanPos = this.transform.position;
        origPos = scanPos;
        bDrag = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        print("Mouse down");
        renderer.material.color = c;
     
        index++;
        if (index == 3)
            index = 0;

        /////
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        offset = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //print(curPosition);
        transform.position = curPosition;
    }
    void OnMouseEnter()
    {
        print("Mouse enter");
        index = 0;
        renderer.material.color = Color.red;
    }
    void OnMouseExit()
    {
        print("Mouse exit");
        renderer.material.color = c;
        renderer.material.mainTexture = origPic;
    }

    void OnMouseDrag()
    {
        bDrag = true;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        print("curPosition" + curPosition);
    }

    void OnMouseUp()
    {
        print("mouse up");
        //transform.TransformPoint(origPos);
        bDrag = false;
        transform.position = origPos;
    }

}
