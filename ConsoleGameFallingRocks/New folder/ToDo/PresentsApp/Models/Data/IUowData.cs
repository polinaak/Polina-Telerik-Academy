using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentsApp.Models.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Quest> Quests { get; }
        IRepository<UserProfile> Users { get; }
        IRepository<Present> Presents { get; }
        IRepository<Vote> Votes { get; }
        int SaveChanges();

    }
}
