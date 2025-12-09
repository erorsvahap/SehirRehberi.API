using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.DataAccess
{
    public class AppRepository : IAppRepository
    {
        private DataContext _dataContext;
        public AppRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public List<City> GetCities()
        {
           var cities=_dataContext.Cities.Include(c=>c.Photos).ToList();
            return cities;
        }

        public City GetCityById(int id)
        {
            var city =_dataContext.Cities.Include(c=>c.Photos).FirstOrDefault(c=>c.Id == id);
            return city;
        }

        public Photo GetPhoto(int id)
        {
            var photo= _dataContext.Photos.FirstOrDefault(p=>p.Id == id);
            return photo;
        }

        public List<Photo> GetPhotoByCity(int id)
        {
            var photos= _dataContext.Photos.Where(p=>p.CityId == id).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
