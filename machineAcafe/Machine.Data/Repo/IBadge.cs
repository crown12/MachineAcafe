using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public interface IBadge
    {
        Task<Badge> Find(string serial);
    }
}
