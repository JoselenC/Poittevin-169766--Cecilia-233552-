using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace MSP.BetterCalm.DataAccess
{
    public class DataBaseRepository<D, T>: IRepository<D> where T: class
    {
        private IMapper<D,T> mapper;
        public DataBaseRepository(IMapper<D,T> mapper)
        {
            this.mapper = mapper;
        }

        public List<D> Get()
        {
            using (ContextDB context = new ContextDB())
            {
                Microsoft.EntityFrameworkCore.DbSet<T> entity = context.Set<T>();
                List<D> Dlist = new List<D>();
                foreach (T item in entity.ToList())
                {
                    var x = mapper.DtoToDomain(item, context);
                    Dlist.Add(x);
                }
                return Dlist;
            }
        }
        
        public D Find(Predicate<D> condition)
        {
            using ContextDB context = new ContextDB();
            Microsoft.EntityFrameworkCore.DbSet<T> entity = context.Set<T>();
            List<T> dtos = entity.ToList();
            foreach (var dto in dtos)
            {
                var dDto = mapper.DtoToDomain(dto, context);
                var condResult = condition(dDto);
                if (condResult)
                    return dDto;
            };
            throw new ValueNotFound();
        }

       public void Add(D objectToAdd)
        {
          //  try
            //{
                using (ContextDB context = new ContextDB())
                {
                    var TDto = mapper.DomainToDto(objectToAdd, context);
                    var entity = context.Set<T>();
                    //if (context.Entry(TDto).State == (EntityState) System.Data.Entity.EntityState.Detached)
                        entity.Add(TDto);
                    context.SaveChanges();
                }
            //}
           // catch (DbUpdateException)
            //{
              //  throw new ExceptionUnableToSaveData();
            //}
        }

        private T FindDto(Predicate<D> condition, ContextDB context)
        {
            Microsoft.EntityFrameworkCore.DbSet<T> entity = context.Set<T>();
            List<T> TDtos = entity.ToList();
            foreach (var TDto in TDtos)
            {
                var DDto = mapper.DtoToDomain(TDto, context);
                var condResult = condition(DDto);
                if (condResult)
                    return TDto;
            };
            return null;
            // throw new ValueNotFound();
        }

        public void Delete(D objectToDelete)
        {
            using (ContextDB context = new ContextDB())
            {
                var entity = context.Set<T>();
                var ObjectToDeleteDto = FindDto(x => x.Equals(objectToDelete), context);
                entity.Remove(ObjectToDeleteDto);
                context.SaveChanges();
            }
        }
        public void Set(List<D> objectToAdd)
        {
            throw new NotImplementedException();
        }

        public D Update(D OldObject, D UpdatedObject)
        {
           // try
            //{
                using (ContextDB context = new ContextDB())
                {
                    Microsoft.EntityFrameworkCore.DbSet<T> entity = context.Set<T>();
                    T objToUpdate = FindDto(x => x.Equals(OldObject), context);
                    mapper.UpdateDtoObject(objToUpdate, UpdatedObject, context);
                    context.SaveChanges();
                    return UpdatedObject;
                }
           // }
           // catch (DbUpdateException)
            //{
              //  throw new ExceptionUnableToSaveData();
            //}
        }
    }
}
  
  