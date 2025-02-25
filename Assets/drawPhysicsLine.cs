using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class drawPhysicsLine : MonoBehaviour
{

    public GameObject linePrefab;
    public float lineLength = 0.2f;
    public float lineWidth = 0.1f;

    private Vector3 touchPos;

    bool isLined = false;

    public bool isTweet = false;

    void Start(){

    }

    void Update (){
        drawLine ();
    }

    void drawLine(){
    

        if(Input.GetMouseButtonDown(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z=0;

            if(isLined == true ){

                if(isTweet == true){
                    if(IsExist() == false){
                      for(int i = 0; i < this.transform.childCount; i++){
                       Destroy(transform.GetChild(i).gameObject);
                      }

                      isLined = false;
                    }
                }else{

                  for(int i = 0; i < this.transform.childCount; i++){
                      Destroy(transform.GetChild(i).gameObject);
                  }

                  isLined = false;

                }

            }
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




    }


    public bool IsExist(){
    var current = EventSystem.current;
    var eventData = new PointerEventData( current )
    {
        position = Input.mousePosition
    };
    var raycastResults = new List<RaycastResult>();
    current.RaycastAll( eventData, raycastResults );
    var isExist = 0 < raycastResults.Count;
    return isExist;
   }
}