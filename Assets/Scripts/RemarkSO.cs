using UnityEngine;

[CreateAssetMenu(fileName = "RemarkReaction", menuName = "ScriptableObjects/SpawnRemarkReaction", order = 1)]
public class RemarkSO: ScriptableObject
{
    public int id;
    public string header;
    public string mainText;
}