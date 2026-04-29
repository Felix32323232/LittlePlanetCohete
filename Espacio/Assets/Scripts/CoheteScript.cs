using UnityEngine;
using UnityEngine.InputSystem;

public class CoheteScript : MonoBehaviour
{
    public Cohete[] rockets;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            foreach (Cohete rocket in rockets)
            {
                if (rocket != null)
                {
                    rocket.Launch();
                }
            }
        }
    }
}