using UnityEngine;

public class PitonRouge : MonoBehaviour
{
    [SerializeField] private MeshRenderer _myMeshRenderer;
    [SerializeField] private MeshRenderer _meshRenderer1;
    [SerializeField] private MeshRenderer _meshRenderer2;

    private void Update()
    {
        if (_myMeshRenderer.material.IsKeywordEnabled("_EMISSION") &&
            !_meshRenderer1.material.IsKeywordEnabled("_EMISSION"))
        {
            _meshRenderer1.material.EnableKeyword("_EMISSION");
            _meshRenderer2.material.EnableKeyword("_EMISSION");
        } else if (!_myMeshRenderer.material.IsKeywordEnabled("_EMISSION") &&
                   _meshRenderer1.material.IsKeywordEnabled("_EMISSION"))
        {
            _meshRenderer1.material.DisableKeyword("_EMISSION");
            _meshRenderer2.material.DisableKeyword("_EMISSION");
        }
    }
    
}
