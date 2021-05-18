using UnityEngine;

public class KeypadLightManager : MonoBehaviour
{
    public Material openedMaterial;
    public Material closedMaterial;

    private MeshRenderer[] _lightMr;

    // Start is called before the first frame update
    private void Start()
    {
        _lightMr = transform.GetComponentsInChildren<MeshRenderer>();
    }


    public void SetLight(int nbLightOpen)
    {
        for (int i = 0; i < nbLightOpen; i++)
        {
            _lightMr[i].material = openedMaterial;
        }

        for (int i = nbLightOpen; i < _lightMr.Length; i++)
        {
            _lightMr[i].material = closedMaterial;
        }
    }
}