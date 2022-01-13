using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IBaseBL<MISAEntity>
    {
        IEnumerable<MISAEntity> GetAll();

        MISAEntity GetById(Guid id);


        IEnumerable<MISAEntity> GetFindBy(String entityCode, int pageSize, int pageIndex);


        IEnumerable<MISAEntity> GetTotalFillter(String entityTotal);

        int Insert(MISAEntity entity);


        int Update(MISAEntity entity, Guid entityId);


        int Delete(Guid entityId);
    }
}
