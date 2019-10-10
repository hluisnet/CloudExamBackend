using CloudExam.Models;
using CloudExam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public interface IDashboardService 
    {

        DashboardViewModel GetDashboard();
       

    }
}
