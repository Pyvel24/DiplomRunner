using System;
using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace UI_View
{
    [Serializable]
    public abstract  class UIView : MonoBehaviour
    {
        public abstract string ViewName { get;  }
        protected void Initialize()
        {
            transform.localScale=Vector3.zero;
        }

        public Tweener Show()
        {
            gameObject.SetActive(true);
            return transform.DOScale(1f, .3f);
            
        }

        public Tweener Hide()
        {
            var tweener = transform.DOScale(0f, .5f);
            tweener.onComplete += () => gameObject.SetActive(false);
            return tweener;
        }
    }
}