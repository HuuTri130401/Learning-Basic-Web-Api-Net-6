using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Services
{
    public interface IPublisherService
    {
        Publisher GetPublisherById(int id);
        //IQueryable<Publisher> GetAllPublishers();
        IQueryable<Publisher> GetAllPublishers(PublisherParameters publisherParameters);
        void CreatePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(int id);
    }
}
