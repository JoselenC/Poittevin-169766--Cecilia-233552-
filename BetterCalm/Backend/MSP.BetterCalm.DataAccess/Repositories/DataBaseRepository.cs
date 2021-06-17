using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.DataAccess.Mappers;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class DataBaseRepository<D, T> : IRepository<D> where T : class
    {
        private IMapper<D, T> mapper;
        private ContextDb context;
        private DbSet<T> entity;

        public DataBaseRepository(IMapper<D, T> mapper, DbSet<T> entity, ContextDb context)
        {
            this.entity = entity;
            this.mapper = mapper;
            this.context = context;
        }

        public List<D> Get()
        {
            List<D> dlist = new List<D>();
            foreach (T item in entity.ToList())
            {
                var x = mapper.DtoToDomain(item, context);
                if(x!=null)
                    dlist.Add(x);
            }

            return dlist;
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
            var dto = mapper.DomainToDto(objectToAdd, context);
            if (context.Entry(dto).State == (EntityState) EntityState.Detached)
                entity.Add(dto);
            context.SaveChanges();
            var domainObj = mapper.DtoToDomain(dto, context);
            return domainObj;
        }

        private T FindDto(Predicate<D> condition)
        {
            List<T> dtos = entity.ToList();
            foreach (var dto in dtos)
            {
                var dDto = mapper.DtoToDomain(dto, context);
                var condResult = condition(dDto);
                if (condResult)
                    return dto;
            }
            throw new KeyNotFoundException();
        }

        public void Delete(D objectToDelete)
        {
            var objectToDeleteDto = FindDto(x => x.Equals(objectToDelete));
            entity.Remove(objectToDeleteDto);
            context.SaveChanges();
        }

        public D Update(D oldObject, D updatedObject)
        {
            T objToUpdate = FindDto(x => x.Equals(oldObject));
            T returnObject = mapper.UpdateDtoObject(objToUpdate, updatedObject, context);
            context.SaveChanges();
            return mapper.DtoToDomain(returnObject, context);
        }
    }
}
  
  