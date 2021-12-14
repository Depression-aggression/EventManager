using Depra.EventSystem.Runtime.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace Depra.EventSystem.Runtime.ScriptableEvents.Editor
{
    [CustomEditor(typeof(VoidEvent))]
    public class VoidEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUI.enabled = Application.isPlaying;

            if (GUILayout.Button("Invoke"))
            {
                var gameEvent = target as VoidEvent;
                gameEvent.Invoke();
            }
        }
    }
}