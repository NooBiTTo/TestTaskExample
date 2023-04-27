using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "ReceiptsData", menuName = "StaticData/Receipts")]
    public class ReceiptsData : ScriptableObject
    {
        [SerializeField] private List<ReceiptData> receipts;

        public List<ReceiptData> Content => receipts;
    }
}