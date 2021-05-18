using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text credits;

    private void Start()
    {
        credits.DOFade(1f, 1f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6f);
        credits.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(1);
    }
}
