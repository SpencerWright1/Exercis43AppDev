using RenoSystem.DAL;
using RenoSystem.Models;

namespace RenoSystem.BLL
{
    public class SupplyServices
    {
        private readonly RenosContext _context;

        public SupplyServices(RenosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Supply> GetByJobId(int jobId)
        {
            return _context.Supplies
                .Where(s => s.JobId == jobId)
                .OrderBy(s => s.Material)
                .ToList();
        }

        public int GetJobSupplyCount(int jobId)
        {
            return _context.Supplies.Count(s => s.JobId == jobId);
        }
    }
}