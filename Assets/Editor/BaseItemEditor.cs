namespace Sleepy.Editor
{
    using Loot;
    using System;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(BaseItem), true)]
    public class BaseItemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            BaseItem item = (BaseItem) target;

            if (GUILayout.Button("Generate ID"))
            {
                item.Id = Guid.NewGuid().ToString();
            }

            DrawDefaultInspector();
        }
    }
}
