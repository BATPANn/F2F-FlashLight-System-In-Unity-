using UnityEngine;

public class TakeFlashLighttest : MonoBehaviour
{


    bool Caninteract = true;

    public Transform HeldPoint;

    [SerializeField] float ThrowForce = 10f;

    private GameObject HeldObject;
    private Rigidbody HeldRB;


    // ref
    [SerializeField] private FlashLightController FlashScript;
    [SerializeField] private CameraHorizontalRotation CamScript;
    // ref


    private void Start()
    {

        FlashScript.enabled = false;
        CamScript.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        

        if(Caninteract)
        {


            if(HeldObject == null)
            {

                if(Input.GetMouseButtonDown(0))
                {

                    Ray ray1 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    RaycastHit hit;

                    if(Physics.Raycast(ray1, out hit, 5f))
                    {

                        if (hit.collider.CompareTag("FlashLight"))
                        {

                            // pickup
                            HeldObject = hit.collider.gameObject;
                            HeldRB = HeldObject.GetComponent<Rigidbody>();

                            HeldObject.transform.SetParent(HeldPoint);
                            HeldObject.transform.localPosition = Vector3.zero;
                            HeldObject.transform.localRotation = Quaternion.identity;

                            HeldRB.useGravity = false;
                            HeldRB.isKinematic = true;

                            // ref
                            FlashScript.enabled = true;
                            CamScript.enabled = true;
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
                    CamScript.enabled = false;
                    FlashScript.enabled = false;
                    // ref


                }

            }


        }

    }
}
