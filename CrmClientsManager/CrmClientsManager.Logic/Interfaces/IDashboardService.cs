using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface IDashboardService
    {
        DashboardDto GetDashboardData();
    }
}
