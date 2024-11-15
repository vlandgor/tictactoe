using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;

        protected VisualElement _root;
        protected VisualElement _visual;

        private void Start()
        {
            InitializeVisuals();
        }

        public virtual void InitializeVisuals()
        {
            _root = _uiDocument.rootVisualElement;
            _visual = _root.Q<VisualElement>("Visual");
        }
        
        public virtual void Show() => _visual.style.display = DisplayStyle.Flex;
        public virtual void Hide() => _visual.style.display = DisplayStyle.None;
    }
}