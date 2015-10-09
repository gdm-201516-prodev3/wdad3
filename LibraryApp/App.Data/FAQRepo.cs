using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public class FAQRepo : IFAQRepo
    {
        private readonly LibraryDbContext _db;

        public FAQRepo(LibraryDbContext db)
        {
            _db = db;
        }

        public FAQ AddFAQ(FAQ faq)
        {
            _db.FAQs.Add(faq);

            if (_db.SaveChanges() > 0)
            {
                return faq;
            }
            return null;
        }

        public bool DeleteFAQ(int faqId)
        {
            var faq = _db.FAQs.FirstOrDefault(c => c.Id == faqId);
            if (faq != null)
            {
                _db.FAQs.Remove(faq);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public IEnumerable<FAQ> GetFAQs()
        {
            return _db.FAQs.AsEnumerable();
        }

        public FAQ GetFAQ(int faqId)
        {
            return _db.FAQs.FirstOrDefault(c => c.Id == faqId);
        }
    }
}
