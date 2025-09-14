using UnityEngine;

public class FlashLightController : MonoBehaviour
{

    bool FlashLigtOn = false;

    public Light FlashLight;


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F))
        {

            if(FlashLight != null)
            {

                FlashLigtOn = !FlashLigtOn;

                if (FlashLigtOn)
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
}
