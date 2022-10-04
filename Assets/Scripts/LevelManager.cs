using Unity.Netcode;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : NetworkBehaviour
    {

        [SerializeField]
        public NetworkVariable<int> Level = new NetworkVariable<int>(1);

        [SerializeField]
        public NetworkVariable<int> Xp = new NetworkVariable<int>(0);

        [SerializeField]
        public NetworkVariable<int> XpNeeded = new NetworkVariable<int>(10);

        public void AddXp(int xp)
        {
            if (!IsServer)
                return;
            
            var newXp = Xp.Value + xp;
            if(newXp >= XpNeeded.Value){
                Xp.Value = 0;
                Level.Value++;
                XpNeeded.Value += 100;
                return;
            }
            Xp.Value = newXp;
        }
    }
}
