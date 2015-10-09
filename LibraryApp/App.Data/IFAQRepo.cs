using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public interface IFAQRepo
    {
        IEnumerable<FAQ> GetFAQs();
        FAQ GetFAQ(int faqId);
        FAQ AddFAQ(FAQ faq);
        bool DeleteFAQ(int faqId);
    }
}
