using UnityEngine;

public class F2FFLCamHorzM : MonoBehaviour
{

    public float Sens = 2f;
    public float MaxLeftRot = 10f;
    public float MaxRightRot = 50f;


    private float CurrentYaw;
    private float startYaw;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        startYaw = transform.localEulerAngles.y;
        CurrentYaw = 0f;

    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * Sens;

        CurrentYaw += mouseX;

        CurrentYaw = Mathf.Clamp(CurrentYaw, -MaxLeftRot, MaxRightRot);

        float finalYaw = startYaw + CurrentYaw;
        transform.localRotation = Quaternion.Euler(0f, finalYaw, 0f);
        
    }
}
