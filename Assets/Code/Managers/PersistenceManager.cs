using Code.Utils.SaveData;
using Pepersistence;

namespace Code.Managers
{
    public class PersistenceManager: BasePersistenceManager<SaveData>
    {
        public PersistenceManager(ISaveSource saveSource) : base(saveSource)
        {
        }

    }
}