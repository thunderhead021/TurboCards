using UnityEngine;
using UnityEngine.UI;

public class ClockRTE_View : RTE_View
{
    public RectTransform clockHand;
    public float rotationSpeed = 200f;
    public Image successZoneImage;

    private float successZoneStart;
    private float successZoneEnd;

    private bool startRunning = false;

    public override void StartRTE() 
    {
        var successZoneAngle = 10f * (5 - difficulty);
        successZoneStart = Random.Range(0f, 365f);
        successZoneEnd = successZoneStart + successZoneAngle;
        if (successZoneImage != null)
        {
            successZoneImage.fillAmount = successZoneAngle / 365f;
            successZoneImage.transform.rotation = Quaternion.Euler(0, 0, -successZoneStart);
        }
        startRunning = true;
    }

    void Update()
    {
        if(startRunning) 
            clockHand.Rotate(0, 0, -rotationSpeed * Time.deltaTime); 
    }


    public void StopPointer()
    {
        // Get the current rotation of the hand (0-360)
        float handAngle = 365 - clockHand.eulerAngles.z;

        // Adjust for success zone wrapping around 360
        bool success = false;
        if (successZoneEnd <= 365)
        {
            if (handAngle >= successZoneStart && handAngle <= successZoneEnd)
                success = true;
        }
        else
        {
            float wrappedEnd = successZoneEnd - 365;
            if (handAngle >= successZoneStart || handAngle <= wrappedEnd)
                success = true;
        }

        TrainingManager.Instance.QTAResult(success, trainingType, difficulty);

        Destroy(gameObject);
    }
}
