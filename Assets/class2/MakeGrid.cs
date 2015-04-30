using UnityEngine;
using System.Collections;

public class MakeGrid : MonoBehaviour {

    public int length=9;
    public int width=9;
    public GameObject tileObject=null;
    public GameObject planCollider = null;

    private GameObject otherTile=null;
    private GameObject clickTile = null;
    private bool isClick = false;
   


    //private Color otherTileColor ;
	// Use this for initialization
	void Start () {
        //设置碰撞体的尺寸和中心点
        BoxCollider box=planCollider.GetComponent<BoxCollider>();
        box.center = new Vector3(length/2,0,width/2);
        box.size = new Vector3(length+1,0.1f,width+1);
        
        for (int i = 0; i < length; i++) {
            for (int j = 0; j < width;j++ )
            {
                GameObject t = (GameObject)Instantiate(tileObject, new Vector3(i, 0, j), Quaternion.identity);

                setTileColor(t,0f);
                
                //if((i+j)%2==0){
                //    //unity写法改名物体颜色
                //    //t.renderer.material.color = Color.black;
                //    //itween的改变物体颜色
                //    iTween.ColorTo(t, Color.black, 0f);
                //}
            }
        }
	}

    
    void tileMoveUp(GameObject obj) {
        iTween.MoveTo(obj, new Vector3(obj.transform.position.x,0.5f,obj.transform.position.z), 0.5f);
        iTween.ColorTo(obj, Color.green, 0.5f);
        if (obj!=otherTile)
        {
            otherTile = obj;
            //otherTileColor = obj.renderer.material.GetColor("_Color");
        }
    }

   public void tileMoveDown(GameObject obj) {
       Debug.Log("MakeGrid.tileMoveDown()");
        iTween.MoveTo(obj, new Vector3(obj.transform.position.x, 0, obj.transform.position.z), 0.5f);
        setTileColor(obj,0.5f);
        otherTile = null;
        isClick = false;
        //iTween.ColorTo(obj, otherTileColor, 0.5f);
    }

    //设置颜色
    void setTileColor(GameObject obj,float tiem) {
        float val = obj.transform.position.x + obj.transform.position.z;
        if (val % 2 == 0)
        {
            iTween.ColorTo(obj, Color.black, tiem);
        }
        else {
            iTween.ColorTo(obj, Color.white, tiem);
        }
    }

	
	// Update is called once per frame
	void Update () {
       
      
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit)&& !isClick){

            if (hit.transform.tag == "tile")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("点击");
                    clickTile = hit.transform.gameObject;
                    tileMoveDown(clickTile);
                    //isClick = true;
                }

                if ((otherTile != null) && (otherTile != hit.transform.gameObject))
                {
                    tileMoveDown(otherTile);
                }

                if (clickTile != hit.transform.gameObject)
                {
                    tileMoveUp(hit.transform.gameObject);
                }
                
               
            }

        }
        else if (otherTile != null)
        {
            Debug.Log("kong");
            tileMoveDown(otherTile);
            otherTile = null;
        }
	}
}
