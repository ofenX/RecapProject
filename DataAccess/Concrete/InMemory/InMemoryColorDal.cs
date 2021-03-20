using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{Id=1,Name="Metallic"},
                new Color{Id=2,Name="Blueeee"},
                new Color{Id=3,Name="Silver"},
                new Color{Id=4,Name="Gray"},
                new Color{Id=5,Name="Green"},
                new Color{Id=6,Name="Pearl"},
                new Color{Id=7,Name="PearlPurple"},
                new Color{Id=8,Name="Red"},
                new Color{Id=9,Name="Paint"},
                new Color{Id=10,Name="White"},
                new Color{Id=11,Name="White"}

            };

        }

        public void Add(Color entity)
        {
            _colors.Add(entity);
        }

        public void Delete(Color entity)
        {
            Color colorToDelete =_colors.SingleOrDefault(p => p.Id == entity.Id);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return _colors.AsQueryable<Color>().Where(filter).SingleOrDefault();

        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return filter == null
               ? _colors
               : _colors.AsQueryable<Color>().Where(filter).ToList();

        }

        public void Update(Color entity)
        {

            Color colorToUpdate = _colors.SingleOrDefault(p => p.Id == entity.Id);
            colorToUpdate.Name = entity.Name;
            
        }
    }
}
