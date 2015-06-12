using UnityEngine;
using System.Collections;

public class CameraCsharp : MonoBehaviour {

    public GameObject planObj;
    public GameObject ball;

    private Vector3[] paths=new Vector3[3];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "flat")
            {
                iTween.MoveUpdate(planObj,new Vector3(hit.point.x,planObj.transform.position.y,hit.point.z),.1f);
                float dist=Vector3.Distance(gameObject.transform.position,planObj.transform.position);

                float x = 0.3f - dist * 0.01f;
                float z = 0.3f - dist * 0.01f;
                planObj.transform.localScale = new Vector3(x,planObj.transform.localScale.y,z);

                             
            }
        }
        
	    if(Input.GetMouseButtonUp(0)){
                paths[0] = new Vector3(0,0,0);
                paths[1] = new Vector3(planObj.transform.position.x / 2, 4f, planObj.transform.position.z/2);
                paths[2] = new Vector3(planObj.transform.position.x, 0.5f, planObj.transform.position.z);
                GameObject newBall=(GameObject)Instantiate(ball, new Vector3(0,0,0), Quaternion.identity);
                iTween.MoveTo(newBall, iTween.Hash("path",paths,"movetopath",true,"orienttopath",false, "time", 5f, "easetype", iTween.EaseType.linear));
                //Destroy(newBall, 2f);
        }
	}

    void OnDrawGizmos()
    {
        iTween.DrawLine(paths, Color.red);
        iTween.DrawPath(paths, Color.blue);
    }

}
