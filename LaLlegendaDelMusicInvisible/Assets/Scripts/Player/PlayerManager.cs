using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlayerManager : MonoBehaviour
{
    public PlayerPrefsData prefsData { get; private set; }
  
    public Camera cam;
    public DoubleClick doubleClick;
    public TimelineController timelineController;

    private GameObject gObj = null;
    private Plane objPlane;
    private Vector3 mouseOffset;

    int index = 0;

    PlayerRotation playerRotation;
    Transform targetPlace;
    Node node;
    Node backNode = null;
    DestinationPlace place;
    DestinationPlace backPlace;
    Interactable interactable;
    Transform newTransform;
    string targetName;
    string goBackTag;
    float previousTouchDistance;
    float deltaDistance;

    private float deltaX = 0f;
    private float deltaY = 0f;
    private Touch initTouch = new Touch();
    float posX;
    Vector3 position;
    bool on;
    bool back;
    EnableCollider enableCollider;
    bool moveEnded;
    string locationName;
    bool enable;

    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        moveEnded = true;

        
    }
    
    private void OnEnable()
    {
        playerRotation = GetComponent<PlayerRotation>();

        prefsData = PlayerPrefsPersistentData.LoadData();
        locationName = prefsData.LocationName;
      

        Debug.Log("locationName " + locationName);
        
    }
    private void OnDisable()
    {
        PlayerPrefsPersistentData.SaveData(this);


    }
    private void Start()
    {

        playerRotation = GetComponent<PlayerRotation>();
       
        //if(locationName == "Porta" || locationName == "TimbreEntrada" || locationName == "StartPosition")
        //{
        //    place = GameObject.Find("StartPosition").GetComponent<DestinationPlace>();

        //    Debug.Log("StartLocationName" + place);
        //}
        //else if(locationName == "GerroBlau" || locationName == "Tarot_Diable" || locationName == "QuadreChopin" || locationName == "PortaPedraVestibul" || locationName == "EntradaVestibul")
        //{
        //    place = GameObject.Find("EntradaVestibul").GetComponent<DestinationPlace>();

        //}
        //else if (locationName == "EntradaSalaPlantaBaixa" || locationName == "TaulaPlantaBaixa" || locationName == "PortaEscalaPlantaBaixa" )
        //{
        //    place = GameObject.Find("EntradaSalaPlantaBaixa").GetComponent<DestinationPlace>();
        //}
        //else 
        //{
        //    place = GameObject.Find("EntradaSalaPlantaBaixa").GetComponent<DestinationPlace>();
        //}
        // place.GetComponent<Collider>().enabled = true;
        place = GameObject.Find(locationName).GetComponent<DestinationPlace>();
        transform.parent = place.interactiveLocation;

        SetNewTransform(place);

    }

    // Update is called once per frame
    void Update()
    {

        if (newTransform)
            Move();

        
        //Detectem nodes on es desplaça el player i activem el desplaçament amb un doble "tap"
        if (doubleClick.doubleClickDone)
        {
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {

                if (moveEnded)
                {
                   
                    place = hit.collider.GetComponent<DestinationPlace>();
                  

                    if (place != null)
                    {
                        Debug.Log("place collider: " + hit.collider.name);

                        SetNewTransform(place);


                    }



                    if(hit.collider.tag == "Stairs")
                    {
                        timelineController.PlayFromTimelines(index);
                        index++;

                        if (index > 1)
                            index = 0;
                    }
                }

                
            }
            
            doubleClick.doubleClickDone = false;
        }

        //Usem dos dits per retornar a una posició 
       

        if (Input.touchCount == 2)
        {
            

            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)
            {
                Debug.Log("Began");
                playerRotation.enabled = false;

                previousTouchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                on = true;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Debug.Log("Move");
                float distance;
                Vector2 touch1 = Input.GetTouch(0).position;
                Vector2 touch2 = Input.GetTouch(1).position;
                distance = Vector2.Distance(touch1, touch2);
                deltaDistance = previousTouchDistance - distance;

                if (deltaDistance > 40f && on)
                {
                    if(place.reachablePlaces.Count > 0)
                    {
                        if(place.tag == "GoBack")
                             place = place.reachablePlaces[0];
                       // Debug.Log("Dos dits " + place);

                        SetNewTransform(place);
                        on = false;
                    }
                   
                }
                return;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended)
            {
                
            }
          
        }
        
        if( Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2f))
            {
               // Debug.Log("Interactuable amb " + hit.collider);
                Interactuable interactuable = hit.collider.GetComponentInChildren<Interactuable>();
                if(interactuable != null)
                {
                    interactuable.Interactua();
                }
            }


        }

    }
    

    void SetNewTransform(DestinationPlace _place)
    {
        //Desvinculem del pare
        transform.parent = null;
        //Assignem el lloc de destí
        newTransform = _place.interactiveLocation;
        //Orientem correctament el lloc de destí
        newTransform.localRotation = Quaternion.identity;
        //Assignem el lloc de destí com a pare
        transform.parent = newTransform;
        targetName = newTransform.tag;
        //rotació
        playerRotation.SetRotationValues(0, 0, Quaternion.identity);
        playerRotation.GetTargetName(targetName);
        //Activem els nodes
        _place.ReachablePlaces();
        place = _place;
    }

    void Move()
    {
        playerRotation.enabled = false;
        moveEnded = false;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, Time.deltaTime * 4f);
       // transform.parent.localRotation = Quaternion.identity;
       // playerRotation.enabled = false;

        if (targetName == "Panoramic")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 4f);

            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, 0)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;
            }
        }
        if (targetName == "LookAt")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, -2), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, -2)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, -2);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;

            }

        }
        if (targetName == "Detail")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, -0.5f), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, -0.5f)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, -0.5f);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;

            }

        }
        if (targetName == "NoRotation")
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, 0)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                moveEnded = true;

                // playerRotation.enabled = true;
            }
        }

       
    }

   

    //private void OnApplicationQuit()
    //{
    //    SaveSystemJSON.SavePlayerData(this);
    //}



    //private void OnApplicationPause(bool pause)
    //{
    //    SaveSystemJSON.SavePlayerData(this);
    //}

}
