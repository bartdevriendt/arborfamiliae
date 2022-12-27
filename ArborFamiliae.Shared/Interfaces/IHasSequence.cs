namespace ArborFamiliae.Shared.Interfaces
{
    public interface IHasSequence
    {
        string SequenceType { get; }
        void SetSequence(int sequence);
    }
}
