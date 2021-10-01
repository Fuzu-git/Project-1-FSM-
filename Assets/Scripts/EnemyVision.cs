using UnityEngine;

public class EnemyVision : MonoBehaviour {

    public bool PlayerInSight;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInSight = true;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInSight = false;
    }
    
}
