using UnityEngine;

public class F2FFLFlashLightOnOff : MonoBehaviour
{


    private bool FlashLightIsOn = false;

    [SerializeField] private Light FlashLight;

    [SerializeField] private AudioSource FlashSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        FlashLight.enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.F))
        {

            FlashLightIsOn = !FlashLightIsOn;

            FlashSound.Play();

            if(FlashLightIsOn == true)
            {

                FlashLight.enabled = true;

            }
            else
            {
                FlashLight.enabled = false;
            }


        }


    }
}
