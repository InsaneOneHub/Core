using System;
using System.Collections.Generic;
using UnityEngine;

namespace InsaneOne.Core
{
    [CreateAssetMenu(menuName = "InsaneOne/Core Data")]
    public sealed class CoreData : ScriptableObject
    {
        const string RepoName = "OlegDzhuraev";
        
        static CoreData instance;
        
        public GameObject UiFaderTpl;

        [Header("Setup Project Tool settings")]
        public List<LinkHolder> GitPackages = new List<LinkHolder>()
        {
            new LinkHolder() { Name = "Modifiers", Link = $"https://github.com/{RepoName}/Modifiers.git" },
            new LinkHolder() { Name = "Perseids Pooling", Link = $"https://github.com/{RepoName}/PerseidsPooling.git" },
            new LinkHolder() { Name = "NavMesh Avoidance", Link = $"https://github.com/{RepoName}/NavMeshAvoidance.git" },
            new LinkHolder() { Name = "Tags", Link = $"https://github.com/{RepoName}/Tags.git" },
        };
        
        public List<LinkHolder> Packages = new List<LinkHolder>()
        {
            new LinkHolder() { Name = "Post Effects", Link = "com.unity.postprocessing" },
            new LinkHolder() { Name = "Recorder", Link = "com.unity.recorder" },
            new LinkHolder() { Name = "Cinemachine", Link = "com.unity.cinemachine" },
        };
        
        public List<LinkHolder> AssetLinks = new List<LinkHolder>()
        {
            new LinkHolder() { Name = "DOTween", Link = "https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676" },
            new LinkHolder() { Name = "More Effective Coroutines", Link = "https://assetstore.unity.com/packages/tools/animation/more-effective-coroutines-free-54975" },
            new LinkHolder() { Name = "ReWired", Link = "https://assetstore.unity.com/packages/tools/utilities/rewired-21676" },
            new LinkHolder() { Name = "Odin Inspector", Link = "https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041" },
            new LinkHolder() { Name = "FMOD", Link = "https://www.fmod.com/unity" },
            new LinkHolder() { Name = "MicroSplat Terrain", Link = "https://assetstore.unity.com/packages/tools/terrain/microsplat-96478" },
            new LinkHolder() { Name = "NG Soft Shadows", Link = "https://assetstore.unity.com/packages/vfx/shaders/next-gen-soft-shadows-137380" },
        };
        
        [Header("Debugging")]
        [Tooltip("If you don't want to see plugin logs, set this.")]
        public bool SuppressLogs;

        public static CoreData Load()
        {
            if (instance)
                return instance;
            
            instance = Resources.Load<CoreData>("InsaneOne/CoreData");

            if (!instance)
                throw new NullReferenceException("Possible, InsaneOne.Core initialization was failed, no CoreData found!");
            
            return instance;
        }
    }

    [Serializable]
    public struct LinkHolder
    {
        public string Name;
        public string Link;
    }
}