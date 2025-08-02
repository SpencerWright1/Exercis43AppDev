using RenoSystem.DAL;
using RenoSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace RenoSystem.BLL
{
    public class JobServices
    {
        private readonly RenosContext _context;

        public JobServices(RenosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Job> Job_GetList()
        {
            return _context.Jobs
                .Include(j => j.Client)
                .OrderBy(j => j.Description)
                .ToList();
        }
    }
}