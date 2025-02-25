using UnityEngine;
using System.Collections;

public class drawPhys2 : MonoBehaviour
{

    public GameObject linePrefab;
    public float lineLength = 0.2f;
    public float lineWidth = 0.1f;

    public bool isCut = false;

    private Vector3 touchPos;

    bool isLined = false;

    void Start(){

    }

    void Update (){
        drawLine ();
    }

    void drawLine(){

        //isCut = false;

        if(Input.GetMouseButtonDown(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
/*
            if(isLined == true){

                for(int i = 0; i < this.transform.childCount; i++){
                    Destroy(transform.GetChild(i).gameObject);
                }

                isLined = false;
            }
            */
        }

        if(Input.GetMouseButton(0))
        {

            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z=0;

            if((endPos-startPos).magnitude > lineLength){
                GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                obj.transform.position = (startPos+endPos)/2;
                obj.transform.right = (endPos-startPos).normalized;

                obj.transform.localScale = new Vector3( (endPos-startPos).magnitude, lineWidth , lineWidth );

                obj.transform.parent = this.transform;

                if(isLined == false){
                    isLined = true;
                }

                touchPos = endPos;
            }
        }

        if(Input.GetMouseButtonUp(0)){
            isCut = true;
            if(isLined == true){

                for(int i = 0; i < this.transform.childCount; i++){
                    Destroy(transform.GetChild(i).gameObject);
                }

                isLined = false;
            }
            isCut = false;
            
        }

    }
}