using UnityEditor;
using UnityEngine;

namespace OmiyaGames.UI.Scenes
{
    ///-----------------------------------------------------------------------
    /// <copyright file="SceneTransitionManagerEditor.cs" company="Omiya Games">
    /// The MIT License (MIT)
    /// 
    /// Copyright (c) 2014-2016 Omiya Games
    /// 
    /// Permission is hereby granted, free of charge, to any person obtaining a copy
    /// of this software and associated documentation files (the "Software"), to deal
    /// in the Software without restriction, including without limitation the rights
    /// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    /// copies of the Software, and to permit persons to whom the Software is
    /// furnished to do so, subject to the following conditions:
    /// 
    /// The above copyright notice and this permission notice shall be included in
    /// all copies or substantial portions of the Software.
    /// 
    /// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    /// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    /// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    /// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    /// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    /// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    /// THE SOFTWARE.
    /// </copyright>
    /// <author>Taro Omiya</author>
    /// <date>4/15/2016</date>
    ///-----------------------------------------------------------------------
    /// <summary>
    /// Editor script for <code>SceneInfo</code>
    /// </summary>
    /// <seealso cref="SceneInfo"/>
    [CustomPropertyDrawer(typeof(SceneInfo))]
    public class SceneInfoDrawer : PropertyDrawer
    {
        const int FileNameLabelWidth = 82;
        const float RevertTimeLabelWidth = 102;
        const float RevertTimeFieldTotalMargin = 14;
        const int CursorModeLabelWidth = 160;
        const int VerticalMargin = 2;

        static GUIContent revertTimeScaleContent = null;
        public GUIContent RevertTimeScaleContent
        {
            get
            {
                if(revertTimeScaleContent == null)
                {
                    revertTimeScaleContent = new GUIContent("Reset TimeScale?", "See TimeManager script to set the scene's timescale.");
                }
                return revertTimeScaleContent;
            }
        }

        static GUIStyle rightAlignStyleCache = null;
        public static GUIStyle RightAlignStyle
        {
            get
            {
                if(rightAlignStyleCache == null)
                {
                    rightAlignStyleCache = new GUIStyle();
                    rightAlignStyleCache.alignment = TextAnchor.MiddleRight;
                }
                return rightAlignStyleCache;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return GetHeight(label);
        }

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Don't make child fields be indented
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Draw label
            Rect labelRect = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (string.IsNullOrEmpty(label.text) == false)
            {
                position.y += (EditorGUIUtility.singleLineHeight + VerticalMargin);
                EditorGUI.indentLevel = 1;
            }

            // Draw the File Name label
            position.height = base.GetPropertyHeight(property, label);
            DrawTextField(position, property, "Scene Path", "scenePath");

            // Dock the rest of the fields down a bit
            position.y += (position.height + VerticalMargin);

            // We're going through this from right to left
            // Draw Revert Time field
            Rect fieldRect = position;
            fieldRect.width = EditorGUIUtility.singleLineHeight;
            fieldRect.x = (position.xMax - fieldRect.width);
            if (string.IsNullOrEmpty(label.text) == false)
            {
                fieldRect.x -= RevertTimeFieldTotalMargin;
            }
            EditorGUI.PropertyField(fieldRect, property.FindPropertyRelative("revertTimeScale"), GUIContent.none);

            // Draw Revert Time label
            labelRect = position;
            labelRect.width = RevertTimeLabelWidth;
            labelRect.x = (fieldRect.x - labelRect.width);
            if (string.IsNullOrEmpty(label.text) == true)
            {
                labelRect.x -= RevertTimeFieldTotalMargin;
            }
            EditorGUI.LabelField(labelRect, RevertTimeScaleContent, RightAlignStyle);

            // Draw the Display Name label
            fieldRect.x = position.x;
            fieldRect.width = (labelRect.x - position.x);
            DrawTextField(fieldRect, property, "Display Name", "displayName");

            // Dock the rest of the fields down a bit
            position.y += (position.height + VerticalMargin);

            // Draw Cursor label
            EditorGUI.PropertyField(position, property.FindPropertyRelative("cursorMode"), new GUIContent("Cursor Lock Mode"));
            //DrawTextField(position, property, "Cursor Lock Mode", "cursorMode", CursorModeLabelWidth);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

        static void DrawTextField(Rect position, SerializedProperty property, string label, string variableName, float labelWidth = FileNameLabelWidth)
        {
            Rect labelRect = position;
            labelRect.width = labelWidth;
            EditorGUI.LabelField(labelRect, label, GUIStyle.none);

            // Draw the Scene Name field
            Rect fieldRect = position;
            fieldRect.x += labelRect.width;
            fieldRect.width -= labelRect.width;
            EditorGUI.PropertyField(fieldRect, property.FindPropertyRelative(variableName), GUIContent.none);
        }

        internal static float GetHeight(GUIContent label = null)
        {
            return EditorUiUtility.GetHeight(label, 3, VerticalMargin);
        }
    }
}
