using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GasMaskInteraction : MonoBehaviour
{

    XRBaseInteractable m_Interactable; 

    // Start is called before the first frame update
    void OnEnable()
    {
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
    }

    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => WearGasMask();

    void WearGasMask()
    {
        FireScenarioManager.isGasMaskOn = true;
        FireScenarioManager.GasMaskEffect();
        Destroy(this);
    }
}
