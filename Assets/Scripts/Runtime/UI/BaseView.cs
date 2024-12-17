using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        [SerializeField] private bool enableOnStart;
        
        [Space]
        [SerializeField] private UIDocument _uiDocument;

        protected VisualElement _root;
        protected VisualElement _visual;
        
        protected BasePresenter BasePresenter;
        
        public void Initialize(BasePresenter basePresenter)
        {
            BasePresenter = basePresenter;
            InitializeVisuals();
        }

        protected virtual void InitializeVisuals()
        {
            _root = _uiDocument.rootVisualElement;
            _visual = _root.Q<VisualElement>("Visual");
            
            if (enableOnStart)
                Show();
            else
                Hide();
        }
        
        public virtual void Show()
        {
            _visual.style.display = DisplayStyle.Flex;
        }

        public virtual void Hide()
        {
            _visual.style.display = DisplayStyle.None;
        }
    }
}