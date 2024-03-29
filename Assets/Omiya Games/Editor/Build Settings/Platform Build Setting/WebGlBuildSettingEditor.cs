﻿using UnityEditor;
using OmiyaGames.Builds;

namespace OmiyaGames.UI.Builds
{
    ///-----------------------------------------------------------------------
    /// <copyright file="WebGlBuildSettingEditor.cs" company="Omiya Games">
    /// The MIT License (MIT)
    /// 
    /// Copyright (c) 2014-2018 Omiya Games
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
    /// <date>11/21/2015</date>
    ///-----------------------------------------------------------------------
    /// <summary>
    /// Editor script for <code>WebGlBuildSetting</code>
    /// </summary>
    /// <seealso cref="WebGlBuildSetting"/>
    [CustomEditor(typeof(WebGlBuildSetting))]
    public class WebGlBuildSettingEditor : IPlatformBuildSettingEditor
    {
        private SerializedProperty webLocations;
        // FIXME: do more research on the Facebook builds
        //private SerializedProperty forFacebook;

        // FIXME: delete this variable
        private SerializedProperty testZipFolder;

        public override string FileExtension
        {
            get
            {
                return "";
            }
        }

        public override void OnEnable()
        {
            base.OnEnable();
            webLocations = serializedObject.FindProperty("webLocations");
            //forFacebook = serializedObject.FindProperty("forFacebook");
            testZipFolder = serializedObject.FindProperty("testZipFolder");
        }

        protected override void DrawPlatformSpecificSettings()
        {
            // FIXME: customize this
            //EditorGUILayout.PropertyField(webLocations);
            // FIXME: to draw
            //EditorGUILayout.PropertyField(forFacebook);

            // FIXME: delete all lines below
            EditorGUILayout.PropertyField(testZipFolder);
            UnityEngine.Rect rect = EditorGUILayout.GetControlRect();
            if(UnityEngine.GUI.Button(rect, "Test Zipping") == true)
            {
                ((WebGlBuildSetting)target).TestZip();
            }
        }
    }
}
