using System.Threading.Tasks;

namespace ArborFamiliae.Shared.Interfaces
{
    public interface ISequenceGeneratorService
    {
        Task<int> GenerateSequence(string type);
    }
}
