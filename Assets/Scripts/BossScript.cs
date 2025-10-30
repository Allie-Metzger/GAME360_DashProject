using UnityEngine;

public class BossScript : MonoBehaviour
{
    private HealthController healthController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.healthController = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if current health reaches 0, boss is destroyed, activates game won panel
        //  if (HealthController != null) 
        if (healthController.CurrentHealth == 0)
        {
            Destroy(gameObject);
            Debug.Log("You beat the boss!");
        }

    }
}
