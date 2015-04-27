using UnityEngine;
using System.Collections;

public class MakeGrid : MonoBehaviour {

    public int length=9;
    public int width=9;
    public GameObject tileObject;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < length; i++) {
            for (int j = 0; j < width;j++ )
            {
                GameObject t = (GameObject)Instantiate(tileObject, new Vector3(i, 0, j), Quaternion.identity);

                if((i+j)%2==0){
                    //unity写法改名物体颜色
                    //t.renderer.material.color = Color.black;
                    //itween的改变物体颜色
                    iTween.ColorTo(t, Color.black, 0f);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
