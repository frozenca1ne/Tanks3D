using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Scripts.Managers;
using SOData;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LoadinScript : MonoBehaviour
    {
        [SerializeField] private SceneLoadingSettings sceneLoadingSettings;
        [SerializeField] private Image image;
        private float duration = 0.5f;

        private IEnumerator Start()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(image.transform.DOScaleX(-1f, duration))
                .Join(image.transform.DOScaleY(1f, duration))
                .Append(image.transform.DOScaleY(-1f, duration))
                .Append(image.transform.DOScaleX(1f, duration))
                .Append(image.transform.DOScaleY(1f, duration))
                .SetLoops(-1);
            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(sceneLoadingSettings.LoadingScene);
        }
    }
}
