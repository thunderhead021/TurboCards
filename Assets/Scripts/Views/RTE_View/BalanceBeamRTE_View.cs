using UnityEngine;
using UnityEngine.UI;

public class BalanceBeamRTE_View : RTE_View
{
    public RectTransform beam;
    public Slider timer;

    public float duration = 5f;      
    public float maxAngle = 30f;

    public float instability = 1.5f;
    public float damping = 0.7f;
    public float noiseTorque = 0.5f;
    public float startKickRange = 0.8f;

    public float controlTorque = 60f;
    public bool impulseOnClick = false;
    public float impulseStrength = 25f;

    private float angle;           
    private float angularVel;
    private bool isRunning = false;

    public override void StartRTE()
    {
        timer.maxValue = duration;
        timer.value = duration;
        isRunning = true;
        instability *= (float)(0.5 * (difficulty + 1));
        angle = Random.Range(-startKickRange, startKickRange);
        angularVel = 0f;
        UpdateBeam();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) return;

        float dt = Time.deltaTime;

        float playerTorque = 0f;
        if (Input.GetMouseButton(0)) playerTorque -= controlTorque; 
        if (Input.GetMouseButton(1)) playerTorque += controlTorque; 

        if (impulseOnClick)
        {
            if (Input.GetMouseButtonDown(0)) angularVel -= impulseStrength;
            if (Input.GetMouseButtonDown(1)) angularVel += impulseStrength;
        }

        float noise = (Random.value * 2f - 1f) * noiseTorque;
        float angularAcc = instability * angle - damping * angularVel + playerTorque + noise;

        angularVel += angularAcc * dt;
        angle += angularVel * dt;

        UpdateBeam();

        timer.value -= dt;
        if (Mathf.Abs(angle) >= maxAngle)
        {
            TrainingManager.Instance.QTAResult(false, trainingType, difficulty);
            Destroy(gameObject);
        }

        if (timer.value <= 0f)
        {
            TrainingManager.Instance.QTAResult(true, trainingType, difficulty);
            Destroy(gameObject);
        }
    }

    private void UpdateBeam()
    {
        float visAngle = Mathf.Clamp(angle, -85f, 85f);
        beam.rotation = Quaternion.Euler(0f, 0f, visAngle);
    }
}
