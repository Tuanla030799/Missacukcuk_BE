using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL
{
     public interface IBaseDL<MISAEntity>
    {
        IEnumerable<MISAEntity> GetAll();

        MISAEntity GetId(Guid entityId);

        IEnumerable<MISAEntity> GetFind(String entity, int e_pageSize, int e_pageIndex);

        IEnumerable<MISAEntity> GetTotal(String entityCode);

        int Insert(MISAEntity entity);


        int Update(MISAEntity entity, Guid entityId);


        int Delete(Guid entityId);
    }
}
