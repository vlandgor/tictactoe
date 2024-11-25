using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private bool enableOnStart;
        
        [Space]
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
            
            if (enableOnStart)
                Show();
            else
                Hide();
        }
        
        public virtual void Show()
        {
            Debug.Log("Showing view");
            _visual.style.display = DisplayStyle.Flex;
        }

        public virtual void Hide()
        {
            Debug.Log("Hiding view");
            _visual.style.display = DisplayStyle.None;
        }
    }
}