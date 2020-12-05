using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace UI
{
    public class ButtonAnimator : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] private float multiplayer = 1.15f;
        [SerializeField] private float duration = 0.2f;

        private Transform m_ButtonTransform;
        
        private void Awake()
        {
            m_ButtonTransform = GetComponent<Transform>();
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            m_ButtonTransform.DOScale(Vector3.one * multiplayer, duration)
                .SetUpdate(UpdateType.Normal, true);
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            m_ButtonTransform.DOScale(Vector3.one, duration)
                .SetUpdate(UpdateType.Normal, true);
        }
    
        public void OnDisable()
        {
            m_ButtonTransform.localScale = Vector3.one;
        }
    }
}
