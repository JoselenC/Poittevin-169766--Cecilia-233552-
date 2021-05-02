using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace MSP.BetterCalm.DataAccess
{
    public class DataBaseRepository<D, T> : IRepository<D> where T : class
    {
        private IMapper<D, T> mapper;
        private ContextDB context;
        private DbSet<T> entity;

        public DataBaseRepository(IMapper<D, T> mapper, DbSet<T> entity, ContextDB context)
        {
            this.entity = entity;
            this.mapper = mapper;
            this.context = context;
        }

        public List<D> Get()
        {
            List<D> Dlist = new List<D>();
            foreach (T item in entity.ToList())
            {
                var x = mapper.DtoToDomain(item, context);
                Dlist.Add(x);
            }

            return Dlist;
        }

        public D Find(Predicate<D> condition)
        {

            List<T> dtos = entity.ToList();
            foreach (var dto in dtos)
            {
                var dDto = mapper.DtoToDomain(dto, context);
                var condResult = condition(dDto);
                if (condResult)
                    return dDto;
            }

            throw new KeyNotFoundException();
  
        }

        public D FindById(int id)
        {
           var dDto = mapper.GetById(context,id);
           if (dDto!=null)
                 return dDto;
           throw new KeyNotFoundException();
        }
       
        public D Add(D objectToAdd)
        {
            var TDto = mapper.DomainToDto(objectToAdd, context);
            if (context.Entry(TDto).State == (EntityState) EntityState.Detached)
                entity.Add(TDto);
            context.SaveChanges();
            var domainObj = mapper.DtoToDomain(TDto, context);
            return domainObj;
        }

        private T FindDto(Predicate<D> condition)
        {
            List<T> TDtos = entity.ToList();
            foreach (var TDto in TDtos)
            {
                var DDto = mapper.DtoToDomain(TDto, context);
                var condResult = condition(DDto);
                if (condResult)
                    return TDto;
            }
            throw new KeyNotFoundException();
        }

        public void Delete(D objectToDelete)
        {
            var ObjectToDeleteDto = FindDto(x => x.Equals(objectToDelete));
            entity.Remove(ObjectToDeleteDto);
            context.SaveChanges();

        }

        public void Set(List<D> objectToAdd)
        {
            throw new NotImplementedException();
        }

        public D Update(D OldObject, D UpdatedObject)
        {
            T objToUpdate = FindDto(x => x.Equals(OldObject));
            T returnObject = mapper.UpdateDtoObject(objToUpdate, UpdatedObject, context);
            context.SaveChanges();
            return mapper.DtoToDomain(returnObject, context);
        }
    }
}
  
  