using System;

namespace Code.Utils.SaveData
{
    [Serializable]
    public struct KindSafeData
    {
        public string KindNaam;
        public bool hasReadPart1;
        public bool hasReadPart2;
        public bool hasReadPart3;
        public bool hasReadPart4;
    }
}