using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using MISA.Common.Attributes;
using MISA.DL;
using System;
using System.Collections.Generic;

namespace MISA.BL
{
    public class BaseBL<MISAEntity> : IBaseBL<MISAEntity>
    {
        IBaseDL<MISAEntity> _baseDL;

        public BaseBL(IBaseDL<MISAEntity> baseDL)
        {
            _baseDL = baseDL;
        }
        public IEnumerable<MISAEntity> GetAll()
        {

            return _baseDL.GetAll();
        }

        public MISAEntity GetById(Guid entityID)
        {

            return _baseDL.GetId(entityID);
        }

        public IEnumerable<MISAEntity> GetFindBy(String entityCode, int pageSize, int pageIndex)
        {
            return _baseDL.GetFind(entityCode, pageSize, pageIndex);
        }

        public IEnumerable<MISAEntity> GetTotalFillter(String entityTotal)
        {
            return _baseDL.GetTotal(entityTotal);
        }

        public int Insert(MISAEntity entity)
        {
            //validate du lieu
            Validate(entity);
            ValidateInsert(entity);
            return _baseDL.Insert(entity);
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            Validate(entity);
            ValidateUpdate(entity, entityId);
            return _baseDL.Update(entity, entityId);
        }

        public int Delete(Guid entityId)
        {

            return _baseDL.Delete(entityId);
        }
        /// <summary>
        /// valide du lieu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        void Validate(MISAEntity entity)
        {
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var attributeRequireds = property.GetCustomAttributes(typeof(MISARequired), true);
                var attributeMaxlength = property.GetCustomAttributes(typeof(MISARequired), true);
                if (attributeRequireds.Length > 0)
                {
                    //lay gia tri cua property
                    var propertyValue = property.GetValue(entity);
                    var propertyType = property.PropertyType;

                    if (property.PropertyType == typeof(String) && String.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        //lay ra cau canh bao loi
                        var msgError = (attributeRequireds[0] as MISARequired).MsgError;
                        throw new GuardException<MISAEntity>(msgError, entity);
                    }
                }
            }
        }

        protected virtual void ValidateInsert(MISAEntity entity)
        {

        }

        protected virtual void ValidateUpdate(MISAEntity entity ,Guid entityId)
        {

        }
    }
}
