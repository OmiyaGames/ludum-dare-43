﻿using UnityEngine;
using UnityEditor;

namespace OmiyaGames.Builds
{
    ///-----------------------------------------------------------------------
    /// <copyright file="WindowsBuildSetting.cs" company="Omiya Games">
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
    /// <date>10/31/2018</date>
    ///-----------------------------------------------------------------------
    /// <summary>
    /// Build settings for Windows platform.
    /// </summary>
    public class WindowsBuildSetting : IStandaloneBuildSetting
    {
        [SerializeField]
        protected Architecture architecture = Architecture.Build64Bit;
        [SerializeField]
        protected bool includePdbFles = false;
        // FIXME: do more research on the Facebook builds
        //[SerializeField]
        //protected bool forFacebook = false;

        #region Overrides
        //protected override BuildTargetGroup TargetGroup
        //{
        //    get
        //    {
        //        if (forFacebook == true)
        //        {
        //            return BuildTargetGroup.Facebook;
        //        }
        //        else
        //        {
        //            return base.TargetGroup;
        //        }
        //    }
        //}

        protected override BuildTarget Target
        {
            get
            {
                if (architecture == Architecture.Build64Bit)
                {
                    return BuildTarget.StandaloneWindows64;
                }
                else
                {
                    return BuildTarget.StandaloneWindows;
                }
            }
        }

        public override string FileExtension
        {
            get
            {
                return ".exe";
            }
        }

        protected override BuildOptions Options
        {
            get
            {
                BuildOptions options = base.Options;

                // Add PDB options
                if (includePdbFles == true)
                {
                    options |= BuildOptions.IncludeTestAssemblies;
                }
                return options;
            }
        }
        #endregion
    }
}
