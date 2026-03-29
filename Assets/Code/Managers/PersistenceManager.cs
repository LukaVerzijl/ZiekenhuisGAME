using Code.Utils.SaveData;
using Pepersistence;

namespace Code.Managers
{
    public class PersistenceManager: BasePersistenceManager<SaveData>
    {
        /// <summary>
        /// Init verplicht voor de dependency
        /// </summary>
        /// <param name="saveSource">naam en loc van save file</param>
        public PersistenceManager(ISaveSource saveSource) : base(saveSource)
        {
        }

    }
}