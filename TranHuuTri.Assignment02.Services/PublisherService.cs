using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.Repositories;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublisherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePublisher(Publisher publisher)
        {
            _unitOfWork.PublisherRepository.Add(publisher);
        }

        public void DeletePublisher(int id)
        {
            Publisher publisher = _unitOfWork.PublisherRepository.GetById(id);
            if(publisher != null)
            {
                publisher.State = 0;
                _unitOfWork.PublisherRepository.Update(publisher);
            }
        }

        public Publisher GetPublisherById(int id)
        {
            return _unitOfWork.PublisherRepository.GetPublisherById(id);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _unitOfWork.PublisherRepository.Update(publisher);
        }

        //public IQueryable<Publisher> GetAllPublishers()
        //{
        //    return _unitOfWork.PublisherRepository.GetAllPublishers();
        //}
        public IQueryable<Publisher> GetAllPublishers(PublisherParameters publisherParameters)
        {
            return _unitOfWork.PublisherRepository.GetAllPublishers(publisherParameters);
        }
    }
}
