using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts.View.Outline
{
    [RequireComponent(typeof(global::Outline))]
    public class OutlineView : MonoBehaviour, IHighlightable
    {
        private global::Outline _outline;

        private void Awake()
        {
            _outline = GetComponent<global::Outline>();

            if (_outline == null)
                throw new NullReferenceException("Outline component not founded");

            _outline.enabled = false;
        }

        public void Highlight(bool isEnabled)
        {
           _outline.enabled = isEnabled;
        }
        
    }
}