using UnityEngine;

public class F2FFLTakeThrowFL : MonoBehaviour
{

    private bool CanInteract = true;

    [SerializeField] private Transform HeldPoint;

    [SerializeField] float ThrowForce = 10f;

    private GameObject HeldObject;
    private Rigidbody HeldRB;

    // ref
    [SerializeField] private F2FFLCamHorzM MoveScript;
    [SerializeField] private F2FFLFlashLightOnOff FlashScript;
    // ref


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // ref
        MoveScript.enabled = false;
        FlashScript.enabled = false;
        // ref
        
    }

    // Update is called once per frame
    void Update()
    {

        if (CanInteract)
        {

            if (HeldObject == null)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 5f))
                    {

                        if (hit.collider.CompareTag("FlashLight"))
                        {

                            // pick up 
                            HeldObject = hit.collider.gameObject;
                            HeldRB = HeldObject.GetComponent<Rigidbody>();

                            HeldObject.transform.SetParent(HeldPoint);
                            HeldObject.transform.localPosition = Vector3.zero;
                            HeldObject.transform.localRotation = Quaternion.identity;

                            HeldRB.useGravity = false;
                            HeldRB.isKinematic = true;

                            // ref
                            FlashScript.enabled = true;
                            MoveScript.enabled = true;
                            // ref


                        }

                    }


                }


            }
            else
            {

                if(Input.GetKeyDown(KeyCode.G))
                {

                    // throw
                    HeldObject.transform.SetParent(null);

                    HeldRB.useGravity = true;
                    HeldRB.isKinematic = false;

                    HeldRB.AddForce(Camera.main.transform.forward * ThrowForce, ForceMode.Impulse);

                    HeldObject = null;
                    HeldRB = null;


                    // ref
                    FlashScript.enabled = false;
                    MoveScript.enabled = false;
                    // ref


                }

            }


        }

        
    }
}
