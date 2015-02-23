using UnityEngine;

public class KongregateReporter : MonoBehaviour
{
    void Start()
    {
        try
        {
            // Report Game Completion
            GameObject khGo = GameObject.Find("KongregateHelper");

            if (khGo != null)
            {
                KongregateController kc = khGo.GetComponent<KongregateController>();

                if (kc != null)
                    kc.ReportGameCompleted();
            }
        }
        catch
        { }
    }
}