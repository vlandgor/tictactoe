using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI
{
    public abstract class ScreenUI : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;

        private VisualElement container;
        
        protected VisualElement _visual;
        
        public void Awake()
        {
            InitializeVisuals();
        }

        protected void InitializeVisuals()
        {
            container = _uiDocument.rootVisualElement;
            _visual = container.Q<VisualElement>("Visual");
        }
        
        public virtual void Show() => _visual.style.display = DisplayStyle.Flex;
        public virtual void Hide() => _visual.style.display = DisplayStyle.None;
    }
}